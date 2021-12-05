using System.Collections.Generic;
using cse210_final_metroidvania.Services;
using cse210_final_metroidvania.Casting;

namespace cse210_final_metroidvania
{
    public class FrictionAction : Action
    {
        private PhysicsService _physicsService = new PhysicsService();

        public FrictionAction(PhysicsService physicsService)
        {
            _physicsService = physicsService;
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            List<Actor> heros = cast["heros"];


            foreach (Actor hero in heros)
            {
                if (!hero.IsOnGround())
                {
                    if (hero.GetVelocity().GetX() > 0)
                    {
                        if (hero.GetVelocity().GetX() - Constants.AIR_RESISTANCE < 0)
                        {
                            hero.SetVelocity(new Point(0, hero.GetVelocity().GetY()));
                        }
                        else
                        {
                            _physicsService.ChangeAcceleration(hero, -Constants.AIR_RESISTANCE, "x");
                        }
                    }
                    else if (hero.GetVelocity().GetX() < 0)
                    {
                        if (hero.GetVelocity().GetX() + Constants.AIR_RESISTANCE > 0)
                        {
                            hero.SetVelocity(new Point(0, hero.GetVelocity().GetY()));
                        }
                        else
                        {
                            _physicsService.ChangeAcceleration(hero, Constants.AIR_RESISTANCE, "x");
                        }
                    }
                    else
                    {
                        hero.SetVelocity(new Point(0, hero.GetVelocity().GetY()));
                    }
                }
            }
        }
    }
}