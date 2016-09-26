using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using gameLIB.main;
using System.Reflection;

namespace PeaceGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        API api;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            this.Window.AllowUserResizing = true;
            this.graphics.PreferredBackBufferWidth = 800;
            this.graphics.PreferredBackBufferHeight = 600;
           // this.graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            api = new API();
            api.instantiateGameController(this, Content, GraphicsDevice);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            Rectangle[] playerSpritesParts = new Rectangle[] {
                                                                 new Rectangle(1, 1, 31, 47),
                                                                 new Rectangle(33, 1, 31, 47),
                                                                 new Rectangle(65, 1, 31, 47),
                                                                 new Rectangle(97, 1, 31, 47)
                                                             };

            Rectangle[] fairiesParts = new Rectangle[] {
                                                                  new Rectangle(1, 1, 30, 30),
                                                                  new Rectangle(33, 1, 30, 30),
                                                                  new Rectangle(65, 1, 30, 30),
                                                                  new Rectangle(97, 1, 30, 30)
                                                              };

            api.loadSound("Select", @"sounds\menu\selectMenu");
            api.loadSound("PlayerShoot", @"sounds\particle\playerShoot");
            api.loadSound("PlayerDies", @"sounds\player\playerDead");
            api.loadSound("EnemyDamage", @"sounds\enemy\enemyDamage");
            api.loadImage("Black", @"images\background\black", null);
            api.loadImage("MoonBackground", @"images\menu\menuBackground", null);
            api.loadImage("Player", @"images\player\player00", @"images\player\player00_a");
            api.loadImage("Missile", @"images\player\player00", @"images\player\player00_a");
            api.loadImage("Bullets", @"images\particles\etama3", @"images\particles\etama3_a");
            api.loadImage("Stage1Enm", @"images\enemy\stg1enm", @"images\enemy\stg1enm_a");
            api.loadImage("Stage1Enm2", @"images\enemy\stg1enm2", @"images\enemy\stg1enm2_a");
            api.loadFont("MyFont", @"spritefonts\menuFont");
            api.loadAlphaShader(@"alpha\AlphaMap");
            api.instantiateScreenMenu("Select", "MoonBackground", "MyFont", new Vector2(200,200));
            api.instantiatePauseMenu("Select", "MoonBackground", "MyFont", new Vector2(200, 200));
            api.instantiateInGameBackground("MoonBackground", "Black");
            api.instantiatePlayer("PlayerDies", "PlayerShoot","Player", playerSpritesParts,  100, new Vector2(300, 200), 4, 1f);
            api.instantiatePlayerParticle("PlayerParticle", "Missile", new Vector2(-9,-15), new Vector2(6,-15), new Rectangle[1] { new Rectangle(197, 0, 8, 47) }, 20, 15f, 1f);
            api.instantiateEnemyParticle("GrayKnife", "Bullets", new Rectangle[] { new Rectangle(0, 160, 32, 32) }, 1.25f);
            api.instantiateEnemyParticle("RedKnife", "Bullets", new Rectangle[] { new Rectangle(32, 160, 32, 32) }, 1.25f);
            api.instantiateEnemyParticle("PinkKnife", "Bullets", new Rectangle[] { new Rectangle(64, 160, 32, 32) }, 1.25f);
            api.instantiateEnemyParticle("BlueKnife", "Bullets", new Rectangle[] { new Rectangle(96, 160, 32, 32) }, 1.25f);
            api.instantiateEnemyParticle("TurquoiseKnife", "Bullets", new Rectangle[] { new Rectangle(128, 160, 32, 32) }, 1.25f);
            api.instantiateEnemyParticle("GreenKnife", "Bullets", new Rectangle[] { new Rectangle(160, 160, 32, 32) }, 1.25f);
            api.instantiateEnemyParticle("YellowKnife", "Bullets", new Rectangle[] { new Rectangle(192, 160, 32, 32) }, 1.25f);
            api.instantiateEnemyParticle("WhiteKnife", "Bullets", new Rectangle[] { new Rectangle(224, 160, 32, 32) }, 1.25f);
            api.instantiateEnemy("Fairies", "Select", "EnemyDamage", "Stage1Enm", fairiesParts, 4, 1.25f);
            api.instantiateStage(@"scriptStage.txt");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            api.dispose();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                this.Exit();
            }
            api.update(gameTime);
            base.Update(gameTime);

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);
            api.draw();
            base.Draw(gameTime);
        }
    }
}
