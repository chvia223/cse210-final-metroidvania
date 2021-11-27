﻿using System;
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

            // The Bricks
            cast["bricks"] = new List<Actor>();

            // The Ball
            cast["balls"] = new List<Actor>();

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
            outputService.OpenWindow(Constants.MAX_X, Constants.MAX_Y, "Batter", Constants.FRAME_RATE);
            audioService.StartAudio();
            audioService.PlaySound(Constants.SOUND_START);

            Director theDirector = new Director(cast, script);
            theDirector.Direct();

            audioService.StopAudio();
        }
    }
}
