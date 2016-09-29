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
                InstructionCreate ins = new InstructionCreate(t.type, t.id, t.health, t.position, t.destination, t.direction, t.fdirection, t.speed, t.fspeed);
                Task task = new Task(e.time, ins);
                _stage.addTask(task);
            }

            foreach (ShootEvent e in script.shoot)
            {
                Bullet b = e.bullet;
                InstructionShoot ins = new InstructionShoot(e.targetId, b.type, b.id, b.destination, b.direction, b.speed);
                Task task = new Task(e.time, ins);
                _stage.addTask(task);
            }

            foreach (MoveEvent e in script.move)
            {
                InstructionMove ins = new InstructionMove(e.targetId, e.destination, e.direction, e.speed, e.fdirection, e.fspeed);
                Task task = new Task(e.time, ins);
                _stage.addTask(task);
            }
        }
    }
}