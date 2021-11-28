using System;

namespace cse210_final_metroidvania.Casting
{
    /// <summary>
    /// Base class for all actors in the game.
    /// </summary>
    public class Hero : Actor
    {
        public Hero()
        {
            SetHeight(Constants.HERO_HEIGHT);
            SetWidth(Constants.HERO_WIDTH);
            SetImage(Constants.IMAGE_HERO);
            SetPosition(new Point(100, 100));
            SetVelocity(new Point(0, Constants.GRAVITY));
        }

    }

}