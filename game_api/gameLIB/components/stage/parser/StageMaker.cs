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

        public StageMaker(Stage stage)
        {
            _stage = stage;
        }

        private void addTask(float time, Instruction ins)
        {
            Task task = new Task(time, ins);
            _stage.addTask(task);
        }

        public void createStageFromPath(string path)
        {
            string data = File.ReadAllText(path, Encoding.UTF8);
            this.createStage(data);
        }

        public void createStage(string data)
        {
            Script script = JsonConvert.DeserializeObject<Script>(data);
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