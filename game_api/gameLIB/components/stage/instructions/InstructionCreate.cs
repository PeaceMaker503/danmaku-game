using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace gameLIB.components.stage.instructions
{
    public class InstructionCreate : Instruction
    {
        public int health { get; set; }
        public float speed { get; set; }
        public Vector2 position { get; set; }
        public Vector2 destination { get; set; }
        public Vector2 direction { get; set; }
        public Vector2 finishDirection { get; set; }
        public float finishSpeed { get; set; }


        public InstructionCreate(String _type, int _id, int _health, Vector2 _position, Vector2 _destination, Vector2 _direction, Vector2 _finishDirection, float _speed, float _finishSpeed)
            : base(_type, _id)
        {
            direction = _direction;
            health = _health;
            speed = _speed;
            position = _position;
            destination = _destination;
            finishDirection = _finishDirection;
            finishSpeed = _finishSpeed;
        }

        public override void run(Stage s)
        {
            s.instantiateEnemy(type, id, position, direction, destination, finishDirection, health, speed, finishSpeed);
        }
    }
}
