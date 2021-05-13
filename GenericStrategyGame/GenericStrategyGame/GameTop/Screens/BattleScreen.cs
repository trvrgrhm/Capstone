using GenericStrategyGame.GameTop.ArmyInfo;
using GenericStrategyGame.GameTop.BattleLogic;
using GenericStrategyGame.GameTop.Tiles;
using GenericStrategyGame.GameTop.UI;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStrategyGame.GameTop.Screens
{
    class BattleScreen : Screen
    {
        Battle battle;
        public BattleScreen(ScreenController controller, Renderer renderer, SoundController soundController, PlayerInfo info) : base(controller, renderer,soundController, info) {}

        //testing
        //Button backButton;

        BattleInfoTile battleControls;

        BattleTile battleTile;

        override public void init(Rectangle screenSize)
        {
            //init self
            base.init(screenSize);


            //backButton = new Button(this, Renderer, new Rectangle(0, 0, 100, 100), "Back");
            //backButton.setClick(() => {
            //    base.gameController.goToPreviousScreen();
            //    return true;
            //});

            battleControls = new BattleInfoTile(this, Renderer, new Rectangle(0, (int)(ScreenSize.Height*.8), (int)(ScreenSize.Width), (int)(ScreenSize.Height*.2)));

            Rectangle battleTileRect = new Rectangle(0, 0, (int)(ScreenSize.Width), (int)(ScreenSize.Height * .8));
            battle = new Battle(playerInfo.PlayerArmy, playerInfo.EnemyArmy, battleTileRect);

            battleTile = new BattleTile(this,this.Renderer, battleTileRect, battle);

            soundController.playSong("HeroicDemise");
        }
        public override void update()
        {
            base.update();

            battleTile.update();

            if (battle.battleOverDelay<=0)
            {
                playerInfo.SelectedMap.SelectedCity.SetStationedArmy(battle.Winner);
                if(battle.Winner.Equals(playerInfo.PlayerArmy))
                {
                    playerInfo.PlayerArmy.addUnit(playerInfo.EnemyArmy.removeRandomUnitFromArmy());
                }
                gameController.goToScreen(ScreenState.MapScreenState);
                soundController.playSong("MagicalTheme");
            }
        }
    }
}
