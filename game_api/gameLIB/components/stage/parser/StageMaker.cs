using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using gameLIB.components.stage.parser.models;
using gameLIB.components.stage.instructions;
using gameLIB.utils;

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

        private void addTask(float time, Instruction ins)
        {
            Task task = new Task(time, ins);
            _stage.addTask(task);
        }

        public void createStage()
        {
            string text = File.ReadAllText(_path, Encoding.UTF8);
            Script script = JsonConvert.DeserializeObject<Script>(text);
            foreach(CreateEvent e in script.create)
            {
                InstructionCreate ins = JsonHelper.createInstructionCreate(e);
                this.addTask(e.time, ins);
            }

            foreach (ShootEvent e in script.shoot)
            {
                InstructionShoot ins = JsonHelper.createInstructionShoot(e);
                this.addTask(e.time, ins);
            }

            foreach (MoveEvent e in script.move)
            {
                InstructionMove ins = JsonHelper.createInstructionMove(e);
                this.addTask(e.time, ins);
            }

            foreach (ParticleMoveEvent e in script.particleMove)
            {
                InstructionParticleMove ins = JsonHelper.createInstructionParticleMove(e);
                this.addTask(e.time, ins);
            }
        }
    }
}