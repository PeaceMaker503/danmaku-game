using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

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

        public void instantiatePauseMenu(Vector2 margin)
        {
            _gameController.instantiatePauseMenu(LoadHelper.MENU_SELECT_SOUND, LoadHelper.BACKGROUND_TEXTURE, LoadHelper.TEXT_FONT, margin);
        }

        public void instantiatePlayer(Rectangle[] parts, int lifes, Vector2 position, int nbFrames, float scale)
        {
            _gameController.instantiatePlayer(LoadHelper.PLAYER_DIES_SOUND, LoadHelper.PLAYER_SHOOT_SOUND, LoadHelper.PLAYER_TEXTURE, parts, lifes, position, nbFrames, scale);
        }
        
        public void instantiatePlayerParticle(Vector2 offset1, Vector2 offset2, Rectangle[] parts, int damage, float speed, float scale)
        {
            _gameController.instantiatePlayerParticle(LoadHelper.MISSILE_TEXTURE, LoadHelper.MISSILE_TEXTURE, offset1, offset2, parts, damage, speed, scale);
        }

        public void instantiatePlayerParticle(Vector2 offset1, Vector2 offset2, Rectangle part, int damage, float speed, float scale)
        {
            _gameController.instantiatePlayerParticle(LoadHelper.MISSILE_TEXTURE, LoadHelper.MISSILE_TEXTURE, offset1, offset2, new Rectangle[] { part }, damage, speed, scale);
        }

        public void instantiateInGameBackground()
        {
            _gameController.instantiateInGameBackground(LoadHelper.BACKGROUND_TEXTURE, LoadHelper.BORDER_TEXTURE);
        }

        public void instantiateScreenMenu(Vector2 margin)
        {
            _gameController.instantiateScreenMenu(LoadHelper.MENU_SELECT_SOUND, LoadHelper.BACKGROUND_TEXTURE, LoadHelper.TEXT_FONT, margin);
        }

        public void instantiateEnemy(String typeName, String iname, Rectangle[] parts, int nbFrames, float scale)
        {
            _gameController.instantiateEnemy(typeName, LoadHelper.ENEMY_DAMAGE_SOUND, LoadHelper.ENEMY_DAMAGE_SOUND, iname, parts, nbFrames, scale);
        }

        public void instantiateStage(String path)
        {
            _gameController.instantiateStage(path);
        }

        public void instantiateEnemyParticle(String pname, String iname, Rectangle[] parts, float scale)
        {
            _gameController.instantiateEnemyParticle(pname, iname, parts, scale);
        }

        public void instantiateEnemyParticle(String pname, String iname, Rectangle part, float scale)
        {
            _gameController.instantiateEnemyParticle(pname, iname, new Rectangle[] { part }, scale);
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
