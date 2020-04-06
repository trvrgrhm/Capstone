using CrossPlatform.GameTop.ArmyInfo;
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
    class ArmyScreen: Screen
    {
        public ArmyScreen(ScreenController controller, Renderer renderer, PlayerInfo info) : base(controller, renderer) { playerInfo = info; }

        //testing
        Button mapButton;
        Button mainButton;
        PlayerInfo playerInfo;

        public Squad SelectedSquad { get { return selectedSquad; } set { selectedSquad = value; selectedSquadTile.SelectedSquad = value; } }
        private Squad selectedSquad;
        public Unit SelectedUnit { get { return selectedUnit; } set { selectedUnit = value; selectedUnitTile.SelectedUnit = value; } }
        private Unit selectedUnit;

        SquadFormationTile formationTile;
        SelectedSquadTile selectedSquadTile;
        UnitSelectorTile unitSelectorTile;
        SelectedUnitTile selectedUnitTile;

        override public void init(Microsoft.Xna.Framework.Rectangle screenSize)
        {
            //init self
            base.init(screenSize);
            //this.Texture = TextureName.BasicButtonBackground;
            //init children
            

            formationTile = new SquadFormationTile(this, this.Renderer, new Rectangle(0, 0, (int)(screenSize.Width * .5), (int)(screenSize.Height * .75)), playerInfo);
            selectedSquadTile = new SelectedSquadTile(this, this.Renderer, new Rectangle(0, (int)(screenSize.Height * .75), (int)(screenSize.Width * .5), (int)(screenSize.Height * .25)));
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
                SelectedSquad = formationTile.SelectedSquad;
                formationTile.NewSquadSelected = false;
            }
            if (unitSelectorTile.NewUnitSelected)
            {
                SelectedUnit = unitSelectorTile.SelectedUnit;
                unitSelectorTile.NewUnitSelected = false;
            }
            if (selectedSquadTile.NewUnitSelected)
            {
                SelectedUnit = selectedSquadTile.SelectedUnit;
                selectedSquadTile.NewUnitSelected = false;
            }
            if (unitSelectorTile.unitTilesReset)
            {
                selectedUnitTile.destroy();
                selectedUnitTile = new SelectedUnitTile(this, Renderer, new Rectangle((int)(screenSize.Width * .5), (int)(screenSize.Height * .5), (int)(screenSize.Width * .5), (int)(screenSize.Height * .3)));
                Button newButton = new Button(this, Renderer, new Rectangle((int)(screenSize.Width * .5), (int)(screenSize.Height * .5), (int)(screenSize.Width * .5), (int)(screenSize.Height * .3)));
                selectedUnitTile.SelectedUnit = SelectedUnit;
            }
            if (selectedUnitTile.addUnitToSquad)
            {
                //addUnit function
                if (playerInfo.PlayerArmy.addUnitToSquad(SelectedUnit, SelectedSquad.Row, SelectedSquad.Column))
                {
                    unitSelectorTile.removeUnitFromTile(SelectedUnit);
                    selectedSquadTile.populateWithSquad(SelectedSquad);
                }
                selectedUnitTile.addUnitToSquad = false;
            }
            if (selectedUnitTile.removeUnitFromSquad)
            {
                if (playerInfo.PlayerArmy.removeUnitFromSquad(SelectedUnit.SquadPosition, SelectedSquad.Row, SelectedSquad.Column))
                {
                    unitSelectorTile.addUnitToTile(SelectedUnit);
                    selectedSquadTile.populateWithSquad(SelectedSquad);
                }
                //removeUnit function
                selectedUnitTile.removeUnitFromSquad = false;
            }
            //update selected unit
            //update selected squad
        }
    }
}
