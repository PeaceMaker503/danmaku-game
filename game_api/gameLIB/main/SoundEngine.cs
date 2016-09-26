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

namespace gameLIB.main
{
    public class SoundEngine
    {
        private Dictionary<String ,SoundEffect> _sounds;
        private ContentManager _content;
        private CommonComponents _common;

        public SoundEngine(ContentManager content, CommonComponents common)
        {
            _content = content;
            _common = common;
            _sounds = new Dictionary<String, SoundEffect>();
        }

        public void loadSound(String soundName, String soundPath)
        {
            _sounds.Add(soundName, _content.Load<SoundEffect>(soundPath));
        }

        public SoundEffect getSound(String soundName)
        {
            return _sounds[soundName];
        }

        public void unloadContent()
        {
            _content.Unload();
        }

        public void loadContent()
        {
            //Activator.CreateInstance(t,17); // Incase you are calling a constructor of int type
            /*_sounds.Add("Select", _content.Load<SoundEffect>(@"sounds/menu/selectMenu"));
            _sounds.Add("PlayerDead", _content.Load<SoundEffect>(@"sounds/player/playerDead"));
            _sounds.Add("PlayerShoot", _content.Load<SoundEffect>(@"sounds/particle/playerShoot"));
            _sounds.Add("EnemyDamage", _content.Load<SoundEffect>(@"sounds/enemy/enemyDamage"));*/
        }

        public void playSound(String soundName)
        {
            _sounds[soundName].Play();
        }
    }
}
