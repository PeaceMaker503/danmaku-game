using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using gameLIB.components.characters;
using gameLIB.components.particles;
using gameLIB.components.sprites;
using gameLIB.components.stage;
using gameLIB.components.gui;
using System.IO;
using System.Text;
using gameLIB.components.stage.parser;

namespace gameLIB.main.engines
{
    public class GameEngine
    {
        public enum GameState { PauseMenu, ScreenMenu, Stage };
        public GameState state { get; set; }
        private KeyboardEventEmitter _eventHandler;
        private bool _firstTimeStage;
        private delegate void PlaySoundHandler(String sound);
        private delegate void ExitHandler();
        private event PlaySoundHandler RaisePlaySound;
        private event ExitHandler RaiseExit;
        private CommonComponents _common;

        public GameEngine(GameController gameController)
        {
            _common = CommonComponents.getInstance();
            _eventHandler = new KeyboardEventEmitter(this);
            _firstTimeStage = true;
            RaisePlaySound = new PlaySoundHandler(gameController.playSound);
            RaiseExit = new ExitHandler(gameController.exit);
            _common.currentStage = new Stage();
            state = GameState.ScreenMenu;
        }

        public void runMenu()
        {
            _eventHandler.listenKeyDown(false); //listen key, not in game
        }

        public void updateGameState(String keyDown, bool inGame)
        {
            if (!inGame)
            {
                switch (state)
                {
                    case GameState.ScreenMenu:
                        switch (keyDown)
                        {
                            case "Down":
                                if (_common.screenMenu.selected >= (int)ScreenMenu.Options.Play && _common.screenMenu.selected < (int)ScreenMenu.Options.Exit)
                                {
                                    _common.screenMenu.selected++;
                                    RaisePlaySound(_common.screenMenu.selectSound);
                                }
                                break;

                            case "Up":
                                if (_common.screenMenu.selected > (int)ScreenMenu.Options.Play && _common.screenMenu.selected <= (int)ScreenMenu.Options.Exit)
                                {
                                    _common.screenMenu.selected--;
                                    RaisePlaySound(_common.screenMenu.selectSound);
                                }
                                break;
                            case "Enter":
                                if (_common.screenMenu.selected == (int)ScreenMenu.Options.Play)
                                {
                                    RaisePlaySound(_common.screenMenu.selectSound);
                                    state = GameState.Stage;
                                }
                                else if (_common.screenMenu.selected == (int)ScreenMenu.Options.Exit)
                                {
                                    RaiseExit();
                                }
                                break;
                        }
                        break;

                    case GameState.PauseMenu:
                        switch (keyDown)
                        {
                            case "Down":
                                if (_common.pauseMenu.selected >= (int)PauseMenu.Options.Resume && _common.pauseMenu.selected < (int)PauseMenu.Options.Exit)
                                {
                                    _common.pauseMenu.selected++;
                                    RaisePlaySound(_common.pauseMenu.selectSound);
                                }
                                break;

                            case "Up":
                                if (_common.pauseMenu.selected > (int)PauseMenu.Options.Resume && _common.pauseMenu.selected <= (int)PauseMenu.Options.Exit)
                                {
                                    _common.pauseMenu.selected--;
                                    RaisePlaySound(_common.pauseMenu.selectSound);
                                }
                                break;

                            case "Enter":
                                if (_common.pauseMenu.selected == (int)PauseMenu.Options.Resume)
                                {
                                    RaisePlaySound(_common.pauseMenu.selectSound);
                                    state = GameState.Stage;
                                }
                                else if (_common.pauseMenu.selected == (int)PauseMenu.Options.Return)
                                {
                                    RaisePlaySound(_common.pauseMenu.selectSound);
                                    _common.currentMenu = _common.screenMenu;
                                    state = GameState.ScreenMenu;
                                    _firstTimeStage = true;
                                }
                                else if (_common.pauseMenu.selected == (int)PauseMenu.Options.Exit)
                                {
                                    RaiseExit();
                                }
                                break;

                            case "Pause":
                                RaisePlaySound(_common.pauseMenu.selectSound);
                                state = GameState.Stage;
                                break;
                        }
                        break;
                }
            }
            else
            {
                if (state == GameState.Stage)
                {
                    switch (keyDown)
                    {
                        case "Down":
                            _common.currentStage.player.moveOf(new Vector2(0, 8));
                            break;
                        case "ShiftDown":
                            _common.currentStage.player.moveOf(new Vector2(0, 2));
                            break;
                        case "Up":
                            _common.currentStage.player.moveOf(new Vector2(0, -8));
                            break;
                        case "ShiftUp":
                            _common.currentStage.player.moveOf(new Vector2(0, -2));
                            break;
                        case "Right":
                            _common.currentStage.player.moveOf(new Vector2(8, 0));
                            break;
                        case "ShiftRight":
                            _common.currentStage.player.moveOf(new Vector2(2, 0));
                            break;
                        case "Left":
                            _common.currentStage.player.moveOf(new Vector2(-8, 0));
                            break;
                        case "ShiftLeft":
                            _common.currentStage.player.moveOf(new Vector2(-2, 0));
                            break;
                        case "Shoot":
                            RaisePlaySound(_common.currentStage.player.shootSound);
                            _common.currentStage.playerShoot();
                            break;
                        case "Pause":
                            RaisePlaySound(_common.pauseMenu.selectSound);
                            _common.currentMenu = _common.pauseMenu;
                            _common.currentMenu.initialize();
                            state = GameState.PauseMenu;
                            break;
                    }
                }
            }
        }

        public void runStage(GameTime gameTime)
        {
            this.disposeObjects();
            this.controlCollision();

            _common.currentStage.time += ((double)gameTime.ElapsedGameTime.Milliseconds) / 1000.0;
            if (_firstTimeStage == true)
            {
                _common.currentStage.initialize();
                _firstTimeStage = false;
            }
            _common.currentStage.run();
            _eventHandler.listenKeyDown(true);
            if (_common.currentStage.player.lifes < 0)
            {
                state = GameState.ScreenMenu;
                _common.currentMenu = _common.screenMenu;
                _firstTimeStage = true;
            }
            _common.currentStage.updateParticlesPositions();
            _common.currentStage.updateEnemiesPositions();
        }

        public void createStageFrom(String scriptPath)
        {
            StageMaker sm = new StageMaker(_common.currentStage, scriptPath);
            sm.createStage();
        }

        public void createPlayerFrom(String soundPlayerDies, String soundPlayerShoot, Image image, Rectangle[] parts, int lifes, Vector2 position, int nbFrames, float scale)
        {
            _common.currentStage.player = new Player(image, position, parts, lifes, nbFrames, scale, soundPlayerDies, soundPlayerShoot);
        }

        public void createPlayerParticleFrom(String particleName, Vector2 particleOffset1, Vector2 particleOffset2, Image particleImage, Rectangle[] parts, int damage, float speed, float scale)
        {
            _common.currentStage.player.particleName = particleName;
            _common.currentStage.player.particleImageName = particleImage.name;
            _common.currentStage.player.particleOffset1 = particleOffset1;
            _common.currentStage.player.particleOffset2 = particleOffset2;
            _common.currentStage.player.particleDamage = damage;
            Particle m = new Particle(particleImage, parts, new Vector2(0, -1), speed, scale);
            _common.currentStage.addNewParticlePrototype(particleName, m);
        }

        public void createEnemyParticleFrom(String particleName, Image particleImage, Rectangle[] parts, float scale)
        {
            Particle p = new Particle(particleImage, parts, Vector2.Zero, 0, scale);
            _common.currentStage.addNewParticlePrototype(particleName, p);
        }

        public void createEnemyFrom(String enemyType, String enemyDiesSound, String enemyDamageSound, Image image, Rectangle[] parts, int nbFrames, float scale)
        {
            Enemy e = new Enemy(image, enemyDiesSound, enemyDamageSound, Vector2.Zero, parts, nbFrames, scale);
            _common.currentStage.addNewEnemyPrototype(enemyType, e);
        }

        private String getName(Sprite sprite)
        {
            int n = sprite.GetType().ToString().LastIndexOf('.');
            String name = sprite.GetType().ToString().Substring(n + 1);
            return name;
        }

        private void disposeObjects()
        {
            this.disposeEnemies();
            this.disposeParticles();
        }

        private void controlCollision()
        {
            this.controlCollisionEnemy();
            this.controlCollisionPlayer();
        }

        private void disposeParticles()
        {
            if (_common.currentStage.particles.Count > 0)
            {
                IEnumerable<KeyValuePair<int, Particle>> particlesToBeRemoved = _common.currentStage.particles.Where(item => ((item.Value.position.Y > GraphicEngine.WindowDimension.Height + 100) ||
                                                                                                                                (item.Value.position.Y < -100) ||
                                                                                                                                (item.Value.position.X > GraphicEngine.WindowDimension.Width + 100) ||
                                                                                                                                (item.Value.position.X < -100) ||
                                                                                                                                (item.Value.hit)));
                _common.currentStage.particles = _common.currentStage.particles.Where(item => !particlesToBeRemoved.Contains(item)).ToDictionary(item => item.Key, item => item.Value);
            }
        }

        private void disposeEnemies()
        {

            if (_common.currentStage.enemies.Count > 0)
            {
                IEnumerable<KeyValuePair<int, Enemy>> enemiesToBeRemoved = _common.currentStage.enemies.Where(item => ((item.Value.position.Y >  GraphicEngine.WindowDimension.Height + 100) ||
                                                                                                                         (item.Value.position.Y < -500) ||
                                                                                                                         (item.Value.position.X > GraphicEngine.WindowDimension.Width + 100) ||
                                                                                                                         (item.Value.position.X < -500) ||
                                                                                                                         (!item.Value.isAlive)));
                _common.currentStage.enemies = _common.currentStage.enemies.Where(item => !enemiesToBeRemoved.Contains(item)).ToDictionary(item => item.Key, item => item.Value);
            }
        }

        private void controlCollisionEnemy() //proj player sur ennemi
        {
            if (_common.currentStage.enemies.Count > 0 && _common.currentStage.particles.Count > 0)
            {
                foreach (Enemy enemy in _common.currentStage.enemies.Values)
                {
                    foreach (Particle particle in _common.currentStage.particles.Values)
                    {
                        if (particle.image.name.Equals(_common.currentStage.player.particleImageName) && 
                            !particle.hit && 
                            enemy.isAlive &&
                            Math.Abs(particle.position.X - enemy.position.X) < 20 &&
                            Math.Abs(particle.position.Y - enemy.position.Y) < 20 &&
                            particle.position.Y < GraphicEngine.WindowDimension.Height - 10 &&
                            particle.position.X < GraphicEngine.WindowDimension.Width - 10 &&
                            particle.position.Y > -10 &&
                            particle.position.X > -10)
                        {
                            particle.hit = true;
                            enemy.health -= _common.currentStage.player.particleDamage;
                            if (enemy.health <= 0)
                            {
                                enemy.isAlive = false;
                                RaisePlaySound(enemy.enemyDiesSound);
                            }
                            else
                            {
                                RaisePlaySound(enemy.enemyDamageSound);
                            }
                        }
                    }
                }
            }
        }

        private void controlCollisionPlayer() //proj ennemi sur player + sa hitbox à lui sur player
        {
            if (_common.currentStage.player != null) //tour de boucle pour le draw
            
                if(_common.currentStage.particles.Values.Count > 0)
                {
                    foreach (Particle proj in _common.currentStage.particles.Values)
                    {
                        if (_common.currentStage.player.isAlive && Math.Abs(proj.position.X - _common.currentStage.player.position.X) < 5 && Math.Abs(proj.position.Y - _common.currentStage.player.position.Y) < 5)
                        {
                            _common.currentStage.player.lifes--;
                            _common.currentStage.player.isAlive = false;
                            string sound = _common.currentStage.player.diesSound;
                            RaisePlaySound(sound);
                        }
                    }
                }

            if (_common.currentStage.enemies.Values.Count > 0)
            {
                foreach (Enemy enemy in _common.currentStage.enemies.Values)
                {
                    if (_common.currentStage.player.isAlive && enemy.isAlive && Math.Abs(enemy.position.X - _common.currentStage.player.position.X) < 10 && Math.Abs(enemy.position.Y - _common.currentStage.player.position.Y) < 10)
                    {
                        _common.currentStage.player.lifes--;
                        _common.currentStage.player.isAlive = false;
                        RaisePlaySound(_common.currentStage.player.diesSound);
                    }
                }
            }
        }
    }
}
