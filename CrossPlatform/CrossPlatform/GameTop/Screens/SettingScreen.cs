using CrossPlatform.GameTop.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop.Screens
{
    class SettingScreen : Screen
    {
        public SettingScreen(ScreenController controller, Renderer renderer, SoundController soundController, PlayerInfo playerInfo) : base(controller, renderer, soundController,playerInfo) { }

        //testing
        Button backButton;

        override public void init(Microsoft.Xna.Framework.Rectangle screenSize)
        {
            //init self
            base.init(screenSize);
            //this.Texture = TextureName.BasicButtonBackground;
            //init children
            backButton = new Button(this, Renderer, new Microsoft.Xna.Framework.Rectangle(0, 0, 100, 100), "Back");
            backButton.setClick(() => {
                base.gameController.goToPreviousScreen();
                return true;
            });
        }
    }
}
