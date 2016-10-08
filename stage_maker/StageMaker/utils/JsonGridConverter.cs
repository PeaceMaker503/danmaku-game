using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using StageMaker.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static StageMaker.StageMaker;

namespace StageMaker.utils
{
    public class JsonGridConverter
    {
        public static long importJson(DataGridView enemies, DataGridView create, DataGridView shoot, DataGridView move, DataGridView particleMove, string path)
        {
            try
            {
                string text = File.ReadAllText(path);
                Script script = JsonConvert.DeserializeObject<Script>(text);
                long idEnemy = 0;
                enemies.Rows.Clear();
                create.Rows.Clear();
                shoot.Rows.Clear();
                move.Rows.Clear();

                foreach (CreateEvent ev in script.create)
                {
                    JsonGridHelper.insertEnemy(enemies, ev.target);
                    JsonGridHelper.insertCreate(create, ev);
                    idEnemy = Math.Max(idEnemy, ev.target.id);
                }
                idEnemy++;

                foreach (ShootEvent ev in script.shoot)
                {
                    JsonGridHelper.insertShoot(shoot, ev);
                }

                foreach (MoveEvent ev in script.move)
                {
                    JsonGridHelper.insertMove(move, ev);
                }

                foreach (ParticleMoveEvent ev in script.particleMove)
                {
                    JsonGridHelper.insertParticleMove(particleMove, ev);
                }

                return idEnemy;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void exportJson(DataGridView enemies, DataGridView create, DataGridView shoot, DataGridView move, DataGridView particleMove, string path)
        {
            try
            {
                Script script = new Script();
                script.create = new List<CreateEvent>();
                script.shoot = new List<ShootEvent>();
                script.move = new List<MoveEvent>();
                script.particleMove = new List<ParticleMoveEvent>();
                Dictionary<long, Target> targets = new Dictionary<long, Target>();

                foreach (DataGridViewRow row in enemies.Rows)
                {
                    Target t = JsonGridHelper.createTarget(row);
                    targets[t.id] = t;
                }
                
                foreach (DataGridViewRow row in create.Rows)
                {
                    CreateEvent ev = JsonGridHelper.createCreateEvent(row, targets);
                    script.create.Add(ev);
                }

                foreach (DataGridViewRow row in shoot.Rows)
                {
                    ShootEvent ev = JsonGridHelper.createShootEvent(row);
                    script.shoot.Add(ev);
                }

                foreach (DataGridViewRow row in move.Rows)
                {
                    MoveEvent ev = JsonGridHelper.createMoveEvent(row);
                    script.move.Add(ev);
                }

                foreach (DataGridViewRow row in particleMove.Rows)
                {
                    ParticleMoveEvent ev = JsonGridHelper.createParticleMoveEvent(row);
                    script.particleMove.Add(ev);
                }

                string text = JsonConvert.SerializeObject(script, Formatting.Indented);
                File.WriteAllText(path, text, Encoding.UTF8);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static OpenJsonResults openJson(DataGridView enemies, DataGridView create, DataGridView shoot, DataGridView move, DataGridView particleMove, string path)
        {
            try
            {
                string text = File.ReadAllText(path);
                ScriptSave script = JsonConvert.DeserializeObject<ScriptSave>(text);
                long idEnemy = 0;
                enemies.Rows.Clear();
                create.Rows.Clear();
                shoot.Rows.Clear();
                move.Rows.Clear();

                foreach (Target target in script.enemies)
                {
                    JsonGridHelper.insertEnemy(enemies, target);
                }

                foreach (CreateEventSave ev in script.create)
                {
                    JsonGridHelper.insertCreateSave(create, ev);
                    idEnemy = Math.Max(idEnemy, ev.targetId);
                }
                idEnemy++;

                foreach (ShootEvent ev in script.shoot)
                {
                    JsonGridHelper.insertShoot(shoot, ev);
                }

                foreach (MoveEvent ev in script.move)
                {
                    JsonGridHelper.insertMove(move, ev);
                }

                foreach (ParticleMoveEvent ev in script.particleMove)
                {
                    JsonGridHelper.insertParticleMove(particleMove, ev);
                }

                return new OpenJsonResults(idEnemy, script.spells);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void saveJson(DataGridView enemies, DataGridView create, DataGridView shoot, DataGridView move, DataGridView particleMove, List<SpellLine> jsonSpells, string path)
        {
            try
            {
                ScriptSave script = new ScriptSave();
                script.enemies = new List<Target>();
                script.create = new List<CreateEventSave>();
                script.shoot = new List<ShootEvent>();
                script.move = new List<MoveEvent>();
                script.particleMove = new List<ParticleMoveEvent>();
                script.spells = jsonSpells;

                foreach (DataGridViewRow row in enemies.Rows)
                {
                    Target t = JsonGridHelper.createTarget(row);
                    script.enemies.Add(t);
                }

                foreach (DataGridViewRow row in create.Rows)
                {
                    CreateEventSave ev = JsonGridHelper.createCreateEventSave(row);
                    script.create.Add(ev);
                }

                foreach (DataGridViewRow row in shoot.Rows)
                {
                    ShootEvent ev = JsonGridHelper.createShootEvent(row);
                    script.shoot.Add(ev);
                }

                foreach (DataGridViewRow row in move.Rows)
                {
                    MoveEvent ev = JsonGridHelper.createMoveEvent(row);
                    script.move.Add(ev);
                }

                foreach(DataGridViewRow row in particleMove.Rows)
                {
                    ParticleMoveEvent ev = JsonGridHelper.createParticleMoveEvent(row);
                    script.particleMove.Add(ev);
                }

                string text = JsonConvert.SerializeObject(script, Formatting.Indented);
                File.WriteAllText(path, text, Encoding.UTF8);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
