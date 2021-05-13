using GenericStrategyGame.GameTop.ArmyInfo;
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
    class ArmyScreen: Screen
    {
        public ArmyScreen(ScreenController controller, Renderer renderer, SoundController soundController, PlayerInfo info) : base(controller, renderer,soundController, info) { }

        //testing
        Button mapButton;
        Button mainButton;

        public Squad SelectedSquad { get { return selectedSquad; } set { selectedSquad = value; selectedSquadTile.SelectedSquad = value; } }
        private Squad selectedSquad;
        public Unit SelectedUnit { get { return selectedUnit; } set { selectedUnit = value; selectedUnitTile.SelectedUnit = value; } }
        private Unit selectedUnit;

        SquadFormationTile formationTile;
        SelectedSquadTile selectedSquadTile;
        UnitSelectorTile unitSelectorTile;
        SelectedUnitTile selectedUnitTile;

        override public void init(Rectangle screenSize)
        {
            //init self
            base.init(screenSize);


            //init children
            formationTile = new SquadFormationTile(this, this.Renderer, new Rectangle(0, 0, (int)(screenSize.Width * .5), (int)(screenSize.Height * .75)), playerInfo);
            selectedSquadTile = new SelectedSquadTile(this, this.Renderer, new Rectangle(0, (int)(screenSize.Height * .75), (int)(screenSize.Width * .5), (int)(screenSize.Height * .25)));
            SelectedSquad = playerInfo.PlayerArmy.squads[0, 0];
            formationTile.SelectedSquad = SelectedSquad;
            unitSelectorTile = new UnitSelectorTile(this, this.Renderer, new Rectangle((int)(screenSize.Width * .5), 0, (int)(screenSize.Width * .5), (int)(screenSize.Height * .5)), playerInfo);
            selectedUnitTile = new SelectedUnitTile(this, this.Renderer, new Rectangle((int)(screenSize.Width * .5), (int)(screenSize.Height * .5), (int)(screenSize.Width * .5), (int)(screenSize.Height * .3)));

            mapButton = new Button(this, Renderer, new Rectangle(selectedUnitTile.Rect.X, selectedUnitTile.Rect.Y+selectedUnitTile.Rect.Height, selectedUnitTile.Rect.Width / 2, (background.Rect.Y+background.Rect.Height)-(selectedUnitTile.Rect.Y+selectedUnitTile.Rect.Height)), "Map");
            mapButton.setClick(() => {
                base.gameController.goToScreen(ScreenState.MapScreenState);
                return true;
            });
            mainButton = new Button(this, Renderer, new Rectangle(selectedUnitTile.Rect.X+selectedUnitTile.Rect.Width/2, selectedUnitTile.Rect.Y + selectedUnitTile.Rect.Height, selectedUnitTile.Rect.Width/2, (background.Rect.Y + background.Rect.Height) - (selectedUnitTile.Rect.Y + selectedUnitTile.Rect.Height)), "Main Menu");
            mainButton.setClick(() => {
                base.gameController.goToScreen(ScreenState.MainScreenState);
                return true;
            });



        }

        public override void update()
        {
            base.update();
            if (formationTile.NewSquadSelected)
            {
                //update selected squad
                if (SelectedSquad.containsUnit(SelectedUnit))
                {
                    SelectedUnit = null;
                }
                SelectedSquad = formationTile.SelectedSquad;
                
                formationTile.NewSquadSelected = false;
            }
            if (unitSelectorTile.NewUnitSelected)
            {
                //update selected unit
                SelectedUnit = unitSelectorTile.SelectedUnit;
                unitSelectorTile.NewUnitSelected = false;
            }
            if (selectedSquadTile.NewUnitSelected)
            {
                //update selected unit
                SelectedUnit = selectedSquadTile.SelectedUnit;
                selectedSquadTile.NewUnitSelected = false;
            }
            
            if (selectedUnitTile.addUnitToSquad)
            {
                //add unit
                if (playerInfo.PlayerArmy.addUnitToSquad(SelectedUnit, SelectedSquad.Row, SelectedSquad.Column))
                {
                    unitSelectorTile.removeUnitFromTile(SelectedUnit);
                    selectedSquadTile.populateWithSquad(SelectedSquad);
                    formationTile.addSquadTile(selectedSquad.Row,selectedSquad.Column);
                    Console.WriteLine("unit added");
                }
                selectedUnitTile.addUnitToSquad = false;
            }
            if (selectedUnitTile.removeUnitFromSquad)
            {
                //remove unit
                if (playerInfo.PlayerArmy.removeUnitFromSquad(SelectedUnit.SquadPosition, SelectedSquad.Row, SelectedSquad.Column))
                {
                    unitSelectorTile.addUnitToTile(SelectedUnit);
                    selectedSquadTile.populateWithSquad(SelectedSquad);
                    formationTile.removeSquadTile(selectedSquad.Row, selectedSquad.Column);
                    formationTile.addSquadTile(selectedSquad.Row, selectedSquad.Column);
                    Console.WriteLine("unit removed");
                }
                selectedUnitTile.removeUnitFromSquad = false;
            }

            if (unitSelectorTile.unitTilesReset)
            {
                //reset unit selector
                selectedUnitTile.reset();
                selectedUnitTile.SelectedUnit = SelectedUnit;
            }
        }
    }
}
