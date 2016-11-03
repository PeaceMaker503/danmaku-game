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
        public Game1(string scriptData) : this()
        {
            this.scriptData = scriptData;
        }

        GraphicsDeviceManager graphics;
        GameApi api;
        string scriptData;

        readonly Rectangle[] PLAYER_PARTS = new Rectangle[] {
                                                    new Rectangle(1, 1, 31, 47),
                                                    new Rectangle(33, 1, 31, 47),
                                                    new Rectangle(65, 1, 31, 47),
                                                    new Rectangle(97, 1, 31, 47)
        };

        readonly Rectangle[] FAIRIES_PARTS = new Rectangle[] {
                                                        new Rectangle(1, 1, 30, 30),
                                                        new Rectangle(33, 1, 30, 30),
                                                        new Rectangle(65, 1, 30, 30),
                                                        new Rectangle(97, 1, 30, 30)
        };
        readonly int WINDOW_WIDTH = 800;
        readonly int WINDOW_HEIGHT = 600;
        readonly bool IS_FULLSCREEN = false;
        readonly bool ALLOW_RESIZING = true;
        readonly int FAIRIES_FRAMES_IMAGE_COUNT = 4;
        readonly string MENU_SELECT_SOUND = @"sounds\menu\selectMenu";
        readonly string PLAYER_SHOOT_SOUND = @"sounds\particle\playerShoot";
        readonly string PLAYER_DEAD_SOUND = @"sounds\player\playerDead";
        readonly string ENEMY_DAMAGE_SOUND = @"sounds\enemy\enemyDamage";
        readonly string BORDER_TEXTURE = @"images\background\black";
        readonly string BACKGROUND_TEXTURE = @"images\menu\menuBackground";
        readonly string PLAYER_TEXTURE = @"images\player\player00";
        readonly string PLAYER_TEXTURE_ALPHA = @"images\player\player00_a";
        readonly string MISSILE_TEXTURE = @"images\player\player00";
        readonly string MISSILE_TEXTURE_ALPHA = @"images\player\player00_a";
        readonly string TEXT_FONT = @"spritefonts\menuFont";
        readonly string BULLETS_TEXTURE = @"images\particles\etama3";
        readonly string BULLETS_TEXTURE_ALPHA = @"images\particles\etama3_a";
        readonly string STAGE1_ENM_TEXTURE = @"images\enemy\stg1enm";
        readonly string STAGE1_ENM_TEXTURE_ALPHA = @"images\enemy\stg1enm_a";
        readonly string STAGE1_ENM2_TEXTURE = @"images\enemy\stg1enm2";
        readonly string STAGE1_ENM2_TEXUTURE_ALPHA = @"images\enemy\stg1enm2_a";
        readonly string ALPHA_SHADER = @"alpha\AlphaMap";
        readonly string BULLETS = "BULLETS";
        readonly string STAGE1_ENM = "STAGE1_ENM";
        readonly string STAGE1_ENM2 = "STAGE1_ENM2";
        readonly string GRAY_KNIFE = "GRAY_KNIFE";
        readonly string RED_KNIFE = "RED_KNIFE";
        readonly string PINK_KNIFE = "PINK_KNIFE";
        readonly string BLUE_KNIFE = "BLUE_KNIFE";
        readonly string TURQUOISE_KNIFE = "TURQUOISE_KNIFE";
        readonly string GREEN_KNIFE = "GREEN_KNIFE";
        readonly string YELLOW_KNIFE = "YELLOW_KNIFE";
        readonly string WHITE_KNIFE = "WHITE_KNIFE";
        readonly string FAIRIES = "FAIRIES";
        readonly int PLAYER_LIFES_COUNT = 100;
        readonly int PLAYER_FRAMES_IMAGE_COUNT = 4;
        readonly float PLAYER_IMAGE_SCALE = 1f;
        readonly float FAIRIES_SCALE = 1.5f;
        readonly Vector2 PLAYER_INITIAL_POSITION = new Vector2(300, 200);
        readonly Vector2 PLAYER_LEFT_PARTICLE_POSITION = new Vector2(-9, -15);
        readonly Vector2 PLAYER_RIGHT_PARTICLE_POSITION = new Vector2(6, -15);
        readonly Rectangle PLAYER_PARTICLE_PART = new Rectangle(197, 0, 8, 47);
        readonly int PLAYER_PARTICLE_DAMAGE = 20;
        readonly float PLAYER_PARTICLE_SPEED = 15;
        readonly float PLAYER_PARTICLE_IMAGE_SCALE = 1f;
        readonly float KNIFE_SCALE = 1.25f;
        readonly Vector2 MENU_MARGIN = new Vector2(200, 200);
        readonly Rectangle GRAY_KNIFE_PART = new Rectangle(0, 160, 32, 32);
        readonly Rectangle RED_KNIFE_PART = new Rectangle(32, 160, 32, 32);
        readonly Rectangle PINK_KNIFE_PART = new Rectangle(64, 160, 32, 32);
        readonly Rectangle BLUE_KNIFE_PART = new Rectangle(96, 160, 32, 32);
        readonly Rectangle TURQUOISE_KNIFE_PART = new Rectangle(128, 160, 32, 32);
        readonly Rectangle GREEN_KNIFE_PART = new Rectangle(160, 160, 32, 32);
        readonly Rectangle YELLOW_KNIFE_PART = new Rectangle(192, 160, 32, 32);
        readonly Rectangle WHITE_KNIFE_PART = new Rectangle(224, 160, 32, 32);

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            this.graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            this.graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
            this.graphics.IsFullScreen = IS_FULLSCREEN;
            this.Window.AllowUserResizing = ALLOW_RESIZING;
            graphics.SynchronizeWithVerticalRetrace = false;
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
            api = new GameApi();
            api.instantiateGameController(this, Content, GraphicsDevice);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            api.loadSound(GameApi.LoadHelper.MENU_SELECT_SOUND, MENU_SELECT_SOUND);
            api.loadSound(GameApi.LoadHelper.PLAYER_SHOOT_SOUND, PLAYER_SHOOT_SOUND);
            api.loadSound(GameApi.LoadHelper.PLAYER_DIES_SOUND, PLAYER_DEAD_SOUND);
            api.loadSound(GameApi.LoadHelper.ENEMY_DAMAGE_SOUND, ENEMY_DAMAGE_SOUND);
            api.loadImage(GameApi.LoadHelper.BORDER_TEXTURE, BORDER_TEXTURE);
            api.loadImage(GameApi.LoadHelper.BACKGROUND_TEXTURE, BACKGROUND_TEXTURE);
            api.loadImage(GameApi.LoadHelper.PLAYER_TEXTURE, PLAYER_TEXTURE, PLAYER_TEXTURE_ALPHA);
            api.loadImage(GameApi.LoadHelper.MISSILE_TEXTURE, MISSILE_TEXTURE, MISSILE_TEXTURE_ALPHA);
            api.loadFont(GameApi.LoadHelper.TEXT_FONT, TEXT_FONT);
            api.createScreenMenu(MENU_MARGIN);
            api.createPauseMenu(MENU_MARGIN);
            api.createInGameBackground();
            api.loadImage(BULLETS, BULLETS_TEXTURE, BULLETS_TEXTURE_ALPHA);
            api.loadImage(STAGE1_ENM, STAGE1_ENM_TEXTURE, STAGE1_ENM_TEXTURE_ALPHA);
            api.loadImage(STAGE1_ENM2, STAGE1_ENM2_TEXTURE, STAGE1_ENM2_TEXUTURE_ALPHA);
            api.loadAlphaShader(ALPHA_SHADER);
            api.createPlayer(PLAYER_PARTS, PLAYER_LIFES_COUNT, PLAYER_INITIAL_POSITION, PLAYER_FRAMES_IMAGE_COUNT, PLAYER_IMAGE_SCALE);
            api.createPlayerParticle(PLAYER_LEFT_PARTICLE_POSITION, PLAYER_RIGHT_PARTICLE_POSITION, PLAYER_PARTICLE_PART, PLAYER_PARTICLE_DAMAGE, PLAYER_PARTICLE_SPEED, PLAYER_PARTICLE_IMAGE_SCALE);
            api.createParticle(GRAY_KNIFE, BULLETS, GRAY_KNIFE_PART, KNIFE_SCALE);
            api.createParticle(RED_KNIFE, BULLETS, RED_KNIFE_PART, KNIFE_SCALE);
            api.createParticle(PINK_KNIFE, BULLETS, PINK_KNIFE_PART, KNIFE_SCALE);
            api.createParticle(BLUE_KNIFE, BULLETS, BLUE_KNIFE_PART, KNIFE_SCALE);
            api.createParticle(TURQUOISE_KNIFE, BULLETS, TURQUOISE_KNIFE_PART, KNIFE_SCALE);
            api.createParticle(GREEN_KNIFE, BULLETS, GREEN_KNIFE_PART, KNIFE_SCALE);
            api.createParticle(YELLOW_KNIFE, BULLETS, YELLOW_KNIFE_PART, KNIFE_SCALE);
            api.createParticle(WHITE_KNIFE, BULLETS, WHITE_KNIFE_PART, KNIFE_SCALE);
            api.createEnemy(FAIRIES, STAGE1_ENM, FAIRIES_PARTS, FAIRIES_FRAMES_IMAGE_COUNT, FAIRIES_SCALE);

            if (scriptData == null)
            {
                api.createStageFromPath(@"script.json");
            }
            else
            {
                api.createStage(scriptData);
            }
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
