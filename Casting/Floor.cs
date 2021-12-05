using System;

namespace cse210_final_metroidvania.Casting
{
    /// <summary>
    /// Base class for all actors in the game.
    /// </summary>
    public class Floor : Actor
    {
        private double _frictionConstant;

        public Floor()
        {
            SetHeight(Constants.FLOOR_HEIGHT);
            SetWidth(Constants.FLOOR_WIDTH);
            SetImage(Constants.IMAGE_FLOOR);
            SetFrictionConstant(0.9);
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
    }

}