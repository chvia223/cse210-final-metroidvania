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

        public ControlActorsAction(InputService inputService)
        {
            _inputService = inputService;
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            Point direction = _inputService.GetDirection();
            Actor hero = cast["heros"][0];
            Point velocity = hero.GetVelocity();


            if (direction.GetX() == 1)
            {
                hero.SetVelocity(new Point(Constants.PADDLE_SPEED, velocity.GetY()));
            }
            else if (direction.GetX() == -1)
            {
                hero.SetVelocity(new Point(-Constants.PADDLE_SPEED, velocity.GetY()));
            }
            else
            {
                hero.SetVelocity(new Point(0, velocity.GetY()));
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