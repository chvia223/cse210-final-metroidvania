using System;
using System.Collections.Generic;
using cse210_final_metroidvania.Casting.HudElements;

namespace cse210_final_metroidvania.Casting.HudElements
{
    /// <summary>
    /// Will display the hero's current health.
    /// </summary>
    public class Health : HUD
    {
        // private int _health;


        public Health()
        {
            SetText(_text);
            SetPosition(new Point(20,20));
        }

        public override void Update(Hero hero)
        {
            _text = $"Health: {hero.GetHealth()}";
        }


    }

}