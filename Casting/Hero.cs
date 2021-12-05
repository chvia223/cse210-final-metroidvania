using System;

namespace cse210_final_metroidvania.Casting
{
    /// <summary>
    /// Base class for all actors in the game.
    /// </summary>
    public class Hero : Actor
    {
        private bool _isHit = false;
        private int _health;
        private int _stunTime = 0;

        public Hero()
        {
            SetHeight(Constants.HERO_HEIGHT);
            SetWidth(Constants.HERO_WIDTH);
            SetImage(Constants.IMAGE_HERO);
            SetHealth(100);
            SetPosition(new Point(100, 100));
            SetVelocity(new Point(0, 0));
            SetGravity(true);
        }

        public int GetHealth()
        {
            return _health;
        }

        public void SetHealth(int health)
        {
            _health = health;
        }

        public void SetHitState(bool hit)
        {
            _isHit = hit;
        }

        public bool IsHit()
        {
            return _isHit;
        }

        public void LoseHealth(int healthLost)
        {
            _health -= healthLost;
        }

        public void GainHealth(int healthGained)
        {
            _health += healthGained;
        }

        public void CountDownStun()
        {
            _stunTime -= 1;
        }

        public int GetStunTime()
        {
            return _stunTime;
        }

        public void SetStunTime(int stunTime)
        {
            _stunTime = stunTime;
        }
    }

}