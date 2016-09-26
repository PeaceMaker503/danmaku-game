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

namespace gameLIB.components.stage
{
    public class InstructionCreate : Instruction
    {
        private int _health;
        private float _speed;
        private Vector2 _position;
        private Vector2 _destination;
        private Vector2 _direction;
        private Vector2 _finishDirection;
        private float _finishSpeed;


        public InstructionCreate(String type, String id, int health, Vector2 position, Vector2 destination, Vector2 direction, Vector2 finishDirection, float speed, float finishSpeed)
            : base(type, id)
        {
            _direction = direction;
            _health = health;
            _speed = speed;
            _position = position;
            _destination = destination;
            _finishDirection = finishDirection;
            _finishSpeed = finishSpeed;
        }

        public override void run(Stage s)
        {
            s.instantiateEnemy(Type, Id, _position, _direction, _destination, _finishDirection, _health, _speed, _finishSpeed);
        }

        public int health
        {
            get { return _health; }
            set { _health = value;}
        }
        public Vector2 position
        {
            get { return _position; }
            set { _position = value; }
        }

        public float speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public float finishSpeed
        {
            get { return _finishSpeed; }
            set { _finishSpeed = value; }
        }

        public Vector2 destination
        {
            get { return _destination; }
            set { _destination = value; }
        }

        public Vector2 finishDirection
        {
            get { return _finishDirection; }
            set { _finishDirection = value; }
        }
    }
}
