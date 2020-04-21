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
        public Unit(string unitType) : this (Enum.TryParse(unitType, out UnitType type)? type : UnitType.BasicDude){}
        //unit from type
        public Unit(UnitType unitType)
        {
            //eventually load in unit types and stats from a file to make adding new ones easier

            //add base stats
            addStats(unitType, Enum.TryParse(unitType.ToString(), out TextureName type) ? type : TextureName.BasicDude, 100, 10, 5, 1, 3, 10, 1);

            //adjust stats based on unit type
            switch (unitType)
            {

                case UnitType.BasicDude:
                    {
                        //addStats(UnitType.Basic, TextureName.BasicDude, 100, 10, 5, 1, 2, 10, 1);
                        //basic is base unit
                        break;
                    }
                case UnitType.Miku:
                    {
                        MaxHealth += 50;
                        Attack += 10;
                        AttackSpeed += 1;
                        break;
                    }
                case UnitType.Archer1:
                    {
                        //Picture = TextureName.Archer1;
                        Attack += -1;
                        AttackSpeed -= 1;
                        Range += 70;
                        break;
                    }
                case UnitType.Archer2:
                    {
                        //Picture = TextureName.Archer2;
                        MaxHealth -= 10;
                        Attack += -1;
                        AttackSpeed -= 1;
                        Range += 70;
                        break;
                    }
                case UnitType.Archer3:
                    {
                        //Picture = TextureName.Archer3;
                        MaxHealth -= 10;
                        Attack += -1;
                        AttackSpeed -= 1;
                        Range += 70;
                        break;
                    }
                case UnitType.Cyclop1:
                    {
                        //Picture = TextureName.Cyclop1;
                        MaxHealth += 30;
                        Attack += -1;
                        AttackSpeed -= 2;
                        Range += 10;
                        MaxTargets += 1;
                        break;
                    }
                case UnitType.Cyclop2:
                    {
                        //Picture = TextureName.Cyclop2;
                        MaxHealth += 30;
                        Attack += -1;
                        AttackSpeed -= 2;
                        Range += 10;
                        MaxTargets += 1;
                        break;
                    }
                case UnitType.Cyclop3:
                    {
                        //Picture = TextureName.Cyclop3;
                        MaxHealth += 30;
                        Attack += -1;
                        AttackSpeed -= 2;
                        Range += 10;
                        MaxTargets += 1;
                        break;
                    }
                case UnitType.Demon1:
                    {
                        //Picture = TextureName.Demon1;
                        MaxHealth += 20;
                        Attack += 3;
                        AttackSpeed += 2;
                        Range += 5;
                        break;
                    }
                case UnitType.Demon2:
                    {
                        //Picture = TextureName.Demon1;
                        MaxHealth += 20;
                        Attack += 3;
                        AttackSpeed += 2;
                        Range += 5;
                        break;
                    }
                case UnitType.Demon3:
                    {
                        //Picture = TextureName.Demon1;
                        MaxHealth += 20;
                        Attack += 3;
                        AttackSpeed += 2;
                        Range += 5;
                        break;
                    }
                case UnitType.Goblin1| UnitType.Goblin2 | UnitType.Goblin3:
                    {
                        MaxHealth -= 20;
                        Attack -= 3;
                        AttackSpeed += 3;
                        Range += 5;
                        break;
                    }
                case UnitType.Knight1 | UnitType.Knight2 | UnitType.Knight3:
                    {
                        MaxHealth += 20;
                        AttackSpeed += 3;
                        Range += 5;
                        break;
                    }
                case UnitType.Orc1 | UnitType.Orc2 | UnitType.Orc3:
                    {
                        MaxHealth += 20;
                        AttackSpeed += 3;
                        Range += 5;
                        break;
                    }
                case UnitType.Skull1 | UnitType.Skull2 | UnitType.Skull3:
                    {
                        MaxHealth -= 30;
                        AttackSpeed += 4;
                        Range += 5;
                        break;
                    }

            }

        }
        //basic unit
        public Unit() : this(UnitType.BasicDude) { }

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

        Archer1,
        Archer2,
        Archer3,
        Cyclop1,
        Cyclop2,
        Cyclop3,
        Demon1,
        Demon2,
        Demon3,
        Goblin1,
        Goblin2,
        Goblin3,
        Knight1,
        Knight2,
        Knight3,
        Orc1,
        Orc2,
        Orc3,
        Skull1,
        Skull2,
        Skull3,
        BasicDude,
        Miku
    }
}
