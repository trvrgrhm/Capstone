using GenericStrategyGame.GameTop.ArmyInfo;
using GenericStrategyGame.GameTop.LevelInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStrategyGame.GameTop
{
    class PlayerInfo
    {
        public CityMap SelectedMap { get; set; }
        public Army PlayerArmy { get; set; }
        public Army EnemyArmy { get; set; }
        //settings?

        public PlayerInfo() : this(new Army("Player"), new CityMap())
        {
            Unit firstUnit = new Unit();
            PlayerArmy.addUnit(firstUnit);
            PlayerArmy.addUnit(new Unit(UnitType.Miku));
            for (int i = 0;i < 10; i++)
            {
                PlayerArmy.addUnit(new Unit());
            }
            PlayerArmy.squads[0, 0].addUnit(0, firstUnit);
        }
        public PlayerInfo(Army playerArmy, CityMap cityMap)
        {
            PlayerArmy = playerArmy;
            SelectedMap = cityMap;
            EnemyArmy = null;
        }

        public void resetGame()
        {
            PlayerArmy = new Army("Player");
            SelectedMap = new CityMap();
            EnemyArmy = null;

            Unit firstUnit = new Unit();
            PlayerArmy.addUnit(firstUnit);
            PlayerArmy.addUnit(new Unit(UnitType.Miku));
            for (int i = 0; i < 10; i++)
            {
                PlayerArmy.addUnit(new Unit());
            }
            PlayerArmy.squads[0, 0].addUnit(0, firstUnit);
        }
    }
}
