using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace gameLIB.main
{
    public class API
    {
        private GameController _gameController;

        public int instantiateGameController(Game game, ContentManager content, GraphicsDevice graphicsDevice)
        {
            try
            {
                _gameController = new GameController(game, content, graphicsDevice);
            }
            catch(Exception)
            {
                return -1;
            }
            return 0;
        }

        public int dispose()
        {
            try
            {
                _gameController.dispose();
                _gameController = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            catch (Exception)
            {
                return -1;
            }
            return 0;
        }

        public void loadSound(String name, String path)
        {
            _gameController.loadSound(name, path);
        }

        public void update(GameTime gt)
        {
            _gameController.update(gt);
        }

        public void draw()
        {
            _gameController.draw();
        }

        public void loadFont(String name, String path)
        {
            _gameController.loadFont(name, path);
        }

        public void loadEffet(String name, String path)
        {
            _gameController.loadEffect(name, path);
        }

        public void loadAlphaShader(String path)
        {
            _gameController.loadAlphaShader(path);
        }

        public void instantiatePauseMenu(String sound, String background, String font, Vector2 margin)
        {
            _gameController.instantiatePauseMenu(sound, background, font, margin);
        }

        public void instantiatePlayer(String soundDies, String soundShoot, String iname, Rectangle[] parts, int lifes, Vector2 position, int nbFrames, float scale)
        {
            _gameController.instantiatePlayer(soundDies, soundShoot, iname, parts, lifes, position, nbFrames, scale);
        }
        
        public void instantiatePlayerParticle(String nameParticle, String iname, Vector2 offset1, Vector2 offset2, Rectangle[] parts, int damage, float speed, float scale)
        {
            _gameController.instantiatePlayerParticle(nameParticle, iname, offset1, offset2, parts, damage, speed, scale);
        }
        
        public void instantiateInGameBackground(String bname, String UIiname)
        {
            _gameController.instantiateInGameBackground(bname, UIiname);
        }

        public void instantiateScreenMenu(String sound, String background, String font, Vector2 margin)
        {
            _gameController.instantiateScreenMenu(sound, background, font, margin);
        }

        public void instantiateEnemy(String typeName, String dies, String damage, String iname, Rectangle[] parts, int nbFrames, float scale)
        {
            _gameController.instantiateEnemy(typeName, dies, damage, iname, parts, nbFrames, scale);
        }

        public void instantiateStage(String path)
        {
            _gameController.instantiateStage(path);
        }

        public void instantiateEnemyParticle(String pname, String iname, Rectangle[] parts, float scale)
        {
            _gameController.instantiateEnemyParticle(pname, iname, parts, scale);
        }
        
        public void loadImage(String name, String path, String path2)
        {
            _gameController.loadImage(name, path, path2);
        }
        
    }
}
