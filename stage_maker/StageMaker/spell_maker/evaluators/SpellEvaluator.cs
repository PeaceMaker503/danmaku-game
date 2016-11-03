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
        private Dictionary<string, List<string>> behaviorsBuffer;
        private Dictionary<string, int> behaviorsValuesCursor;
        private Dictionary<string, Dictionary<string, Types>> argsDeclarationBehaviors;
        private float time;
        private float initTime;
        private long targetId;
        private long particleId;
        private DataGridView shoot;
        private DataGridView particleMove;
        private Bullet lastBullet;
        private string spellName;
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
            this.behaviorsValuesCursor = new Dictionary<string, int>();
            this.behaviorParticleId = -1;
            this.spellName = spellName;
            this.time = time;
            this.targetId = targetId;
            this.particleId = particleId;
            this.spells = spells;
            this.behaviorsBuffer = new Dictionary<string, List<string>>();
            this.argsDeclarationBehaviors = new Dictionary<string, Dictionary<string, Types>>();
            this.varsManager = new VarsManager();
            this.argsDeclarationBehaviors = new Dictionary<string, Dictionary<string, Types>>();
            if (spellName != null)
                this.declareArgs();
        }

        private SpellEvaluator(string spellName, float time, long targetId, long particleId, Dictionary<string, string> spells, long behaviorParticleId, float initTime)
            : this(spellName, time, targetId, particleId, spells)
        {
            this.initTime = initTime;
            this.behaviorParticleId = behaviorParticleId;
            this.varsManager = new VarsManager(behaviorParticleId);
        }

        private void declareArgs()
        {
            /*Dictionary<string, Types> spellArgsDeclaration = FileHelper.getArgsDeclaration(spells[spellName]);
            this.varsManager.declareArgs(spellArgsDeclaration);*/
        }

        public void initializeGrids(DataGridView shoot, DataGridView particleMove)
        {
            this.shoot = shoot;
            this.particleMove = particleMove;
        }

        public bool mustSpecifyArgs()
        {
            return false;
        }

        public Dictionary<string, Types> getArgsDeclaration()
        {
            return new Dictionary<string, Types>();
        }

        public void specifyArgs(string[] argsValues)
        {
            // this.varsManager.specifyArgs(argsValues);
        }

        public long evaluate(string[] text)
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
                    argsDeclarationBehaviors[behaviorName] = this.varsManager.valueEvaluator.evaluateBehaviorDeclarationArgs(behaviorArgs);
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
                    caseFalse = !this.varsManager.valueEvaluator.evaluateCase(v1, v2, op);
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
                    loopCount = (int)this.varsManager.valueEvaluator.evaluateArithmeticOperation(args[1]);
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
                        this.evaluate_make_behavior(currentBehaviorName, behaviorCallArgs);
                    }
                }
                else if (line.StartsWith("DELAY"))
                {
                    line = line.Replace("DELAY", String.Empty);
                    string[] args = line.Substring(1, line.Length - 2).Split(',').Where(s => s != null && s != String.Empty).ToArray();
                    string delay = args[0];
                    this.evaluate_delay(delay);
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
                else if(line.StartsWith("LET_AFF"))
                {
                    line = line.Replace("LET_AFF", String.Empty);
                    string[] args = line.Substring(1, line.Length - 2).Split(',').Where(s => s != null && s != String.Empty).ToArray();
                    string id = args[0];
                    string type = args[1];
                    string value = args[2];
                    this.evaluate_let_aff(id, type, value);
                }
            }
            return particleId;
        }

        private void evaluate_make_behavior(string currentBehaviorName, string behaviorCallArgs)
        {
            Dictionary<string, Types> behaviorDeclarationArgs = argsDeclarationBehaviors[currentBehaviorName];
            Dictionary<string, Value> behaviorCallValues = this.varsManager.valueEvaluator.evaluateBehaviorCallArgs(behaviorDeclarationArgs, behaviorCallArgs);
            SpellEvaluator spBehavior = new SpellEvaluator(null, time, targetId, particleId, spells, Math.Max(0, particleId - 1), initTime);
            spBehavior.setBehaviorCallValues(behaviorCallValues);
            spBehavior.initializeGrids(shoot, particleMove);
            spBehavior.setBehaviors(argsDeclarationBehaviors, behaviorsBuffer);
            particleId = spBehavior.evaluate(behaviorsBuffer[currentBehaviorName].ToArray());
        }

        private void evaluate_make()
        {
            if (lastBullet.position == null)
                shoot.Rows.Add(new JsonFloat(time), particleId++, targetId, null, lastBullet.destination, lastBullet.direction, new JsonFloat(lastBullet.speed), lastBullet.type);
            else
                shoot.Rows.Add(new JsonFloat(time), particleId++, null, lastBullet.position, lastBullet.destination, lastBullet.direction, new JsonFloat(lastBullet.speed), lastBullet.type);

            lastBullet = null;
        }

        private void evaluate_delay(string delay)
        {
            float fDelay = this.varsManager.valueEvaluator.evaluateArithmeticOperation(delay);
            time += fDelay;
        }

        private void evaluate_with_position(string position)
        {
            if (lastBullet == null)
                lastBullet = new Bullet();

            string vPosition = this.varsManager.valueEvaluator.evaluateVector(position);
            lastBullet.position = vPosition;
        }

        private void evaluate_with_destination(string destination)
        {
            if (lastBullet == null)
                lastBullet = new Bullet();

            string vDestination = this.varsManager.valueEvaluator.evaluateVector(destination);
            lastBullet.destination = vDestination;
        }

        private void evaluate_with_angle(string angle)
        {
            if (lastBullet == null)
                lastBullet = new Bullet();

            float fAngle = this.varsManager.valueEvaluator.evaluateArithmeticOperation(angle);
            Vector2 direction = Vector2Extension.valueOf(fAngle);
            lastBullet.direction = new JsonVector2(direction).ToString();
        }

        private void evaluate_with_speed(string speed)
        {
            if (lastBullet == null)
                lastBullet = new Bullet();

            lastBullet.speed = this.varsManager.valueEvaluator.evaluateArithmeticOperation(speed);
        }

        private void evaluate_with_type(string type)
        {
            if (lastBullet == null)
                lastBullet = new Bullet();

            lastBullet.type = this.varsManager.valueEvaluator.evaluateString(type);
        }

        private void evaluate_aff(string id, string value)
        {
            varsManager.updateValue(id, value);
        }

        private void evaluate_let_aff(string id, string type, string value)
        {
            varsManager.setValue(id, value, type);
        }

        private void evaluate_dimove(string destination)
        {

        }

        /*
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
            
            else if (args[0] == Command.FREE)
            {
                string token = args[1];
                this.varsManager.removeValue(token);
            }
           
        }*/

        private void setBehaviors(Dictionary<string, Dictionary<string, Types>> decl, Dictionary<string, List<string>> beh)
        {
            this.argsDeclarationBehaviors = decl;
            this.behaviorsBuffer = beh;
        }

        private void setBehaviorCallValues(Dictionary<string, Value> args)
        {
            this.varsManager.setValues(args);
        }
    }
}
