using System.Collections.Generic;
using cse210_final_metroidvania.Casting;
using cse210_final_metroidvania.Services;


namespace cse210_final_metroidvania.Scripting
{
    /// <summary>
    /// An action to get user input and update actors accordingly.
    /// </summary>
    public class ControlActorsAction : Action
    {
        private InputService _inputService;
        private PhysicsService _physicsService;

        public ControlActorsAction(InputService inputService, PhysicsService physicsService)
        {
            _inputService = inputService;
            _physicsService = physicsService;
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            Point direction = _inputService.GetDirection();
            List<Actor> heros = cast["heros"];
            
            
            foreach (Hero hero in heros)
            {
                Point velocity = hero.GetVelocity();

                if (direction.GetX() == 1)
                {
                    hero.SetVelocity(new Point(Constants.HERO_SPEED, velocity.GetY()));
                }
                else if (direction.GetX() == -1)
                {
                    hero.SetVelocity(new Point(-Constants.HERO_SPEED, velocity.GetY()));
                }
                else
                {
                    // Do something with friction here
                    hero.SetVelocity(new Point(0, velocity.GetY()));
                }

                if (direction.GetY() == 1 && hero.CanJump())
                {
                    hero.SetCanJump(false);
                    _physicsService.ChangeAcceleration(hero, Constants.HERO_JUMP_ACCELERATION, "y");
                }
            }
        }
    }
}