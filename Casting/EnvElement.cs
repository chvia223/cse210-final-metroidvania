using System;

namespace cse210_final_metroidvania.Casting
{
    /// <summary>
    /// Base class for all actors in the game.
    /// </summary>
    public class EnvElement : Actor
    {
        private double _frictionConstant;
        private string _interactSound;

        public EnvElement()
        {
            SetHeight(Constants.ENV_ELEMENT_HEIGHT);
            SetWidth(Constants.ENV_ELEMENT_WIDTH);
            // SetImage(Constants.IMAGE_FLOOR);
            SetFrictionConstant(0.5);
            SetInteractSound(Constants.SOUND_LAND_ON_STONE);
            SetGravity(false);
        }

        public void SetFrictionConstant(double frictionConstant)
        {
            _frictionConstant = frictionConstant;
        }

        public double GetFrictionConstant()
        {
            return _frictionConstant;
        }

        public void SetInteractSound(string interactSound)
        {
            _interactSound = interactSound;
        }

        public string GetInteractSound()
        {
            return _interactSound;
        }
    }

}