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
        public Squad squad { get; set; }
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

        //custom unit; pretty much just for testing
        public Unit(UnitType type, TextureName picture, int health, int attack, int defense, int attackSpeed, int moveSpeed, int range, int maxTargets)
        {
            addStats(type, picture, health, attack, defense, attackSpeed, moveSpeed, range, maxTargets);
        }
        //unit from type string
        public Unit(string unitType) : this (Enum.TryParse(unitType, out UnitType type)? type : UnitType.Basic){}
        //unit from type
        public Unit(UnitType unitType)
        {
            //eventually load in unit types and stats from a file to make adding new ones easier
            switch (unitType)
            {
                case UnitType.Basic:
                    {
                        addStats(UnitType.Basic, TextureName.BasicDude, 100, 10, 5, 1, 2, 50, 1);
                        break;
                    }
                case UnitType.Miku:
                    {
                        addStats(UnitType.Miku, TextureName.MikuWarrior, 100, 10, 5, 1, 2, 50, 1);
                        Type = UnitType.Miku;
                        Picture = TextureName.MikuWarrior;
                        MaxHealth += 50;
                        Attack += 10;
                        AttackSpeed += 1;
                        break;
                    }
            }

        }
        //basic unit
        public Unit() : this(UnitType.Basic) { }

        private void addStats(UnitType type, TextureName picture, int health, int attack, int defense, int attackSpeed, int moveSpeed, int range, int maxTargets)
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
            Name = type.ToString();
        }
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
