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
using System.CodeDom.Compiler;
using Newtonsoft.Json;
using gameLIB.components.stage.models;

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
                                    RaisePlaySound(GameApi.LoadHelper.MENU_SELECT_SOUND);
                                }
                                break;

                            case "Up":
                                if (_common.screenMenu.selected > (int)ScreenMenu.Options.Play && _common.screenMenu.selected <= (int)ScreenMenu.Options.Exit)
                                {
                                    _common.screenMenu.selected--;
                                    RaisePlaySound(GameApi.LoadHelper.MENU_SELECT_SOUND);
                                }
                                break;
                            case "Enter":
                                if (_common.screenMenu.selected == (int)ScreenMenu.Options.Play)
                                {
                                    RaisePlaySound(GameApi.LoadHelper.MENU_SELECT_SOUND);
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
                                    RaisePlaySound(GameApi.LoadHelper.MENU_SELECT_SOUND);
                                }
                                break;

                            case "Up":
                                if (_common.pauseMenu.selected > (int)PauseMenu.Options.Resume && _common.pauseMenu.selected <= (int)PauseMenu.Options.Exit)
                                {
                                    _common.pauseMenu.selected--;
                                    RaisePlaySound(GameApi.LoadHelper.MENU_SELECT_SOUND);
                                }
                                break;

                            case "Enter":
                                if (_common.pauseMenu.selected == (int)PauseMenu.Options.Resume)
                                {
                                    RaisePlaySound(GameApi.LoadHelper.MENU_SELECT_SOUND);
                                    state = GameState.Stage;
                                }
                                else if (_common.pauseMenu.selected == (int)PauseMenu.Options.Return)
                                {
                                    RaisePlaySound(GameApi.LoadHelper.MENU_SELECT_SOUND);
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
                                RaisePlaySound(GameApi.LoadHelper.MENU_SELECT_SOUND);
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
                            _common.currentStage.player.move(new Vector2(0, 8));
                            break;
                        case "ShiftDown":
                            _common.currentStage.player.move(new Vector2(0, 2));
                            break;
                        case "Up":
                            _common.currentStage.player.move(new Vector2(0, -8));
                            break;
                        case "ShiftUp":
                            _common.currentStage.player.move(new Vector2(0, -2));
                            break;
                        case "Right":
                            _common.currentStage.player.move(new Vector2(8, 0));
                            break;
                        case "ShiftRight":
                            _common.currentStage.player.move(new Vector2(2, 0));
                            break;
                        case "Left":
                            _common.currentStage.player.move(new Vector2(-8, 0));
                            break;
                        case "ShiftLeft":
                            _common.currentStage.player.move(new Vector2(-2, 0));
                            break;
                        case "Shoot":
                            RaisePlaySound(GameApi.LoadHelper.PLAYER_SHOOT_SOUND);
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

        public void createPlayer(Image image, Rectangle[] parts, int nbFrames, float scale, int lifes, Vector2 position)
        {
            _common.currentStage.player = new Player(image, position, parts, nbFrames, scale, lifes);
        }

        public void createPlayerParticle(Vector2 particleOffset1, Vector2 particleOffset2, int damage, Image image, Rectangle[] parts, float speed, float scale)
        {
            _common.currentStage.player.particleP1 = particleOffset1;
            _common.currentStage.player.particleP2 = particleOffset2;
            _common.currentStage.player.particleDamage = damage;
            createParticle(GameApi.LoadHelper.MISSILE_TEXTURE, image, parts, scale);
        }

        public void createParticle(String particleName, Image image, Rectangle[] parts, float scale)
        {
            Particle p = new Particle(image, parts, scale);
            _common.currentStage.addNewParticlePrototype(particleName, p);
        }

        public void createStage(List<string> scriptPaths)
        {
            List<string> referencedAssemblies = new List<string> { "gameLIB.dll", "System.dll", "Microsoft.Xna.Framework.dll" };
            foreach (string path in scriptPaths)
            {
                CompilerResults cp = CSharpCompiler.compileCSharp(path, referencedAssemblies);
                _common.currentStage.setScript(cp);
            }
        }

        public void createEnemy(String enemyName, Image image, Rectangle[] parts, int nbFrames, float scale)
        {
            Enemy e = new Enemy(image, parts, nbFrames, scale);
            _common.currentStage.addNewEnemyPrototype(enemyName, e);
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
            Dictionary<string, Dictionary<long, Particle>> result = new Dictionary<string, Dictionary<long, Particle>>();

            foreach (string key in _common.currentStage.particles.Keys)
            {
                IEnumerable<KeyValuePair<long, Particle>> particles = _common.currentStage.particles[key].Where(item => (!((item.Value.position.Y > 600) ||
                                                                                                                        (item.Value.position.Y < 0) ||
                                                                                                                        (item.Value.position.X > 600) ||
                                                                                                                        (item.Value.position.X < 0) ||
                                                                                                                        (item.Value.hit))));

                result[key] = particles.ToDictionary(item => item.Key, item => item.Value);
            }

            _common.currentStage.particles = result;

        }

        private void disposeEnemies()
        {
            Dictionary<string, Dictionary<long, Enemy>> result = new Dictionary<string, Dictionary<long, Enemy>>();

            foreach (string key in _common.currentStage.enemies.Keys)
            {
                IEnumerable<KeyValuePair<long, Enemy>> enemies = _common.currentStage.enemies[key].Where(item => !((item.Value.position.Y > GraphicEngine.WindowDimension.Height + 100) ||
                                                                                                                 (item.Value.position.Y < -500) ||
                                                                                                                 (item.Value.position.X > GraphicEngine.WindowDimension.Width + 100) ||
                                                                                                                 (item.Value.position.X < -500) ||
                                                                                                                 (!item.Value.isAlive)));

                result[key] = enemies.ToDictionary(item => item.Key, item => item.Value);
            }

            _common.currentStage.enemies = result;
           
        }

        private void controlCollisionEnemy() //proj player sur ennemi
        {
            foreach (string key in _common.currentStage.enemies.Keys)
            {
                foreach (Enemy enemy in _common.currentStage.enemies[key].Values)
                {
                    foreach (string key2 in _common.currentStage.particles.Keys)
                    {
                        foreach (Particle particle in _common.currentStage.particles[key2].Values)
                        {
                            if (particle.image.name.Equals(GameApi.LoadHelper.MISSILE_TEXTURE) &&
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
                                enemy.health -= (long)_common.currentStage.player.particleDamage;
                                if (enemy.health <= 0)
                                {
                                    enemy.isAlive = false;
                                    RaisePlaySound(GameApi.LoadHelper.ENEMY_DAMAGE_SOUND);
                                }
                                else
                                {
                                    RaisePlaySound(GameApi.LoadHelper.ENEMY_DAMAGE_SOUND);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void controlCollisionPlayer() //proj ennemi sur player + sa hitbox à lui sur player
        {
            if (_common.currentStage.player != null) //tour de boucle pour le draw

                foreach (string key in _common.currentStage.particles.Keys)
                {
                    foreach (Particle proj in _common.currentStage.particles[key].Values)
                    {
                        if (_common.currentStage.player.isAlive && Math.Abs(proj.position.X - _common.currentStage.player.position.X) < 5 && Math.Abs(proj.position.Y - _common.currentStage.player.position.Y) < 5)
                        {
                            _common.currentStage.player.lifes--;
                            _common.currentStage.player.isAlive = false;
                            RaisePlaySound(GameApi.LoadHelper.PLAYER_DIES_SOUND);
                        }
                    }
                }


            foreach (string key in _common.currentStage.enemies.Keys)
            {
                foreach (Enemy enemy in _common.currentStage.enemies[key].Values)
                {
                    if (_common.currentStage.player.isAlive && enemy.isAlive && Math.Abs(enemy.position.X - _common.currentStage.player.position.X) < 10 && Math.Abs(enemy.position.Y - _common.currentStage.player.position.Y) < 10)
                    {
                        _common.currentStage.player.lifes--;
                        _common.currentStage.player.isAlive = false;
                        RaisePlaySound(GameApi.LoadHelper.PLAYER_DIES_SOUND);
                    }
                }
            }
        }
    }
}
