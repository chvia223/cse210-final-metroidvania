using System;
using cse210_final_metroidvania.Services;
using cse210_final_metroidvania.Casting;
using cse210_final_metroidvania.Scripting;
using System.Collections.Generic;

namespace cse210_final_metroidvania
{
    class Program
    {
        static void Main(string[] args)
        {
            // The Cast
            Dictionary<string, List<Actor>> cast = new Dictionary<string, List<Actor>>();

            // The Floor
            cast["floor"] = new List<Actor>();

            int y = 500;
            for (int x = 0; x < 800; x+=50)
            {
                Floor floor = new Floor();
                floor.SetPosition(new Point(x, y));
                cast["floor"].Add(floor);
            }

            // The Heros
            cast["heros"] = new List<Actor>();

            Hero hero = new Hero();
            cast["heros"].Add(hero);

            // Ball ball = new Ball();
            // cast["balls"].Add(ball);

            // The paddle
            cast["paddle"] = new List<Actor>();

            // Paddle paddle = new Paddle();
            // cast["paddle"].Add(paddle);


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

            ControlActorsAction controlActorsAction = new ControlActorsAction(inputService);
            script["input"].Add(controlActorsAction);

            MoveActorsAction moveActorsAction = new MoveActorsAction();
            script["update"].Add(moveActorsAction);

            HandleCollisionsAction handleCollisionsAction = new HandleCollisionsAction(physicsService, audioService);
            script["update"].Add(handleCollisionsAction);

            // Start up the game
            outputService.OpenWindow(Constants.MAX_X, Constants.MAX_Y, "Metroidvania", Constants.FRAME_RATE);
            audioService.StartAudio();
            audioService.PlaySound(Constants.SOUND_START);

            // Raylib.BeginMode2D(Camera2D camera); 

            Director theDirector = new Director(cast, script);
            theDirector.Direct();

            audioService.StopAudio();
        }
    }
}
