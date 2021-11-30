using System.Collections.Generic;
using cse210_final_metroidvania.Casting;
using cse210_final_metroidvania.Services;
using System;


namespace cse210_final_metroidvania
{
    public class HandleCollisionsAction : Action
    {
        private AudioService _audioService = new AudioService();
        private PhysicsService _physicsService = new PhysicsService();
        private List<Actor> _bricksToRemove = new List<Actor>();
        private List<Actor> _ballsToRemove = new List<Actor>();
        
        public HandleCollisionsAction(PhysicsService physicsService, AudioService audioService)
        {
            _physicsService = physicsService;
            _audioService = audioService;
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            List<Actor> heros = cast["heros"];
            List<Actor> floor = cast["floor"];

 
            foreach (Hero hero in heros)
            {
                foreach (Actor floor_piece in floor)
                {
                    HandleCollision(hero, floor_piece);
                }
            }

            ActorsCleanUp(cast);
        }

        private void HandleCollision(Actor first, Actor second)
        {
            if (_physicsService.IsCollision(first, second))
            {
                Point overlap = _physicsService.GetCollisionOverlap(first, second);

                if (overlap.GetX() != 0 && overlap.GetY() != 0)
                {
                    if (Math.Abs(overlap.GetX()) < Math.Abs(overlap.GetY()))
                    {
                        if (overlap.GetX() > 0)
                        {
                            // Collision left of second actor
                            Console.WriteLine("left side collision");
                            _physicsService.HandleLeftCollision(first, second);
                        }
                        else
                        {
                            // Collision right of second actor
                            Console.WriteLine("right side collision");
                            _physicsService.HandleRightCollision(first, second);
                        }
                    }
                    else
                    {
                        if (overlap.GetY() > 0)
                        {
                            // Collision top of second actor
                            Console.WriteLine("top side collision");
                            _physicsService.HandleTopCollision(first, second);
                            if (first.GetType() == typeof(Hero))
                            {
                                first.SetCanJump(true);
                            }
                        }
                        else
                        {
                            // Collision bottom of second actor
                            Console.WriteLine("bottom side collision");
                            _physicsService.HandleBottomCollision(first, second);
                        }
                    }
                }
            }
        }

        private void ActorsCleanUp(Dictionary<string, List<Actor>> cast)
        {
            foreach (Actor brick in _bricksToRemove)
            {
                cast["bricks"].Remove(brick);
            }

            foreach (Actor ball in _ballsToRemove)
            {
                cast["balls"].Remove(ball);
            }

            _ballsToRemove.Clear();
            _bricksToRemove.Clear();
        }
    }
}