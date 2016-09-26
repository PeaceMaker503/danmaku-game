using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using gameLIB.components.characters;
using gameLIB.components.particles;

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

        public void instantiateScreenMenu(String soundSelectMenuName, String imageName, String fontName, Vector2 margin)
        {
            _graphicEngine.createScreenMenuFrom(imageName, soundSelectMenuName, fontName, margin);
        }

        public void instantiatePauseMenu(String soundSelectMenuName, String imageName, String fontName, Vector2 margin)
        {
            _graphicEngine.createPauseMenuFrom(imageName, soundSelectMenuName, fontName, margin);
        }

        public void instantiateInGameBackground(String imageNameBackground, String imageNameLimit)
        {
            _graphicEngine.createInGameBackgroundFrom(imageNameBackground, imageNameLimit);
        }

        public void instantiateStage(String scriptPath)
        {
            _gameEngine.createStageFrom(scriptPath);
        }

        public void instantiatePlayer(String soundPlayerDies, String soundShoot, String imageName, Rectangle[] imageParts, int lifes, Vector2 position, int nbFramesPerSprite, float scale)
        {
            _gameEngine.createPlayerFrom(soundPlayerDies, soundShoot, _graphicEngine.getImage(imageName), imageParts, lifes, position, nbFramesPerSprite, scale);
        }

        public void instantiatePlayerParticle(String particleName, String imageName,  Vector2 particleOffset1, Vector2 particleOffset2, Rectangle[] parts, int damage, float speed, float scale)
        {
            _gameEngine.createPlayerParticleFrom(particleName, particleOffset1, particleOffset2,  _graphicEngine.getImage(imageName), parts, damage, speed, scale);
        }

        public void instantiateEnemyParticle(String particleName, String imageName, Rectangle[] parts, float scale)
        {
            _gameEngine.createEnemyParticleFrom(particleName, _graphicEngine.getImage(imageName), parts, scale);
        }

        public void instantiateEnemy(String enemyType, String enemyDiesSound, String enemyDamageSound, String imageName, Rectangle[] imageParts, int nbFramesPerSprite, float scale)
        {
            _gameEngine.createEnemyFrom(enemyType, enemyDiesSound, enemyDamageSound, _graphicEngine.getImage(imageName), imageParts, nbFramesPerSprite, scale);
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
            CommonComponents common = new CommonComponents();
            _gameEngine = new GameEngine(this, common);
            _graphicEngine = new GraphicEngine(content, graphicsDevice, common);
            _soundEngine = new SoundEngine(content, common);
        }

        public void update(GameTime gameTime)
        {
            switch (_gameEngine.State)
            {
                case GameEngine.GameState.ScreenMenu:
                case GameEngine.GameState.PauseMenu:
                    _gameEngine.runMenu();
                    break;
                case GameEngine.GameState.Stage:
                    _gameEngine.disposeObjects();
                    _gameEngine.runStage(gameTime);
                    break;
            }
        }

        public void draw()
        {
            switch (_gameEngine.State)
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

