using System;
using Microsoft.Xna.Framework.Input;


namespace gameLIB.main.engines
{
    public class KeyboardEventEmitter
    {
        KeyboardState _oldState;
        private GameEngine _gameEngine;
        private int _cptShoot;
        private const int _frameDelay = 5;
        private delegate void KeyboardHandler(String key, bool inGame);
        private event KeyboardHandler _raiseKeyPressedEvent;

        public KeyboardEventEmitter(GameEngine gameEngine)
        {
            _gameEngine = gameEngine;
            _cptShoot = 0;
            _raiseKeyPressedEvent = new KeyboardHandler(_gameEngine.updateGameState);
        }

        public void listenKeyDown(bool inGame)
        {
            KeyboardState newState = Keyboard.GetState();

            if (newState.IsKeyDown(Keys.Down) && !(newState.IsKeyDown(Keys.Up)) && ((_oldState != newState) || inGame))
            {
                if(Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                {
                    _raiseKeyPressedEvent("ShiftDown", inGame);
                }
                else
                {
                    _raiseKeyPressedEvent("Down", inGame);
                }

            }
            else if (newState.IsKeyDown(Keys.Up) && !(newState.IsKeyDown(Keys.Down)) && ((_oldState != newState) || inGame))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                {
                    _raiseKeyPressedEvent("ShiftUp", inGame);
                }
                else
                {
                    _raiseKeyPressedEvent("Up", inGame);
                }
            }

            if (newState.IsKeyDown(Keys.Right) && !(newState.IsKeyDown(Keys.Left)) && ((_oldState != newState) || inGame))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                {
                    _raiseKeyPressedEvent("ShiftRight", inGame);
                }
                else
                {
                    _raiseKeyPressedEvent("Right", inGame);
                }
            }
            else if (newState.IsKeyDown(Keys.Left) && !(newState.IsKeyDown(Keys.Right)) && ((_oldState != newState) || inGame))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                {
                    _raiseKeyPressedEvent("ShiftLeft", inGame);
                }
                else
                {
                    _raiseKeyPressedEvent("Left", inGame);
                }
            }

            if (newState.IsKeyDown(Keys.Escape) && (_oldState != newState))
            {
                _raiseKeyPressedEvent("Pause", inGame);
            }
            else if (newState.IsKeyDown(Keys.Enter) && (_oldState != newState) && !inGame)
            {
                _raiseKeyPressedEvent("Enter", inGame);
            }

            if (newState.IsKeyDown(Keys.W) && inGame)
            {
                //empeche de tirer extremement vite
                if (_cptShoot <= 0)
                {
                    _raiseKeyPressedEvent("Shoot", inGame);
                    _cptShoot = _frameDelay;
                }
                _cptShoot--;
            }
            else if (_cptShoot != _frameDelay)
            {
                _cptShoot = 0;
            }
            _oldState = newState;
        }
    }
}