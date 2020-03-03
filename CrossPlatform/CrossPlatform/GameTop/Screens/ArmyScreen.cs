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
        public ArmyScreen(ScreenController controller, Renderer renderer) : base(controller, renderer) { }

        //testing
        Button mapButton;
        Button mainButton;

        HoverableElement formationTile;
        HoverableElement selectedSquadTile;
        HoverableElement unitSelectorTile;
        HoverableElement selectedUnitTile;

        override public void init(Microsoft.Xna.Framework.Rectangle screenSize)
        {
            //init self
            base.init(screenSize);
            //this.Texture = TextureName.BasicButtonBackground;
            //init children

            formationTile = new HoverableElement(this, this.renderer, new Microsoft.Xna.Framework.Rectangle(0, 0, (int)(screenSize.Width * .5), (int)(screenSize.Height * .75)));
            selectedSquadTile = new HoverableElement(this, this.renderer, new Microsoft.Xna.Framework.Rectangle(0, (int)(screenSize.Height * .75), (int)(screenSize.Width * .5), (int)(screenSize.Height * .25)));
            unitSelectorTile = new HoverableElement(this, this.renderer, new Microsoft.Xna.Framework.Rectangle((int)(screenSize.Width * .5), 0, (int)(screenSize.Width * .5), (int)(screenSize.Height * .5)));
            selectedUnitTile = new HoverableElement(this, this.renderer, new Microsoft.Xna.Framework.Rectangle((int)(screenSize.Width * .5), (int)(screenSize.Height * .5), (int)(screenSize.Width * .5), (int)(screenSize.Height * .5)));

            mapButton = new Button(this, Renderer, new Microsoft.Xna.Framework.Rectangle(300, 100, 250, 100), "Map");
            mapButton.setClick(() => {
                base.gameController.goToScreen(ScreenState.MapScreenState);
                //mapButton.rect = new Microsoft.Xna.Framework.Rectangle(new Microsoft.Xna.Framework.Point(mapButton.rect.Location.X + 50, mapButton.rect.Location.Y + 50), mapButton.rect.Size);
                //mapButton.textPosition = new Microsoft.Xna.Framework.Vector2(mapButton.textPosition.X + 50, mapButton.textPosition.Y + 50);
                return true;
            });

            mainButton = new Button(this, Renderer, new Microsoft.Xna.Framework.Rectangle(0, 100, 250, 100), "Main Menu");
            mainButton.setClick(() => {
                base.gameController.goToScreen(ScreenState.MainScreenState);
                return true;
            });


        }
    }
}
