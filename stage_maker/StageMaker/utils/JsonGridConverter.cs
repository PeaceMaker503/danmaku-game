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
        public static ulong importJson(DataGridView enemies, DataGridView create, DataGridView shoot, DataGridView move, string path)
        {
            try
            {
                string text = File.ReadAllText(path);
                Script script = JsonConvert.DeserializeObject<Script>(text);
                ulong idEnemy = 0;
                enemies.Rows.Clear();
                create.Rows.Clear();
                shoot.Rows.Clear();
                move.Rows.Clear();

                foreach (CreateEvent ev in script.create)
                {
                    enemies.Rows.Add(ev.target.id, ev.target.type, ev.target.health, ev.target.position, ev.target.destination, ev.target.direction, new JsonFloat(ev.target.speed), ev.target.fdirection, new JsonFloat(ev.target.fspeed));
                    create.Rows.Add(new JsonFloat(ev.time), ev.target.id);
                    idEnemy = Math.Max(idEnemy, ev.target.id);
                }
                idEnemy++;

                foreach (ShootEvent ev in script.shoot)
                {
                    shoot.Rows.Add(new JsonFloat(ev.time), ev.targetId, ev.bullet.id, ev.bullet.destination, ev.bullet.direction, new JsonFloat(ev.bullet.speed), ev.bullet.type);
                }

                foreach (MoveEvent ev in script.move)
                {
                    move.Rows.Add(new JsonFloat(ev.time), ev.targetId, ev.destination, ev.direction, new JsonFloat(ev.speed), ev.fdirection, new JsonFloat(ev.fspeed));
                }

                return idEnemy;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void exportJson(DataGridView enemies, DataGridView create, DataGridView shoot, DataGridView move, string path)
        {
            try
            {
                Script script = new Script();
                script.create = new List<CreateEvent>();
                script.shoot = new List<ShootEvent>();
                script.move = new List<MoveEvent>();
                Dictionary<ulong, Target> targets = new Dictionary<ulong, Target>();

                foreach (DataGridViewRow row in enemies.Rows)
                {
                    Target t = new Target();

                    t.id = (ulong)row.Cells[EnemiesGridColumnsName.ID].Value;
                    t.type = (string)row.Cells[EnemiesGridColumnsName.TYPE].Value;
                    t.health = (ulong)row.Cells[EnemiesGridColumnsName.HEALTH].Value;
                    t.position = (JsonVector2)row.Cells[EnemiesGridColumnsName.POSITION].Value;
                    t.destination = (JsonVector2)row.Cells[EnemiesGridColumnsName.DESTINATION].Value;
                    t.direction = (JsonVector2)row.Cells[EnemiesGridColumnsName.DIRECTION].Value;
                    t.speed = ((JsonFloat)(row.Cells[EnemiesGridColumnsName.SPEED].Value)).f;
                    t.fdirection = (JsonVector2)row.Cells[EnemiesGridColumnsName.FINAL_DIRECTION].Value;
                    t.fspeed = ((JsonFloat)(row.Cells[EnemiesGridColumnsName.FINAL_SPEED].Value)).f;

                    targets[t.id] = t;
                }
                
                foreach (DataGridViewRow row in create.Rows)
                {
                    CreateEvent ev = new CreateEvent();

                    ulong targetId = (ulong)row.Cells[CreateGridColumnsName.TARGET_ID].Value;
                    ev.time = ((JsonFloat)(row.Cells[CreateGridColumnsName.TIME].Value)).f;
                    ev.target = targets[targetId];

                    script.create.Add(ev);
                }

                foreach (DataGridViewRow row in shoot.Rows)
                {
                    ShootEvent ev = new ShootEvent();
                    Bullet b = new Bullet();
                    b.destination = (JsonVector2)row.Cells[ShootGridColumnsName.DESTINATION].Value;
                    b.direction = (JsonVector2)row.Cells[ShootGridColumnsName.DIRECTION].Value;
                    b.speed = ((JsonFloat)(row.Cells[ShootGridColumnsName.SPEED].Value)).f;
                    b.id = (ulong)row.Cells[ShootGridColumnsName.PARTICLE_ID].Value;
                    b.type = (string)row.Cells[ShootGridColumnsName.PARTICLE_TYPE].Value;

                    ev.time = ((JsonFloat)(row.Cells[ShootGridColumnsName.TIME].Value)).f;
                    ev.targetId = (ulong)row.Cells[ShootGridColumnsName.TARGET_ID].Value;
                    ev.bullet = b;

                    script.shoot.Add(ev);
                }

                foreach (DataGridViewRow row in move.Rows)
                {
                    MoveEvent ev = new MoveEvent();

                    ev.time = ((JsonFloat)(row.Cells[MoveGridColumnsName.TIME].Value)).f;
                    ev.targetId = (ulong)row.Cells[MoveGridColumnsName.TARGET_ID].Value;
                    ev.destination = (JsonVector2)row.Cells[MoveGridColumnsName.DESTINATION].Value;
                    ev.direction = (JsonVector2)row.Cells[MoveGridColumnsName.DIRECTION].Value;
                    ev.speed = ev.time = ((JsonFloat)(row.Cells[MoveGridColumnsName.SPEED].Value)).f;
                    ev.fdirection = (JsonVector2)row.Cells[MoveGridColumnsName.FINAL_DIRECTION].Value;
                    ev.fspeed = ((JsonFloat)(row.Cells[MoveGridColumnsName.FINAL_SPEED].Value)).f;
                    script.move.Add(ev);
                }

                string text = JsonConvert.SerializeObject(script, Formatting.Indented);
                File.WriteAllText(path, text, Encoding.UTF8);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static ulong openJson(DataGridView enemies, DataGridView create, DataGridView shoot, DataGridView move, string path)
        {
            try
            {
                string text = File.ReadAllText(path);
                ScriptSave script = JsonConvert.DeserializeObject<ScriptSave>(text);
                ulong idEnemy = 0;
                enemies.Rows.Clear();
                create.Rows.Clear();
                shoot.Rows.Clear();
                move.Rows.Clear();

                foreach (Target target in script.enemies)
                {
                    enemies.Rows.Add(target.id, target.type, target.health, target.position, target.destination, target.direction, new JsonFloat(target.speed), target.fdirection, new JsonFloat(target.fspeed));
                }

                foreach (CreateEventSave ev in script.create)
                {
                    create.Rows.Add(new JsonFloat(ev.time), ev.targetId);
                    idEnemy = Math.Max(idEnemy, ev.targetId);
                }
                idEnemy++;

                foreach (ShootEvent ev in script.shoot)
                {
                    shoot.Rows.Add(new JsonFloat(ev.time), ev.targetId, ev.bullet.id,ev.bullet.destination,  ev.bullet.direction, new JsonFloat(ev.bullet.speed), ev.bullet.type);
                }

                foreach (MoveEvent ev in script.move)
                {
                    move.Rows.Add(new JsonFloat(ev.time), ev.targetId, ev.destination, ev.direction, new JsonFloat(ev.speed), ev.fdirection, new JsonFloat(ev.fspeed));
                }

                return idEnemy;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void saveJson(DataGridView enemies, DataGridView create, DataGridView shoot, DataGridView move, string path)
        {
            try
            {
                ScriptSave script = new ScriptSave();
                script.enemies = new List<Target>();
                script.create = new List<CreateEventSave>();
                script.shoot = new List<ShootEvent>();
                script.move = new List<MoveEvent>();

                foreach (DataGridViewRow row in enemies.Rows)
                {
                    Target t = new Target();

                    t.id = (ulong)row.Cells[EnemiesGridColumnsName.ID].Value;
                    t.type = (string)row.Cells[EnemiesGridColumnsName.TYPE].Value;
                    t.health = (ulong)row.Cells[EnemiesGridColumnsName.HEALTH].Value;
                    t.position = (JsonVector2)row.Cells[EnemiesGridColumnsName.POSITION].Value;
                    t.destination = (JsonVector2)row.Cells[EnemiesGridColumnsName.DESTINATION].Value;
                    t.direction = (JsonVector2)row.Cells[EnemiesGridColumnsName.DIRECTION].Value;
                    t.speed = ((JsonFloat)(row.Cells[EnemiesGridColumnsName.SPEED].Value)).f;
                    t.fdirection = (JsonVector2)row.Cells[EnemiesGridColumnsName.FINAL_DIRECTION].Value;
                    t.fspeed = ((JsonFloat)(row.Cells[EnemiesGridColumnsName.FINAL_SPEED].Value)).f;

                    script.enemies.Add(t);
                }

                foreach (DataGridViewRow row in create.Rows)
                {
                    CreateEventSave ev = new CreateEventSave();

                    ulong targetId = (ulong)row.Cells[CreateGridColumnsName.TARGET_ID].Value;
                    ev.time = ((JsonFloat)(row.Cells[CreateGridColumnsName.TIME].Value)).f;
                    ev.targetId = targetId;
                    script.create.Add(ev);
                }

                foreach (DataGridViewRow row in shoot.Rows)
                {
                    ShootEvent ev = new ShootEvent();
                    Bullet b = new Bullet();
                    b.destination = (JsonVector2)row.Cells[ShootGridColumnsName.DESTINATION].Value;
                    b.direction = (JsonVector2)row.Cells[ShootGridColumnsName.DIRECTION].Value;
                    b.speed = ((JsonFloat)(row.Cells[ShootGridColumnsName.SPEED].Value)).f;
                    b.id = (ulong)row.Cells[ShootGridColumnsName.PARTICLE_ID].Value;
                    b.type = (string)row.Cells[ShootGridColumnsName.PARTICLE_TYPE].Value;

                    ev.time = ((JsonFloat)(row.Cells[ShootGridColumnsName.TIME].Value)).f;
                    ev.targetId = (ulong)row.Cells[ShootGridColumnsName.TARGET_ID].Value;
                    ev.bullet = b;

                    script.shoot.Add(ev);
                }

                foreach (DataGridViewRow row in move.Rows)
                {
                    MoveEvent ev = new MoveEvent();

                    ev.time = ((JsonFloat)(row.Cells[MoveGridColumnsName.TIME].Value)).f;
                    ev.targetId = (ulong)row.Cells[MoveGridColumnsName.TARGET_ID].Value;
                    ev.destination = (JsonVector2)row.Cells[MoveGridColumnsName.DESTINATION].Value;
                    ev.direction = (JsonVector2)row.Cells[MoveGridColumnsName.DIRECTION].Value;
                    ev.speed = ev.time = ((JsonFloat)(row.Cells[MoveGridColumnsName.SPEED].Value)).f;
                    ev.fdirection = (JsonVector2)row.Cells[MoveGridColumnsName.FINAL_DIRECTION].Value;
                    ev.fspeed = ((JsonFloat)(row.Cells[MoveGridColumnsName.FINAL_SPEED].Value)).f;

                    script.move.Add(ev);
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
