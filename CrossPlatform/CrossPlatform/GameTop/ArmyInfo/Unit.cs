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
        public TextureName Picture { get; set; }
        public bool IsInSquad { get; set; }
        public int SquadPosition { get; set; }
        public int MaxHealth { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int AttackSpeed { get; set; }
        public int MoveSpeed { get; set; }
        public int Range { get; set; }
        public int MaxTargets { get; set; }
        public int Size { get; set; }
        public string Name { get; set; }

        public Unit(UnitType type, TextureName picture, int health, int attack, int defense, int attackSpeed, int moveSpeed, int range, int maxTargets)
        {
            Type = type;
            IsInSquad = false;
            SquadPosition = -1;
            MaxHealth = health;
            Attack = attack;
            Defense = defense;
            AttackSpeed = attackSpeed;
            MoveSpeed = moveSpeed;
            Range = range;
            MaxTargets = maxTargets;
            //get this from type in the future
            Picture = picture;
            Size = 7;
            Name = "Basic Unit";

        }

        public Unit() : this(UnitType.Basic,TextureName.BasicDude, 100, 10, 5, 1, 4, 5, 1) { }
    }

    
}


namespace CrossPlatform.GameTop
{
    public enum UnitType
    {
        Basic,
        Miku
    }
}
