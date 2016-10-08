using Microsoft.Xna.Framework;
using StageMaker.models;
using StageMaker.utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StageMaker.spell_maker
{
    public class SpellEvaluator
    {
        private VarsManager varsManager;
        private Dictionary<string, string> spells;
        private Dictionary<string, List<string[]>> behaviors;
        private Dictionary<string, string[]> argsBehaviors;
        private float time;
        private long targetId;
        private long particleId;
        private DataGridView shoot;
        private DataGridView particleMove;
        private int currentLoopId;
        private Bullet lastBullet;
        private string spellName;
        private string[] spellArgsNames;
        private float[] spellArgsValues;
        private long behaviorParticleId;

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
            public static readonly string MUL = "mul";
            public static readonly string DIV = "div";
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

        public SpellEvaluator(string spellName, float time, long targetId, long particleId, Dictionary<string, string> spells)
        {
            this.behaviorParticleId = -1;
            this.spellName = spellName;
            this.time = time;
            this.targetId = targetId;
            this.particleId = particleId;
            this.spells = spells;
            this.behaviors = new Dictionary<string, List<string[]>>();
            this.argsBehaviors = new Dictionary<string, string[]>();
            this.currentLoopId = 0;
            this.varsManager = new VarsManager();

            if (spellName != null)
                this.initializeArgs();
        }

        private SpellEvaluator(string spellName, float time, long targetId, long particleId, Dictionary<string, string> spells, long behaviorParticleId)
        {
            this.behaviorParticleId = behaviorParticleId;
            this.spellName = spellName;
            this.time = time;
            this.targetId = targetId;
            this.particleId = particleId;
            this.spells = spells;
            this.behaviors = new Dictionary<string, List<string[]>>();
            this.argsBehaviors = new Dictionary<string, string[]>();
            this.currentLoopId = 0;
            this.varsManager = new VarsManager();
            if (spellName != null)
                this.initializeArgs();
        }

        private void initializeArgs()
        {
            string[] spellArgs = FileHelper.getFirstLineArgs(spells[spellName]);
            if(spellArgs[0] == "args")
            {
                spellArgsNames = this.varsManager.valueEvaluator.parseArgsNames(spellArgs, 1);
                float[] argsValues = new float[spellArgsNames.Length];

                for (int i = 0; i < argsValues.Length; i++)
                {
                    argsValues[i] = 0f;
                }
                this.specifyArgs(spellArgsNames, argsValues);
            }
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

        public string[] getCallArgsNames()
        {
            return varsManager.getAllArgsNames();
        }

        private void specifyArgs(string[] names, float[] values)
        {
            for(int i=0;i<names.Length;i++)
            {
                this.varsManager.setValue(names[i], StringHelper.FormatFloat(values[i]), Value.Types.FLOAT);
            }
            spellArgsValues = values;
        }

        public void specifyArgs(string[] values)
        {
            float[] fValues = this.varsManager.valueEvaluator.parseArgsValues(values, 0);
            this.specifyArgs(spellArgsNames, fValues);
        }

        public long evaluate()
        {
            string text = File.ReadAllText(spells[spellName]);
            string[] lines = StringHelper.FormatAllText(text);
            List<string[]> allargs = new List<string[]>();
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] args = StringHelper.FormatLine(line);
                allargs.Add(args);
            }
            return evaluate(allargs);
            
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

                    if(op == "==" && v1 != v2)
                        inCaseFalse = true;
                    else if(op == "!=" && v1 == v2)
                        inCaseFalse = true;
                    else if (op == ">" && v1 <= v2)
                        inCaseFalse = true;
                    else if (op == "<" && v1 >= v2)
                        inCaseFalse = true;
                    else if (op == ">=" && v1 < v2)
                        inCaseFalse = true;
                    else if (op == "<=" && v1 > v2)
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

                    varsManager.setValue(token, result.ToString(), Value.Types.FLOAT);
                }
                else if (!inBehavior && args[0] == Command.BEHAVIOR)
                {
                    currentBehavior = this.varsManager.valueEvaluator.parseBehaviorName(args[1]);
                    behaviors[currentBehavior] = new List<string[]>();
                    string[] argsB = this.varsManager.valueEvaluator.parseBehaviorArgsName(args[1]);
                    argsBehaviors[currentBehavior] = argsB;
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
                    times = (long)this.varsManager.valueEvaluator.parseFloat(args[1]);
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
                            this.varsManager.setValue(Command.INDEX + "_" + saveLoopId, j.ToString(), Value.Types.LONG);
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
                time = value;
            }
            else if (args[0] == Command.CALL)
            {
                string token = args[1];
                SpellEvaluator sp = new SpellEvaluator(token, time, targetId, particleId, spells);
                sp.initializeGrids(shoot, particleMove);
                float[] argsValues = this.varsManager.valueEvaluator.parseArgsValues(args, 2);
                sp.specifyArgs(spellArgsNames, argsValues);
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
                float x = this.varsManager.valueEvaluator.parseFloat(args[2]);
                float y = this.varsManager.valueEvaluator.parseFloat(args[3]);
                string destination = new JsonVector2(x, y).ToString();
                particleMove.Rows.Add(new JsonFloat(time), particleId - 1, destination, null, new JsonFloat(speed));
            }
            else if (args[0] == Command.WITH)
            {
                if (lastBullet == null)
                    lastBullet = new Bullet();

                if (args[1] == Command.TYPE)
                {
                    lastBullet.type = args[2];
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
                    float[] valuesArgs = this.varsManager.valueEvaluator.parseBehaviorArgsValues(args[1]);
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
                string token = args[1];
                string value = args[2];
                this.varsManager.setValue(token, value, Value.Types.FLOAT);
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
        }

        private void specifyBehaviors(Dictionary<string, List<string[]>> behaviors, Dictionary<string, string[]> argsBehaviors)
        {
            this.behaviors = behaviors;
            this.argsBehaviors = argsBehaviors;
        }
        private long parseBehavior(string behaviorToken, float[] valuesArgs)
        {
            SpellEvaluator sp = new SpellEvaluator(null, time, targetId, particleId, spells, particleId-1);
            sp.initializeGrids(shoot, particleMove);
            sp.specifyArgs(argsBehaviors[behaviorToken], valuesArgs);
            sp.specifyBehaviors(behaviors, argsBehaviors);
            particleId = sp.evaluate(behaviors[behaviorToken]);
            return particleId;
        }

        private long executeBehavior(List<string[]> behavior)
        {
            return evaluate(behavior);
        }
    }
}
