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
        public List<BattlePuppet> BattleTargets { get; set; }
        public BattlePuppetState CurrentState { get; set; }
        public int sightRange;

        //delays
        public int dyingDelay;
        public int attackDelay;
        public int idleDelay;

        //for now

        public BattlePuppet(Unit unit, int initialX, int initialY, Point initialDestination)
        {
            Unit = unit;
            CurrentHealth = unit.MaxHealth;
            isDead = false;
            CurrentX = initialX;
            CurrentY = initialY;
            CurrentDX = 0;
            CurrentDY = 0;
            BattleTargets = new List<BattlePuppet>();
            ImageBox = new Rectangle(initialX, initialY, Unit.Size*5, Unit.Size*5);
            HitBox = ImageBox;
            CurrentState = BattlePuppetState.Walking;
            Destination = initialDestination;
            sightRange = 200;
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
            if (CurrentState == BattlePuppetState.Dead)
            {
                
            }
            else if (CurrentState == BattlePuppetState.Dying)
            {
                if (dyingDelay == 0)
                {
                    CurrentState = BattlePuppetState.Dead;
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
                if(inRangeOfTarget() && idleDelay == 0)
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
                if(attackDelay == 0)
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
        void beginIdleState()
        {
            CurrentState = BattlePuppetState.Idle;
            //TODO: augment by attack speed
            idleDelay = 10;
        }
        void beginAttackState()
        {
            damageEnemy();
            CurrentState = BattlePuppetState.Attacking;
            attackDelay = 5;
            //TODO: augment by animation
        }
        void beginDyingState()
        {
            dyingDelay = 10;
            //TODO: augment by animation
        }
        bool inRangeOfTarget()
        {
            if (BattleTargets.Count >0)
            {
                if (distance(BattleTargets[0].HitBox.Center) <= Unit.Range)
                {
                    return true;
                }
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
            foreach (BattlePuppet target in BattleTargets) {
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
            //remove dead or out of range targets
            BattleTargets.RemoveAll(target => target.isDead || target.distance(HitBox.Center) > sightRange);
            if(BattleTargets.Count > 0)
            {
                //target first target
                Destination = BattleTargets[0].HitBox.Center;
            }
        }
        void move()
        {
            //adjust velocity toward destination
            CurrentDX = (int)((1.0 *(Unit.MoveSpeed) / distance(Destination)) * (Destination.X - HitBox.Center.X));
            CurrentDY = (int)((1.0*(Unit.MoveSpeed) / distance(Destination)) * (Destination.Y - HitBox.Center.Y));
            CurrentX += CurrentDX;
            CurrentY += CurrentDY;
            ImageBox = new Rectangle(ImageBox.X + CurrentDX, ImageBox.Y + CurrentDY, ImageBox.Width, ImageBox.Height);
            HitBox = new Rectangle(HitBox.X + CurrentDX, HitBox.Y + CurrentDY, HitBox.Width, ImageBox.Height);
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
