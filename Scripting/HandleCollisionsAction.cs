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
                    // _physicsService.HeroBottomToTopCollision(hero, floor_piece);
                    // _physicsService.HeroRightToLeftCollision(hero, floor_piece);

                    if (_physicsService.IsCollision(hero, floor_piece))
                    {
                        if (_physicsService.IsBottomCollision(hero, floor_piece))
                        {
                            _physicsService.HeroBottomToTopCollision(hero, floor_piece);
                        }
                        else if (_physicsService.IsTopCollision(hero, floor_piece))
                        {
                            _physicsService.HeroTopToBottomCollision(hero, floor_piece);
                        }
                        else if (_physicsService.IsRightCollision(hero, floor_piece))
                        {
                            _physicsService.HeroRightToLeftCollision(hero, floor_piece);
                        }
                        else if (_physicsService.IsLeftCollision(hero, floor_piece))
                        {
                            _physicsService.HeroLeftToRightCollision(hero, floor_piece);
                        }
                        
                        
                    }
                    else
                    {
                        // hero.SetGravity(true);
                    }
                }
            }

            ActorsCleanUp(cast);
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