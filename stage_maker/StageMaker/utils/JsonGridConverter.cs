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
        public static long importJson(DataGridView enemies, DataGridView shoot, DataGridView move, DataGridView particleMove, string path)
        {
            try
            {
                string text = File.ReadAllText(path);
                Script script = JsonConvert.DeserializeObject<Script>(text);
                long idEnemy = 0;
                enemies.Rows.Clear();
                shoot.Rows.Clear();
                move.Rows.Clear();

                foreach (CreateEvent ev in script.create)
                {
                    JsonGridHelper.insertEnemy(enemies, ev);
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

        public static string exportJson(DataGridView enemies, DataGridView shoot, DataGridView move, DataGridView particleMove, bool isIndented)
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
                    CreateEvent ev = JsonModelHelper.generateCreateEvent(row);
                    script.create.Add(ev);
                }
                
                foreach (DataGridViewRow row in shoot.Rows)
                {
                    ShootEvent ev = JsonModelHelper.generatecreateShootEvent(row);
                    script.shoot.Add(ev);
                }

                foreach (DataGridViewRow row in move.Rows)
                {
                    MoveEvent ev = JsonModelHelper.generateMoveEvent(row);
                    script.move.Add(ev);
                }

                foreach (DataGridViewRow row in particleMove.Rows)
                {
                    ParticleMoveEvent ev = JsonModelHelper.generateParticleMoveEvent(row);
                    script.particleMove.Add(ev);
                }

                string data;
                if (isIndented)
                    data = JsonConvert.SerializeObject(script, Formatting.Indented);
                else
                    data = JsonConvert.SerializeObject(script, Formatting.None);

                return data;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static string exportConfigJson(Dictionary<string, List<EnemyType>> enemyTypes, List<SpellLine> spells, bool isIndented)
        {
            try
            {
                Config config = new Config();
                config.enemyTypes = enemyTypes;
                config.spells = spells;

                string data;
                if (isIndented)
                    data  = JsonConvert.SerializeObject(config, Formatting.Indented);
                else
                    data = JsonConvert.SerializeObject(config, Formatting.None);

                return data;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
