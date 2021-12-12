using System;
using cse210_final_metroidvania.Services;

namespace cse210_final_metroidvania.Casting
{
    /// <summary>
    /// Base class for all actors in the game.
    /// </summary>
    public class Enemy : Actor
    {
        private const int BASIC_ATTACK_DAMAGE = 10;
        private const int BASIC_ATTACK_STUN_TIME = 20;

        public Enemy()
        {
            
        }

        public virtual void RightAttack(Hero hero, PhysicsService physicsService)
        {
            physicsService.ChangeAcceleration(hero, Constants.BASIC_ENEMY_HIT_KNOCKBACK, "x");
            physicsService.ChangeAcceleration(hero, -Constants.BASIC_ENEMY_HIT_KNOCKBACK, "y");

            hero.SetHitState(true);
            hero.SetStunTime(BASIC_ATTACK_STUN_TIME);
            hero.LoseHealth(BASIC_ATTACK_DAMAGE);
        }

        public virtual void LeftAttack(Hero hero, PhysicsService physicsService)
        {
            physicsService.ChangeAcceleration(hero, -Constants.BASIC_ENEMY_HIT_KNOCKBACK, "xy");

            hero.SetHitState(true);
            hero.SetStunTime(BASIC_ATTACK_STUN_TIME);
            hero.LoseHealth(BASIC_ATTACK_DAMAGE);
        }


    }

}