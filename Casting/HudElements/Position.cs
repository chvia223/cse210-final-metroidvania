using System;
using System.Collections.Generic;
using cse210_final_metroidvania.Casting.HudElements;

namespace cse210_final_metroidvania.Casting.HudElements
{
    /// <summary>
    /// Will display the hero's current velocity.
    /// </summary>
    public class Position : HUD
    {
        // private int _health;


        public Position()
        {
            SetText(_text);
            SetPosition(new Point(20,80));
        }

        public override void Update(Hero hero)
        {
            _text = $"Position: ({Math.Round(hero.GetPosition().GetX())}, {Math.Round(hero.GetPosition().GetY())})";
        }


    }

}