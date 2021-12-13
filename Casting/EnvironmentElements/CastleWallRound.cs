using System;
using cse210_final_metroidvania.Casting;

namespace cse210_final_metroidvania.Casting.EnvironmentElements
{
    /// <summary>
    /// Base class for all actors in the game.
    /// </summary>
    public class CastleWallRound : EnvElement
    {

        public CastleWallRound()
        {
            SetHeight(Constants.ENV_ELEMENT_HEIGHT);
            SetWidth(Constants.ENV_ELEMENT_WIDTH);
            // SetImage(Constants.IMAGE_CASTLEWALLROUND);
            SetFrictionConstant(0.5);
            SetInteractSound(Constants.SOUND_LAND_ON_STONE);
            SetGravity(false);
        }

    }

}