using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StageMaker.utils
{
    public class DataGridViewHelper
    {
        public enum DataType { ID, FLOAT, VECTOR2, STRING };
        public static readonly long LONG_DEFAULT = (long)0;
        public static readonly string STRING_DEFAULT = "-";

        public sealed class EnemiesGridColumnsName
        {
            public static readonly string ID = "ID_ENEMIES";
            public static readonly string TYPE = "TYPE_ENEMIES";
            public static readonly string HEALTH = "HEALTH_ENEMIES";
            public static readonly string POSITION = "POSITION_ENEMIES";
            public static readonly string DESTINATION = "DESTINATION_ENEMIES";
            public static readonly string DIRECTION = "DIRECTION_ENEMIES";
            public static readonly string SPEED = "SPEED_ENEMIES";
            public static readonly string FINAL_DIRECTION = "FINAL_DIRECTION_ENEMIES";
            public static readonly string FINAL_SPEED = "FINAL_SPEED_ENEMIES";
        }

        public sealed class CreateGridColumnsName
        {
            public static readonly string TIME = "TIME_CREATE";
            public static readonly string TARGET_ID = "TARGET_ID_CREATE";
        }

        public sealed class ShootGridColumnsName
        {
            public static readonly string TIME = "TIME_SHOOT";
            public static readonly string TARGET_ID = "TARGET_ID_SHOOT";
            public static readonly string DESTINATION = "DESTINATION_SHOOT";
            public static readonly string DIRECTION = "DIRECTION_SHOOT";
            public static readonly string SPEED = "SPEED_SHOOT";
            public static readonly string PARTICLE_TYPE = "PARTICLE_TYPE_SHOOT";
            public static readonly string PARTICLE_ID = "PARTICLE_ID_SHOOT";
            public static readonly string POSITION = "POSITION_SHOOT";
        }

        public sealed class MoveGridColumnsName
        {
            public static readonly string TIME = "TIME_MOVE";
            public static readonly string TARGET_ID = "TARGET_ID_MOVE";
            public static readonly string DESTINATION = "DESTINATION_MOVE";
            public static readonly string DIRECTION = "DIRECTION_MOVE";
            public static readonly string SPEED = "SPEED_MOVE";
            public static readonly string FINAL_DIRECTION = "FINAL_DIRECTION_MOVE";
            public static readonly string FINAL_SPEED = "FINAL_SPEED_MOVE";
        }

        public sealed class ParticleMoveColumnsName
        {
            public static readonly string TIME = "TIME_PARTICLE";
            public static readonly string PARTICLE_ID = "PARTICLE_ID_PARTICLE";
            public static readonly string DESTINATION = "DESTINATION_PARTICLE";
            public static readonly string DIRECTION = "DIRECTION_PARTICLE";
            public static readonly string SPEED = "SPEED_PARTICLE";
        }

        public static readonly Dictionary<string, DataType> COLUMNS_TYPE = new Dictionary<string, DataType> {

            { EnemiesGridColumnsName.ID, DataType.ID },
            { EnemiesGridColumnsName.TYPE, DataType.STRING },
            { EnemiesGridColumnsName.HEALTH, DataType.ID },
            { EnemiesGridColumnsName.POSITION, DataType.VECTOR2 },
            { EnemiesGridColumnsName.DESTINATION, DataType.VECTOR2 },
            { EnemiesGridColumnsName.DIRECTION,  DataType.VECTOR2},
            { EnemiesGridColumnsName.SPEED, DataType.FLOAT },
            { EnemiesGridColumnsName.FINAL_DIRECTION, DataType.VECTOR2 },
            { EnemiesGridColumnsName.FINAL_SPEED, DataType.FLOAT },
            { CreateGridColumnsName.TIME, DataType.FLOAT },
            { CreateGridColumnsName.TARGET_ID, DataType.ID },
            { ShootGridColumnsName.TIME, DataType.FLOAT },
            { ShootGridColumnsName.TARGET_ID, DataType.ID },
            { ShootGridColumnsName.DESTINATION, DataType.VECTOR2 },
            { ShootGridColumnsName.DIRECTION, DataType.VECTOR2 },
            { ShootGridColumnsName.SPEED, DataType.FLOAT },
            { ShootGridColumnsName.PARTICLE_TYPE, DataType.STRING },
            { ShootGridColumnsName.PARTICLE_ID, DataType.ID },
            { ShootGridColumnsName.POSITION, DataType.VECTOR2 },
            { MoveGridColumnsName.TIME, DataType.FLOAT },
            { MoveGridColumnsName.TARGET_ID, DataType.ID },
            { MoveGridColumnsName.DESTINATION, DataType.VECTOR2 },
            { MoveGridColumnsName.DIRECTION, DataType.VECTOR2 },
            { MoveGridColumnsName.SPEED, DataType.FLOAT },
            { MoveGridColumnsName.FINAL_DIRECTION, DataType.VECTOR2 },
            { MoveGridColumnsName.FINAL_SPEED, DataType.FLOAT },
            { ParticleMoveColumnsName.TIME, DataType.FLOAT },
            { ParticleMoveColumnsName.PARTICLE_ID, DataType.ID },
            { ParticleMoveColumnsName.DESTINATION, DataType.VECTOR2 },
            { ParticleMoveColumnsName.DIRECTION, DataType.VECTOR2 },
            { ParticleMoveColumnsName.SPEED, DataType.FLOAT },

        };

        public static DataGridViewRow CloneRowWithValues(DataGridViewRow row)
        {
            DataGridViewRow clonedRow = (DataGridViewRow)row.Clone();
            for (Int32 index = 0; index < row.Cells.Count; index++)
            {
                clonedRow.Cells[index].Value = row.Cells[index].Value;
            }
            return clonedRow;
        }
    }
}
