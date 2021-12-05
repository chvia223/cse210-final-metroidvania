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

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            List<Actor> heros = cast["heros"];
            List<Actor> floor = cast["floor"];


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

            foreach (Actor floor_piece in floor)
            {
                if (floor_piece.HasGravity())
                {
                    _physicsService.ChangeAcceleration(floor_piece, Constants.GRAVITY, "y");
                }
            }
        }
    }
}