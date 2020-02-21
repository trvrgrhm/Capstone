using CrossPlatform.GameTop.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop.Screens
{
    class MapScreen: Screen
    {
        public MapScreen(ScreenController controller, Renderer renderer) : base(controller, renderer) { }

        //testing
        Button backButton;
        Button armyButton;
        HoverableTile map;

        override public void init(Microsoft.Xna.Framework.Rectangle screenSize)
        {
            
            base.init(screenSize);


            map = new HoverableTile(this, Renderer, new Microsoft.Xna.Framework.Rectangle(0, 0, (int)(ScreenSize.Width * .75), (int)(ScreenSize.Height * .75)));

            armyButton = new Button(this, Renderer);
            armyButton.setText("Army");
            armyButton.changeLocation((int)(ScreenSize.Width * .75), (int)(ScreenSize.Height * .75));
            armyButton.setClick(() => {
                base.gameController.goToScreen(ScreenState.ArmyScreenState);
                return true;
            });

            backButton = new Button(this, Renderer, new Microsoft.Xna.Framework.Rectangle(0, 0, 100, 100), "Back");
            backButton.setClick(() => {
                base.gameController.goToPreviousScreen();
                return true;
            });


        }
    }
}
