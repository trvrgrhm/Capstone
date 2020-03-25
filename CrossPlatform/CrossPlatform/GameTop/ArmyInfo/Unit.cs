using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop.ArmyInfo
{
    class Unit
    {
        public UnitType Type { get; set; }
        public bool IsInSquad { get; set; }
        public int MaxHealth { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int AttackSpeed { get; set; }
        public int MoveSpeed { get; set; }
        public int Range { get; set; }

        public Unit(UnitType type, int health, int attack, int defense, int attackSpeed, int moveSpeed, int range)
        {
            Type = type;
            IsInSquad = false;
            MaxHealth = health;
            Attack = attack;
            Defense = defense;
            AttackSpeed = attackSpeed;
            MoveSpeed = moveSpeed;
            Range = range;
        }

        public Unit() : this(UnitType.Basic, 100, 10, 5, 1, 1, 1) { }
    }

    
}


namespace CrossPlatform.GameTop
{
    public enum UnitType
    {
        Basic
    }
}
