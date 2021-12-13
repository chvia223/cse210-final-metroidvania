using System.Collections.Generic;
using cse210_final_metroidvania.Casting;
using cse210_final_metroidvania.Casting.Enemies;
using cse210_final_metroidvania.Casting.HudElements;
using cse210_final_metroidvania.Casting.EnvironmentElements;
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
        private int _movementSoundInterval = 0;
        
        public HandleCollisionsAction(PhysicsService physicsService, AudioService audioService)
        {
            _physicsService = physicsService;
            _audioService = audioService;
        }

        public override string Execute(Dictionary<string, List<Actor>> cast)
        {
            List<Actor> heros = cast["heros"];
            List<Actor> envElements = cast["envElements"];
            List<Actor> enemies = cast["enemies"];
            List<Actor> hud = cast["hud"];
            
            // HUD hud = new HUD();
            // hud = (HUD)hudActor;

            // This foreach loop is rediculous. I need the hud to act like a HUD not an Actor
            foreach (HUD hud_element in hud)
            {
                foreach (Hero hero in heros)
                {
                    // loop through hero/floor collisions
                    foreach (EnvElement envElement in envElements)
                    {
                        if (envElement.GetCanCollide())
                        {
                            HandleStaticEnvironmentCollision(hero, envElement);
                        }
                    }
                    // loop through hero/enemy collisions
                    foreach (Enemy enemy in enemies)
                    {
                        HandleDynamicEnemyCollision(hero, enemy);

                        // loop through enemy/floor collisions
                        foreach (EnvElement envElement in envElements)
                        {
                            if (envElement.GetCanCollide())
                            {
                                HandleStaticEnvironmentCollision(enemy, envElement);
                            }
                        }
                    }

                    hud_element.Update(hero);

                    if (hero.GetHealth() <= 0 || hero.GetPosition().GetY() > 1300)
                    {
                        if (hero.GetPosition().GetY() > 1300)
                        {
                            _audioService.PlaySound(Constants.SOUND_HIT_ENEMY);
                        }
                        hero.SetCanMove(false);
                        hero.SetGravity(false);
                        hero.SetVelocity(new Point(0, 0));
                        Point finalPosition = new Point(600 - Constants.HERO_WIDTH/2, 575);
                        hero.SetPosition(finalPosition);

                        _audioService.PlaySound(Constants.SOUND_OVER);

                        _newRoom = "gameOver";
                    }

                }
            }

            ActorsCleanUp(cast);

            return _newRoom;
        }

        /// <summary>
        /// This is inteded to handle the collision logic between an actor and
        /// the static environmental elements found in the game.
        /// The results of all comparisons will be relative to the second actor
        /// passed in.
        /// </summary>
        private void HandleStaticEnvironmentCollision(Actor first, EnvElement second)
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
                            _physicsService.HandleLeftCollision(first, second);

                            if (first.CanBounceOffEnv())
                            {
                                first.SetVelocity(new Point(-Constants.ENEMY_SPEED, first.GetVelocity().GetY()));
                            }

                            // If the player hits the door it'll take them to a new room
                            if (first.GetType() == typeof(Hero) && second.GetType() == typeof(Door))
                            {
                                Point newPosition = ((Door)second).GetNewHeroPosition();
                                _newRoom = ((Door)second).GetNewRoomName();
                                first.SetPosition(newPosition);
                            }
                        }
                        else
                        {
                            // Collision right of second actor
                            _physicsService.HandleRightCollision(first, second);

                            if (first.CanBounceOffEnv())
                            {
                                first.SetVelocity(new Point(Constants.ENEMY_SPEED, first.GetVelocity().GetY()));
                            }


                            // If the player hits the door it'll take them to a new room
                            if (first.GetType() == typeof(Hero) && second.GetType() == typeof(Door))
                            {
                                Point newPosition = ((Door)second).GetNewHeroPosition();
                                _newRoom = ((Door)second).GetNewRoomName();
                                first.SetPosition(newPosition);

                            }
                        }
                    }
                    else
                    {
                        if (overlap.GetY() > 0)
                        {
                            // Collision top of second actor
                            _physicsService.HandleTopCollision(first, second);
                            _physicsService.HandleFriction(first, second.GetFrictionConstant());
                            
                            // This will make sure the sound is only played once when the Hero lands.
                            if(!first.IsOnGround())
                            {
                                _audioService.PlaySound(second.GetInteractSound());
                            }

                            // Player must be going a certain speed to make noise on the ground
                            if (Math.Abs(first.GetVelocity().GetX()) > Constants.HERO_SPEED - 1 && _movementSoundInterval == 0)
                            {
                                _audioService.PlaySound(second.GetInteractSound());
                                _movementSoundInterval = 15;
                            }
                            if (_movementSoundInterval > 0)
                            {
                                _movementSoundInterval -= 1;
                            }

                            if (first.GetType() == typeof(Hero))
                            {
                                first.SetCanJump(true);
                                ((Hero)first).SetHitState(false);
                                
                                // I only want the sound to play for the Hero
                                // _audioService.PlaySound(second.GetInteractSound());
                            }
                            first.SetOnGround(true);
                        }
                        else
                        {
                            // Collision bottom of second actor
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
        private void HandleDynamicEnemyCollision(Actor first, Enemy enemy)
        {
            if (_physicsService.IsCollision(first, enemy))
            {
                Point overlap = _physicsService.GetCollisionOverlap(first, enemy);

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
                            _physicsService.HandleLeftCollision(first, enemy);

                            if (first.GetType() == typeof(Hero))
                            {
                                enemy.LeftAttack((Hero)first, _physicsService);
                                _audioService.PlaySound(Constants.SOUND_GOT_HIT_BY_ENEMY);
                            }
                        }
                        else
                        {
                            // Collision right of second actor
                            // Make the hero jump back unless the actor coming into
                            // contact is a sword. Then the enemy will jump back.
                            Console.WriteLine("right side collision");
                            _physicsService.HandleRightCollision(first, enemy);

                            if (first.GetType() == typeof(Hero))
                            {
                                enemy.RightAttack((Hero)first, _physicsService);
                                _audioService.PlaySound(Constants.SOUND_GOT_HIT_BY_ENEMY);
                            }
                        }
                    }
                    else
                    {
                        if (overlap.GetY() > 0)
                        {
                            // Collision top of second actor
                            Console.WriteLine("top side collision");
                            _physicsService.HandleTopCollision(first, enemy);
                            _enemiesToRemove.Add(enemy);

                            if (first.GetType() == typeof(Hero))
                            {
                                first.SetCanJump(true);
                                _audioService.PlaySound(Constants.SOUND_HIT_ENEMY);
                            }
                        }
                        else
                        {
                            // Collision bottom of second actor
                            // Make hero take damage and be pushed in some direction.
                            Console.WriteLine("bottom side collision");
                            _physicsService.HandleBottomCollision(first, enemy);
                            _audioService.PlaySound(Constants.SOUND_GOT_HIT_BY_ENEMY);
                        }
                    }
                }
            }
        }

        private void ActorsCleanUp(Dictionary<string, List<Actor>> cast)
        {
            foreach (Actor element in _environmentElementsToRemove)
            {
                cast["envElements"].Remove(element);
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