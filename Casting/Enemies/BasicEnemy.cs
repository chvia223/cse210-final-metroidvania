using System;
using cse210_final_metroidvania.Services;

namespace cse210_final_metroidvania.Casting.Enemies
{
    /// <summary>
    /// Base class for all actors in the game.
    /// </summary>
    public class BasicEnemy : Enemy
    {
        private const int BASIC_ATTACK_DAMAGE = 10;
        private const int BASIC_ATTACK_STUN_TIME = 20;

        public BasicEnemy()
        {
            SetHeight(Constants.ENEMY_HEIGHT);
            SetWidth(Constants.ENEMY_WIDTH);
            // SetImage(Constants.IMAGE_HERO);
            SetPosition(new Point(700, 500 - Constants.ENEMY_HEIGHT));
            SetVelocity(new Point(Constants.ENEMY_SPEED, Constants.GRAVITY));
            SetCanBounceOffEnv(true);
        }

        public override void RightAttack(Hero hero, PhysicsService physicsService)
        {
            physicsService.ChangeAcceleration(hero, Constants.BASIC_ENEMY_HIT_KNOCKBACK, "x");
            physicsService.ChangeAcceleration(hero, -Constants.BASIC_ENEMY_HIT_KNOCKBACK, "y");

            hero.SetHitState(true);
            hero.SetStunTime(BASIC_ATTACK_STUN_TIME);
            hero.LoseHealth(BASIC_ATTACK_DAMAGE);
        }

        public override void LeftAttack(Hero hero, PhysicsService physicsService)
        {
            physicsService.ChangeAcceleration(hero, -Constants.BASIC_ENEMY_HIT_KNOCKBACK, "xy");

            hero.SetHitState(true);
            hero.SetStunTime(BASIC_ATTACK_STUN_TIME);
            hero.LoseHealth(BASIC_ATTACK_DAMAGE);
        }


    }

}