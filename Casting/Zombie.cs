using System;

namespace cse210_final_metroidvania.Casting
{
    /// <summary>
    /// Base class for all actors in the game.
    /// </summary>
    public class Zombie : Actor
    {
        public Zombie()
        {
            SetHeight(Constants.HERO_HEIGHT);
            SetWidth(Constants.HERO_WIDTH);
            SetImage(Constants.IMAGE_HERO);
            SetPosition(new Point(200, 100));
            SetVelocity(new Point(0, Constants.GRAVITY));
        }

    }

}