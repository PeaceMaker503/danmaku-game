using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace gameLIB.main
{
    public class GameApi
    {
        private GameController _gameController;

        public sealed class LoadHelper {

            public static readonly string MISSILE_TEXTURE = "Missile";
            public static readonly string MENU_SELECT_SOUND = "MenuSelect";
            public static readonly string PLAYER_SHOOT_SOUND = "PlayerShoots";
            public static readonly string PLAYER_DIES_SOUND = "PlayerDies";
            public static readonly string ENEMY_DAMAGE_SOUND = "EnemyDamaged";
            public static readonly string BORDER_TEXTURE = "Border";
            public static readonly string BACKGROUND_TEXTURE = "Background";
            public static readonly string PLAYER_TEXTURE = "Player";
            public static readonly string TEXT_FONT = "TextFont";

        }

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

        public void createPauseMenu(Vector2 margin)
        {
            _gameController.createPauseMenu(margin);
        }

        public void createPlayer(Rectangle[] parts, int lifes, Vector2 position, int nbFrames, float scale)
        {
            _gameController.createPlayer(parts, lifes, position, nbFrames, scale);
        }
        
        public void createPlayerParticle(Vector2 offset1, Vector2 offset2, Rectangle[] parts, int damage, float speed, float scale)
        {
            _gameController.createPlayerParticle(offset1, offset2, parts, damage, speed, scale);
        }

        public void createPlayerParticle(Vector2 offset1, Vector2 offset2, Rectangle part, int damage, float speed, float scale)
        {
            _gameController.createPlayerParticle(offset1, offset2, new Rectangle[] { part }, damage, speed, scale);
        }

        public void createInGameBackground()
        {
            _gameController.createInGameBackground();
        }

        public void createScreenMenu(Vector2 margin)
        {
            _gameController.createScreenMenu(margin);
        }

        public void createEnemy(String typeName, String iname, Rectangle[] parts, int nbFrames, float scale)
        {
            _gameController.createEnemy(typeName, iname, parts, nbFrames, scale);
        }

        public void createStage(List<string> scriptPaths)
        {
            _gameController.createStage(scriptPaths);
        }

        public void createParticle(String pname, String iname, Rectangle[] parts, float scale)
        {
            _gameController.createParticle(pname, iname, parts, scale);
        }

        public void createParticle(String pname, String iname, Rectangle part, float scale)
        {
            _gameController.createParticle(pname, iname, new Rectangle[] { part }, scale);
        }

        public void loadImage(String name, String imagePath, String alphaPath)
        {
            _gameController.loadImage(name, imagePath, alphaPath);
        }

        public void loadImage(String name, String imagePath)
        {
            _gameController.loadImage(name, imagePath, null);
        }
    }
}
