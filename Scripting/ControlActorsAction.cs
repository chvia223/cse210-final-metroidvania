using System.Collections.Generic;
using System;
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

        public override string Execute(Dictionary<string, List<Actor>> cast)
        {
            Point direction = _inputService.GetDirection();
            List<Actor> heros = cast["heros"];
            
            // HERO CONTROLS
            foreach (Hero hero in heros)
            {
                // This is in place to prevent player movement when an enemy attacks them. Each
                // enemy will be able to provide it's own amount of stun time for it's unique
                // attacks dynamically changing the wait time for movement to be unlocked. The
                // hero's hit state is also set to false allow the hero to be effected by an
                // enemy attack again. This is to prevent the potential for hit locking.
                if (hero.GetStunTime() == 0)
                {
                    hero.SetHitState(false);
                    Point velocity = hero.GetVelocity();
                    double dx = velocity.GetX();
                    double dy = velocity.GetY();

                    // If right arrow was pressed
                    if (direction.GetX() == 1)
                    {
                        Console.WriteLine("Right Arrow");
                        // Will make sure the hero only accelerates is they are below max speed and on ground.
                        // Otherwise they will move max speed. This was done to put a cap on the max speed and
                        // also so the player will be able to immediately change directions while in mid air.
                        if (hero.GetVelocity().GetX() < Constants.HERO_SPEED -1 && hero.IsOnGround())
                        {
                            _physicsService.ChangeAcceleration(hero, hero.GetAcceleration(), "x");
                        }
                        else
                        {
                            hero.SetVelocity(new Point(Constants.HERO_SPEED, velocity.GetY()));
                        }
                    }
                    // If left arrow was pressed
                    else if (direction.GetX() == -1)
                    {
                        Console.WriteLine("Left Arrow");
                        // Will make sure the hero only accelerates is they are below max speed and on ground.
                        // Otherwise they will move max speed. This was done to put a cap on the max speed and
                        // also so the player will be able to immediately change directions while in mid air.
                        if (hero.GetVelocity().GetX() > -Constants.HERO_SPEED +1 && hero.IsOnGround())
                        {
                            _physicsService.ChangeAcceleration(hero, -hero.GetAcceleration(), "x");
                        }
                        else
                        {
                            hero.SetVelocity(new Point(-Constants.HERO_SPEED, velocity.GetY()));
                        }
                    }

                    // Will do a large amount of things when the hero jumps. A state that allows them to
                    // jump will be flipped to false. This is to prevent the player from continuously
                    // jumping while in the air. An onGround state will be set to false because they are
                    // no longer on the ground. This mainly effects how movement works. See above for it's
                    // use case. An gravity state is set to true. This adds a continuous negative acceleration
                    // on the players vertical movement to allow an arching jump. The hero's base accleration 
                    // is then set to the acceleration of the constant. I may move this to be inside the
                    // hero.
                    if (direction.GetY() == 1 && hero.CanJump())
                    {
                        hero.SetCanJump(false);
                        hero.SetOnGround(false);
                        hero.SetGravity(true);
                        _physicsService.ChangeAcceleration(hero, Constants.HERO_JUMP_ACCELERATION, "y");
                    }
                }
                else
                {
                    hero.CountDownStun();
                }
            }

            return _newRoom;
        }
    }
}