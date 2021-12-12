using System;
using cse210_final_metroidvania.Casting;

namespace cse210_final_metroidvania.Casting.EnvironmentElements
{
    /// <summary>
    /// Base class for all actors in the game.
    /// </summary>
    public class WoodenCrate : EnvElement
    {

        public WoodenCrate()
        {
            SetHeight(Constants.ENV_ELEMENT_HEIGHT);
            SetWidth(Constants.ENV_ELEMENT_WIDTH);
            SetImage(Constants.IMAGE_WOODEN_CRATE);
            SetFrictionConstant(0.5);
            SetGravity(false);
        }

    }

}