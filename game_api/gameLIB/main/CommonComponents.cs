using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gameLIB.components.gui;
using gameLIB.components.stage;

namespace gameLIB.main
{
    public class CommonComponents //singleton
    {
        public Menu currentMenu { get; set; }
        public ScreenMenu screenMenu { get; set; }
        public PauseMenu pauseMenu { get; set; }
        public Stage currentStage { get; set; }
        private static CommonComponents _instance;

        public static CommonComponents getInstance()
        {
            if(_instance == null) 
                _instance = new CommonComponents();
           
            return _instance;
        }
    }
}
