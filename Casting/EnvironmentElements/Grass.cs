using System;
using cse210_final_metroidvania.Casting;

namespace cse210_final_metroidvania.Casting.EnvironmentElements
{
    /// <summary>
    /// Base class for all actors in the game.
    /// </summary>
    public class Grass : EnvElement
    {

        public Grass()
        {
            SetHeight(Constants.ENV_ELEMENT_HEIGHT);
            SetWidth(Constants.ENV_ELEMENT_WIDTH);
            // SetImage(Constants.IMAGE_GRASS);
            SetFrictionConstant(0.5);
            SetInteractSound(Constants.SOUND_LAND_ON_GRASS);
            SetGravity(false);
        }

    }

}