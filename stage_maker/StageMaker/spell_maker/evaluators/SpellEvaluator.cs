using Microsoft.Xna.Framework;
using StageMaker.models;
using StageMaker.spell_maker.models;
using StageMaker.spell_maker.parser;
using StageMaker.utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static StageMaker.spell_maker.evaluators.GrammarEvaluator;
using static StageMaker.spell_maker.models.Delegates;
using static StageMaker.spell_maker.models.Value;

namespace StageMaker.spell_maker.evaluators
{
    public class SpellEvaluator
    {
        private ValueEvaluator valueEvaluator;
        private VarsManager varsManager;
        private Dictionary<string, string> spells;
        private Dictionary<string, List<string>> behaviorsBuffer;
        private Dictionary<string, Dictionary<string, Types>> behaviorsDeclarationArgs;
        private Dictionary<string, long> customIds;
        private static long particleId = 0;
        private float time;
        private long targetId;
        private DataGridView shoot;
        private DataGridView particleMove;
        private Bullet lastBullet;
        private string lastBulletId;
        private long behaviorParticleId;
        private Dictionary<string, Value> callValues;

        public SpellEvaluator(float time, long targetId, long particleId)
        {
            this.behaviorParticleId = -1;
            this.time = time;
            this.lastBulletId = null;
            this.customIds = new Dictionary<string, long>();
            this.targetId = targetId;
            this.valueEvaluator = new ValueEvaluator();
            this.varsManager = new VarsManager(this.valueEvaluator);
            this.valueEvaluator.initializeVarsManager(this.varsManager);
            this.behaviorsBuffer = new Dictionary<string, List<string>>();
            this.behaviorsDeclarationArgs = new Dictionary<string, Dictionary<string, Types>>();
            this.behaviorsDeclarationArgs = new Dictionary<string, Dictionary<string, Types>>();
            this.callValues = new Dictionary<string, Value>();
        }

        private SpellEvaluator(float time, long targetId, long particleId, long behaviorParticleId)
            : this(time, targetId, particleId)
        {
            this.behaviorParticleId = behaviorParticleId;
            this.valueEvaluator = new ValueEvaluator(behaviorParticleId);
            this.varsManager = new VarsManager(this.valueEvaluator);
            this.valueEvaluator.initializeVarsManager(this.varsManager);
        }

        public static long getParticleId()
        {
            return particleId;
        }

        public void initializeSpells(Dictionary<string, string> spells)
        {
            this.spells = spells;
        }

        public void initializeGrids(DataGridView shoot, DataGridView particleMove)
        {
            this.shoot = shoot;
            this.particleMove = particleMove;
        }

        public bool hasArgs(string firstLine)
        {
            return false;
        }

        public Dictionary<string, Types> getArgsDeclaration()
        {
            return new Dictionary<string, Types>();
        }

        public void evaluate(string[] text)
        {
            List<string> loopBuffer = new List<string>();
            int loopCount = -1;
            bool inLoop = false;
            bool caseFalse = false;
            bool inBehavior = false;
            int loopId = -1;
            int caseId = -1;
            int behaviorId = 0;
            string behaviorName = String.Empty;

            for (int i=0;i<text.Length;i++)
            {
                string line = text[i].Replace(" ", String.Empty);

                if(inBehavior && !line.StartsWith("END_BEHAVIOR(" + behaviorId + ")"))
                {
                    behaviorsBuffer[behaviorName].Add(line);
                }
                else if(caseFalse && !line.StartsWith("END_CASE(" + caseId + ")"))
                {
                    continue;
                }
                else if (inLoop && !line.StartsWith("END_LOOP(" + loopId + ")"))
                {
                    loopBuffer.Add(line);
                }
                else if (line.StartsWith("START_BEHAVIOR"))
                {
                    line = line.Replace("START_BEHAVIOR", String.Empty);
                    string[] args = line.Substring(1, line.Length - 2).Split(',').Where(s => s != null && s != String.Empty).ToArray();
                    behaviorId = int.Parse(args[0]);
                    behaviorName = args[1];
                    string behaviorArgs = args[2];
                    behaviorsDeclarationArgs[behaviorName] = this.valueEvaluator.evaluateDeclarationArgs(behaviorArgs);
                    behaviorsBuffer[behaviorName] = new List<string>();
                    inBehavior = true;
                }
                else if (line.StartsWith("END_BEHAVIOR"))
                {
                    inBehavior = false;
                    behaviorName = String.Empty;
                    behaviorId = -1;
                }
                else if (line.StartsWith("START_CASE"))
                {
                    line = line.Replace("START_CASE", String.Empty);
                    string[] args = line.Substring(1, line.Length - 2).Split(',').Where(s => s != null && s != String.Empty).ToArray();
                    caseId = int.Parse(args[0]);
                    string v1 = args[1];
                    string op = args[2];
                    string v2 = args[3];
                    caseFalse = !this.valueEvaluator.evaluateCase(v1, v2, op);
                }
                else if (line.StartsWith("END_CASE"))
                {
                    caseFalse = false;
                    caseId = -1;
                }
                else if (line.StartsWith("START_LOOP"))
                {
                    line = line.Replace("START_LOOP", String.Empty);
                    string[] args = line.Substring(1, line.Length - 2).Split(',').Where(s => s != null && s != String.Empty).ToArray();
                    loopId = int.Parse(args[0]);
                    loopCount = (int)this.valueEvaluator.evaluateArithmeticOperation(args[1]);
                    inLoop = true;
                }
                else if (line.StartsWith("END_LOOP"))
                {
                    for (int j = 0; j < loopCount; j++)
                    {
                        this.evaluate(loopBuffer.ToArray());
                    }
                    loopCount = -1;
                    loopId = -1;
                    inLoop = false;
                    loopBuffer.Clear();
                }
                else if (line.StartsWith("MAKE"))
                {
                    line = line.Replace("MAKE", String.Empty);
                    string[] args = line.Substring(1, line.Length - 2).Split(',').Where(s => s != null && s != String.Empty).ToArray();
                    this.evaluate_make();
                    if (args.Length > 0)
                    {
                        string currentBehaviorName = args[0];
                        string behaviorCallArgs = args[1];
                        this.evaluate_behavior(currentBehaviorName, behaviorCallArgs, text[0]);
                    }
                }
                else if (line.StartsWith("DELAY"))
                {
                    line = line.Replace("DELAY", String.Empty);
                    string[] args = line.Substring(1, line.Length - 2).Split(',').Where(s => s != null && s != String.Empty).ToArray();
                    string delay = args[0];
                    this.evaluate_delay(delay);
                }
                else if (line.StartsWith("WITH_ID"))
                {
                    line = line.Replace("WITH_ID", String.Empty);
                    string[] args = line.Substring(1, line.Length - 2).Split(',').Where(s => s != null && s != String.Empty).ToArray();
                    string customId = args[0];
                    lastBulletId = this.valueEvaluator.evaluateString(customId);
                }
                else if (line.StartsWith("WITH_POSITION"))
                {
                    line = line.Replace("WITH_POSITION", String.Empty);
                    string[] args = line.Substring(1, line.Length - 2).Split(',').Where(s => s != null && s != String.Empty).ToArray();
                    string position = args[0];
                    this.evaluate_with_position(position);
                }
                else if (line.StartsWith("WITH_DESTINATION"))
                {
                    line = line.Replace("WITH_DESTINATION", String.Empty);
                    string[] args = line.Substring(1, line.Length - 2).Split(',').Where(s => s != null && s != String.Empty).ToArray();
                    string destination = args[0];
                    this.evaluate_with_destination(destination);
                }
                else if (line.StartsWith("WITH_ANGLE"))
                {
                    line = line.Replace("WITH_ANGLE", String.Empty);
                    string[] args = line.Substring(1, line.Length - 2).Split(',').Where(s => s != null && s != String.Empty).ToArray();
                    string angle = args[0];
                    this.evaluate_with_angle(angle);
                }
                else if (line.StartsWith("WITH_SPEED"))
                {
                    line = line.Replace("WITH_SPEED", String.Empty);
                    string[] args = line.Substring(1, line.Length - 2).Split(',').Where(s => s != null && s != String.Empty).ToArray();
                    string speed = args[0];
                    this.evaluate_with_speed(speed);
                }
                else if (line.StartsWith("WITH_TYPE"))
                {
                    line = line.Replace("WITH_TYPE", String.Empty);
                    string[] args = line.Substring(1, line.Length - 2).Split(',').Where(s => s != null && s != String.Empty).ToArray();
                    string type = args[0];
                    this.evaluate_with_type(type);
                }
                else if (line.StartsWith("AFF"))
                {
                    line = line.Replace("AFF", String.Empty);
                    string[] args = line.Substring(1, line.Length - 2).Split(',').Where(s => s != null && s != String.Empty).ToArray();
                    string id = args[0];
                    string value = args[1];
                    this.evaluate_aff(id, value);
                }
                else if(line.StartsWith("VAR_AFF"))
                {
                    line = line.Replace("VAR_AFF", String.Empty);
                    string[] args = line.Substring(1, line.Length - 2).Split(',').Where(s => s != null && s != String.Empty).ToArray();
                    string id = args[0];
                    string type = args[1];
                    string value = args[2];
                    this.evaluate_var_aff(id, type, value);
                }
                else if(line.StartsWith("CALL"))
                {
                    line = line.Replace("CALL", String.Empty);
                    string[] args = line.Substring(1, line.Length - 2).Split(',').Where(s => s != null && s != String.Empty).ToArray();
                    string spellName = args[0];
                    string spellArgs = args[1];
                    this.evaluate_call(spellName, spellArgs);
                }
                else if (line.StartsWith("MOVE"))
                {
                    line = line.Replace("MOVE", String.Empty);
                    string[] args = line.Substring(1, line.Length - 2).Split(',').Where(s => s != null && s != String.Empty).ToArray();
                    this.evaluate_move();
                }
            }
        }
       
        private void evaluate_move()
        {
            long pId = particleId - 1;
            if (lastBulletId != null)
            {
                pId = this.customIds[lastBulletId];
            }

            particleMove.Rows.Add(new JsonFloat(time), pId, lastBullet.position, lastBullet.destination, lastBullet.direction, new JsonFloat(lastBullet.speed));
            lastBullet = null;
            lastBulletId = null;
        }

        public Dictionary<string, Types> evaluate_declaration_args(string firstLine)
        {
            if (firstLine.StartsWith("ARGS"))
            {
                string line = firstLine.Replace("ARGS", String.Empty);
                string[] args = line.Substring(1, line.Length - 2).Split(',').Where(s => s != null && s != String.Empty).ToArray();
                string sDeclValues = args[0];
                Dictionary<string, Types> declarationArgs = this.valueEvaluator.evaluateDeclarationArgs(sDeclValues);
                return declarationArgs;
            }
            else
                return new Dictionary<string, Types>();
        }

        private void evaluate_call(string spellName, string spellArgs)
        {
            string[] compiledSpellLines;
            string spellPath = spells[spellName];
            if (!SpellCompiler.isSpellCompiled(spellPath))
            {
                compiledSpellLines = SpellCompiler.compileSpell(spellPath);
            }
            else
                compiledSpellLines = SpellCompiler.getCompiledSpell(spellPath);

            string firstLine = compiledSpellLines[0];
            Dictionary<string, Types> declarationArgs = this.evaluate_declaration_args(firstLine);
            Dictionary<string, Value> callValues = this.valueEvaluator.evaluateCallArgs(declarationArgs, spellArgs);
            SpellEvaluator sp = new SpellEvaluator(time, targetId, particleId);
            sp.initializeGrids(shoot, particleMove);
            sp.initializeSpells(spells);
            sp.setArgs(callValues);
        }

        private void evaluate_behavior(string currentBehaviorName, string behaviorCallArgs, string currentSpellFirstLine)
        {
            Dictionary<string, Types> behaviorDeclarationArgs = behaviorsDeclarationArgs[currentBehaviorName];
            Dictionary<string, Value> behaviorCallValues = this.valueEvaluator.evaluateCallArgs(behaviorDeclarationArgs, behaviorCallArgs);
            SpellEvaluator spBehavior = new SpellEvaluator(time, targetId, particleId, particleId - 1);
            spBehavior.initializeGrids(shoot, particleMove);
            spBehavior.initializeSpells(spells);
            spBehavior.setBehaviors(behaviorsDeclarationArgs, behaviorsBuffer);
            spBehavior.setArgs(behaviorCallValues);
            spBehavior.setArgs(callValues);
            spBehavior.setCustomIds(this.customIds);
            spBehavior.evaluate(behaviorsBuffer[currentBehaviorName].ToArray());
        }

        private void evaluate_make()
        {
            if (lastBullet.position == null)
                shoot.Rows.Add(new JsonFloat(time), particleId, targetId, null, lastBullet.destination, lastBullet.direction, new JsonFloat(lastBullet.speed), lastBullet.type);
            else
                shoot.Rows.Add(new JsonFloat(time), particleId, null, lastBullet.position, lastBullet.destination, lastBullet.direction, new JsonFloat(lastBullet.speed), lastBullet.type);

            if(lastBulletId != null)
            {
                if (this.customIds.ContainsKey(lastBulletId))
                    throw new Exception("Custom id already exists.");
                else
                    this.customIds[lastBulletId] = particleId;
            }

            particleId++;
            lastBullet = null;
            lastBulletId = null;
        }

        private void evaluate_delay(string delay)
        {
            float fDelay = this.valueEvaluator.evaluateArithmeticOperation(delay);
            time = Math.Max(0, time + fDelay);
        }

        private void evaluate_with_position(string position)
        {
            if (lastBullet == null)
                lastBullet = new Bullet();

            string vPosition = this.valueEvaluator.evaluateVector(position);
            lastBullet.position = vPosition;
        }

        private void evaluate_with_destination(string destination)
        {
            if (lastBullet == null)
                lastBullet = new Bullet();

            string vDestination = this.valueEvaluator.evaluateVector(destination);
            lastBullet.destination = vDestination;
        }

        private void evaluate_with_angle(string angle)
        {
            if (lastBullet == null)
                lastBullet = new Bullet();

            float fAngle = this.valueEvaluator.evaluateArithmeticOperation(angle);
            Vector2 direction = Vector2Extension.valueOf(fAngle);
            lastBullet.direction = new JsonVector2(direction).ToString();
        }

        private void evaluate_with_speed(string speed)
        {
            if (lastBullet == null)
                lastBullet = new Bullet();

            lastBullet.speed = this.valueEvaluator.evaluateArithmeticOperation(speed);
        }

        private void evaluate_with_type(string type)
        {
            if (lastBullet == null)
                lastBullet = new Bullet();

            lastBullet.type = this.valueEvaluator.evaluateString(type);
        }

        private void evaluate_aff(string id, string value)
        {
            this.varsManager.updateValue(id, value);
        }

        private void evaluate_var_aff(string id, string type, string value)
        {
            this.varsManager.setValue(id, value, type);
        }

        private void setBehaviors(Dictionary<string, Dictionary<string, Types>> decl, Dictionary<string, List<string>> beh)
        {
            this.behaviorsDeclarationArgs = decl;
            this.behaviorsBuffer = beh;
        }

        public void setArgs(Dictionary<string, Types> declarationArgs, string[] argsValues)
        {
            Dictionary <string, Value> callValues = this.valueEvaluator.evaluateCallArgs(declarationArgs, argsValues);
            this.callValues = callValues;
            this.setArgs(callValues);
        }

        public void setCustomIds(Dictionary<string, long> customIds)
        {
            this.customIds = customIds;
        }

        private void setArgs(Dictionary<string, Value> args)
        {
            this.varsManager.setValues(args);
        }
    }
}
