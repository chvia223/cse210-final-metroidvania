using System;
using cse210_final_metroidvania.Casting;

namespace cse210_final_metroidvania.Casting.EnvironmentElements
{
    /// <summary>
    /// Base class for all actors in the game.
    /// </summary>
    public class Brick : EnvElement
    {

        public Brick()
        {
            SetHeight(Constants.ENV_ELEMENT_HEIGHT);
            SetWidth(Constants.ENV_ELEMENT_WIDTH);
            SetImage(Constants.IMAGE_BRICK);
            SetFrictionConstant(0.5);
            SetInteractSound(Constants.SOUND_LAND_ON_STONE);
            SetGravity(false);
        }

    }

}