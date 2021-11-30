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
                    hero.SetVelocity(new Point(5, velocity.GetY()));
                    // _physicsService.ChangeAcceleration(hero, 1, "x");
                }
                else if (direction.GetX() == -1)
                {
                    // hero.SetVelocity(new Point(0, velocity.GetY()));
                    hero.SetVelocity(new Point(-5, velocity.GetY()));
                    // _physicsService.ChangeAcceleration(hero, -1, "x");
                }
                else
                {
                    hero.SetVelocity(new Point(0, velocity.GetY()));
                    // _physicsService.ChangeAcceleration(hero, 0, "x");
                }

                if (direction.GetY()  == 1)
                {
                    _physicsService.ChangeAcceleration(hero, -2, "y");
                    // hero.SetGravity(true);
                }
            }
            // if (hero.GetRightEdge() > Constants.MAX_X)
            // {
            //     if (direction.GetX() == 1)
            //     {
            //         velocity.SetX(0);
            //     }
            //     else
            //     {
            //         velocity.SetX(Constants.PADDLE_SPEED);
            //     }
            // }
            // else if (hero.GetLeftEdge() < 0)
            // {
            //     if (direction.GetX() == -1)
            //     {
            //         velocity.SetX(0);
            //     }
            //     else
            //     {
            //         velocity.SetX(-Constants.PADDLE_SPEED);
            //     }    
            // }
            // else
            // {
            //     velocity.SetX(Constants.PADDLE_SPEED);
            // }
 
            
            // 
        }
        
    }
}