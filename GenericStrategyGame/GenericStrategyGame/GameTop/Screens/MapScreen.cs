﻿using GenericStrategyGame.GameTop.ArmyInfo;
using GenericStrategyGame.GameTop.LevelInfo;
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
    class MapScreen: Screen
    {
        public City SelectedCity { get { return selectedCity; } set { selectedCity = value; selectedArmyTile.SelectedArmy = (value != null) ?  value.GetStationedArmy() :  null; selectedCityTile.SelectedCity = value; } }
        private City selectedCity;

        //testing
        Button backButton;
        Button battleButton;
        Button armyButton;
        MapTile mapTile;
        CityInfoTile selectedCityTile;
        ArmyInfoTile selectedArmyTile;
        public MapScreen(ScreenController controller, Renderer renderer,SoundController soundController, PlayerInfo playerInfo) : base(controller, renderer, soundController,playerInfo) { this.playerInfo = playerInfo; }

        

        override public void init(Rectangle screenSize)
        {
            
            base.init(screenSize);
            mapTile = new MapTile(this, Renderer, new Rectangle(0, 0, (int)(ScreenSize.Width * .75), (int)(ScreenSize.Height * .75)),playerInfo);
            selectedCityTile = new CityInfoTile(this, Renderer, new Rectangle((int)(ScreenSize.Width * .75), 0, (int)(ScreenSize.Width * .25), (int)(ScreenSize.Height*.8)));
            selectedArmyTile = new ArmyInfoTile(this, Renderer, new Rectangle(0, (int)(ScreenSize.Height * .8), (int)(ScreenSize.Width * .75), (int)(ScreenSize.Height*.2)));

            armyButton = new Button(this, Renderer, new Rectangle((int)(ScreenSize.Width * .75), (int)(ScreenSize.Height * .8), (int)(ScreenSize.Width * .25), (int)(ScreenSize.Height * .1)),"Army");
            armyButton.setClick(() => {
                base.gameController.goToScreen(ScreenState.ArmyScreenState);
                return true;
            }); 

            battleButton = new Button(this, Renderer, new Rectangle((int)(ScreenSize.Width * .75), (int)(ScreenSize.Height * .9), (int)(ScreenSize.Width * .25), (int)(ScreenSize.Height * .1)), "To Battle!");
            battleButton.setClick(() =>
            {
                if (SelectedCity != null&&SelectedCity.GetCityOwner() != "Player")
                {
                    playerInfo.SelectedMap.SelectedCity = SelectedCity;
                    playerInfo.EnemyArmy = SelectedCity.GetStationedArmy();
                    base.gameController.goToScreen(ScreenState.BattleScreenState);
                }
                return true;
            });

            //backButton = new Button(this, Renderer, new Rectangle(0, 0, 100, 100), "Back");
            //backButton.setClick(() => {
            //    base.gameController.goToPreviousScreen();
            //    return true;
            //});



            SelectedCity = null;

        }

        public override void update()
        {
            base.update();
            if (mapTile.newCitySelected)
            {
                SelectedCity = mapTile.SelectedCity;
            }
        }
    }
}
