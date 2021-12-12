using System;
using System.Collections.Generic;
using cse210_final_metroidvania.Casting.HudElements;


namespace cse210_final_metroidvania.Casting.HudElements
{
    /// <summary>
    /// Base class for all HUD elements.
    /// </summary>
    public abstract class HUD : Actor
    {
        public abstract void Update(Hero hero);
    }

}