using System;
using cse210_final_metroidvania.Casting;

namespace cse210_final_metroidvania.Casting.EnvironmentElements
{
    /// <summary>
    /// Base class for all actors in the game.
    /// </summary>
    public class Door : EnvElement
    {
        private string _newRoomName;
        private Point _newHeroPosition;

        public Door()
        {
            SetHeight(Constants.ENV_ELEMENT_HEIGHT);
            SetWidth(5);
            // SetImage(Constants.IMAGE_FLOOR);
            SetGravity(false);
        }

        public string GetNewRoomName()
        {
            return _newRoomName;
        }

        public void SetNewRoomName(string newRoomName)
        {
            _newRoomName = newRoomName;
        }

        public Point GetNewHeroPosition()
        {
            return _newHeroPosition;
        }

        public void SetNewHeroPosition(Point newHeroPosition)
        {
            _newHeroPosition = newHeroPosition;
        }

    }

}