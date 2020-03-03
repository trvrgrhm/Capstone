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
        Button battleButton;
        Button armyButton;
        HoverableElement mapTile;
        HoverableElement selectedCityTile;
        HoverableElement selectedArmyTIle;

        override public void init(Microsoft.Xna.Framework.Rectangle screenSize)
        {
            
            base.init(screenSize);


            mapTile = new HoverableElement(this, Renderer, new Microsoft.Xna.Framework.Rectangle(0, 0, (int)(ScreenSize.Width * .75), (int)(ScreenSize.Height * .75)));
            selectedCityTile = new HoverableElement(this, Renderer, new Microsoft.Xna.Framework.Rectangle((int)(ScreenSize.Width * .75), 0, (int)(ScreenSize.Width * .25), (int)(ScreenSize.Height)));
            selectedArmyTIle = new HoverableElement(this, Renderer, new Microsoft.Xna.Framework.Rectangle(0, (int)(ScreenSize.Height * .75), (int)(ScreenSize.Width * .75), (int)(ScreenSize.Height*.25)));

            armyButton = new Button(this, Renderer);
            armyButton.setText("Army");
            armyButton.Rect = new Microsoft.Xna.Framework.Rectangle((int)(ScreenSize.Width * .75), (int)(ScreenSize.Height * .75), (int)(ScreenSize.Width * .25), (int)(ScreenSize.Height * .1));
            armyButton.setClick(() => {
                base.gameController.goToScreen(ScreenState.ArmyScreenState);
                return true;
            }); 
            battleButton = new Button(this, Renderer);
            battleButton.setText("To Battle!");
            battleButton.Rect = new Microsoft.Xna.Framework.Rectangle((int)(ScreenSize.Width * .75), (int)(ScreenSize.Height * .9), (int)(ScreenSize.Width * .25), (int)(ScreenSize.Height * .1));
            battleButton.setClick(() => {
                base.gameController.goToScreen(ScreenState.BattleScreenState);
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
