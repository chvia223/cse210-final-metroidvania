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
            // // The Cast
            // Dictionary<string, List<Actor>> cast = new Dictionary<string, List<Actor>>();

            // // The EnvElements
            // cast["envElements"] = new List<Actor>();

            // // int y = 500;
            // // for (int x = 0; x < 850; x+=50)
            // // {
            // //     EnvElement floor = new EnvElement();
            // //     floor.SetPosition(new Point(x, y));
            // //     cast["envElements"].Add(floor);
            // // }
            // Brick floor = new Brick();
            // floor.SetPosition(new Point(0, 500));
            // floor.SetWidth(800);
            // cast["envElements"].Add(floor);
            
            // // For Collision debug
            // EnvElement barrier = new EnvElement();
            // barrier.SetPosition(new Point(350, 450));
            // cast["envElements"].Add(barrier);

            // EnvElement barrier2 = new EnvElement();
            // barrier2.SetPosition(new Point(750, 450));
            // cast["envElements"].Add(barrier2);
            // //

            // // The Heros
            // cast["heros"] = new List<Actor>();

            // Hero hero = new Hero();
            // cast["heros"].Add(hero);

            // // The Enemies
            // cast["enemies"] = new List<Actor>();

            // BasicEnemy zombie = new BasicEnemy();
            // cast["enemies"].Add(zombie);

            // ///////////////////////////////////////////////////////
            // // The HUD
            // cast["hud"] = new List<Actor>();

            // Health health = new Health();
            // cast["hud"].Add(health);

            // Velocity velocity = new Velocity();
            // cast["hud"].Add(velocity);

            // EquippedWeapon equippedWeapon = new EquippedWeapon();
            // cast["hud"].Add(equippedWeapon);
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

            ControlActorsAction controlActorsAction = new ControlActorsAction(inputService, physicsService);
            script["input"].Add(controlActorsAction);

            MoveActorsAction moveActorsAction = new MoveActorsAction();
            script["update"].Add(moveActorsAction);

            HandleCollisionsAction handleCollisionsAction = new HandleCollisionsAction(physicsService, audioService);
            script["update"].Add(handleCollisionsAction);

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
