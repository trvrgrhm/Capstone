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
        public MainScreen(ScreenController controller, Renderer renderer) : base(controller, renderer) { }

        //testing
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

            mapButton = new Button(this, Renderer, new Microsoft.Xna.Framework.Rectangle(0,(int)(ScreenSize.Height * .25),midWidth,100), "Map");
            mapButton.setClick(() => {
                base.gameController.goToScreen(ScreenState.MapScreenState);
                return true; });

            armyButton = new Button(this, Renderer, new Microsoft.Xna.Framework.Rectangle(0, (int)(ScreenSize.Height * .5), midWidth,100), "Army");
            armyButton.setClick(() => {
                base.gameController.goToScreen(ScreenState.ArmyScreenState);
                return true;
            });

            settingsButton = new Button(this, Renderer, new Microsoft.Xna.Framework.Rectangle(0, (int)(ScreenSize.Height * .75), midWidth, 100), "Settings");
            settingsButton.setClick(() => {
                base.gameController.goToScreen(ScreenState.SettingScreenState);
                return true;
            });





        }
        override public void update()
        {
            base.update();
        }
            
    }
}
