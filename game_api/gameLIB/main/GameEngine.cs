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

namespace gameLIB.main
{
    public class GameEngine
    {
        public enum GameState { PauseMenu, ScreenMenu, Stage };
        private static GameState _state;
        private GameEventHandler _eventHandler;
        private bool _firstTimeStage;
        private delegate void PlaySoundHandler(String sound);
        private delegate void ExitHandler();
        private event PlaySoundHandler RaisePlaySound;
        private event ExitHandler RaiseExit;
        private CommonComponents _common;

        public GameEngine(GameController gameController, CommonComponents common)
        {
            _common = common;
            _eventHandler = new GameEventHandler(this);
            _firstTimeStage = true;
            RaisePlaySound = new PlaySoundHandler(gameController.playSound);
            RaiseExit = new ExitHandler(gameController.exit);
            _common.ScreenMenu = new ScreenMenu();
            _common.PauseMenu = new PauseMenu();
            _common.CurrentMenu = _common.ScreenMenu;
            _common.CurrentStage = new Stage();
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
                                if (_common.ScreenMenu.selected >= (int)ScreenMenu.Options.Play && _common.ScreenMenu.selected < (int)ScreenMenu.Options.Exit)
                                {
                                    _common.ScreenMenu.selected++;
                                    RaisePlaySound(_common.ScreenMenu.SelectSound);
                                }
                                break;

                            case "Up":
                                if (_common.ScreenMenu.selected > (int)ScreenMenu.Options.Play && _common.ScreenMenu.selected <= (int)ScreenMenu.Options.Exit)
                                {
                                    _common.ScreenMenu.selected--;
                                    RaisePlaySound(_common.ScreenMenu.SelectSound);
                                }
                                break;
                            case "Enter":
                                if (_common.ScreenMenu.selected == (int)ScreenMenu.Options.Play)
                                {
                                    RaisePlaySound(_common.ScreenMenu.SelectSound);
                                    State = GameState.Stage;
                                }
                                else if (_common.ScreenMenu.selected == (int)ScreenMenu.Options.Exit)
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
                                if (_common.PauseMenu.selected >= (int)PauseMenu.Options.Resume && _common.PauseMenu.selected < (int)PauseMenu.Options.Exit)
                                {
                                    _common.PauseMenu.selected++;
                                    RaisePlaySound(_common.PauseMenu.SelectSound);
                                }
                                break;

                            case "Up":
                                if (_common.PauseMenu.selected > (int)PauseMenu.Options.Resume && _common.PauseMenu.selected <= (int)PauseMenu.Options.Exit)
                                {
                                    _common.PauseMenu.selected--;
                                    RaisePlaySound(_common.PauseMenu.SelectSound);
                                }
                                break;

                            case "Enter":
                                if (_common.PauseMenu.selected == (int)PauseMenu.Options.Resume)
                                {
                                    RaisePlaySound(_common.PauseMenu.SelectSound);
                                    State = GameState.Stage;
                                }
                                else if (_common.PauseMenu.selected == (int)PauseMenu.Options.Return)
                                {
                                    RaisePlaySound(_common.PauseMenu.SelectSound);
                                    _common.CurrentMenu = _common.ScreenMenu;
                                    State = GameState.ScreenMenu;
                                    _firstTimeStage = true;
                                }
                                else if (_common.PauseMenu.selected == (int)PauseMenu.Options.Exit)
                                {
                                    RaiseExit();
                                }
                                break;

                            case "Pause":
                                RaisePlaySound(_common.PauseMenu.SelectSound);
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
                            _common.CurrentStage.Player.moveOf(new Vector2(0, 8));
                            break;
                        case "ShiftDown":
                            _common.CurrentStage.Player.moveOf(new Vector2(0, 2));
                            break;
                        case "Up":
                            _common.CurrentStage.Player.moveOf(new Vector2(0, -8));
                            break;
                        case "ShiftUp":
                            _common.CurrentStage.Player.moveOf(new Vector2(0, -2));
                            break;
                        case "Right":
                            _common.CurrentStage.Player.moveOf(new Vector2(8, 0));
                            break;
                        case "ShiftRight":
                            _common.CurrentStage.Player.moveOf(new Vector2(2, 0));
                            break;
                        case "Left":
                            _common.CurrentStage.Player.moveOf(new Vector2(-8, 0));
                            break;
                        case "ShiftLeft":
                            _common.CurrentStage.Player.moveOf(new Vector2(-2, 0));
                            break;
                        case "Shoot":
                            RaisePlaySound(_common.CurrentStage.Player.ShootSound);
                            _common.CurrentStage.playerShoot();
                            break;
                        case "Pause":
                            RaisePlaySound(_common.PauseMenu.SelectSound);
                            _common.CurrentMenu = _common.PauseMenu;
                            _common.CurrentMenu.initialize();
                            State = GameState.PauseMenu;
                            break;
                    }
                }
            }
        }

        public void runStage(GameTime gameTime)
        {
            _common.CurrentStage.Time += ((double)gameTime.ElapsedGameTime.Milliseconds) / 1000.0;
            if (_firstTimeStage == true)
            {
                _common.CurrentStage.initialize();
                _firstTimeStage = false;
            }
            _common.CurrentStage.run();
            _eventHandler.listenKeyDown(true);
            if (_common.CurrentStage.Player.lifes < 0)
            {
                State = GameState.ScreenMenu;
                _common.CurrentMenu = _common.ScreenMenu;
                _firstTimeStage = true;
            }
            _common.CurrentStage.updateParticlesPositions();
            _common.CurrentStage.updateEnemiesPositions();
        }

        public void createStageFrom(String scriptPath)
        {
            this.generateStageScript(scriptPath);
            StageMaker sm = new StageMaker(_common.CurrentStage, "stage.dat");
            sm.createStage();
            File.Delete("stage.dat");
        }

        private void generateStageScript(String scriptPath)
        {
            ProcessStartInfo ProcessInfo;
            Process process;

            using (FileStream fs = File.Create("launcher.bat"))
            {
                byte[] bytes = Encoding.ASCII.GetBytes("stage_compiler.exe < " + scriptPath);
                fs.Write(bytes, 0, bytes.Length);
            }

            ProcessInfo = new ProcessStartInfo("launcher.bat");
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = false;
            ProcessInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process = Process.Start(ProcessInfo);
            process.WaitForExit();
            File.Delete("launcher.bat");
        }
        public void createPlayerFrom(String soundPlayerDies, String soundPlayerShoot, Image image, Rectangle[] parts, int lifes, Vector2 position, int nbFrames, float scale)
        {
            _common.CurrentStage.Player = new Player(image, position, parts, lifes, nbFrames, scale);
            _common.CurrentStage.Player.DiesSound = soundPlayerDies;
            _common.CurrentStage.Player.ShootSound = soundPlayerShoot;
        }

        public void createPlayerParticleFrom(String particleName, Vector2 particleOffset1, Vector2 particleOffset2, Image particleImage, Rectangle[] parts, int damage, float speed, float scale)
        {
            _common.CurrentStage.Player.ParticleName = particleName;
            _common.CurrentStage.Player.ParticleImageName = particleImage.name;
            _common.CurrentStage.Player.ParticleOffset1 = particleOffset1;
            _common.CurrentStage.Player.ParticleOffset2 = particleOffset2;
            _common.CurrentStage.Player.ParticleDamage = damage;
            Particle m = new Particle(particleImage, parts, new Vector2(0, -1), speed, scale);
            _common.CurrentStage.addNewParticlePrototype(particleName, m);
        }

        public void createEnemyParticleFrom(String particleName, Image particleImage, Rectangle[] parts, float scale)
        {
            Particle p = new Particle(particleImage, parts, Vector2.Zero, 0, scale);
            _common.CurrentStage.addNewParticlePrototype(particleName, p);
        }

        public void createEnemyFrom(String enemyType, String enemyDiesSound, String enemyDamageSound, Image image, Rectangle[] parts, int nbFrames, float scale)
        {
            Enemy e = new Enemy(image, enemyDiesSound, enemyDamageSound, Vector2.Zero, parts, nbFrames, scale);
            _common.CurrentStage.addNewEnemyPrototype(enemyType, e);
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
           /* foreach (Enemy enemy in _common.CurrentStage.Enemies.Values)
            {
                /*this.controlCollisionPlayer(enemy);
                this.controlCollisionEnemy(enemy);
            }*/
        }

        private void disposeParticles()
        {
            if (_common.CurrentStage.Particles.Count > 0)
            {
                IEnumerable<KeyValuePair<String, Particle>> particlesToBeRemoved = _common.CurrentStage.Particles.Where(item => ((item.Value.position.Y > GraphicEngine.WindowDimension.Height + 100) ||
                                                                                                                                (item.Value.position.Y < -100) ||
                                                                                                                                (item.Value.position.X > GraphicEngine.WindowDimension.Width + 100) ||
                                                                                                                                (item.Value.position.X < -100) ||
                                                                                                                                (item.Value.Hit)));
                _common.CurrentStage.Particles = _common.CurrentStage.Particles.Where(item => !particlesToBeRemoved.Contains(item)).ToDictionary(item => item.Key, item => item.Value);
            }
        }

        private void disposeEnemies()
        {

            if (_common.CurrentStage.Enemies.Count > 0)
            {
                IEnumerable<KeyValuePair<String, Enemy>> enemiesToBeRemoved = _common.CurrentStage.Enemies.Where(item => ((item.Value.position.Y >  GraphicEngine.WindowDimension.Height +500) ||
                                                                                                                         (item.Value.position.Y < -500) ||
                                                                                                                         (item.Value.position.X > GraphicEngine.WindowDimension.Width + 500) ||
                                                                                                                         (item.Value.position.X < -500) ||
                                                                                                                         (!item.Value.isAlive)));
                _common.CurrentStage.Enemies = _common.CurrentStage.Enemies.Where(item => !enemiesToBeRemoved.Contains(item)).ToDictionary(item => item.Key, item => item.Value);
            }
        }

        private void controlCollisionEnemy() //proj player sur ennemi
        {
            if (_common.CurrentStage.Enemies.Count > 0 && _common.CurrentStage.Particles.Count > 0)
            {
                foreach (Enemy enemy in _common.CurrentStage.Enemies.Values)
                {
                    foreach (Particle particle in _common.CurrentStage.Particles.Values)
                    {
                        if (particle.image.name.Equals(_common.CurrentStage.Player.ParticleImageName) && 
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
                            enemy.health -= _common.CurrentStage.Player.ParticleDamage;
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
            if (_common.CurrentStage.Player != null && enemy != null) //tour de boucle pour le draw
            {
                foreach (Particle proj in enemy.particles.Values)
                {
                    if (_common.CurrentStage.Player.isAlive && Math.Abs(proj.position.X - _common.CurrentStage.Player.position.X) < 5 && Math.Abs(proj.position.Y - _common.CurrentStage.Player.position.Y) < 5)
                    {
                        _common.CurrentStage.Player.lifes--;
                        _common.CurrentStage.Player.isAlive = false;
                        //SoundEngine.playSound(PlayerDies);
                    }
                }
                if (_common.CurrentStage.Player.isAlive && enemy.isAlive && Math.Abs(enemy.position.X - _common.CurrentStage.Player.position.X) < 10 && Math.Abs(enemy.position.Y - _common.CurrentStage.Player.position.Y) < 10)
                {
                    _common.CurrentStage.Player.lifes--;
                    _common.CurrentStage.Player.isAlive = false;
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
