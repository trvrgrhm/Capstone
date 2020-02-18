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
        public MainScreen(GameController controller, Renderer renderer) : base(controller, renderer) { }

        //testing
        Button mapButton;
        Button armyButton;

        override public void init()
        {
            //init self
            base.init();
            this.texture = TextureName.MainScreenBackground;
            //init children
            mapButton = new Button(renderer, new Microsoft.Xna.Framework.Rectangle(300,100,250,100), "Map");
            mapButton.setClick(() => {
                base.gameController.goToScreen(ScreenState.MapScreenState);
                //mapButton.rect = new Microsoft.Xna.Framework.Rectangle(new Microsoft.Xna.Framework.Point(mapButton.rect.Location.X + 50, mapButton.rect.Location.Y + 50), mapButton.rect.Size);
                //mapButton.textPosition = new Microsoft.Xna.Framework.Vector2(mapButton.textPosition.X + 50, mapButton.textPosition.Y + 50);
                return true; });

            base.renderableChildren.Add(mapButton);
            base.clickableChildren.Add(mapButton);
            base.hoverableChildren.Add(mapButton);

            armyButton = new Button(renderer, new Microsoft.Xna.Framework.Rectangle(0,100,250,100), "Army");
            armyButton.setClick(() => {
                base.gameController.goToScreen(ScreenState.ArmyScreenState);
                return true;
            });

            base.renderableChildren.Add(armyButton);
            base.clickableChildren.Add(armyButton);
            base.hoverableChildren.Add(armyButton);


        }
        override public void update()
        {
            base.update();
        }
            
    }
}
