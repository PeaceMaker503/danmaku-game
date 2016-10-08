using gameLIB.components.stage.instructions;
using gameLIB.components.stage.parser.models;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameLIB.utils
{
    public class JsonHelper
    {
        public static string JsonSerializeWithoutQuoteInNames(object obj)
        {
            using (var stringWriter = new StringWriter())
            {
                using (var writer = new JsonTextWriter(stringWriter) { QuoteName = false })
                    new JsonSerializer().Serialize(writer, obj);
                return stringWriter.ToString();
            }
        }

        public static InstructionCreate createInstructionCreate(CreateEvent e)
        {
            Target t = e.target;
            InstructionCreate ins = new InstructionCreate(t.type, t.id, t.health, t.position, t.destination, t.direction, t.fdirection, t.speed, t.fspeed);
            return ins;
        }

        public static InstructionShoot createInstructionShoot(ShootEvent e)
        {
            Bullet b = e.bullet;
            InstructionShoot ins = new InstructionShoot(e.targetId, b.type, e.bullet.id, e.bullet.position, e.bullet.destination, e.bullet.direction, e.bullet.speed);
            return ins;
        }

        public static InstructionMove createInstructionMove(MoveEvent e)
        {
            return new InstructionMove(e.targetId, e.destination, e.direction, e.speed, e.fdirection, e.fspeed);
        }

        public static InstructionParticleMove createInstructionParticleMove(ParticleMoveEvent e)
        {
            return new InstructionParticleMove(e.particleId, e.destination, e.direction, e.speed);
        }

        public static Vector2 valueOf(JsonVector2 v)
        {
            if (v == null)
                return new Vector2(float.NaN, float.NaN);
            else
                return new Vector2(v.X, v.Y);
        }
    }
}
