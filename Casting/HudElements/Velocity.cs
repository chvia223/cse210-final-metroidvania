using System;
using System.Collections.Generic;
using cse210_final_metroidvania.Casting.HudElements;

namespace cse210_final_metroidvania.Casting.HudElements
{
    /// <summary>
    /// Will display the hero's current velocity.
    /// </summary>
    public class Velocity : HUD
    {
        // private int _health;


        public Velocity()
        {
            SetText(_text);
            SetPosition(new Point(20,50));
        }

        public override void Update(Hero hero)
        {
            _text = $"Velocity: {hero.GetVelocity().GetX():0,0.00}";
        }


    }

}