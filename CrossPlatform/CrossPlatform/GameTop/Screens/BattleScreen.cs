using CrossPlatform.GameTop.ArmyInfo;
using CrossPlatform.GameTop.BattleLogic;
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
        public Army PlayerArmy { get; set; }
        public Army EnemyArmy { get; set; }
        Battle battle;
        public BattleScreen(ScreenController controller, Renderer renderer, PlayerInfo info) : base(controller, renderer, info) {}

        //testing
        Button backButton;
        BattleInfoTile battleControls;

        BattleTile battleTile;

        override public void init(Rectangle screenSize)
        {
            

            //init self
            base.init(screenSize);
            backButton = new Button(this, Renderer, new Rectangle(0, 0, 100, 100), "Back");
            backButton.setClick(() => {
                base.gameController.goToPreviousScreen();
                return true;
            });

            battleControls = new BattleInfoTile(this, Renderer, new Rectangle(0, (int)(ScreenSize.Height*.8), (int)(ScreenSize.Width), (int)(ScreenSize.Height*.2)));

            Rectangle battleTileRect = new Rectangle(0, 0, (int)(ScreenSize.Width), (int)(ScreenSize.Height * .8));
            battle = new Battle(playerInfo.PlayerArmy, playerInfo.EnemyArmy, battleTileRect);

            battleTile = new BattleTile(this,this.Renderer, battleTileRect, battle);
        }
        public override void update()
        {
            base.update();

            battleTile.update();
        }
    }
}
