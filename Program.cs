using System;
using cse210_final_metroidvania.Services;
using cse210_final_metroidvania.Casting;
using cse210_final_metroidvania.Casting.Enemies;
using cse210_final_metroidvania.Casting.HudElements;
using cse210_final_metroidvania.Casting.EnvironmentElements;
using cse210_final_metroidvania.Scripting;
using System.Collections.Generic;

namespace cse210_final_metroidvania
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<Actor>>> map = new Dictionary<string, Dictionary<string, List<Actor>>>();
            
            MapInitializer mapInitializer = new MapInitializer();
            map = mapInitializer.GetGameMap();

            /////////////////////////////////////////////////////////////////////////////////

            // Create the script
            Dictionary<string, List<Action>> script = new Dictionary<string, List<Action>>();

            OutputService outputService = new OutputService();
            InputService inputService = new InputService();
            PhysicsService physicsService = new PhysicsService();
            AudioService audioService = new AudioService();

            script["output"] = new List<Action>();
            script["input"] = new List<Action>();
            script["update"] = new List<Action>();

            DrawActorsAction drawActorsAction = new DrawActorsAction(outputService);
            script["output"].Add(drawActorsAction);

            ControlActorsAction controlActorsAction = new ControlActorsAction(inputService, physicsService, audioService);
            script["input"].Add(controlActorsAction);

            MoveActorsAction moveActorsAction = new MoveActorsAction();
            script["update"].Add(moveActorsAction);

            HandleCollisionsAction handleCollisionsAction = new HandleCollisionsAction(physicsService, audioService);
            script["update"].Add(handleCollisionsAction);

            GameOverAction gameOverAction = new GameOverAction();
            script["update"].Add(gameOverAction);

            GravityAction gravityAction = new GravityAction(physicsService);
            script["update"].Add(gravityAction);

            // Start up the game
            outputService.OpenWindow(Constants.MAX_X, Constants.MAX_Y, "Metroidvania", Constants.FRAME_RATE);
            audioService.StartAudio();
            audioService.PlaySound(Constants.SOUND_START);

            // Raylib.BeginMode2D(Camera2D camera); 

            Director theDirector = new Director(map, script);
            theDirector.Direct();

            audioService.StopAudio();
        }
    }
}
