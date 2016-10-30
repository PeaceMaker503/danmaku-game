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
        private VarsManager varsManager;
        private Dictionary<string, string> spells;
        private Dictionary<string, List<string[]>> behaviors;
        private Dictionary<string, Dictionary<string, Types>> argsDeclarationBehaviors;
        private float time;
        private float initTime;
        private long targetId;
        private long particleId;
        private DataGridView shoot;
        private DataGridView particleMove;
        private int currentLoopId;
        private Bullet lastBullet;
        private string spellName;
        private long behaviorParticleId;
        private GrammarEvaluator g;

        public sealed class Command
        {
            public static readonly string ARGS = "args";
            public static readonly string COMMENT = "#";
            public static readonly string OPEN = "{";
            public static readonly string CLOSE = "}";
            public static readonly string BEHAVIOR = "behavior";
            public static readonly string MAKE = "make";
            public static readonly string LOOP = "loop";
            public static readonly string INDEX = "INDEX";
            public static readonly string TIMESET = "timeset";
            public static readonly string DIMOVE = "dimove";
            public static readonly string DMOVE = "dmove";
            public static readonly string CALL = "call";
            public static readonly string LET = "let";
            public static readonly string ADD = "add";
            public static readonly string SUB = "sub";
            public static readonly string MOD = "mod";
            public static readonly string MUL = "mul";
            public static readonly string DIV = "div";
            public static readonly string VMUL = "vmul";
            public static readonly string SET = "set";
            public static readonly string FREE = "free";
            public static readonly string DELAY = "delay";
            public static readonly string WITH = "with";
            public static readonly string POSITION = "position";
            public static readonly string DESTINATION = "destination";
            public static readonly string DIRECTION = "direction";
            public static readonly string SPEED = "speed";
            public static readonly string TYPE = "type";
            public static readonly string ANGLE = "angle";
            public static readonly string COMPARE = "compare";
            public static readonly string CASE = "case";
        }

        public sealed class Operator
        {
            public static readonly string EQUALS = "==";
            public static readonly string DIFFERENT = "!=";
            public static readonly string SUPERIOR = ">";
            public static readonly string INFERIOR = "<";
            public static readonly string INFERIOR_EQUALS = "<=";
            public static readonly string SUPERIOR_EQUALS = ">=";
        }

        public SpellEvaluator(string spellName, float time, long targetId, long particleId, Dictionary<string, string> spells)
        {
            this.initTime = time;
            this.behaviorParticleId = -1;
            this.spellName = spellName;
            this.time = time;
            this.targetId = targetId;
            this.particleId = particleId;
            this.spells = spells;
            this.behaviors = new Dictionary<string, List<string[]>>();
            this.argsDeclarationBehaviors = new Dictionary<string, Dictionary<string, Types>>();
            this.currentLoopId = 0;
            this.varsManager = new VarsManager();
            this.argsDeclarationBehaviors = new Dictionary<string, Dictionary<string, Types>>();
            if (spellName != null)
                this.declareArgs();
        }

        private SpellEvaluator(string spellName, float time, long targetId, long particleId, Dictionary<string, string> spells, long behaviorParticleId, float initTime)
        {
            this.initTime = initTime;
            this.behaviorParticleId = behaviorParticleId;
            this.spellName = spellName;
            this.time = time;
            this.targetId = targetId;
            this.particleId = particleId;
            this.spells = spells;
            this.behaviors = new Dictionary<string, List<string[]>>();
            this.argsDeclarationBehaviors = new Dictionary<string, Dictionary<string, Types>>();
            this.currentLoopId = 0;
            this.varsManager = new VarsManager();
            this.argsDeclarationBehaviors = new Dictionary<string, Dictionary<string, Types>>();
            if (spellName != null)
                this.declareArgs();
        }

        private void declareArgs()
        {
            Dictionary<string, Types> spellArgsDeclaration = FileHelper.getArgsDeclaration(spells[spellName]);
            this.varsManager.declareArgs(spellArgsDeclaration);
        }

        public void initializeGrids(DataGridView shoot, DataGridView particleMove)
        {
            this.shoot = shoot;
            this.particleMove = particleMove;
        }

        public bool mustSpecifyArgs()
        {
            return !varsManager.empty();
        }

        public Dictionary<string, Types> getArgsDeclaration()
        {
            return varsManager.getArgsDeclaration();
        }

        public void specifyArgs(string[] argsValues)
        {
            this.varsManager.specifyArgs(argsValues);
        }

        private float calculateFloat(float v1, float v2, string op)
        {
            float result = float.NaN;
            if (op == "+")
                result = v1 + v2;
            else if (op == "-")
                result = v1 - v2;
            else if (op == "*")
                result = v1 * v2;
            else if (op == "/")
                result = v1 / v2;

            return result;
        }

        private float getFloat(string[] values)
        {
            if (values.Length == 1)
                return this.varsManager.valueEvaluator.parseFloat(values[0]);
            else if (values.Length == 2)
                return this.varsManager.valueEvaluator.parseFloat(values[0] + "." + values[1]);
            else
                throw new Exception("Float error");
        }
        
        private string getString(string[] values)
        {
            if (values.Length == 1)
                return this.varsManager.valueEvaluator.parseString(values[0]);
            else if (values.Length == 3 && values[0] == "'" && values[2] == "'")
                return this.varsManager.valueEvaluator.parseString("'" + values[1] + "'");
            else
                throw new Exception("String error");
        }

        private float getFloatOpResult(string[] vs1, string op, string [] vs2)
        {
            float result = float.NaN;
            float v1 = getFloat(vs1);
            float v2 = getFloat(vs2);
            result = calculateFloat(v1, v2, op);
            return result;
        }

        private class GrammarResult
        {
            public object value { get; set; }
            public object[] values { get; set; }
            public bool isArray { get; set; }
            public GrammarResult(object[] values)
            {
                this.values = values;
                isArray = true;
            }

            public GrammarResult(object value)
            {
                this.values = values;
                isArray = false;
            }
        }

        private void let_float(GrammarArgs args)
        {
            string id = args.values[0];
            string type = args.values[1];
            string op = args.values[3][0][1];
            object[] ovs1 = args.values[3][0][0];
            object[] ovs2 = args.values[3][0][2];
            string[] vs1 = ovs1.Where(x => x != null).Select(x => x.ToString()).ToArray();
            string[] vs2 = ovs2.Where(x => x != null).Select(x => x.ToString()).ToArray();

            if (varsManager.getValue(id) != null)
                 throw new Exception("Variable '" + id + "' already exists.");

             string result = getFloatOpResult(vs1, op, vs2).ToString();
             this.varsManager.setValue(id, result, Types.FLOAT);
        }

        private void let_string(GrammarArgs args)
        {
            string id = args.values[0];
            string type = args.values[1];
            object[] ovs1 = args.values[3];
            string[] vs1 = ovs1.Where(x => x != null).Select(x => x.ToString()).ToArray();

            if (varsManager.getValue(id) != null)
                throw new Exception("Variable '" + id + "' already exists.");

            string result = getString(vs1);
            this.varsManager.setValue(id, result, Types.STRING);
        }

        private void let_vector(GrammarArgs args)
        {
            string id = args.values[0];
            string type = args.values[1];
            object[] ovs1 = args.values[3][0];
            string[] vs1 = ovs1.Where(x => x != null).Select(x => x.ToString()).ToArray();
            object[] ovs2 = args.values[3][1];
            string[] vs2 = ovs2.Where(x => x != null).Select(x => x.ToString()).ToArray();
            float vx = getFloat(vs1);
            float vy = getFloat(vs2);
            string v = new JsonVector2(vx, vy).ToString();

            if (varsManager.getValue(id) != null)
                throw new Exception("Variable '" + id + "' already exists.");

            this.varsManager.setValue(id, v, Types.VECTOR2);
        }

        private void aff_float(GrammarArgs args)
        {
            string id = args.values[0];
            string op = args.values[2][0][1];
            object[] ovs1 = args.values[2][0][0];
            object[] ovs2 = args.values[2][0][2];
            string[] vs1 = ovs1.Where(x => x != null).Select(x => x.ToString()).ToArray();
            string[] vs2 = ovs2.Where(x => x != null).Select(x => x.ToString()).ToArray();

            if (this.varsManager.getValue(id) == null)
                throw new Exception("Variable '" + args.values[0] + "' does not exist.");

            string result = getFloatOpResult(vs1, op, vs2).ToString();
            this.varsManager.setValue(args.values[0], result, Types.FLOAT);
        }

        private void aff_string(GrammarArgs args)
        {
            string id = args.values[0];
            object[] ovs1 = args.values[2];
            string[] vs1 = ovs1.Where(x => x != null).Select(x => x.ToString()).ToArray();

            if (this.varsManager.getValue(id) == null)
                throw new Exception("Variable '" + args.values[0] + "' does not exist.");

            string result = getString(vs1);
            this.varsManager.setValue(args.values[0], result, Types.STRING);
        }

        private void aff_vector(GrammarArgs args)
        {
            string id = args.values[0];
            object[] ovs1 = args.values[2][0];
            string[] vs1 = ovs1.Where(x => x != null).Select(x => x.ToString()).ToArray();
            object[] ovs2 = args.values[2][1];
            string[] vs2 = ovs2.Where(x => x != null).Select(x => x.ToString()).ToArray();
            float vx = getFloat(vs1);
            float vy = getFloat(vs2);
            string v = new JsonVector2(vx, vy).ToString();

            if (this.varsManager.getValue(id) == null)
                throw new Exception("Variable '" + args.values[0] + "' does not exist.");

            this.varsManager.setValue(id, v, Types.VECTOR2);
        }

        private void with_speed(GrammarArgs args)
        {
            if (lastBullet == null)
                lastBullet = new Bullet();

            object[] ovs1 = args.values[0];
            string[] vs1 = ovs1.Where(x => x != null).Select(x => x.ToString()).ToArray();
            lastBullet.speed = getFloat(vs1);
        }

        private void with_angle(GrammarArgs args)
        {
            if (lastBullet == null)
                lastBullet = new Bullet();

            object[] ovs1 = args.values[0];
            string[] vs1 = ovs1.Where(x => x != null).Select(x => x.ToString()).ToArray();
            float angle = getFloat(vs1);

            Vector2 direction = Vector2Extension.valueOf(angle);
            lastBullet.direction = new JsonVector2(direction).ToString();
        }

        private void make(GrammarArgs args)
        {
            if (lastBullet.position == null)
                shoot.Rows.Add(new JsonFloat(time), particleId++, targetId, null, lastBullet.destination, lastBullet.direction, new JsonFloat(lastBullet.speed), lastBullet.type);
            else
                shoot.Rows.Add(new JsonFloat(time), particleId++, null, lastBullet.position, lastBullet.destination, lastBullet.direction, new JsonFloat(lastBullet.speed), lastBullet.type);

            lastBullet = null;
        }

        private void with_position(GrammarArgs args)
        {
            object[] ovs1 = args.values[0][0];
            string[] vs1 = ovs1.Where(x => x != null).Select(x => x.ToString()).ToArray();
            object[] ovs2 = args.values[0][1];
            string[] vs2 = ovs1.Where(x => x != null).Select(x => x.ToString()).ToArray();
            float vx = getFloat(vs1);
            float vy = getFloat(vs2);

            if (lastBullet == null)
                lastBullet = new Bullet();

            lastBullet.position = new JsonVector2(vx, vy).ToString();
        }

        private void with_destination(GrammarArgs args)
        {
            object[] ovs1 = args.values[0][0];
            string[] vs1 = ovs1.Where(x => x != null).Select(x => x.ToString()).ToArray();
            object[] ovs2 = args.values[0][1];
            string[] vs2 = ovs1.Where(x => x != null).Select(x => x.ToString()).ToArray();
            float vx = getFloat(vs1);
            float vy = getFloat(vs2);

            if (lastBullet == null)
                lastBullet = new Bullet();

            lastBullet.destination = new JsonVector2(vx, vy).ToString();
        }

        private void with_type(GrammarArgs args)
        {
            if (lastBullet == null)
                lastBullet = new Bullet();

            object[] ovs1 = args.values[0];
            string[] vs1 = ovs1.Where(x => x != null).Select(x => x.ToString()).ToArray();
            lastBullet.type = getString(vs1);
        }
        
        private long loop_getter_handler(string times)
        {
            return this.varsManager.valueEvaluator.parseLong(times);
        }

        private bool case_condition_handler(CaseConditionArgs args)
        {
            object[] ovs1 = args.values[0];
            string[] vs1 = ovs1.Where(x => x != null).Select(x => x.ToString()).ToArray();
            object[] ovs2 = args.values[1];
            string[] vs2 = ovs2.Where(x => x != null).Select(x => x.ToString()).ToArray();
            object[] ovs3 = args.values[2];
            string[] vs3 = ovs3.Where(x => x != null).Select(x => x.ToString()).ToArray();
            float v1 = getFloat(vs1);
            float v2 = getFloat(vs3);
            string boolOp = getBoolOp(vs2);
            return evaluateFloat(v1, v2, boolOp);
        }

        private string getBoolOp(string[] values)
        {
            if (values.Length == 1)
                return values[0];
            else if (values.Length == 2)
                return values[0] + values[1];
            else
                throw new Exception("BoolOp error");
        }

        public bool evaluateFloat(float v1, float v2, string op)
        {
            bool result = false;
            if (op == Operator.EQUALS && v1 == v2)
                result = true;
            else if (op == Operator.DIFFERENT && v1 != v2)
                result = true;
            else if (op == Operator.SUPERIOR && v1 > v2)
                result = true;
            else if (op == Operator.INFERIOR && v1 < v2)
                result = true;
            else if (op == Operator.SUPERIOR_EQUALS && v1 >= v2)
                result = true;
            else if (op == Operator.INFERIOR_EQUALS && v1 <= v2)
                result = true;

            return result;
        }

        public long evaluate()
        {
            string text = File.ReadAllText(spells[spellName]);
            Tokenizer t = new Tokenizer();
            string[] tokens = t.tokenize(text);
            g = new GrammarEvaluator(t.values);
            g.tClose = "tAF";
            g.tEndl = "tPV";
            g.tOpen = "tAO";
            
            g.loopGetterHandler = new LoopGetterAction(loop_getter_handler);
            g.addGrammarRule("Number", "tNUMBER");
            g.addGrammarRule("Number", "tID");
            g.addGrammarRule("Float", "tID");
            g.addGrammarRule("Float", "tNUMBER tDOT tNUMBER");
            g.addGrammarRule("Vector", "tCO Float tV Float tCF");
            g.addGrammarRule("String", "tQUOTE tID tQUOTE");
            g.addGrammarRule("String", "tID");
            g.addGrammarRule("Type", "tFLOAT");
            g.addGrammarRule("Type", "tTNUMBER");
            g.addGrammarRule("Type", "tVECTOR");
            g.addGrammarRule("Type", "tTSTRING");
            g.addGrammarRule("Add", "Float tADD Float");
            g.addGrammarRule("Sub", "Float tSUB Float");
            g.addGrammarRule("Div", "Float tMUL Float");
            g.addGrammarRule("Mul", "Float tDIV Float");
            g.addGrammarRule("Op", "Add");
            g.addGrammarRule("Op", "Sub");
            g.addGrammarRule("Op", "Div");
            g.addGrammarRule("Op", "Mul");
            g.addGrammarRule("BehaviorDeclaration", "tPO tID tDP Type tPF");
            g.addGrammarRule("BehaviorDeclaration", "tPO (tID tDP Type tV)+ (tID tDP Type) tPF");
            g.addGrammarRule("Op", "Float");
            g.addGrammarRule("BoolOp", "tEQ tEQ");
            g.addGrammarRule("BoolOp", "tSUP tEQ");
            g.addGrammarRule("BoolOp", "tINF tEQ");
            g.addGrammarRule("BoolOp", "tDIFF tEQ");
            g.addGrammarRule("BoolOp", "tSUP");
            g.addGrammarRule("BoolOp", "tINF");
            g.addLoopPattern("tLOOP Number");
            g.addCasePattern("tCASE Float BoolOp Float");
            g.caseConditionHandler = new CaseConditionAction(case_condition_handler);
            g.addGrammarAction("tLET tID tDP tFLOAT tEQ Op tPV", new GrammarAction(let_float));
            g.addGrammarAction("tLET tID tDP tTSTRING tEQ String tPV", new GrammarAction(let_string));
            g.addGrammarAction("tLET tID tDP tVECTOR tEQ Vector tPV", new GrammarAction(let_vector));
            g.addGrammarAction("tID tEQ Op tPV", new GrammarAction(aff_float));
            g.addGrammarAction("tID tEQ String tPV", new GrammarAction(aff_string));
            g.addGrammarAction("tID tEQ Vector tPV", new GrammarAction(aff_vector));
            g.addGrammarAction("tWITH tSPEED Float tPV", new GrammarAction(with_speed));
            g.addGrammarAction("tWITH tANGLE Float tPV", new GrammarAction(with_angle));
            g.addGrammarAction("tMAKE tPV", new GrammarAction(make));
            g.addGrammarAction("BehaviorDeclaration", new GrammarAction(make));
            g.addGrammarAction("tWITH tPOSITION Vector tPV", new GrammarAction(with_position));
            g.addGrammarAction("tWITH tDESTINATION Vector tPV", new GrammarAction(with_destination));
            g.addGrammarAction("tWITH tTYPE String tPV", new GrammarAction(with_type));
            g.parseTokens(tokens);
            return particleId;
        }

        private long evaluate(List<string[]> allargs)
        {
            long times = 0;
            int loopCounter = 0;
            int caseFalseCounter = 0;
            int behaviorCounter = 0;
            bool inLoop = false;
            bool inBehavior = false;
            bool inCaseFalse = false;
            string currentBehavior = null;
            List<string[]> argsInLoop = new List<string[]>();

            foreach (string[] args in allargs)
            {
                if (args[0] == Command.COMMENT)
                {
                    continue;
                }
                else if (!inBehavior && !inLoop && !inCaseFalse && args[0] == Command.CASE)
                {
                    float v1 = this.varsManager.valueEvaluator.parseFloat(args[1]);
                    string op = args[2];
                    float v2 = this.varsManager.valueEvaluator.parseFloat(args[3]);

                    if(op == Operator.EQUALS && v1 != v2)
                        inCaseFalse = true;
                    else if(op == Operator.DIFFERENT && v1 == v2)
                        inCaseFalse = true;
                    else if (op == Operator.SUPERIOR && v1 <= v2)
                        inCaseFalse = true;
                    else if (op == Operator.INFERIOR && v1 >= v2)
                        inCaseFalse = true;
                    else if (op == Operator.SUPERIOR_EQUALS && v1 < v2)
                        inCaseFalse = true;
                    else if (op == Operator.INFERIOR_EQUALS && v1 > v2)
                        inCaseFalse = true;

                    if (inCaseFalse)
                        caseFalseCounter = 0;
                }
                else if (!inBehavior && !inLoop && inCaseFalse && args[0] == Command.OPEN)
                {
                    caseFalseCounter++;
                }
                else if(!inBehavior && !inLoop && inCaseFalse && args[0] == Command.CLOSE)
                {
                    caseFalseCounter--;
                    if (caseFalseCounter == 0)
                        inCaseFalse = false;
                }
                else if (!inBehavior && !inLoop && inCaseFalse)
                {
                    continue;
                }
                else if (args[0] == Command.COMPARE)
                {
                    string token = args[1];
                    float value1 = this.varsManager.valueEvaluator.parseFloat(args[2]);
                    float value2 = this.varsManager.valueEvaluator.parseFloat(args[3]);
                    int result;

                    if (value1 == value2)
                        result = 1;
                    else
                        result = 0;

                    varsManager.setValue(token, result.ToString(), Types.FLOAT);
                }
                else if (!inBehavior && args[0] == Command.BEHAVIOR)
                {
                    currentBehavior = this.varsManager.valueEvaluator.parseBehaviorName(args[1]);
                    behaviors[currentBehavior] = new List<string[]>();
                    argsDeclarationBehaviors[currentBehavior] = this.varsManager.valueEvaluator.parseBehaviorArgsName(args[1]);
                    inBehavior = true;
                    behaviorCounter = 0;
                }
                else if (inBehavior && args[0] == Command.OPEN)
                {
                    behaviorCounter++;
                    if (behaviorCounter > 1)
                        behaviors[currentBehavior].Add(args);
                }

                else if (inBehavior && args[0] == Command.CLOSE)
                {
                    behaviorCounter--;
                    if (behaviorCounter == 0)
                        inBehavior = false;
                    else
                        behaviors[currentBehavior].Add(args);
                }
                else if (inBehavior)
                {
                    behaviors[currentBehavior].Add(args);
                }
                else if (!inLoop && args[0] == Command.LOOP)
                {
                    times = (long)this.varsManager.valueEvaluator.parseLong(args[1]);
                    inLoop = true;
                    loopCounter = 0;
                }
                else if (inLoop && args[0] == Command.OPEN)
                {
                    loopCounter++;
                    if (loopCounter > 1)
                        argsInLoop.Add(args);
                }
                else if (inLoop && args[0] == Command.CLOSE)
                {
                    loopCounter--;
                    if (loopCounter == 0)
                    {
                        inLoop = false;
                        int saveLoopId = currentLoopId;
                        currentLoopId++;
                        for (long j = 0; j < times; j++)
                        {
                            this.varsManager.setValue(Command.INDEX + "_" + saveLoopId, j.ToString(), Value.Types.NUMBER);
                            evaluate(argsInLoop);
                        }
                        this.varsManager.removeValue(Command.INDEX + "_" + saveLoopId);
                        currentLoopId--;
                        times = 0;
                        argsInLoop.Clear();
                    }
                    else
                        argsInLoop.Add(args);
                }
                else if (inLoop)
                {
                    argsInLoop.Add(args);
                }
                else
                {
                    this.evaluateLine(args);
                }
            }
            return particleId;
        }

        private void evaluateLine(string[] args)
        {
            if (args[0] == Command.COMMENT)
            {
                return;
            }
            else if (args[0] == Command.TIMESET)
            {
                float value = this.varsManager.valueEvaluator.parseFloat(args[1]);
                time = initTime + value;
            }
            else if (args[0] == Command.CALL)
            {
                string token = args[1];
                SpellEvaluator sp = new SpellEvaluator(token, time, targetId, particleId, spells);
                sp.initializeGrids(shoot, particleMove);
                string[] argsValues = this.varsManager.valueEvaluator.parseArgsValues(args, 2);
                sp.specifyArgs(argsValues);
                particleId = sp.evaluate();
            }
            else if (args[0] == Command.DIMOVE)
            {
                float speed = this.varsManager.valueEvaluator.parseFloat(args[1]);
                float angle = this.varsManager.valueEvaluator.parseFloat(args[2]);
                Vector2 vDirection = Vector2Extension.valueOf(this.varsManager.valueEvaluator.parseFloat(args[2]));
                particleMove.Rows.Add(new JsonFloat(time), particleId - 1, null, new JsonVector2(vDirection).ToString(), new JsonFloat(speed));
            }
            else if (args[0] == Command.DMOVE)
            {
                float speed = this.varsManager.valueEvaluator.parseFloat(args[1]);
                string destination = this.varsManager.valueEvaluator.parseVector(args[2], behaviorParticleId);
                particleMove.Rows.Add(new JsonFloat(time), particleId - 1, destination, null, new JsonFloat(speed));
            }
            else if (args[0] == Command.WITH)
            {
                if (lastBullet == null)
                    lastBullet = new Bullet();

                if (args[1] == Command.TYPE)
                {
                    lastBullet.type = this.varsManager.valueEvaluator.parseString(args[2]);
                }
                else if (args[1] == Command.SPEED)
                {
                    lastBullet.speed = this.varsManager.valueEvaluator.parseFloat(args[2]);
                }
                else if (args[1] == Command.ANGLE)
                {
                    Vector2 direction = Vector2Extension.valueOf(this.varsManager.valueEvaluator.parseFloat(args[2]));
                    lastBullet.direction = new JsonVector2(direction).ToString();
                }
                else if (args[1] == Command.POSITION)
                {
                    string position = this.varsManager.valueEvaluator.parseVector(args[2], behaviorParticleId);
                    lastBullet.position = position;
                }
                else if (args[1] == Command.DESTINATION)
                {
                    string destination = this.varsManager.valueEvaluator.parseVector(args[2], behaviorParticleId);
                    lastBullet.destination = destination;
                }
            }
            else if (args[0] == Command.MAKE)
            {
                if (lastBullet.position == null)
                    shoot.Rows.Add(new JsonFloat(time), particleId++, targetId, null, lastBullet.destination, lastBullet.direction, new JsonFloat(lastBullet.speed), lastBullet.type);
                else
                    shoot.Rows.Add(new JsonFloat(time), particleId++, null, lastBullet.position, lastBullet.destination, lastBullet.direction, new JsonFloat(lastBullet.speed), lastBullet.type);
                if (args.Length > 1)
                {
                    string behaviorToken = this.varsManager.valueEvaluator.parseBehaviorName(args[1]);
                    object[] valuesArgs = this.varsManager.valueEvaluator.parseBehaviorArgsValues(args[1]);
                    particleId = this.parseBehavior(behaviorToken, valuesArgs);
                }
                lastBullet = null;
            }
            else if (args[0] == Command.DELAY)
            {
                time += this.varsManager.valueEvaluator.parseFloat(args[1]);
            }
            else if (args[0] == Command.LET)
            {
                string[] decl = args[1].Split(':');
                string token = decl[0];
                string type = decl[1];
                string value = args[2];
                if(type == "string")
                    this.varsManager.setValue(token, value, Value.Types.STRING);
                else if(type == "float")
                    this.varsManager.setValue(token, value, Value.Types.FLOAT);
                else if(type == "vector")
                    this.varsManager.setValue(token, value, Value.Types.VECTOR2);
                else if (type == "number")
                    this.varsManager.setValue(token, value, Value.Types.NUMBER);
            }
            else if (args[0] == Command.SET)
            {
                string token = args[1];
                string value = args[2];
                this.varsManager.setValue(token, value, Value.Types.FLOAT);
            }
            else if (args[0] == Command.FREE)
            {
                string token = args[1];
                this.varsManager.removeValue(token);
            }
            else if (args[0] == Command.ADD)
            {
                string token = args[1];
                float v1 = this.varsManager.valueEvaluator.parseFloat(args[2]);
                float v2 = this.varsManager.valueEvaluator.parseFloat(args[3]);
                this.varsManager.setValue(token, StringHelper.FormatFloat(v1+v2), Value.Types.FLOAT);
            }
            else if (args[0] == Command.SUB)
            {
                string token = args[1];
                float v1 = this.varsManager.valueEvaluator.parseFloat(args[2]);
                float v2 = this.varsManager.valueEvaluator.parseFloat(args[3]);
                this.varsManager.setValue(token, StringHelper.FormatFloat(v1 - v2), Value.Types.FLOAT);
            }
            else if (args[0] == Command.DIV)
            {
                string token = args[1];
                float v1 = this.varsManager.valueEvaluator.parseFloat(args[2]);
                float v2 = this.varsManager.valueEvaluator.parseFloat(args[3]);
                this.varsManager.setValue(token, StringHelper.FormatFloat(v1 / v2), Value.Types.FLOAT);
            }
            else if (args[0] == Command.MUL)
            {
                string token = args[1];
                float v1 = this.varsManager.valueEvaluator.parseFloat(args[2]);
                float v2 = this.varsManager.valueEvaluator.parseFloat(args[3]);
                this.varsManager.setValue(token, StringHelper.FormatFloat(v1 * v2), Value.Types.FLOAT);
            }
            else if (args[0] == Command.VMUL)
            {
                string token = args[1];
                JsonVector2 v1 = JsonVector2.convertString(this.varsManager.valueEvaluator.parseVector(args[2]));
                JsonVector2 v2 = JsonVector2.convertString(this.varsManager.valueEvaluator.parseVector(args[3]));
                this.varsManager.setValue(token, (v1*v2).ToString(), Value.Types.VECTOR2);
            }
            else if (args[0] == Command.MOD)
            {
                string token = args[1];
                float v1 = this.varsManager.valueEvaluator.parseLong(args[2]);
                float v2 = this.varsManager.valueEvaluator.parseLong(args[3]);
                this.varsManager.setValue(token, (v1%v2).ToString(), Value.Types.NUMBER);
            }
        }

        private void specifyBehaviors(Dictionary<string, List<string[]>> behaviors,  Dictionary<string, Dictionary<string, Value.Types>> argsDeclarationsBehaviors)
        {
            this.behaviors = behaviors;
            this.argsDeclarationBehaviors = argsDeclarationsBehaviors;
        }

        private long parseBehavior(string behaviorToken, object[] valuesArgs)
        {
            SpellEvaluator sp = new SpellEvaluator(null, time, targetId, particleId, spells, particleId-1, initTime);
            sp.initializeGrids(shoot, particleMove);
            sp.specifyBehaviorArgs(argsDeclarationBehaviors[behaviorToken], valuesArgs);
            sp.specifyBehaviors(behaviors, argsDeclarationBehaviors);
            particleId = sp.evaluate(behaviors[behaviorToken]);
            return particleId;
        }

        private void specifyBehaviorArgs(Dictionary<string, Types> argsDeclarations, object[] values)
        {
            int i = 0;
            foreach(string key in argsDeclarations.Keys)
            {
                this.varsManager.setValue(key, values[i].ToString(), argsDeclarations[key]);
                i++;
            }
        }

        private long executeBehavior(List<string[]> behavior)
        {
            return evaluate(behavior);
        }
    }
}
