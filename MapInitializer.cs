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
            // InitializeCast1();
            InitializeCastleOutside();
            InitializeCastleEntrance();
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
            barrier.SetColor(Raylib_cs.Color.RED);
            cast0["envElements"].Add(barrier);

            EnvElement barrier2 = new EnvElement();
            barrier2.SetPosition(new Point(750, 450));
            cast0["envElements"].Add(barrier2);
            //

            Door door = new Door();
            door.SetNewRoomName("castleOutside");
            door.SetNewHeroPosition(new Point(200, 200));
            door.SetPosition(new Point(10, 400));
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

        private void InitializeCastleOutside()
        {
            Dictionary<string, List<Actor>> castCastleOutside = new Dictionary<string, List<Actor>>();
        
            ///////////////////////////////////////////
            // Background
            ///////////////////////////////////////////
            castCastleOutside["background"] = new List<Actor>();

            Actor backgroundSky = new Actor();
            backgroundSky.SetPosition(new Point(0,0));
            backgroundSky.SetWidth(1200);
            backgroundSky.SetHeight(550);
            backgroundSky.SetCanCollide(false);
            backgroundSky.SetColor(Raylib_cs.Color.SKYBLUE);
            castCastleOutside["background"].Add(backgroundSky);

            Actor backgroundDirt = new Actor();
            backgroundDirt.SetPosition(new Point(0,550));
            backgroundDirt.SetWidth(1200);
            backgroundDirt.SetHeight(125);
            backgroundDirt.SetCanCollide(false);
            backgroundDirt.SetColor(Raylib_cs.Color.BROWN);
            castCastleOutside["background"].Add(backgroundDirt);

            ///////////////////////////////////////////
            // Enviroment Elements
            ///////////////////////////////////////////
            castCastleOutside["envElements"] = new List<Actor>();

            Grass grassFloor = new Grass();
            grassFloor.SetPosition(new Point(0, 500));
            grassFloor.SetWidth(900);
            grassFloor.SetColor(Raylib_cs.Color.DARKGREEN);
            castCastleOutside["envElements"].Add(grassFloor);

            CastleWallSquare castleFloor = new CastleWallSquare();
            castleFloor.SetPosition(new Point(900, 500));
            castleFloor.SetWidth(300);
            castleFloor.SetColor(Raylib_cs.Color.GRAY);
            castCastleOutside["envElements"].Add(castleFloor);

            CastleWallSquare castleWallBarrier = new CastleWallSquare();
            castleWallBarrier.SetPosition(new Point(1150, 200));
            castleWallBarrier.SetHeight(300);
            castleWallBarrier.SetColor(Raylib_cs.Color.GRAY);
            castCastleOutside["envElements"].Add(castleWallBarrier);

            Door castleDoor = new Door();
            castleDoor.SetNewRoomName("castleEntrance");
            castleDoor.SetNewHeroPosition(new Point(310, 500));
            castleDoor.SetPosition(new Point(1100, 400));
            castleDoor.SetColor(Raylib_cs.Color.BROWN);
            castCastleOutside["envElements"].Add(castleDoor);

            CastleWallSquare castleWallDoor = new CastleWallSquare();
            castleWallDoor.SetPosition(new Point(1100, 150));
            castleWallDoor.SetHeight(250);
            castleWallDoor.SetCanCollide(false);
            castleWallDoor.SetColor(Raylib_cs.Color.GRAY);
            castCastleOutside["envElements"].Add(castleWallDoor);

            CastleWallRound castleWall0 = new CastleWallRound();
            castleWall0.SetPosition(new Point(950, 100));
            castleWall0.SetHeight(400);
            castleWall0.SetCanCollide(false);
            castleWall0.SetColor(Raylib_cs.Color.DARKGRAY);
            castCastleOutside["envElements"].Add(castleWall0);

            CastleWallRound castleWall1 = new CastleWallRound();
            castleWall1.SetPosition(new Point(1000, 100));
            castleWall1.SetHeight(400);
            castleWall1.SetCanCollide(false);
            castleWall1.SetColor(Raylib_cs.Color.DARKGRAY);
            castCastleOutside["envElements"].Add(castleWall1);

            CastleWallRound castleWall2 = new CastleWallRound();
            castleWall2.SetPosition(new Point(1050, 200));
            castleWall2.SetHeight(300);
            castleWall2.SetCanCollide(false);
            castleWall2.SetColor(Raylib_cs.Color.GRAY);
            castCastleOutside["envElements"].Add(castleWall2);

            ///////////////////////////////////////////
            // Hero
            ///////////////////////////////////////////
            castCastleOutside["heros"] = new List<Actor>();

            ///////////////////////////////////////////
            // Enemies
            ///////////////////////////////////////////
            castCastleOutside["enemies"] = new List<Actor>();

            ///////////////////////////////////////////
            // HUD
            ///////////////////////////////////////////
            castCastleOutside["hud"] = new List<Actor>();

            Health health = new Health();
            castCastleOutside["hud"].Add(health);

            Velocity velocity = new Velocity();
            castCastleOutside["hud"].Add(velocity);

            EquippedWeapon equippedWeapon = new EquippedWeapon();
            castCastleOutside["hud"].Add(equippedWeapon);

            ///////////////////////////////////////////
            _rooms["castleOutside"] = castCastleOutside;
        }

        private void InitializeCastleEntrance()
        {
            Dictionary<string, List<Actor>> castCastleEntrance = new Dictionary<string, List<Actor>>();
        
            ///////////////////////////////////////////
            // Background
            ///////////////////////////////////////////
            castCastleEntrance["background"] = new List<Actor>();

            ///////////////////////////////////////////
            // Enviroment Elements
            ///////////////////////////////////////////
            castCastleEntrance["envElements"] = new List<Actor>();

            EnvElement boxBarrierLeft = new EnvElement();
            boxBarrierLeft.SetPosition(new Point(250, 100));
            boxBarrierLeft.SetHeight(300);
            boxBarrierLeft.SetColor(Raylib_cs.Color.DARKGRAY);
            castCastleEntrance["envElements"].Add(boxBarrierLeft);

            EnvElement boxBarrierTop = new EnvElement();
            boxBarrierTop.SetPosition(new Point(300, 100));
            boxBarrierTop.SetWidth(650);
            boxBarrierTop.SetColor(Raylib_cs.Color.DARKGRAY);
            castCastleEntrance["envElements"].Add(boxBarrierTop);

            EnvElement boxBarrierRight = new EnvElement();
            boxBarrierRight.SetPosition(new Point(900, 250));
            boxBarrierRight.SetHeight(200);
            boxBarrierRight.SetColor(Raylib_cs.Color.DARKGRAY);
            castCastleEntrance["envElements"].Add(boxBarrierRight);

            /////
            Door toOutside = new Door();
            toOutside.SetNewRoomName("castleOutside");
            toOutside.SetNewHeroPosition(new Point(1070, 450));
            toOutside.SetPosition(new Point(250, 400));
            castCastleEntrance["envElements"].Add(toOutside);

            Door toUpperFloor = new Door();
            toUpperFloor.SetNewRoomName("castleUpperFloor");
            toUpperFloor.SetNewHeroPosition(new Point(310, 500));
            toUpperFloor.SetPosition(new Point(900, 150));
            castCastleEntrance["envElements"].Add(toUpperFloor);

            Door toStorage = new Door();
            toStorage.SetNewRoomName("castleStorage");
            toStorage.SetNewHeroPosition(new Point(1070, 450));
            toStorage.SetPosition(new Point(900, 400));
            castCastleEntrance["envElements"].Add(toStorage);

            /////
            CastleWallSquare castleFloor = new CastleWallSquare();
            castleFloor.SetPosition(new Point(250, 500));
            castleFloor.SetWidth(700);
            castleFloor.SetColor(Raylib_cs.Color.DARKGRAY);
            castCastleEntrance["envElements"].Add(castleFloor);

            CastleWallRound Ledge0 = new CastleWallRound();
            Ledge0.SetPosition(new Point(475, 400));
            Ledge0.SetWidth(70);
            Ledge0.SetHeight(20);
            Ledge0.SetColor(Raylib_cs.Color.GRAY);
            castCastleEntrance["envElements"].Add(Ledge0);

            CastleWallRound Ledge1 = new CastleWallRound();
            Ledge1.SetPosition(new Point(640, 315));
            Ledge1.SetWidth(40);
            Ledge1.SetHeight(20);
            Ledge1.SetColor(Raylib_cs.Color.GRAY);
            castCastleEntrance["envElements"].Add(Ledge1);

            CastleWallRound Ledge2 = new CastleWallRound();
            Ledge2.SetPosition(new Point(810, 250));
            Ledge2.SetWidth(90);
            Ledge2.SetHeight(20);
            Ledge2.SetColor(Raylib_cs.Color.GRAY);
            castCastleEntrance["envElements"].Add(Ledge2);

            ///////////////////////////////////////////
            // Hero
            ///////////////////////////////////////////
            castCastleEntrance["heros"] = new List<Actor>();

            ///////////////////////////////////////////
            // Enemies
            ///////////////////////////////////////////
            castCastleEntrance["enemies"] = new List<Actor>();

            BasicEnemy badGuy0 = new BasicEnemy();
            badGuy0.SetPosition(new Point(850, 500));
            badGuy0.SetVelocity(new Point(-Constants.ENEMY_SPEED, Constants.GRAVITY));
            castCastleEntrance["enemies"].Add(badGuy0);

            BasicEnemy badGuy1 = new BasicEnemy();
            badGuy1.SetPosition(new Point(870, 500));
            badGuy1.SetVelocity(new Point(-Constants.ENEMY_SPEED, Constants.GRAVITY));
            castCastleEntrance["enemies"].Add(badGuy1);

            BasicEnemy badGuy2 = new BasicEnemy();
            badGuy2.SetPosition(new Point(700, 500));
            badGuy2.SetVelocity(new Point(-Constants.ENEMY_SPEED, Constants.GRAVITY));
            castCastleEntrance["enemies"].Add(badGuy2);

            ///////////////////////////////////////////
            // HUD
            ///////////////////////////////////////////
            castCastleEntrance["hud"] = new List<Actor>();

            Health health = new Health();
            castCastleEntrance["hud"].Add(health);

            Velocity velocity = new Velocity();
            castCastleEntrance["hud"].Add(velocity);

            EquippedWeapon equippedWeapon = new EquippedWeapon();
            castCastleEntrance["hud"].Add(equippedWeapon);

            ///////////////////////////////////////////
            _rooms["castleEntrance"] = castCastleEntrance;
        }
    }
}