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
            SetHeight(Constants.ENEMY_HEIGHT);
            SetWidth(Constants.ENEMY_WIDTH);
            // SetImage(Constants.IMAGE_HERO);
            SetPosition(new Point(700, 500 - Constants.ENEMY_HEIGHT));
            SetVelocity(new Point(Constants.ENEMY_SPEED, Constants.GRAVITY));
        }

        public void BasicRightAttack(Hero hero, PhysicsService physicsService)
        {
            physicsService.ChangeAcceleration(hero, Constants.BASIC_ENEMY_HIT_KNOCKBACK, "x");
            physicsService.ChangeAcceleration(hero, -Constants.BASIC_ENEMY_HIT_KNOCKBACK, "y");

            hero.SetHitState(true);
            hero.SetStunTime(BASIC_ATTACK_STUN_TIME);
            hero.LoseHealth(BASIC_ATTACK_DAMAGE);
        }

        public void BasicLeftAttack(Hero hero, PhysicsService physicsService)
        {
            physicsService.ChangeAcceleration(hero, -Constants.BASIC_ENEMY_HIT_KNOCKBACK, "xy");

            hero.SetHitState(true);
            hero.SetStunTime(BASIC_ATTACK_STUN_TIME);
            hero.LoseHealth(BASIC_ATTACK_DAMAGE);
        }


    }

}