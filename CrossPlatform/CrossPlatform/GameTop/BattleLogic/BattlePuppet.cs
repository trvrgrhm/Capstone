using CrossPlatform.GameTop.ArmyInfo;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop.BattleLogic
{
    class BattlePuppet
    {
        Battle battle;
        public Unit Unit { get; set; }
        public Rectangle ImageBox { get; set; }
        public Rectangle HitBox { get; set; }
        //movement
        public Point Destination { get; set; }
        public int CurrentX { get; set; }
        public int CurrentY { get; set; }
        public int CurrentDX { get; set; }
        public int CurrentDY { get; set; }
        //battle logic
        public int CurrentHealth { get; set; }
        public bool isDead;
        public int CurrentDamageReceived { get; set; }
        public List<BattlePuppet> Enemies { get; set; }
        public List<BattlePuppet> BattleTargets { get; set; }
        //public BattlePuppet CurrentTarget { get; set; }
        public BattlePuppetState CurrentState { get; set; }
        public int sightRange;

        bool overridingTarget;

        //delays
        public int dyingDelay;
        public int attackDelay;
        public int idleDelay;
        public bool battleOver;

        //for now

        public BattlePuppet(Battle battle, Unit unit, int initialX, int initialY, Point initialDestination)
        {
            this.battle = battle;
            Unit = unit;
            CurrentHealth = unit.MaxHealth;
            isDead = false;
            CurrentX = initialX;
            CurrentY = initialY;
            CurrentDX = 0;
            CurrentDY = 0;
            BattleTargets = new List<BattlePuppet>();
            Enemies = new List<BattlePuppet>();
            ImageBox = new Rectangle(initialX, initialY, Unit.Size*5, Unit.Size*5);
            HitBox = ImageBox;
            CurrentState = BattlePuppetState.Walking;
            Destination = initialDestination;
            sightRange = 200;
            battleOver = false;
            overridingTarget = false;
        }
        //other things can request this puppet to take damage
        public void dealDamage(int amount)
        {
            //TODO: augment by unit def
            CurrentDamageReceived += amount;
        }
        public void checkTarget(BattlePuppet enemy)
        {
            if (distance(enemy.HitBox.Center) <= sightRange)
            {
                BattleTargets.Add(enemy);
            }
        }

        public void update()
        {
            if (!battleOver)
            {
                if (CurrentState == BattlePuppetState.Dead)
                {
                    Console.WriteLine("character has completely died");

                }
                else if (CurrentState == BattlePuppetState.Dying)
                {
                    if (dyingDelay == 0)
                    {
                        CurrentState = BattlePuppetState.Dead;
                    }
                    else
                    {
                        dyingDelay--;
                    }
                }
                else if (CurrentState == BattlePuppetState.Walking)
                {
                    if (inRangeOfTarget())
                    {
                        beginAttackState();
                    }
                    else
                    {
                        updateTarget();
                        move();
                    }
                    damageSelf();
                    checkDeath();
                }
                else if (CurrentState == BattlePuppetState.Idle)
                {
                    if (inRangeOfTarget() && idleDelay == 0)
                    {
                        beginAttackState();
                    }
                    else
                    {
                        idleDelay--;
                    }
                    damageSelf();
                    checkDeath();
                }
                else if (CurrentState == BattlePuppetState.Attacking)
                {
                    if (attackDelay == 0)
                    {
                        beginIdleState();
                    }
                    else
                    {
                        attackDelay--;
                    }
                    damageSelf();
                    checkDeath();
                }
            }
            if (battleOver)
            {
                battle.battleOver = true;
            }
        }
        void beginIdleState()
        {
            Console.WriteLine("beginning idle state");
            CurrentState = BattlePuppetState.Idle;
            //TODO: augment by attack speed
            idleDelay = 10;
        }
        void beginAttackState()
        {
            Console.WriteLine("beginning attack state");
            damageEnemy();
            CurrentState = BattlePuppetState.Attacking;
            attackDelay = 5;
            //TODO: augment by animation
        }
        void beginDyingState()
        {
            Console.WriteLine("beginning dying state");
            CurrentState = BattlePuppetState.Dying;
            dyingDelay = 10;
            //TODO: augment by animation
        }
        //if target is in hitting range
        bool inRangeOfTarget()
        {
            //remove dead or out of range targets
            BattleTargets.RemoveAll(target => target.isDead || target.distance(HitBox.Center) > sightRange);
            BattleTargets.OrderBy(target => target.distance(HitBox.Center));

            if (BattleTargets.Count >0)
            {
                if (distance(BattleTargets[0].HitBox.Center) <= Unit.Range)
                {
                    return true;
                }
            }
            else
            {
                CurrentState = BattlePuppetState.Walking;
            }
            return false;
        }
        //returns distance from this puppet's center
        public int distance(Point destination)
        {
            int result = (int)Math.Sqrt( Math.Pow((destination.X -HitBox.Center.X),2) + Math.Pow((destination.Y - HitBox.Center.Y),2));
            return result;
        }
        
        void damageEnemy()
        {
            //damage as many enemies in range as possible
                int counter = Unit.MaxTargets;
            foreach (BattlePuppet target in BattleTargets)
            {
                if (counter >= 0)
                {
                    target.dealDamage(Unit.Attack);
                    counter--;
                }
            }
        }
        void damageSelf()
        {
            CurrentHealth -= CurrentDamageReceived;
            CurrentDamageReceived = 0;
        }
        void checkDeath()
        {
            if(CurrentHealth <= 0){
                isDead = true;
                beginDyingState();
            }
        }
        void updateTarget()
        {
            if (overridingTarget)
            {
                if (distance(Destination)<=10)
                {
                    //successfully reached target;
                    overridingTarget = false;
                }
            }
            else
            {
                //remove dead or out of range targets
                BattleTargets.RemoveAll(target => target.isDead || target.distance(HitBox.Center) > sightRange);
                BattleTargets.OrderBy(target => target.distance(HitBox.Center));
                if (BattleTargets.Count > 0)
                {
                    //target nearest target
                    Destination = BattleTargets[0].HitBox.Center;
                }
                else
                {
                    Enemies.RemoveAll(target => target.isDead);
                    if (Enemies.Count > 0)
                    {
                        Enemies.OrderBy(target => target.distance(HitBox.Center));
                        //Destination = Enemies[0].HitBox.Center;
                        foreach (BattlePuppet enemy in Enemies)
                        {
                            checkTarget(enemy);
                        }
                    }
                    else
                    {
                        //no enemies, hoooraaaay!!
                        CurrentState = BattlePuppetState.Idle;
                        battleOver = true;

                        //Destination = HitBox.Center;
                    }
                }
            }
        }
        void move()
        {
            //adjust velocity toward destination
            if (!(distance(Destination) <= 5))
            {
                CurrentDX = (int)((1.0 * (Unit.MoveSpeed) / distance(Destination)) * (Destination.X - HitBox.Center.X));
                CurrentDY = (int)((1.0 * (Unit.MoveSpeed) / distance(Destination)) * (Destination.Y - HitBox.Center.Y));
                CurrentX += CurrentDX;
                CurrentY += CurrentDY;
                ImageBox = new Rectangle(ImageBox.X + CurrentDX, ImageBox.Y + CurrentDY, ImageBox.Width, ImageBox.Height);
                HitBox = new Rectangle(HitBox.X + CurrentDX, HitBox.Y + CurrentDY, HitBox.Width, ImageBox.Height);
            }
        }

        public void overrideTarget(Point targetPosition)
        {
            overridingTarget = true;
            BattleTargets.Clear();
            CurrentState = BattlePuppetState.Walking;
            Destination = targetPosition;
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
