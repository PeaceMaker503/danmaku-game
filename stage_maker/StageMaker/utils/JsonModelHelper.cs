using StageMaker.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static StageMaker.utils.DataGridViewHelper;

namespace StageMaker.utils
{
    class JsonModelHelper
    {
        public static MoveEvent createMoveEvent(DataGridViewRow row)
        {
            MoveEvent ev = new MoveEvent();
            ev.time = JsonGridHelper.parseCellValue<float>(row, MoveGridColumnsName.TIME);
            ev.targetId = JsonGridHelper.parseCellValue<long>(row, MoveGridColumnsName.TARGET_ID);
            ev.destination = JsonGridHelper.parseCellValue<string>(row, MoveGridColumnsName.DESTINATION);
            ev.direction = JsonGridHelper.parseCellValue<string>(row, MoveGridColumnsName.DIRECTION);
            ev.speed = JsonGridHelper.parseCellValue<float>(row, MoveGridColumnsName.SPEED);
            ev.fdirection = JsonGridHelper.parseCellValue<string>(row, MoveGridColumnsName.FINAL_DIRECTION);
            ev.fspeed = JsonGridHelper.parseCellValue<float>(row, MoveGridColumnsName.FINAL_SPEED);
            return ev;
        }

        public static ParticleMoveEvent createParticleMoveEvent(DataGridViewRow row)
        {
            ParticleMoveEvent ev = new ParticleMoveEvent();
            ev.time = JsonGridHelper.parseCellValue<float>(row, ParticleMoveColumnsName.TIME);
            ev.particleId = JsonGridHelper.parseCellValue<long>(row, ParticleMoveColumnsName.PARTICLE_ID);
            ev.destination = JsonGridHelper.parseCellValue<string>(row, ParticleMoveColumnsName.DESTINATION);
            ev.direction = JsonGridHelper.parseCellValue<string>(row, ParticleMoveColumnsName.DIRECTION);
            ev.speed = JsonGridHelper.parseCellValue<float>(row, ParticleMoveColumnsName.SPEED);
            return ev;
        }

        public static ShootEvent createShootEvent(DataGridViewRow row)
        {
            ShootEvent ev = new ShootEvent();
            Bullet b = new Bullet();
            b.destination = JsonGridHelper.parseCellValue<string>(row, ShootGridColumnsName.DESTINATION);
            b.direction = JsonGridHelper.parseCellValue<string>(row, ShootGridColumnsName.DIRECTION);
            b.speed = JsonGridHelper.parseCellValue<float>(row, ShootGridColumnsName.SPEED);
            b.id = JsonGridHelper.parseCellValue<long>(row, ShootGridColumnsName.PARTICLE_ID);
            b.type = JsonGridHelper.parseCellValue<string>(row, ShootGridColumnsName.PARTICLE_TYPE);
            b.position = JsonGridHelper.parseCellValue<string>(row, ShootGridColumnsName.POSITION);
            ev.time = JsonGridHelper.parseCellValue<float>(row, ShootGridColumnsName.TIME);
            ev.targetId = JsonGridHelper.parseCellValue<long>(row, ShootGridColumnsName.TARGET_ID);
            ev.bullet = b;
            return ev;
        }

        public static CreateEvent createCreateEvent(DataGridViewRow row, Dictionary<long, Target> targets)
        {
            CreateEvent ev = new CreateEvent();
            long targetId = JsonGridHelper.parseCellValue<long>(row, CreateGridColumnsName.TARGET_ID);

            ev.time = JsonGridHelper.parseCellValue<float>(row, CreateGridColumnsName.TIME);
            ev.target = targets[targetId];

            return ev;
        }

        public static CreateEventSave createCreateEventSave(DataGridViewRow row)
        {
            CreateEventSave ev = new CreateEventSave();
            long targetId = JsonGridHelper.parseCellValue<long>(row, CreateGridColumnsName.TARGET_ID);
            ev.time = JsonGridHelper.parseCellValue<float>(row, CreateGridColumnsName.TIME);
            ev.targetId = targetId;

            return ev;
        }

        public static Target createTarget(DataGridViewRow row)
        {
            Target t = new Target();

            t.id = JsonGridHelper.parseCellValue<long>(row, EnemiesGridColumnsName.ID);
            t.type = JsonGridHelper.parseCellValue<string>(row, EnemiesGridColumnsName.TYPE);
            t.health = JsonGridHelper.parseCellValue<long>(row, EnemiesGridColumnsName.HEALTH);
            t.position = JsonGridHelper.parseCellValue<string>(row, EnemiesGridColumnsName.POSITION);
            t.destination = JsonGridHelper.parseCellValue<string>(row, EnemiesGridColumnsName.DESTINATION);
            t.direction = JsonGridHelper.parseCellValue<string>(row, EnemiesGridColumnsName.DIRECTION);
            t.speed = JsonGridHelper.parseCellValue<float>(row, EnemiesGridColumnsName.SPEED);
            t.fdirection = JsonGridHelper.parseCellValue<string>(row, EnemiesGridColumnsName.FINAL_DIRECTION);
            t.fspeed = JsonGridHelper.parseCellValue<float>(row, EnemiesGridColumnsName.FINAL_SPEED);

            return t;
        }
    }
}
