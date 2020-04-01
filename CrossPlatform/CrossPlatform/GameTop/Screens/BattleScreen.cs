using CrossPlatform.GameTop.Tiles;
using CrossPlatform.GameTop.UI;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop.Screens
{
    class BattleScreen : Screen
    {
        public BattleScreen(ScreenController controller, Renderer renderer, PlayerInfo info) : base(controller, renderer) { playerInfo = info; }

        //testing
        Button backButton;
        HoverableElement battleControls;

        BattleTile battleTile;
        PlayerInfo playerInfo;

        override public void init(Microsoft.Xna.Framework.Rectangle screenSize)
        {
            //init self
            base.init(screenSize);
            backButton = new Button(this, Renderer, new Rectangle(0, 0, 100, 100), "Back");
            backButton.setClick(() => {
                base.gameController.goToPreviousScreen();
                return true;
            });

            battleControls = new HoverableElement(this, Renderer, new Rectangle(0, (int)(ScreenSize.Height*.8), (int)(ScreenSize.Width), (int)(ScreenSize.Height*.2)));

            //eventually change to enemy army
            battleTile = new BattleTile(this,this.Renderer, new Rectangle(0, 0, (int)(ScreenSize.Width*.5), (int)(ScreenSize.Height * .75)), playerInfo.PlayerArmy, playerInfo.PlayerArmy);
        }
    }
}
