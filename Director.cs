using System;
using System.Collections.Generic;
using cse210_final_metroidvania.Casting;
using cse210_final_metroidvania.Services;
using cse210_final_metroidvania.Scripting;

namespace cse210_final_metroidvania
{
    /// <summary>
    /// The director is responsible to direct the game, including to keep track of all
    /// the actors and to control the sequence of play.
    /// 
    /// Stereotype:
    ///     Controller
    /// </summary>
    public class Director
    {
        private AudioService _audioService = new AudioService();
        private CastPrepService _castPrepService = new CastPrepService();
        private bool _keepPlaying = true;
        private Dictionary<string, Dictionary<string, List<Actor>>> _map;
        private Dictionary<string, List<Actor>> _cast;
        private Dictionary<string, List<Action>> _script;

        // public Director(Dictionary<string, List<Actor>> cast, Dictionary<string, List<Action>> script)
        public Director(Dictionary<string, Dictionary<string, List<Actor>>> map, Dictionary<string, List<Action>> script)
        {
            _map = map;
            _script = script;
            _cast = _castPrepService.PopulateCast(map, "room0");
            // ((Hero)map["room0"]["heros"][0]));
        }

        /// <summary>
        /// This method starts the game and continues running until it is finished.
        /// </summary>
        public void Direct()
        {
            while (_keepPlaying)
            {
                CueAction("input");
                CueAction("update");
                CueAction("output");

                if (Raylib_cs.Raylib.WindowShouldClose())
                {
                    _audioService.PlaySound(Constants.SOUND_OVER);
                    _keepPlaying = false;
                    Console.WriteLine("Game over!");
                }
            }

            
        }

        /// <summary>
        /// Executes all of the actions for the provided phase.
        /// </summary>
        /// <param name="phase"></param>
        private void CueAction(string phase)
        {
            List<Action> actions = _script[phase];

            foreach (Action action in actions)
            {
                string newRoom = action.Execute(_cast);
                

                if (newRoom != "")
                {
                    Actor hero = _cast["heros"][0];
                    _cast["heros"].RemoveAt(0);

                    _cast = _castPrepService.PopulateCast(_map, newRoom);

                    _cast["heros"].Add(((Hero)hero));
                }
                

                // This is specifically for the Game Over screen
                if (newRoom == "gameOver")
                {
                    List<Actor> envElements = _cast["envElements"];
                    List<Actor> actorsToRemove = new List<Actor>();

                    if (envElements.Count > 0)
                    {
                        Actor heroGhost = envElements[0];

                        // Will remove the Ghost once it reaches a certain height
                        if (heroGhost.GetPosition().GetY() <= 350)
                        {
                            heroGhost.SetVelocity(new Point(0, 0));
                            actorsToRemove.Add(heroGhost);
                        }

                        foreach (Actor actor in actorsToRemove)
                        {
                            envElements.Remove(actor);
                        }
                    }
                }
            }
        }

    }
}
