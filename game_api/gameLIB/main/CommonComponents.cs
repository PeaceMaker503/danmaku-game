using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gameLIB.components.gui;
using gameLIB.components.stage;

namespace gameLIB.main
{
    public class CommonComponents
    {
        private static Menu _currentMenu;
        private static ScreenMenu _screenMenu;
        private static PauseMenu _pauseMenu;
        private static Stage _currentStage;
        public Stage CurrentStage
        {
            get
            {
                return _currentStage;
            }

            set
            {
                _currentStage = value;
            }
        }
        public Menu CurrentMenu
        {
            get
            {
                return _currentMenu;
            }

            set
            {
                _currentMenu = value;
            }
        }
        public ScreenMenu ScreenMenu
        {
            get
            {
                return _screenMenu;
            }

            set
            {
                _screenMenu = value;
            }
        }
        public PauseMenu PauseMenu
        {
            get
            {
                return _pauseMenu;
            }

            set
            {
                _pauseMenu = value;
            }
        }
    }
}
