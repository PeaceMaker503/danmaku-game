using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.IO;

namespace gameLIB.components.stage
{
    public class StageMaker
    {
        public enum Type { Vector, Number, ID, Type, Particle, Time };
        private Stage _stage;
        private String _path;
        private Dictionary<String, String> _stack;
        private Random _rnd;

        public StageMaker(Stage stage, String path)
        {
            _stage = stage;
            _path = path;
            _rnd = new Random();
            _stack = new Dictionary<String, String>();
        }

        public Object transform(String arg)
        {
            if(arg.Equals(String.Empty))
            {
                return null;
            }
            else if (arg.Contains("(") && (arg.Contains(",")) && arg.Contains(")"))
            {
                int i = arg.IndexOf("(");
                int i2 = arg.IndexOf(",");
                int i3 = arg.IndexOf(")");
                String fx = arg.Substring(i + 1, i2 - 1 - i).Trim();
                String fy = arg.Substring(i2 + 1, i3 - 1 - i2).Trim();
                float x = Convert.ToSingle(transform(fx));
                float y = Convert.ToSingle(transform(fy));
                return new Vector2(x, y);
            }
            else
            {
                return arg.toDouble();
            }
        }

        /* public Object applyFunction(String arg)
         {
             arg = arg.Trim();
             if (_stack.ContainsKey(arg))
             {
                 return applyFunction(_stack[arg]);
             }
             if (arg.Contains("rnd") && !arg.Contains("in"))
             {
                 int i3 = arg.IndexOf("(");
                 int i4 = arg.IndexOf(",");
                 int i5 = arg.IndexOf(")");
                 double nb1 = _parseDouble(arg.Substring(i3 + 1, i4 - 1 - i3));
                 double nb2 = _parseDouble(arg.Substring(i4 + 1, i5 - 1 - i4));
                 return _rnd.Next((int)nb1, (int)nb2 + 1);
             }
             else if (arg.Contains("rndin"))
             {
                 List<double> l = new List<double>();
                 arg = arg.Trim();

                 String rb = arg;
                 int i = rb.IndexOf("(");
                 int i2 = rb.IndexOf(",");
                 String dStr = rb.Substring(i + 1, i2 - 1 - i);
                 double d = _parseDouble(dStr);
                 rb = rb.Substring(rb.IndexOf(",") + 1);
                 l.Add(d);
                 while (rb.Contains(","))
                 {
                     int id = rb.IndexOf(",");
                     String dStr2 = rb.Substring(0, id);
                     double d2 = _parseDouble(dStr2);
                     l.Add(d2);
                     rb = rb.Substring(rb.IndexOf(",") + 1);
                 }
                 int i3 = rb.IndexOf(")");
                 String dStr3 = rb.Substring(0, i3);
                 double d3 = _parseDouble(dStr3);
                 l.Add(d3);
                 int ei = _rnd.Next(0, l.Count);
                 double r = l.ElementAt(ei);
                 return r;
             }
             else if (arg.Contains("(") && (arg.Contains(",")) && arg.Contains(")"))
             {
                 int i = arg.IndexOf("(");
                 int i2 = arg.IndexOf(",");
                 int i3 = arg.IndexOf(")");
                 String fx = arg.Substring(i + 1, i2 - 1 - i);
                 String fy = arg.Substring(i2 + 1, i3 - 1 - i2);
                 float x = Convert.ToSingle(applyFunction(fx));
                 float y = Convert.ToSingle(applyFunction(fy));
                 return new Vector2(x, y);
             }
             else
             {
                 arg = arg.Trim();
                 double nb = _parseDouble(arg);
                 return nb;
             }
         }*/

        public void createStage()
        {
            StreamReader file = new StreamReader(_path);

            for (String line = file.ReadLine(); line != null; line = file.ReadLine())
            {
                if (line.StartsWith("create"))
                {
                    double time = line.get(Type.Time).toDouble();
                    String id = line.get(Type.ID);
                    String type = line.get(Type.Type);
                    String destinationStr = line.get("destination", Type.Vector);
                    String positionStr = line.get("position", Type.Vector);
                    String speedStr = line.get("speed", Type.Number);
                    String directionStr = line.get("direction", Type.Vector);
                    String fdirectionStr = line.get("fDirection", Type.Vector);
                    String fspeedStr = line.get("fSpeed", Type.Number);
                    String healthStr = line.get("health", Type.Number);

                    Vector2 position = (Vector2)this.transform(positionStr);
                    int health = (int)(double)this.transform(healthStr);

                    float speed = (float)(double)this.transform(speedStr);
                    Vector2 destination;
                    try
                    {
                        destination = (Vector2)this.transform(destinationStr);
                    }
                    catch(Exception)
                    {
                        destination = Vector2.Zero;
                    }
                    Vector2 direction;
                    try
                    {
                        direction = Vector2.Normalize((Vector2)this.transform(directionStr));
                    }
                    catch(Exception)
                    {
                        direction = Vector2.Zero;
                    }
                    Vector2 fdirection;
                    try
                    {
                        fdirection = Vector2.Normalize((Vector2)this.transform(fdirectionStr));
                    }
                    catch(Exception)
                    {
                        fdirection = Vector2.Zero;
                    }
                    float fspeed;
                    try
                    {
                        fspeed = (float)(double)this.transform(fspeedStr);
                    }
                    catch(Exception)
                    {
                        fspeed = 0f;
                    }
                    InstructionCreate ins = new InstructionCreate(type, id, health, position, destination, direction, fdirection, speed, fspeed);
                    Task task = new Task(time, ins);
                    _stage.addTask(task);
                }
                else if (line.StartsWith("shoot"))
                {
                    double time = line.get(Type.Time).toDouble();
                    String directionStr = line.get("direction", Type.Vector);
                    String destinationStr = line.get("destination", Type.Vector);
                    String id = line.get(Type.ID);
                    String speedStr = line.get("speed", Type.Number);
                    String particle = line.get(Type.Particle);
                    Vector2 direction;
                    try
                    {
                        direction = (Vector2.Normalize((Vector2)this.transform(directionStr)));
                    }
                    catch(Exception)
                    {
                        direction = Vector2.Zero;
                    }
                    Vector2 destination;
                    try
                    {
                        destination = (Vector2)this.transform(destinationStr);
                    }
                    catch (Exception)
                    {
                        destination = Vector2.Zero;
                    }
                    float speed = (float)(double)this.transform(speedStr);
                    InstructionShoot ins = new InstructionShoot(id, particle, destination, direction, speed);
                    Task task = new Task(time, ins);
                    _stage.addTask(task);

                }
                else if (line.StartsWith("move"))
                {
                    double time = line.get(Type.Time).toDouble();
                    String id = line.get(Type.ID);
                    String directionStr = line.get("direction", Type.Vector);
                    String destinationStr = line.get("destination", Type.Vector);
                    String speedStr = line.get("speed", Type.Number);
                    String fdirectionStr = line.get("fDirection", Type.Vector);
                    String fspeedStr = line.get("fSpeed", Type.Number);
                    Vector2 fdirection;
                    try
                    {
                        fdirection = Vector2.Normalize((Vector2)this.transform(fdirectionStr));
                    }
                    catch (Exception)
                    {
                        fdirection = Vector2.Zero;
                    }
                    Vector2 destination;
                    try
                    {
                        destination = (Vector2)this.transform(destinationStr);
                    }
                    catch (Exception)
                    {
                        destination = Vector2.Zero;
                    }
                    Vector2 direction;
                    try
                    {
                        direction = (Vector2.Normalize((Vector2)this.transform(directionStr)));
                    }
                    catch (Exception)
                    {
                        direction = Vector2.Zero;
                    }
                    float speed = (float)(double)this.transform(speedStr);
                    float fspeed;
                    try
                    {
                        fspeed = (float)(double)this.transform(fspeedStr);
                    }
                    catch (Exception)
                    {
                        fspeed = 0f;
                    }
                    InstructionMove ins = new InstructionMove(id, destination, direction, fdirection, speed, fspeed);
                    Task task = new Task(time, ins);
                    _stage.addTask(task);
                }
            }
            file.Close();
        }
    }
}
