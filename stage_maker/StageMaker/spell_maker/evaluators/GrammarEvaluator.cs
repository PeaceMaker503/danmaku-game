﻿using StageMaker.spell_maker.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static StageMaker.spell_maker.models.Delegates;

namespace StageMaker.spell_maker.evaluators
{
    public class GrammarEvaluator
    {
        
        private List<string> tokens;
        private Dictionary<string, GrammarAction> grammar;
        private List<string> values;
        private Dictionary<string, List<string>> rules;
        public List<string> loopPatterns { get; set; }
        private Dictionary<string, string> grammarPatterns;
        public Dictionary<string, string> behaviorPatterns { get; set; }
        private CaseAction caseHandler;
        private LoopAction loopHandler;
        public Dictionary<string, string> casePatterns { get; set; }
        public CaseConditionAction caseConditionHandler { get; set; }
        public LoopGetterAction loopGetterHandler { get; set; }
        public Action loopBeginHandler { get; set; }
        public Action loopEndHandler { get; set; }
        public Action caseBeginHandler { get; set; }
        public Action caseEndHandler { get; set; }
        public string tOpen { get; set; }
        public string tClose { get; set; }
        public string tEndl { get; set; }
        public List<string> tValues { get; set; }
        private string splitPattern;

        public GrammarEvaluator(List<string> values)
        {
            this.grammar = new Dictionary<string, GrammarAction>();
            this.values = values;
            this.loopPatterns = new List<string>();
            this.casePatterns = new Dictionary<string, string>();
            this.behaviorPatterns = new Dictionary<string, string>();
            this.tValues = new List<string>();
            this.caseHandler = new CaseAction(case_handler);
            this.loopHandler = new LoopAction(loop_handler);
            this.rules = new Dictionary<string, List<string>>();
            this.tokens = new List<string>() { "(", ")", "|", "+", "*", "?", " ", "^" };
            this.splitPattern = "([(])|([)])|([|])|([+])(|[*])|([?])|(\\^)|(\\s)";
            this.parseConf(@"conf/tokenizer.conf");
            this.grammarPatterns = new Dictionary<string, string>();
        }

        public void parseConf(string path)
        {
            string text = File.ReadAllText(path);
            string[] blocks = text.Split(new string[] { "%%" }, StringSplitOptions.RemoveEmptyEntries);
            string[] tokenConf = blocks[0].Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < tokenConf.Length; i++)
            {
                string[] param = tokenConf[i].Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
                string token = param[1].Trim(new char[] { ' ', '\r', '\n' });
                this.addToken(token);
            }
            string[] tokenValues = blocks[1].Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < tokenValues.Length; j++)
            {
                string token = tokenValues[j].Trim(new char[] { ' ', '\r', '\n' });
                this.tValues.Add(token);
            }
        }

        public void addToken(string token)
        {
            tokens.Add(token);
            this.splitPattern += "|(" + token + ")";
        }

        public void parseTokens(string[] tokens, int valuesCursor=0)
        {
            List<string> currentTokens = new List<string>();
            int currentLevel = 0;
            int caseLevel = 0;
            int loopLevel = 0;
            bool inCase = false;
            bool conditionState = false;
            bool inLoop = false;
            string loopTimes = String.Empty;
            List<string> loopBuffer = new List<string>();
            List<string> caseBuffer = new List<string>();

            for (int i =0;i<tokens.Length; i++)
            {
                string currentToken = tokens[i];
                if(currentToken == tOpen || currentToken == tClose)
                {
                    if (currentToken == tOpen)
                        currentLevel++;
                    else if (currentToken == tClose)
                        currentLevel--;
                }

                if (inLoop)
                {
                    if (currentToken == tClose)
                    {
                        if (currentLevel == loopLevel)
                        {
                            string[] loopBufferArray = loopBuffer.ToArray();
                            loopHandler(new LoopArgs(loopBufferArray, loopGetterHandler(loopTimes), valuesCursor));
                            int nbValues = countValuesInTokens(loopBufferArray);
                            valuesCursor += nbValues;
                            loopTimes = String.Empty;
                            inLoop = false;
                            loopBuffer.Clear();
                            loopEndHandler?.Invoke();
                        }
                        else
                            loopBuffer.Add(currentToken);
                    }
                    else if (currentToken != tOpen || currentLevel - loopLevel > 1) //on ne prend pas le tOpen du first loop
                        loopBuffer.Add(currentToken);
                }
                else if (inCase)
                {
                    if(currentToken == tClose)
                    {
                        if (currentLevel == caseLevel)
                        {
                            string[] caseBufferArray = caseBuffer.ToArray();
                            caseHandler(new CaseArgs(caseBufferArray, valuesCursor, conditionState));
                            inCase = false;
                            int nbValues = countValuesInTokens(caseBufferArray);
                            valuesCursor += nbValues;
                            caseBuffer.Clear();
                            caseEndHandler?.Invoke();
                        }
                        else
                            caseBuffer.Add(currentToken);
                    }
                    else if(currentToken != tOpen || currentLevel - caseLevel > 1) //on ne prend pas le tOpen du first case
                        caseBuffer.Add(currentToken);
                }
                else
                {
                    currentTokens.Add(currentToken);
                    string currentTokensLine = String.Empty;
                    foreach (string s in currentTokens)
                        currentTokensLine += s;

                    string loopPattern = getPatternLikeLoop(currentTokensLine);
                    if(loopPattern != null)
                    {
                        loopLevel = currentLevel;
                        loopTimes = values[valuesCursor++];
                        inLoop = true;
                        currentTokens.Clear();
                        loopBeginHandler?.Invoke();
                        continue;
                    }

                    string casePattern = getPatternLikeCase(currentTokensLine);
                    if(casePattern != null)
                    {
                        inCase = true;
                        int countValues = countValuesInTokens(currentTokens.ToArray());
                        dynamic groupedValues;
                        int cursorOnVs = 0;
                        string[] vs = values.GetRange(valuesCursor, countValues).ToArray();
                        groupValues(currentTokensLine.Replace(tEndl, String.Empty), casePattern, vs, out groupedValues, ref cursorOnVs);
                        conditionState = caseConditionHandler(new CaseConditionArgs(groupedValues));
                        valuesCursor += cursorOnVs;
                        caseLevel = currentLevel;
                        currentTokens.Clear();
                        caseBeginHandler?.Invoke();
                        continue;
                    }

                    string grammarPattern = getPatternLikeGrammar(currentTokensLine);
                    if(grammarPattern != null)
                    {
                        int countValues = countValuesInTokens(currentTokens.ToArray());
                        GrammarAction handler = grammar[grammarPattern];
                        string rulePattern = grammarPatterns[grammarPattern];
                        string[] vs = values.GetRange(valuesCursor, countValues).ToArray();
                        dynamic groupedValues;
                        int cursorOnVs = 0;
                        groupValues(currentTokensLine.Replace(tEndl, String.Empty), rulePattern, vs, out groupedValues, ref cursorOnVs);
                        GrammarArgs args = new GrammarArgs((dynamic[])groupedValues);
                        handler(args);
                        currentTokens.Clear();
                        valuesCursor += cursorOnVs;
                    }

                    if (currentToken == tEndl && currentTokens.Count > 0)
                        throw new Exception("Syntax error");
                }
            }
        }
        
        public int groupValues(string tokensLine, string rulePattern, string[] values, out dynamic result, ref int cursorOnVs)
        {
            string[] ruleTokens = new Regex(splitPattern).Split(rulePattern)
                                    .Select(s => s.Trim())
                                    .Where(str => str != String.Empty && str != tEndl && str != "(" && str != ")")
                                    .ToArray();

            int groupCount = ruleTokens.Count(s => tValues.Contains(s) || rules.ContainsKey(s));
            dynamic[] groupedValues = new object[1];
            int groupedIndex = 0;
            int lengthRemovedFromTokensLine = 0;
            for(int i=0;i< ruleTokens.Length; i++)
            {
                string token = ruleTokens[i];
                int currentLengthToRemove = token.Length;
                if (tValues.Contains(token) && !rules.ContainsKey(token))
                {
                    groupedValues[groupedIndex++] = values[cursorOnVs++];
                }
                else if(!tValues.Contains(token) && rules.ContainsKey(token))
                {
                    string line = string.Empty;
                    foreach (string rule in rules[token])
                    {
                        string p = getPatternRegexValue(rule);
                        Regex r = new Regex("^" + p);
                        if(r.IsMatch(tokensLine))
                        {
                            currentLengthToRemove = groupValues(tokensLine, rule, values, out groupedValues[groupedIndex++], ref cursorOnVs);
                            break;
                        }
                    }
                }
                tokensLine = tokensLine.Substring(currentLengthToRemove);
                lengthRemovedFromTokensLine += currentLengthToRemove;
            }
            result = groupedValues;
            return lengthRemovedFromTokensLine;
        }

        public void addLoopPattern(string pattern)
        {
            string regex = this.getPatternRegexValue(pattern);
            this.loopPatterns.Add(regex);
        }

        public void addBehaviorPattern(string pattern)
        {
            string regex = this.getPatternRegexValue(pattern);
            this.behaviorPatterns[regex] = pattern;
        }

        public void addCasePattern(string pattern)
        {
            string regex = this.getPatternRegexValue(pattern);
            this.casePatterns[regex] = pattern;
        }

        private string getPatternLikeLoop(string tokens)
        {
            foreach (string loopPattern in loopPatterns)
            {
                Regex r = new Regex("^" + loopPattern);
                if (r.IsMatch(tokens))
                {
                    return loopPattern;
                }
            }
            return null;
        }

        private string getPatternLikeCase(string tokens)
        {
            foreach (string casePattern in casePatterns.Keys)
            {
                Regex r = new Regex("^" + casePattern);
                if (r.IsMatch(tokens))
                {
                    return casePatterns[casePattern];
                }
            }
            return null;
        }

        private string getPatternLikeGrammar(string tokens)
        {
            foreach (string grammarPattern in grammar.Keys)
            {
                Regex r = new Regex("^" + grammarPattern);
                if (r.IsMatch(tokens))
                {
                    return grammarPattern;
                }
            }
            return null;
        }

        private void loop_handler(LoopArgs args)
        {
            for (long i = 0; i < args.times; i++)
                this.parseTokens(args.tokens, args.valuesCursor);
        }

        private void case_handler(CaseArgs args)
        {
            if (args.conditionState)
                this.parseTokens(args.tokens, args.valuesCursor);
        }

        public void addGrammarAction(string regex, GrammarAction a)
        {
            string pattern = getPatternRegexValue(regex);
            grammar[pattern] = a;
            grammarPatterns[pattern] = regex;
        }

        private bool isRule(string token)
        {
            return rules.ContainsKey(token);
        }

        public string getPatternRegexValue(string pattern)
        {
            string result = string.Empty;
            Regex rsplit = new Regex(splitPattern);
            string[] tokens = rsplit.Split(pattern)
                                    .Select(s => s.Trim())
                                    .Where(str => str != String.Empty)
                                    .ToArray();

            for (int i = 0; i < tokens.Length; i++)
            {
                List<string> listRules;
                if (rules.TryGetValue(tokens[i], out listRules))
                {
                    string rulePattern = String.Empty;
                    int k = 0;
                    foreach(string r in listRules)
                    {
                        rulePattern += getPatternRegexValue("(" + r + ")");

                        if (k < listRules.Count - 1)
                            rulePattern += "|";

                        k++;
                    }
                    result += getPatternRegexValue("(" + rulePattern + ")");
                }
                    
                else if (this.tokens.Contains(tokens[i]))
                    result += tokens[i];
                else
                    throw new Exception("Unknown token");
            }
            return result;
        }

        public void addGrammarRule(string name, string rule)
        {
            List<string> listRules;
            if(rules.TryGetValue(name, out listRules))
                listRules.Add(rule);
            else
            {
                rules[name] = new List<string> { rule };
                this.splitPattern += "|(" + name + ")";
            }
        }

        private int countValuesInTokens(string[] tokens)
        {
            return tokens.Count(s => tValues.Contains(s));
        }
    }
}
