using System;
using System.Collections.Generic;
using cse210_final_metroidvania.Casting;
using cse210_final_metroidvania.Casting.EnvironmentElements;
using cse210_final_metroidvania.Casting.Enemies;
using cse210_final_metroidvania.Casting.HudElements;

namespace cse210_final_metroidvania
{
    public class MapInitializer
    {
        Dictionary<string, Dictionary<string, List<Actor>>> _rooms = new Dictionary<string, Dictionary<string, List<Actor>>>();


        public MapInitializer()
        {
            InitializeCast0();
            InitializeCast1();
        }

        public Dictionary<string, Dictionary<string, List<Actor>>> GetGameMap()
        {
            return _rooms;
        }

        private void InitializeCast0()
        {
            Dictionary<string, List<Actor>> cast0 = new Dictionary<string, List<Actor>>();

            ///////////////////////////////////////////
            // Enviroment Elements
            ///////////////////////////////////////////
            cast0["envElements"] = new List<Actor>();

            Brick floor = new Brick();
            floor.SetPosition(new Point(0, 500));
            floor.SetWidth(800);
            // _rooms["room0"].Add("envElements", floor);
            cast0["envElements"].Add(floor);

            // For Collision debug
            EnvElement barrier = new EnvElement();
            barrier.SetPosition(new Point(350, 450));
            cast0["envElements"].Add(barrier);

            EnvElement barrier2 = new EnvElement();
            barrier2.SetPosition(new Point(750, 450));
            cast0["envElements"].Add(barrier2);
            //

            Door door = new Door();
            door.SetNewRoomName("room1");
            door.SetNewHeroPosition(new Point(200, 200));
            door.SetPosition(new Point(10, 450));
            cast0["envElements"].Add(door);

            ///////////////////////////////////////////
            // Hero
            ///////////////////////////////////////////
            cast0["heros"] = new List<Actor>();

            Hero hero = new Hero();
            cast0["heros"].Add(hero);

            ///////////////////////////////////////////
            // Enemies
            ///////////////////////////////////////////
            cast0["enemies"] = new List<Actor>();

            BasicEnemy zombie = new BasicEnemy();
            cast0["enemies"].Add(zombie);

            ///////////////////////////////////////////
            // HUD
            ///////////////////////////////////////////
            cast0["hud"] = new List<Actor>();

            Health health = new Health();
            cast0["hud"].Add(health);

            Velocity velocity = new Velocity();
            cast0["hud"].Add(velocity);

            EquippedWeapon equippedWeapon = new EquippedWeapon();
            cast0["hud"].Add(equippedWeapon);

            ///////////////////////////////////////////
            _rooms["room0"] = cast0;
        }

        private void InitializeCast1()
        {
            Dictionary<string, List<Actor>> cast1 = new Dictionary<string, List<Actor>>();

            ///////////////////////////////////////////
            // Enviroment Elements
            ///////////////////////////////////////////
            cast1["envElements"] = new List<Actor>();

            Brick floor = new Brick();
            floor.SetPosition(new Point(0, 500));
            floor.SetWidth(800);
            // _rooms["room0"].Add("envElements", floor);
            cast1["envElements"].Add(floor);

            // // For Collision debug
            // EnvElement barrier = new EnvElement();
            // barrier.SetPosition(new Point(350, 450));
            // cast1["envElements"].Add(barrier);

            // EnvElement barrier2 = new EnvElement();
            // barrier2.SetPosition(new Point(750, 450));
            // cast1["envElements"].Add(barrier2);
            // //

            ///////////////////////////////////////////
            // Hero
            ///////////////////////////////////////////
            cast1["heros"] = new List<Actor>();

            ///////////////////////////////////////////
            // Enemies
            ///////////////////////////////////////////
            cast1["enemies"] = new List<Actor>();

            // BasicEnemy zombie = new BasicEnemy();
            // cast1["enemies"].Add(zombie);

            ///////////////////////////////////////////
            // HUD
            ///////////////////////////////////////////
            cast1["hud"] = new List<Actor>();

            Health health = new Health();
            cast1["hud"].Add(health);

            Velocity velocity = new Velocity();
            cast1["hud"].Add(velocity);

            EquippedWeapon equippedWeapon = new EquippedWeapon();
            cast1["hud"].Add(equippedWeapon);

            ///////////////////////////////////////////
            _rooms["room1"] = cast1;
        }
    }
}