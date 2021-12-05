using System;

namespace cse210_final_metroidvania.Casting
{
    /// <summary>
    /// Base class for all actors in the game.
    /// </summary>
    public class HUD : Actor
    {
        // private int _health;

        public HUD()
        {
            SetText(_text);
            SetPosition(new Point(20,20));
        }

        public void UpdateHealth(Hero hero)
        {
            _text = $"Health: {hero.GetHealth()}";
        }


    }

}