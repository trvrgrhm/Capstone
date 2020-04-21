using CrossPlatform.GameTop.UI;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop
{
    class MainScreen: Screen
    {
        public MainScreen(ScreenController controller, Renderer renderer, SoundController soundController, PlayerInfo playerInfo) : base(controller, renderer, soundController, playerInfo) { }

        //testing
        TextElement title;
        Button mapButton;
        Button armyButton;
        Button settingsButton;

        override public void init(Microsoft.Xna.Framework.Rectangle screenSize)
        {
            //init self
            base.init(screenSize);
            //this.texture = TextureName.MainScreenBackground;
            this.background.Texture = TextureName.MainScreenBackground;
            //init children


            var midWidth = ScreenSize.Width / 2;
            int numButtons = 4;
            title = new TextElement(this, Renderer, new Microsoft.Xna.Framework.Rectangle(0, (ScreenSize.Height / numButtons) * 0, ScreenSize.Width, (ScreenSize.Height / numButtons)), "Generic Strategy Game");
            mapButton = new Button(this, Renderer, new Microsoft.Xna.Framework.Rectangle(0, (ScreenSize.Height / numButtons) * 1, ScreenSize.Width, (ScreenSize.Height / numButtons)), "Map");
            mapButton.setClick(() => {
                base.gameController.goToScreen(ScreenState.MapScreenState);
                return true; });

            armyButton = new Button(this, Renderer, new Microsoft.Xna.Framework.Rectangle(0, (ScreenSize.Height / numButtons) * 2, ScreenSize.Width, (ScreenSize.Height / numButtons)), "Army");
            armyButton.setClick(() => {
                base.gameController.goToScreen(ScreenState.ArmyScreenState);
                return true;
            });

            settingsButton = new Button(this, Renderer, new Microsoft.Xna.Framework.Rectangle(0, (ScreenSize.Height / numButtons) * 3, ScreenSize.Width, (ScreenSize.Height / numButtons)), "Settings");
            settingsButton.setClick(() => {
                base.gameController.goToScreen(ScreenState.SettingScreenState);
                return true;
            });



            soundController.playSong("MagicalTheme");


        }
        override public void update()
        {
            base.update();
        }
            
    }
}
