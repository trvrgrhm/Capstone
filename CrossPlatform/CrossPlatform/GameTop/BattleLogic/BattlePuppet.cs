using CrossPlatform.GameTop.ArmyInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop.BattleLogic
{
    class BattlePuppet
    {
        Unit Unit { get; set; }
        public int CurrentHealth { get; set; }
        public int CurrentX { get; set; }
        public int CurrentY { get; set; }
        public int CurrentDX { get; set; }
        public int CurrentDY { get; set; }

        public BattlePuppet(Unit unit, int initialX, int initialY)
        {
            Unit = unit;
            CurrentHealth = unit.MaxHealth;
            CurrentX = initialX;
            CurrentY = initialY;
            CurrentDX = 0;
            CurrentDY = 0;
        }

    }

    public enum BattlePuppetState
    {
        Idle,
        Walking,
        Attacking,
        TakingDamage,
        Dying,
        Dead,
    }
}
