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
        public static MoveEvent generateMoveEvent(DataGridViewRow row)
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

        public static ParticleMoveEvent generateParticleMoveEvent(DataGridViewRow row)
        {
            ParticleMoveEvent ev = new ParticleMoveEvent();
            ev.time = JsonGridHelper.parseCellValue<float>(row, ParticleMoveColumnsName.TIME);
            ev.particleId = JsonGridHelper.parseCellValue<long>(row, ParticleMoveColumnsName.PARTICLE_ID);
            ev.position = JsonGridHelper.parseCellValue<string>(row, ParticleMoveColumnsName.POSITION);
            ev.destination = JsonGridHelper.parseCellValue<string>(row, ParticleMoveColumnsName.DESTINATION);
            ev.direction = JsonGridHelper.parseCellValue<string>(row, ParticleMoveColumnsName.DIRECTION);
            ev.speed = JsonGridHelper.parseCellValue<float>(row, ParticleMoveColumnsName.SPEED);
            return ev;
        }

        public static ShootEvent generatecreateShootEvent(DataGridViewRow row)
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

        public static CreateEvent generateCreateEvent(DataGridViewRow row)
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

            CreateEvent ev = new CreateEvent();
            ev.time = JsonGridHelper.parseCellValue<float>(row, EnemiesGridColumnsName.TIME);
            ev.target = t;

            return ev;
        }
    }
}
