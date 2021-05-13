using GenericStrategyGame.GameTop.Storage;
using GenericStrategyGame.GameTop.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStrategyGame.GameTop.Screens
{
    class SettingScreen : Screen
    {
        StorageManager storageManager;

        //testing
        Button backButton;

        Button saveButton;
        Button loadButton;
        Button resetButton;

        public SettingScreen(ScreenController controller, Renderer renderer, SoundController soundController, PlayerInfo playerInfo, StorageManager storageManager) : base(controller, renderer, soundController,playerInfo) { this.storageManager = storageManager; }


        override public void init(Microsoft.Xna.Framework.Rectangle screenSize)
        {
            int numButtons = 4;

            //init self
            base.init(screenSize);
            //this.Texture = TextureName.BasicButtonBackground;
            //init children
            

            saveButton = new Button(this, Renderer, new Microsoft.Xna.Framework.Rectangle(0, (ScreenSize.Height / numButtons) * 0, ScreenSize.Width, (ScreenSize.Height / numButtons)), "Save");
            saveButton.setClick(() =>
            {
                storageManager.SaveGame();
                return true;
            });
            loadButton = new Button(this, Renderer, new Microsoft.Xna.Framework.Rectangle(0, (ScreenSize.Height / numButtons) * 1, ScreenSize.Width, (ScreenSize.Height / numButtons)), "Load"); 
            loadButton.setClick(() =>
            {
                storageManager.LoadGame();
                return true;
            }); 
            resetButton = new Button(this, Renderer, new Microsoft.Xna.Framework.Rectangle(0, (ScreenSize.Height / numButtons) * 2, ScreenSize.Width, (ScreenSize.Height / numButtons)), "Reset Game"); 
            resetButton.setClick(() =>
            {
                storageManager.ResetGame();
                return true;
            });
            backButton = new Button(this, Renderer, new Microsoft.Xna.Framework.Rectangle(0, (ScreenSize.Height / numButtons) * 3, ScreenSize.Width, (ScreenSize.Height / numButtons)), "Back");
            backButton.setClick(() => {
                base.gameController.goToPreviousScreen();
                return true;
            });


        }
    }
}
