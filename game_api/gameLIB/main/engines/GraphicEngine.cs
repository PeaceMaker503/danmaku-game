using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using gameLIB.components.sprites;
using gameLIB.components.gui;
using gameLIB.components.characters;
using gameLIB.components.particles;

namespace gameLIB.main.engines
{
    public class GraphicEngine
    {

        private ContentManager _content;
        private GraphicsDevice _graphicsDevice;
        private SpriteBatch _spriteBatch;
        private Dictionary<String, Image> _images;
        private Dictionary<String, SpriteFont> _fonts;
        private Dictionary<String, Effect> _effects;
        private static Rectangle windowDimension;
        private Rectangle _inGameWindow;
        private InGameBackground _inGameBackground;
        private Effect _alphaShader;
        private CommonComponents _common;

        public GraphicEngine(ContentManager content, GraphicsDevice graphicsDevice)
        {
            _content = content;
            _common = CommonComponents.getInstance();
            _graphicsDevice = graphicsDevice;
            WindowDimension = _graphicsDevice.Viewport.Bounds;
            _images = new Dictionary<String, Image>();
            _fonts = new Dictionary<String, SpriteFont>();
            _effects = new Dictionary<String, Effect>();
            _inGameWindow = new Rectangle(35, 25, WindowDimension.Width - 25 - 275, WindowDimension.Height - 50);
        }

        public void loadAlphaShader(String alphaPath)
        {
            _alphaShader = _content.Load<Effect>(alphaPath);
        }

        public void loadImage(String imageName, String imagePath, String alphaPath)
        {
            if(_spriteBatch == null)
            {
                _spriteBatch = new SpriteBatch(_graphicsDevice);
            }

            if (!_images.ContainsKey(imageName))
            {
                Texture2D texture = _content.Load<Texture2D>(imagePath);
                Texture2D alpha=null;
                if (alphaPath!=null)
                {
                    alpha = _content.Load<Texture2D>(alphaPath);
                }
                _images.Add(imageName, new Image(imageName, texture, alpha));
            }
        }

        public void loadEffect(String effectName, String effectPath)
        {
            Effect effect = _content.Load<Effect>(effectPath);
            _effects.Add(effectName, effect);
        }

        public void loadFont(String fontName, String fontPath)
        {
            SpriteFont spriteFont = _content.Load<SpriteFont>(fontPath);
            _fonts.Add(fontName, spriteFont);
        }

        public void createInGameBackground()
        {
            StaticSprite left = new StaticSprite(_images[GameApi.LoadHelper.BORDER_TEXTURE], new Vector2(0, 0), new Vector2(_inGameWindow.X, WindowDimension.Height));
            StaticSprite up = new StaticSprite(_images[GameApi.LoadHelper.BORDER_TEXTURE], new Vector2(0, 0), new Vector2(WindowDimension.Width, _inGameWindow.Y));
            StaticSprite down = new StaticSprite(_images[GameApi.LoadHelper.BORDER_TEXTURE], new Vector2(0, WindowDimension.Height - _inGameWindow.Y), new Vector2(WindowDimension.Width, _inGameWindow.Y));
            StaticSprite right = new StaticSprite(_images[GameApi.LoadHelper.BORDER_TEXTURE], new Vector2(_inGameWindow.Width + _inGameWindow.X, 0), new Vector2(WindowDimension.Width - _inGameWindow.Width - _inGameWindow.X, WindowDimension.Height));
            StaticSprite background = new StaticSprite(_images[GameApi.LoadHelper.BACKGROUND_TEXTURE], new Vector2(0, 0), new Vector2(WindowDimension.Width, WindowDimension.Height));
            _inGameBackground = new InGameBackground(left, up, down, right, background);
        }

        public void createScreenMenu(Vector2 marginMenu)
        {
            StaticSprite background = new StaticSprite(_images[GameApi.LoadHelper.BACKGROUND_TEXTURE], new Vector2(0, 0), new Vector2(WindowDimension.Width, WindowDimension.Height));
            _common.screenMenu = new ScreenMenu(marginMenu, GameApi.LoadHelper.MENU_SELECT_SOUND, _fonts[GameApi.LoadHelper.TEXT_FONT], background);
            _common.currentMenu = _common.screenMenu;
        }

        public void createPauseMenu(Vector2 marginMenu)
        {
            StaticSprite background = new StaticSprite(_images[GameApi.LoadHelper.BACKGROUND_TEXTURE], new Vector2(0, 0), new Vector2(WindowDimension.Width, WindowDimension.Height));
            _common.pauseMenu = new PauseMenu(marginMenu, GameApi.LoadHelper.MENU_SELECT_SOUND, _fonts[GameApi.LoadHelper.TEXT_FONT], background);
        }

        public void unloadContent()
        {
            _content.Unload();
        }

        public void drawMenu()
        {
            _spriteBatch.Begin();
            _common.currentMenu.drawMenu(_spriteBatch);
            _spriteBatch.End();
        }

        public void drawStage()
        {
            _spriteBatch.Begin();
            _inGameBackground.drawInGameBackground(_spriteBatch);
            _spriteBatch.End();

            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, _alphaShader);
            _alphaShader.Parameters["MaskTexture"].SetValue(_common.currentStage.player.image.alpha);

            if(!_common.currentStage.player.isAlive)
                _alphaShader.Parameters["Opacity"].SetValue(0.5f);
            else
                _alphaShader.Parameters["Opacity"].SetValue(1f);

            _common.currentStage.player.draw(_spriteBatch);
            _spriteBatch.End();

            foreach (String key in _common.currentStage.enemies.Keys)
            {
                if (_common.currentStage.enemies[key].Count > 0)
                {
                    _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, _alphaShader);
                    _alphaShader.Parameters["MaskTexture"].SetValue(_images[key].alpha);
                    _alphaShader.Parameters["Opacity"].SetValue(1f);
                    foreach (Enemy enemy in _common.currentStage.enemies[key].Values)
                    {
                        enemy.draw(_spriteBatch);
                    }
                    _spriteBatch.End();
                }
            }

            foreach(String key in _common.currentStage.particles.Keys)
            {
                if (_common.currentStage.particles[key].Count > 0)
                {
                    _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, _alphaShader);
                    _alphaShader.Parameters["MaskTexture"].SetValue(_images[key].alpha);
                    _alphaShader.Parameters["Opacity"].SetValue(1f);

                    foreach (Particle particle in _common.currentStage.particles[key].Values)
                    {
                        particle.draw(_spriteBatch);
                    }
                    _spriteBatch.End();
                }
            }
            

            _spriteBatch.Begin();
            _inGameBackground.drawInGameUI(_spriteBatch);
            _spriteBatch.DrawString(_fonts[GameApi.LoadHelper.TEXT_FONT], ((float)_common.currentStage.time).ToString(), new Vector2(600, 300), Color.White);
            _spriteBatch.End();
        }

        public Image getImage(String imageName)
        {
            return _images[imageName];
        }

        public SpriteFont getFont(String fontName)
        {
            return _fonts[fontName];
        }

        public Effect getEffect(String effectName)
        {
            return _effects[effectName];
        }

        public static Rectangle WindowDimension
        {
            get
            {
                return windowDimension;
            }

            set
            {
                windowDimension = value;
            }
        }
    }
}
