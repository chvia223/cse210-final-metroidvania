using System;
using System.Collections.Generic;
using cse210_final_metroidvania.Casting.HudElements;

namespace cse210_final_metroidvania.Casting.HudElements
{
    /// <summary>
    /// Will display the hero's currently set equipped weapon
    /// </summary>
    public class EquippedWeapon : HUD
    {

        public EquippedWeapon()
        {
            SetText(_text);
            SetPosition(new Point(1000,20));
        }

        public override void Update(Hero hero)
        {
            _text = $"Weapon: {hero.GetEquippedWeapon()}";
        }

    }

}