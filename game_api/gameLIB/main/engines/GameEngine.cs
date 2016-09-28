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
        private static GameState _state;
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
            _common.screenMenu = new ScreenMenu();
            _common.pauseMenu = new PauseMenu();
            _common.currentMenu = _common.screenMenu;
            _common.currentStage = new Stage();
            State = GameState.ScreenMenu;
        }

        public void runMenu()
        {
            _eventHandler.listenKeyDown(false); //listen key, not in game
        }

        public void updateGameState(String keyDown, bool inGame)
        {
            if (!inGame)
            {
                switch (State)
                {
                    case GameState.ScreenMenu:
                        switch (keyDown)
                        {
                            case "Down":
                                if (_common.screenMenu.selected >= (int)ScreenMenu.Options.Play && _common.screenMenu.selected < (int)ScreenMenu.Options.Exit)
                                {
                                    _common.screenMenu.selected++;
                                    RaisePlaySound(_common.screenMenu.SelectSound);
                                }
                                break;

                            case "Up":
                                if (_common.screenMenu.selected > (int)ScreenMenu.Options.Play && _common.screenMenu.selected <= (int)ScreenMenu.Options.Exit)
                                {
                                    _common.screenMenu.selected--;
                                    RaisePlaySound(_common.screenMenu.SelectSound);
                                }
                                break;
                            case "Enter":
                                if (_common.screenMenu.selected == (int)ScreenMenu.Options.Play)
                                {
                                    RaisePlaySound(_common.screenMenu.SelectSound);
                                    State = GameState.Stage;
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
                                    RaisePlaySound(_common.pauseMenu.SelectSound);
                                }
                                break;

                            case "Up":
                                if (_common.pauseMenu.selected > (int)PauseMenu.Options.Resume && _common.pauseMenu.selected <= (int)PauseMenu.Options.Exit)
                                {
                                    _common.pauseMenu.selected--;
                                    RaisePlaySound(_common.pauseMenu.SelectSound);
                                }
                                break;

                            case "Enter":
                                if (_common.pauseMenu.selected == (int)PauseMenu.Options.Resume)
                                {
                                    RaisePlaySound(_common.pauseMenu.SelectSound);
                                    State = GameState.Stage;
                                }
                                else if (_common.pauseMenu.selected == (int)PauseMenu.Options.Return)
                                {
                                    RaisePlaySound(_common.pauseMenu.SelectSound);
                                    _common.currentMenu = _common.screenMenu;
                                    State = GameState.ScreenMenu;
                                    _firstTimeStage = true;
                                }
                                else if (_common.pauseMenu.selected == (int)PauseMenu.Options.Exit)
                                {
                                    RaiseExit();
                                }
                                break;

                            case "Pause":
                                RaisePlaySound(_common.pauseMenu.SelectSound);
                                State = GameState.Stage;
                                break;
                        }
                        break;
                }
            }
            else
            {
                if (State == GameState.Stage)
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
                            RaisePlaySound(_common.currentStage.player.ShootSound);
                            _common.currentStage.playerShoot();
                            break;
                        case "Pause":
                            RaisePlaySound(_common.pauseMenu.SelectSound);
                            _common.currentMenu = _common.pauseMenu;
                            _common.currentMenu.initialize();
                            State = GameState.PauseMenu;
                            break;
                    }
                }
            }
        }

        public void runStage(GameTime gameTime)
        {
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
                State = GameState.ScreenMenu;
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
            _common.currentStage.player = new Player(image, position, parts, lifes, nbFrames, scale);
            _common.currentStage.player.DiesSound = soundPlayerDies;
            _common.currentStage.player.ShootSound = soundPlayerShoot;
        }

        public void createPlayerParticleFrom(String particleName, Vector2 particleOffset1, Vector2 particleOffset2, Image particleImage, Rectangle[] parts, int damage, float speed, float scale)
        {
            _common.currentStage.player.ParticleName = particleName;
            _common.currentStage.player.ParticleImageName = particleImage.name;
            _common.currentStage.player.ParticleOffset1 = particleOffset1;
            _common.currentStage.player.ParticleOffset2 = particleOffset2;
            _common.currentStage.player.ParticleDamage = damage;
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

        public void disposeObjects()
        {
            this.disposeEnemies();
            this.disposeParticles();
            this.controlCollisionEnemy();
           /* foreach (Enemy enemy in _common.currentStage.Enemies.Values)
            {
                /*this.controlCollisionPlayer(enemy);
                this.controlCollisionEnemy(enemy);
            }*/
        }

        private void disposeParticles()
        {
            if (_common.currentStage.particles.Count > 0)
            {
                IEnumerable<KeyValuePair<int, Particle>> particlesToBeRemoved = _common.currentStage.particles.Where(item => ((item.Value.position.Y > GraphicEngine.WindowDimension.Height + 100) ||
                                                                                                                                (item.Value.position.Y < -100) ||
                                                                                                                                (item.Value.position.X > GraphicEngine.WindowDimension.Width + 100) ||
                                                                                                                                (item.Value.position.X < -100) ||
                                                                                                                                (item.Value.Hit)));
                _common.currentStage.particles = _common.currentStage.particles.Where(item => !particlesToBeRemoved.Contains(item)).ToDictionary(item => item.Key, item => item.Value);
            }
        }

        private void disposeEnemies()
        {

            if (_common.currentStage.enemies.Count > 0)
            {
                IEnumerable<KeyValuePair<int, Enemy>> enemiesToBeRemoved = _common.currentStage.enemies.Where(item => ((item.Value.position.Y >  GraphicEngine.WindowDimension.Height +500) ||
                                                                                                                         (item.Value.position.Y < -500) ||
                                                                                                                         (item.Value.position.X > GraphicEngine.WindowDimension.Width + 500) ||
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
                        if (particle.image.name.Equals(_common.currentStage.player.ParticleImageName) && 
                            !particle.Hit && 
                            enemy.isAlive &&
                            Math.Abs(particle.position.X - enemy.position.X) < 20 &&
                            Math.Abs(particle.position.Y - enemy.position.Y) < 20 &&
                            particle.position.Y < GraphicEngine.WindowDimension.Height - 10 &&
                            particle.position.X < GraphicEngine.WindowDimension.Width - 10 &&
                            particle.position.Y > -10 &&
                            particle.position.X > -10)
                        {
                            particle.Hit = true;
                            enemy.health -= _common.currentStage.player.ParticleDamage;
                            if (enemy.health <= 0)
                            {
                                enemy.isAlive = false;
                                RaisePlaySound(enemy.EnemyDiesSound);
                            }
                            else
                            {
                                RaisePlaySound(enemy.EnemyDamageSound);
                            }
                        }
                    }
                }
            }
        }

       /* private void controlCollisionPlayer(Character enemy) //proj ennemi sur player + sa hitbox à lui sur player
        {
            if (_common.currentStage.Player != null && enemy != null) //tour de boucle pour le draw
            {
                foreach (Particle proj in enemy.particles.Values)
                {
                    if (_common.currentStage.Player.isAlive && Math.Abs(proj.position.X - _common.currentStage.Player.position.X) < 5 && Math.Abs(proj.position.Y - _common.currentStage.Player.position.Y) < 5)
                    {
                        _common.currentStage.Player.lifes--;
                        _common.currentStage.Player.isAlive = false;
                        //SoundEngine.playSound(PlayerDies);
                    }
                }
                if (_common.currentStage.Player.isAlive && enemy.isAlive && Math.Abs(enemy.position.X - _common.currentStage.Player.position.X) < 10 && Math.Abs(enemy.position.Y - _common.currentStage.Player.position.Y) < 10)
                {
                    _common.currentStage.Player.lifes--;
                    _common.currentStage.Player.isAlive = false;
                    //SoundEngine.playSound(PlayerDies);
                }
            }
        }*/

        public GameState State
        {
            get
            {
                return _state;
            }

            set
            {
                _state = value;
            }
        }
    }
}
