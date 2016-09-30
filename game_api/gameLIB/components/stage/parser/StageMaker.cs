using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using gameLIB.components.stage.parser.models;
using gameLIB.components.stage.instructions;

namespace gameLIB.components.stage.parser
{
    public sealed class StageMaker
    {
        private Stage _stage;
        private String _path;
        private Dictionary<String, String> _stack;

        public StageMaker(Stage stage, String path)
        {
            _stage = stage;
            _path = path;
            _stack = new Dictionary<String, String>();
        }

        public void createStage()
        {
            string text = File.ReadAllText(_path, Encoding.UTF8);
            Script script = JsonConvert.DeserializeObject<Script>(text);
            foreach(CreateEvent e in script.create)
            {
                Target t = e.target;
                InstructionCreate ins = new InstructionCreate(t.type, t.id, t.health, new Vector2(t.position.X, t.position.Y), new Vector2(t.destination.X, t.destination.Y), new Vector2(t.direction.X, t.direction.Y), new Vector2(t.fdirection.X, t.fdirection.Y), t.speed, t.fspeed);
                Task task = new Task(e.time, ins);
                _stage.addTask(task);
            }

            foreach (ShootEvent e in script.shoot)
            {
                Bullet b = e.bullet;
                InstructionShoot ins = new InstructionShoot(e.targetId, b.type, b.id, new Vector2(b.destination.X, b.destination.Y), new Vector2(b.direction.X, b.direction.Y), b.speed);
                Task task = new Task(e.time, ins);
                _stage.addTask(task);
            }

            foreach (MoveEvent e in script.move)
            {
                InstructionMove ins = new InstructionMove(e.targetId, new Vector2(e.destination.X, e.destination.Y), new Vector2(e.direction.X, e.direction.Y), e.speed, new Vector2(e.fdirection.X, e.fdirection.Y), e.fspeed);
                Task task = new Task(e.time, ins);
                _stage.addTask(task);
            }
        }
    }
}