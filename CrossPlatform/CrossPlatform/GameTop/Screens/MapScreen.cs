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
        public MapScreen(GameController controller, Renderer renderer) : base(controller, renderer) { }

        //testing
        Button mainButton;
        Button armyButton;

        override public void init()
        {
            //init self
            base.init();
            this.texture = TextureName.BasicScreenBackground;
            //init children
            mainButton = new Button(renderer, new Microsoft.Xna.Framework.Rectangle(300, 100, 250, 100), "Main Menu");
            mainButton.setClick(() => {
                base.gameController.goToScreen(ScreenState.MainScreenState);
                //mainButton.rect = new Microsoft.Xna.Framework.Rectangle(new Microsoft.Xna.Framework.Point(mainButton.rect.Location.X + 50, mainButton.rect.Location.Y + 50), mainButton.rect.Size);
                //mainButton.textPosition = new Microsoft.Xna.Framework.Vector2(mainButton.textPosition.X + 50, mainButton.textPosition.Y + 50);
                return true;
            });

            base.renderableChildren.Add(mainButton);
            base.clickableChildren.Add(mainButton);
            base.hoverableChildren.Add(mainButton);

            armyButton = new Button(renderer, new Microsoft.Xna.Framework.Rectangle(0, 100, 250, 100), "Army");
            armyButton.setClick(() => {
                base.gameController.goToScreen(ScreenState.ArmyScreenState);
                return true;
            });

            base.renderableChildren.Add(armyButton);
            base.clickableChildren.Add(armyButton);
            base.hoverableChildren.Add(armyButton);


        }
    }
}
