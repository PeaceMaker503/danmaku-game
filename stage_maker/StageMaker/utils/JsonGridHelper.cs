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

        public static void insertEnemy(DataGridView enemies, CreateEvent ev)
        {
            object time = null;
            if (ev.time >= 0)
                time = new JsonFloat(ev.time);

            object health = null;
            if (ev.target.health >= 0)
                health = ev.target.health;

            object speed = null;
            if (!float.IsNaN(ev.target.speed))
                speed = new JsonFloat(ev.target.speed);

            object fspeed = null;
            if (!float.IsNaN(ev.target.fspeed))
                fspeed = new JsonFloat(ev.target.fspeed);

            enemies.Rows.Add(time, ev.target.type, health, ev.target.position, ev.target.destination, ev.target.direction, speed, ev.target.fdirection, fspeed);
        }

        public static T parseCellValue<T>(DataGridViewRow row, string columnName) //generics abuse but w/e
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
