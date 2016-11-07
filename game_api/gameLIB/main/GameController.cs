using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using gameLIB.components.characters;
using gameLIB.components.particles;
using gameLIB.main.engines;

namespace gameLIB.main
{
    public class GameController
    {
        private SoundEngine _soundEngine;
        private GameEngine _gameEngine;
        private GraphicEngine _graphicEngine;
        private Game _game;

        public enum GameState { PauseMenu, ScreenMenu, Stage };

        public void playSound(String soundName)
        {
            _soundEngine.playSound(soundName);
        }

        public void exit()
        {
            _game.Exit();
        }

        public void loadImage(String imageName, String texturePath, String alphaPath)
        {
            _graphicEngine.loadImage(imageName, texturePath, alphaPath);
        }

        public void createScreenMenu(Vector2 margin)
        {
            _graphicEngine.createScreenMenu(margin);
        }

        public void createPauseMenu(Vector2 margin)
        {
            _graphicEngine.createPauseMenu(margin);
        }

        public void createInGameBackground()
        {
            _graphicEngine.createInGameBackground();
        }

        public void createStage(List<string> scriptPaths)
        {
            _gameEngine.createStage(scriptPaths);
        }

        public void createPlayer(Rectangle[] imageParts, int lifes, Vector2 position, int nbFramesPerSprite, float scale)
        {
            _gameEngine.createPlayer(_graphicEngine.getImage(GameApi.LoadHelper.PLAYER_TEXTURE), imageParts, nbFramesPerSprite, scale, lifes, position);
        }

        public void createPlayerParticle(Vector2 particleOffset1, Vector2 particleOffset2, Rectangle[] parts, int damage, float speed, float scale)
        {
            _gameEngine.createPlayerParticle(particleOffset1, particleOffset2, damage,  _graphicEngine.getImage(GameApi.LoadHelper.MISSILE_TEXTURE), parts, speed, scale);
        }

        public void createParticle(String particleName, String imageName, Rectangle[] parts, float scale)
        {
            _gameEngine.createParticle(particleName, _graphicEngine.getImage(imageName), parts, scale);
        }

        public void createEnemy(String enemyType, String imageName, Rectangle[] imageParts, int nbFramesPerSprite, float scale)
        {
            _gameEngine.createEnemy(enemyType, _graphicEngine.getImage(imageName), imageParts, nbFramesPerSprite, scale);
        }

        public void loadImage(String imageName, String texturePath)
        {
            _graphicEngine.loadImage(imageName, texturePath, null);
        }

        public void loadSound(String soundName, String soundPath)
        {
            _soundEngine.loadSound(soundName, soundPath);
        }

        public void loadAlphaShader(String alphaShaderPath)
        {
            _graphicEngine.loadAlphaShader(alphaShaderPath);
        }

        public void loadEffect(String effectName, String effectPath)
        {
            _graphicEngine.loadEffect(effectName, effectPath);
        }

        public void loadFont(String fontName, String fontPath)
        {
            _graphicEngine.loadFont(fontName, fontPath);
        }

        public void dispose()
        {
            _graphicEngine.unloadContent();
            _soundEngine.unloadContent();
        }

        public GameController(Game game, ContentManager content, GraphicsDevice graphicsDevice)
        {
            _game = game;
            _gameEngine = new GameEngine(this);
            _graphicEngine = new GraphicEngine(content, graphicsDevice);
            _soundEngine = new SoundEngine(content);
        }

        public void update(GameTime gameTime)
        {
            switch (_gameEngine.state)
            {
                case GameEngine.GameState.ScreenMenu:
                case GameEngine.GameState.PauseMenu:
                    _gameEngine.runMenu();
                    break;
                case GameEngine.GameState.Stage:
                    _gameEngine.runStage(gameTime);
                    break;
            }
        }

        public void draw()
        {
            switch (_gameEngine.state)
            {
                case GameEngine.GameState.ScreenMenu:
                case GameEngine.GameState.PauseMenu :
                    _graphicEngine.drawMenu();
                    break;
                case GameEngine.GameState.Stage:
                    _graphicEngine.drawStage();
                    break;
            }
        }
    }
}

