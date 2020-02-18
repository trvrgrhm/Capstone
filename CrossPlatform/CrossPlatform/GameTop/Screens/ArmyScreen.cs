using CrossPlatform.GameTop.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop.Screens
{
    class ArmyScreen: Screen
    {
        public ArmyScreen(GameController controller, Renderer renderer) : base(controller, renderer) { }

        //testing
        Button mapButton;
        Button mainButton;

        override public void init()
        {
            //init self
            base.init();
            this.texture = TextureName.BasicButtonBackground;
            //init children
            mapButton = new Button(renderer, new Microsoft.Xna.Framework.Rectangle(300, 100, 250, 100), "Map");
            mapButton.setClick(() => {
                base.gameController.goToScreen(ScreenState.MapScreenState);
                //mapButton.rect = new Microsoft.Xna.Framework.Rectangle(new Microsoft.Xna.Framework.Point(mapButton.rect.Location.X + 50, mapButton.rect.Location.Y + 50), mapButton.rect.Size);
                //mapButton.textPosition = new Microsoft.Xna.Framework.Vector2(mapButton.textPosition.X + 50, mapButton.textPosition.Y + 50);
                return true;
            });

            base.renderableChildren.Add(mapButton);
            base.clickableChildren.Add(mapButton);
            base.hoverableChildren.Add(mapButton);

            mainButton = new Button(renderer, new Microsoft.Xna.Framework.Rectangle(0, 100, 250, 100), "Main Menu");
            mainButton.setClick(() => {
                base.gameController.goToScreen(ScreenState.MainScreenState);
                return true;
            });

            base.renderableChildren.Add(mainButton);
            base.clickableChildren.Add(mainButton);
            base.hoverableChildren.Add(mainButton);


        }
    }
}
