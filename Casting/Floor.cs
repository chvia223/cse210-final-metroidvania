using System;

namespace cse210_final_metroidvania.Casting
{
    /// <summary>
    /// Base class for all actors in the game.
    /// </summary>
    public class Floor : Actor
    {
        public Floor()
        {
            SetHeight(Constants.FLOOR_HEIGHT);
            SetWidth(Constants.FLOOR_WIDTH);
            SetImage(Constants.IMAGE_FLOOR);
            SetGravity(false);
        }

    }

}