using System.Collections.Generic;
using cse210_final_metroidvania.Casting;
using cse210_final_metroidvania.Services;

namespace cse210_final_metroidvania
{
    public class GravityAction : Action
    {
        private PhysicsService _physicsService = new PhysicsService();

        public GravityAction(PhysicsService physicsService)
        {
            _physicsService = physicsService;
        }

        public override string Execute(Dictionary<string, List<Actor>> cast)
        {
            List<Actor> heros = cast["heros"];
            List<Actor> envElements = cast["envElements"];


            foreach (Actor hero in heros)
            {
                if (hero.HasGravity())
                {
                    if (hero.GetVelocity().GetY() < Constants.TERMINAL_VELOCITY)
                    {
                        _physicsService.ChangeAcceleration(hero, Constants.GRAVITY, "y");
                    }
                }
            }

            foreach (Actor floor in envElements)
            {
                if (floor.HasGravity())
                {
                    _physicsService.ChangeAcceleration(floor, Constants.GRAVITY, "y");
                }
            }

            return _newRoom;
        }
    }
}