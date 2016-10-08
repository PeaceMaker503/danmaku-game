using StageMaker.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static StageMaker.StageMaker;
using static StageMaker.utils.DataGridViewHelper;

namespace StageMaker.utils
{
    public class JsonGridHelper
    {
        public static void insertCreate(DataGridView create, CreateEvent ev)
        {
            object time = null;
            if (ev.time >= 0)
                time = new JsonFloat(ev.time);

            object targetId = null;
            if (ev.target.id >= 0)
                targetId = ev.target.id;

            create.Rows.Add(time, targetId);
        }

        public static void insertCreateSave(DataGridView create, CreateEventSave ev)
        {
            object time = null;
            if (ev.time >= 0)
                time = new JsonFloat(ev.time);

            object targetId = null;
            if (ev.targetId >= 0)
                targetId = ev.targetId;

            create.Rows.Add(time, targetId);
        }

        public static void insertParticleMove(DataGridView particleMove, ParticleMoveEvent ev)
        {
            object time = null;
            if (ev.time >= 0)
                time = new JsonFloat(ev.time);

            object particleId = null;
            if (ev.particleId >= 0)
                particleId = ev.particleId;

            object speed = null;
            if (!float.IsNaN(ev.speed))
                speed = new JsonFloat(ev.speed);

            particleMove.Rows.Add(time, particleId, ev.destination, ev.direction, speed);
        }

        public static void insertMove(DataGridView move, MoveEvent ev)
        {
            object time = null;
            if (ev.time >= 0)
                time = new JsonFloat(ev.time);

            object targetId = null;
            if (ev.targetId >= 0)
                targetId = ev.targetId;

            object speed = null;
            if (!float.IsNaN(ev.speed))
                speed = new JsonFloat(ev.speed);

            object fspeed = null;
            if (!float.IsNaN(ev.fspeed))
                fspeed = new JsonFloat(ev.fspeed);

            move.Rows.Add(time, targetId, ev.destination, ev.direction, speed, ev.fdirection, fspeed);
        }

        public static void insertShoot(DataGridView shoot, ShootEvent ev)
        {
            object time = null;
            if (ev.time >= 0)
                time = new JsonFloat(ev.time);

            object targetId = null;
            if (ev.targetId >= 0)
                targetId = ev.targetId;

            object speed = null;
            if (!float.IsNaN(ev.bullet.speed))
                speed = new JsonFloat(ev.bullet.speed);

            shoot.Rows.Add(time, ev.bullet.id, targetId, ev.bullet.position, ev.bullet.destination, ev.bullet.direction, speed, ev.bullet.type);
        }

        public static void insertEnemy(DataGridView enemies, Target target)
        {
            object health = null;
            if (target.health >= 0)
                health = target.health;

            object speed = null;
            if (!float.IsNaN(target.speed))
                speed = new JsonFloat(target.speed);

            object fspeed = null;
            if (!float.IsNaN(target.fspeed))
                fspeed = new JsonFloat(target.fspeed);

            enemies.Rows.Add(target.id, target.type, health, target.position, target.destination, target.direction, speed, target.fdirection, fspeed);
        }

        public static MoveEvent createMoveEvent(DataGridViewRow row)
        {
            MoveEvent ev = new MoveEvent();
            ev.time = parseCellValue<float>(row, MoveGridColumnsName.TIME);
            ev.targetId = parseCellValue<long>(row, MoveGridColumnsName.TARGET_ID);
            ev.destination = parseCellValue<string>(row, MoveGridColumnsName.DESTINATION);
            ev.direction = parseCellValue<string>(row, MoveGridColumnsName.DIRECTION);
            ev.speed = parseCellValue<float>(row, MoveGridColumnsName.SPEED);
            ev.fdirection = parseCellValue<string>(row, MoveGridColumnsName.FINAL_DIRECTION);
            ev.fspeed = parseCellValue<float>(row, MoveGridColumnsName.FINAL_SPEED);
            return ev;
        }

        public static ParticleMoveEvent createParticleMoveEvent(DataGridViewRow row)
        {
            ParticleMoveEvent ev = new ParticleMoveEvent();
            ev.time = parseCellValue<float>(row, ParticleMoveColumnsName.TIME);
            ev.particleId = parseCellValue<long>(row, ParticleMoveColumnsName.PARTICLE_ID);
            ev.destination = parseCellValue<string>(row, ParticleMoveColumnsName.DESTINATION);
            ev.direction = parseCellValue<string>(row, ParticleMoveColumnsName.DIRECTION);
            ev.speed = parseCellValue<float>(row, ParticleMoveColumnsName.SPEED);
            return ev;
        }

        public static ShootEvent createShootEvent(DataGridViewRow row)
        {
            ShootEvent ev = new ShootEvent();
            Bullet b = new Bullet();
            b.destination = parseCellValue<string>(row, ShootGridColumnsName.DESTINATION);
            b.direction = parseCellValue<string>(row, ShootGridColumnsName.DIRECTION);
            b.speed = parseCellValue<float>(row, ShootGridColumnsName.SPEED);
            b.id = parseCellValue<long>(row, ShootGridColumnsName.PARTICLE_ID);
            b.type = parseCellValue<string>(row, ShootGridColumnsName.PARTICLE_TYPE);
            b.position = parseCellValue<string>(row, ShootGridColumnsName.POSITION);
            ev.time = parseCellValue<float>(row, ShootGridColumnsName.TIME);
            ev.targetId = parseCellValue<long>(row, ShootGridColumnsName.TARGET_ID);
            ev.bullet = b;
            return ev;
        }

        public static CreateEvent createCreateEvent(DataGridViewRow row, Dictionary<long, Target> targets)
        {
            CreateEvent ev = new CreateEvent();
            long targetId = parseCellValue<long>(row, CreateGridColumnsName.TARGET_ID);

            ev.time = parseCellValue<float>(row, CreateGridColumnsName.TIME);
            ev.target = targets[targetId];

            return ev;
        }

        public static CreateEventSave createCreateEventSave(DataGridViewRow row)
        {
            CreateEventSave ev = new CreateEventSave();
            long targetId = parseCellValue<long>(row, CreateGridColumnsName.TARGET_ID);
            ev.time = parseCellValue<float>(row, CreateGridColumnsName.TIME);
            ev.targetId = targetId;

            return ev;
        }

        public static Target createTarget(DataGridViewRow row)
        {
            Target t = new Target();

            t.id = parseCellValue<long>(row, EnemiesGridColumnsName.ID);
            t.type = parseCellValue<string>(row, EnemiesGridColumnsName.TYPE);
            t.health = parseCellValue<long>(row, EnemiesGridColumnsName.HEALTH);
            t.position = parseCellValue<string>(row, EnemiesGridColumnsName.POSITION);
            t.destination = parseCellValue<string>(row, EnemiesGridColumnsName.DESTINATION);
            t.direction = parseCellValue<string>(row, EnemiesGridColumnsName.DIRECTION);
            t.speed = parseCellValue<float>(row, EnemiesGridColumnsName.SPEED);
            t.fdirection = parseCellValue<string>(row, EnemiesGridColumnsName.FINAL_DIRECTION);
            t.fspeed = parseCellValue<float>(row, EnemiesGridColumnsName.FINAL_SPEED);

            return t;
        }

        public static T parseCellValue<T>(DataGridViewRow row, string columnName) //abuse generics but w/e
        {
            object result = null;
            if (typeof(float) == typeof(T))
            {
                if (row.Cells[columnName].Value == null)
                {
                    result = float.NaN;
                }
                else
                {
                    result = ((JsonFloat)(row.Cells[columnName].Value)).f;
                }
            }
            else if (typeof(string) == typeof(T))
            {
                result = (string)row.Cells[columnName].Value;
            }
            else if (typeof(long) == typeof(T))
            {
                if (row.Cells[columnName].Value == null)
                {
                    result = (long)-1;
                }
                else
                {
                    result = (long)row.Cells[columnName].Value;
                }
            }

            return (T)result;
        }
    }
}
