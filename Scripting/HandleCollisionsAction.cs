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
        private List<Actor> _environmentElementsToRemove = new List<Actor>();
        private List<Actor> _enemiesToRemove = new List<Actor>();
        
        public HandleCollisionsAction(PhysicsService physicsService, AudioService audioService)
        {
            _physicsService = physicsService;
            _audioService = audioService;
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            List<Actor> heros = cast["heros"];
            List<Actor> floor = cast["floor"];
            List<Actor> enemies = cast["enemies"];
            List<Actor> huds = cast["hud"];
            
            // HUD hud = new HUD();
            // hud = (HUD)hudActor;

            // This foreach loop is rediculous. I need the hud to act like a HUD not an Actor
            foreach (HUD hud in huds)
            {
                foreach (Hero hero in heros)
                {
                    // loop through hero/floor collisions
                    foreach (Floor floor_piece in floor)
                    {
                        HandleStaticEnvironmentCollision(hero, floor_piece);
                    }
                    // loop through hero/enemy collisions
                    foreach (Enemy enemy in enemies)
                    {
                        HandleDynamicEnemyCollision(hero, enemy);

                        // loop through enemy/floor collisions
                        foreach (Actor floor_piece in floor)
                        {
                            HandleStaticEnvironmentCollision(enemy, floor_piece);
                        }
                    }

                    hud.UpdateHealth(hero);

                }
            }

            ActorsCleanUp(cast);
        }

        /// <summary>
        /// This is inteded to handle the collision logic between an actor and
        /// the static environmental elements found in the game.
        /// The results of all comparisons will be relative to the second actor
        /// passed in.
        /// </summary>
        private void HandleStaticEnvironmentCollision(Actor first, Actor second)
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

                            // make this it's own function call
                            if (first.GetType() == typeof(Enemy))
                            {
                                // Change this to internal function of Enemy
                                first.SetVelocity(new Point(-Constants.ENEMY_SPEED, first.GetVelocity().GetY()));
                            }
                        }
                        else
                        {
                            // Collision right of second actor
                            Console.WriteLine("right side collision");
                            _physicsService.HandleRightCollision(first, second);

                            // make this it's own function call
                            if (first.GetType() == typeof(Enemy))
                            {
                                // Change this to internal functino of Enemy
                                first.SetVelocity(new Point(Constants.ENEMY_SPEED, first.GetVelocity().GetY()));
                            }
                        }
                    }
                    else
                    {
                        if (overlap.GetY() > 0)
                        {
                            // Collision top of second actor
                            // Console.WriteLine("top side collision");
                            _physicsService.HandleTopCollision(first, second);
                            if (second.GetType() == typeof(Floor))
                            {
                                Floor floor = (Floor)second;
                                _physicsService.HandleFriction(first, floor.GetFrictionConstant());
                            }
                            if (first.GetType() == typeof(Hero))
                            {
                                first.SetCanJump(true);
                                // find a way to get working
                                // (Hero)first.SetHitState(false);
                            }
                            first.SetOnGround(true);
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

        /// <summary>
        /// This is inteded to handle the collision logic between the hero and
        /// the enemies that will be found in this game.
        /// The results of all comparisons will be relative to the second actor
        /// passed in.
        /// </summary>
        private void HandleDynamicEnemyCollision(Actor first, Enemy second)
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
                            // Collision left of second actor.
                            // Make the hero jump back unless the actor coming into
                            // contact is a sword. Then the enemy will jump back.
                            Console.WriteLine("left side collision");
                            _physicsService.HandleLeftCollision(first, second);

                            if (first.GetType() == typeof(Hero))
                            {
                                second.BasicLeftAttack((Hero)first, _physicsService);
                            }
                        }
                        else
                        {
                            // Collision right of second actor
                            // Make the hero jump back unless the actor coming into
                            // contact is a sword. Then the enemy will jump back.
                            Console.WriteLine("right side collision");
                            _physicsService.HandleRightCollision(first, second);

                            if (first.GetType() == typeof(Hero))
                            {
                                second.BasicRightAttack((Hero)first, _physicsService);
                            }
                        }
                    }
                    else
                    {
                        if (overlap.GetY() > 0)
                        {
                            // Collision top of second actor
                            Console.WriteLine("top side collision");
                            _physicsService.HandleTopCollision(first, second);
                            if (second.GetType() == typeof(Enemy))
                            {
                                _enemiesToRemove.Add(second);
                            }
                            if (first.GetType() == typeof(Hero))
                            {
                                first.SetCanJump(true);
                            }
                        }
                        else
                        {
                            // Collision bottom of second actor
                            // Make hero take damage and be pushed in some direction.
                            Console.WriteLine("bottom side collision");
                            _physicsService.HandleBottomCollision(first, second);
                        }
                    }
                }
            }
        }

        private void ActorsCleanUp(Dictionary<string, List<Actor>> cast)
        {
            foreach (Actor element in _environmentElementsToRemove)
            {
                cast["environmentElements"].Remove(element);
            }

            foreach (Actor enemy in _enemiesToRemove)
            {
                cast["enemies"].Remove(enemy);
            }

            _environmentElementsToRemove.Clear();
            _enemiesToRemove.Clear();
        }
    }
}