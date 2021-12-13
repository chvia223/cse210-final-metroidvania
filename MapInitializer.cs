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
            InitializeCastleUpperFloor();
            InitializeCastleUpperFloorCloset();
            InitializeCastleStorage();
            InitializeGameOver();
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

            Position position = new Position();
            cast0["hud"].Add(position);

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

            Position position = new Position();
            castCastleOutside["hud"].Add(position);

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
            toUpperFloor.SetNewHeroPosition(new Point(53, 476));
            toUpperFloor.SetPosition(new Point(900, 150));
            castCastleEntrance["envElements"].Add(toUpperFloor);

            Door toStorage = new Door();
            toStorage.SetNewRoomName("castleStorage");
            toStorage.SetNewHeroPosition(new Point(156, 226));
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

            Position position = new Position();
            castCastleEntrance["hud"].Add(position);

            EquippedWeapon equippedWeapon = new EquippedWeapon();
            castCastleEntrance["hud"].Add(equippedWeapon);

            ///////////////////////////////////////////
            _rooms["castleEntrance"] = castCastleEntrance;
        }


        private void InitializeCastleUpperFloor()
        {
            Dictionary<string, List<Actor>> castCastleUpperFloor = new Dictionary<string, List<Actor>>();
        
            ///////////////////////////////////////////
            // Background
            ///////////////////////////////////////////
            castCastleUpperFloor["background"] = new List<Actor>();

            ///////////////////////////////////////////
            // Enviroment Elements
            ///////////////////////////////////////////
            castCastleUpperFloor["envElements"] = new List<Actor>();

            EnvElement boxBarrierLeft = new EnvElement();
            boxBarrierLeft.SetPosition(new Point(0, 100));
            boxBarrierLeft.SetHeight(300);
            boxBarrierLeft.SetColor(Raylib_cs.Color.DARKGRAY);
            castCastleUpperFloor["envElements"].Add(boxBarrierLeft);

            EnvElement boxBarrierTop = new EnvElement();
            boxBarrierTop.SetPosition(new Point(50, 100));
            boxBarrierTop.SetWidth(1100);
            boxBarrierTop.SetColor(Raylib_cs.Color.DARKGRAY);
            castCastleUpperFloor["envElements"].Add(boxBarrierTop);

            EnvElement boxBarrierRight = new EnvElement();
            boxBarrierRight.SetPosition(new Point(1150, 100));
            boxBarrierRight.SetHeight(250);
            boxBarrierRight.SetColor(Raylib_cs.Color.DARKGRAY);
            castCastleUpperFloor["envElements"].Add(boxBarrierRight);

            /////
            Door toEntrance = new Door();
            toEntrance.SetNewRoomName("castleEntrance");
            toEntrance.SetNewHeroPosition(new Point(870, 226));
            toEntrance.SetPosition(new Point(0, 400));
            castCastleUpperFloor["envElements"].Add(toEntrance);

            Door toUpperCloset = new Door();
            toUpperCloset.SetNewRoomName("castleUpperFloorCloset");
            toUpperCloset.SetNewHeroPosition(new Point(482, 376));
            toUpperCloset.SetPosition(new Point(1180, 350));
            castCastleUpperFloor["envElements"].Add(toUpperCloset);

            /////
            CastleWallSquare castleFloor = new CastleWallSquare();
            castleFloor.SetPosition(new Point(0, 500));
            castleFloor.SetWidth(650);
            castleFloor.SetColor(Raylib_cs.Color.DARKGRAY);
            castCastleUpperFloor["envElements"].Add(castleFloor);

            CastleWallSquare block0 = new CastleWallSquare();
            block0.SetPosition(new Point(630, 480));
            block0.SetWidth(20);
            block0.SetHeight(20);
            block0.SetColor(Raylib_cs.Color.GRAY);
            castCastleUpperFloor["envElements"].Add(block0);

            CastleWallRound ledge0 = new CastleWallRound();
            ledge0.SetPosition(new Point(320, 400));
            ledge0.SetWidth(90);
            ledge0.SetHeight(20);
            ledge0.SetColor(Raylib_cs.Color.GRAY);
            castCastleUpperFloor["envElements"].Add(ledge0);

            CastleWallRound ledge1 = new CastleWallRound();
            ledge1.SetPosition(new Point(565, 380));
            ledge1.SetWidth(70);
            ledge1.SetHeight(20);
            ledge1.SetColor(Raylib_cs.Color.GRAY);
            castCastleUpperFloor["envElements"].Add(ledge1);

            CastleWallRound ledge2 = new CastleWallRound();
            ledge2.SetPosition(new Point(771, 315));
            ledge2.SetWidth(40);
            ledge2.SetHeight(20);
            ledge2.SetColor(Raylib_cs.Color.GRAY);
            castCastleUpperFloor["envElements"].Add(ledge2);

            CastleWallRound ledge3 = new CastleWallRound();
            ledge3.SetPosition(new Point(860, 434));
            ledge3.SetWidth(30);
            ledge3.SetHeight(20);
            ledge3.SetColor(Raylib_cs.Color.GRAY);
            castCastleUpperFloor["envElements"].Add(ledge3);

            CastleWallRound ledge4 = new CastleWallRound();
            ledge4.SetPosition(new Point(1000, 450));
            ledge4.SetWidth(200);
            ledge4.SetHeight(20);
            ledge4.SetColor(Raylib_cs.Color.GRAY);
            castCastleUpperFloor["envElements"].Add(ledge4);

            ///////////////////////////////////////////
            // Hero
            ///////////////////////////////////////////
            castCastleUpperFloor["heros"] = new List<Actor>();

            ///////////////////////////////////////////
            // Enemies
            ///////////////////////////////////////////
            castCastleUpperFloor["enemies"] = new List<Actor>();

            BasicEnemy badGuy0 = new BasicEnemy();
            badGuy0.SetPosition(new Point(500, 300));
            badGuy0.SetVelocity(new Point(-Constants.ENEMY_SPEED, Constants.GRAVITY));
            castCastleUpperFloor["enemies"].Add(badGuy0);

            BasicEnemy badGuy1 = new BasicEnemy();
            badGuy1.SetPosition(new Point(530, 300));
            badGuy1.SetVelocity(new Point(-Constants.ENEMY_SPEED, Constants.GRAVITY));
            castCastleUpperFloor["enemies"].Add(badGuy1);

            BasicEnemy badGuy2 = new BasicEnemy();
            badGuy2.SetPosition(new Point(460, 300));
            badGuy2.SetVelocity(new Point(Constants.ENEMY_SPEED, Constants.GRAVITY));
            castCastleUpperFloor["enemies"].Add(badGuy2);

            ///////////////////////////////////////////
            // HUD
            ///////////////////////////////////////////
            castCastleUpperFloor["hud"] = new List<Actor>();

            Health health = new Health();
            castCastleUpperFloor["hud"].Add(health);

            Velocity velocity = new Velocity();
            castCastleUpperFloor["hud"].Add(velocity);

            Position position = new Position();
            castCastleUpperFloor["hud"].Add(position);

            EquippedWeapon equippedWeapon = new EquippedWeapon();
            castCastleUpperFloor["hud"].Add(equippedWeapon);

            ///////////////////////////////////////////
            _rooms["castleUpperFloor"] = castCastleUpperFloor;
        }


        private void InitializeCastleUpperFloorCloset()
        {
            Dictionary<string, List<Actor>> castCastleUpperFloorCloset = new Dictionary<string, List<Actor>>();
       
            ///////////////////////////////////////////
            // Background
            ///////////////////////////////////////////
            castCastleUpperFloorCloset["background"] = new List<Actor>();

            Actor closetBackground = new Actor();
            closetBackground.SetPosition(new Point(480, 300));
            closetBackground.SetWidth(220);
            closetBackground.SetHeight(100);
            closetBackground.SetCanCollide(false);
            closetBackground.SetColor(Raylib_cs.Color.BEIGE);
            castCastleUpperFloorCloset["background"].Add(closetBackground);

            ///////////////////////////////////////////
            // Enviroment Elements
            ///////////////////////////////////////////
            castCastleUpperFloorCloset["envElements"] = new List<Actor>();
        
            EnvElement boxBarrierTop = new EnvElement();
            boxBarrierTop.SetPosition(new Point(450, 250));
            boxBarrierTop.SetWidth(300);
            boxBarrierTop.SetColor(Raylib_cs.Color.DARKBROWN);
            castCastleUpperFloorCloset["envElements"].Add(boxBarrierTop);

            EnvElement boxBarrierRight = new EnvElement();
            boxBarrierRight.SetPosition(new Point(700, 300));
            boxBarrierRight.SetHeight(100);
            boxBarrierRight.SetColor(Raylib_cs.Color.DARKBROWN);
            castCastleUpperFloorCloset["envElements"].Add(boxBarrierRight);
            
            /////
            Door toCastleUpperFloor = new Door();
            toCastleUpperFloor.SetNewRoomName("castleUpperFloor");
            toCastleUpperFloor.SetNewHeroPosition(new Point(1152, 426));
            toCastleUpperFloor.SetPosition(new Point(450, 300));
            toCastleUpperFloor.SetWidth(30);
            castCastleUpperFloorCloset["envElements"].Add(toCastleUpperFloor);

            /////
            CastleWallSquare closetFloor = new CastleWallSquare();
            closetFloor.SetPosition(new Point(450, 400));
            closetFloor.SetWidth(300);
            closetFloor.SetCanCollide(true);
            closetFloor.SetColor(Raylib_cs.Color.DARKBROWN);
            castCastleUpperFloorCloset["envElements"].Add(closetFloor);

            ///////////////////////////////////////////
            // Hero
            ///////////////////////////////////////////
            castCastleUpperFloorCloset["heros"] = new List<Actor>();            

            ///////////////////////////////////////////
            // Enemies
            ///////////////////////////////////////////
            castCastleUpperFloorCloset["enemies"] = new List<Actor>();

            ///////////////////////////////////////////
            // HUD
            ///////////////////////////////////////////
            castCastleUpperFloorCloset["hud"] = new List<Actor>();

            Health health = new Health();
            castCastleUpperFloorCloset["hud"].Add(health);

            Velocity velocity = new Velocity();
            castCastleUpperFloorCloset["hud"].Add(velocity);

            Position position = new Position();
            castCastleUpperFloorCloset["hud"].Add(position);

            EquippedWeapon equippedWeapon = new EquippedWeapon();
            castCastleUpperFloorCloset["hud"].Add(equippedWeapon);

            ///////////////////////////////////////////
            _rooms["castleUpperFloorCloset"] = castCastleUpperFloorCloset;
        }


        private void InitializeCastleStorage()
        {
            Dictionary<string, List<Actor>> castCastleStorage = new Dictionary<string, List<Actor>>();
       
            ///////////////////////////////////////////
            // Background
            ///////////////////////////////////////////
            castCastleStorage["background"] = new List<Actor>();

            // Actor closetBackground = new Actor();
            // closetBackground.SetPosition(new Point(480, 300));
            // closetBackground.SetWidth(220);
            // closetBackground.SetHeight(100);
            // closetBackground.SetCanCollide(false);
            // closetBackground.SetColor(Raylib_cs.Color.BEIGE);
            // castCastleUpperFloorCloset["background"].Add(closetBackground);

            ///////////////////////////////////////////
            // Enviroment Elements
            ///////////////////////////////////////////
            castCastleStorage["envElements"] = new List<Actor>();
        
            EnvElement boxBarrierTop0 = new EnvElement();
            boxBarrierTop0.SetPosition(new Point(100, 100));
            boxBarrierTop0.SetWidth(300);
            boxBarrierTop0.SetColor(Raylib_cs.Color.DARKGRAY);
            castCastleStorage["envElements"].Add(boxBarrierTop0);

            EnvElement boxBarrierRight0 = new EnvElement();
            boxBarrierRight0.SetPosition(new Point(400, 100));
            boxBarrierRight0.SetHeight(200);
            boxBarrierRight0.SetColor(Raylib_cs.Color.DARKGRAY);
            castCastleStorage["envElements"].Add(boxBarrierRight0);

            EnvElement boxBarrierTop1 = new EnvElement();
            boxBarrierTop1.SetPosition(new Point(450, 250));
            boxBarrierTop1.SetWidth(650);
            boxBarrierTop1.SetColor(Raylib_cs.Color.DARKBROWN);
            castCastleStorage["envElements"].Add(boxBarrierTop1);

            EnvElement boxBarrierRight1 = new EnvElement();
            boxBarrierRight1.SetPosition(new Point(1050, 300));
            boxBarrierRight1.SetHeight(250);
            boxBarrierRight1.SetColor(Raylib_cs.Color.DARKBROWN);
            castCastleStorage["envElements"].Add(boxBarrierRight1);

            EnvElement boxBarrierLeft0 = new EnvElement();
            boxBarrierLeft0.SetPosition(new Point(100, 250));
            boxBarrierLeft0.SetHeight(350);
            boxBarrierLeft0.SetColor(Raylib_cs.Color.DARKGRAY);
            castCastleStorage["envElements"].Add(boxBarrierLeft0);

            /////
            Door toCastleEntrance = new Door();
            toCastleEntrance.SetNewRoomName("castleEntrance");
            toCastleEntrance.SetNewHeroPosition(new Point(872, 476));
            toCastleEntrance.SetPosition(new Point(100, 150));
            castCastleStorage["envElements"].Add(toCastleEntrance);

            /////
            CastleWallSquare storageFloor0 = new CastleWallSquare();
            storageFloor0.SetPosition(new Point(150, 250));
            storageFloor0.SetWidth(150);
            storageFloor0.SetColor(Raylib_cs.Color.DARKBROWN);
            castCastleStorage["envElements"].Add(storageFloor0);

            CastleWallSquare storageFloor1 = new CastleWallSquare();
            storageFloor1.SetPosition(new Point(150, 550));
            storageFloor1.SetWidth(950);
            storageFloor1.SetColor(Raylib_cs.Color.DARKBROWN);
            castCastleStorage["envElements"].Add(storageFloor1);

            ///////////////////////////////////////////
            // Hero
            ///////////////////////////////////////////
            castCastleStorage["heros"] = new List<Actor>();            

            ///////////////////////////////////////////
            // Enemies
            ///////////////////////////////////////////
            castCastleStorage["enemies"] = new List<Actor>();

            ///////////////////////////////////////////
            // HUD
            ///////////////////////////////////////////
            castCastleStorage["hud"] = new List<Actor>();

            Health health = new Health();
            castCastleStorage["hud"].Add(health);

            Velocity velocity = new Velocity();
            castCastleStorage["hud"].Add(velocity);

            Position position = new Position();
            castCastleStorage["hud"].Add(position);

            EquippedWeapon equippedWeapon = new EquippedWeapon();
            castCastleStorage["hud"].Add(equippedWeapon);

            ///////////////////////////////////////////
            _rooms["castleStorage"] = castCastleStorage;
        }


        private void InitializeGameOver()
        {
            Dictionary<string, List<Actor>> castGameOver = new Dictionary<string, List<Actor>>();
        
            ///////////////////////////////////////////
            // Background
            ///////////////////////////////////////////
            castGameOver["background"] = new List<Actor>();

            Actor gameOverText = new Actor();
            gameOverText.SetPosition(new Point(280, 50));
            gameOverText.SetWidth(640);
            gameOverText.SetHeight(360);
            gameOverText.SetCanCollide(false);
            gameOverText.SetImage(Constants.IMAGE_GAME_OVER);
            castGameOver["background"].Add(gameOverText);

            ///////////////////////////////////////////
            // Enviroment Elements
            ///////////////////////////////////////////
            castGameOver["envElements"] = new List<Actor>();

            EnvElement heroGhost = new EnvElement();
            heroGhost.SetPosition(new Point(600 - Constants.HERO_WIDTH/2, 575));
            heroGhost.SetVelocity(new Point(0,-0.5));
            heroGhost.SetWidth(Constants.HERO_WIDTH);
            heroGhost.SetHeight(Constants.HERO_HEIGHT);
            heroGhost.SetCanJump(false);
            heroGhost.SetGravity(false);
            heroGhost.SetCanCollide(false);
            heroGhost.SetColor(new Raylib_cs.Color(102,255,255,50));
            castGameOver["envElements"].Add(heroGhost);

            ///////////////////////////////////////////
            // Hero
            ///////////////////////////////////////////
            castGameOver["heros"] = new List<Actor>();            

            ///////////////////////////////////////////
            // Enemies
            ///////////////////////////////////////////
            castGameOver["enemies"] = new List<Actor>();

            ///////////////////////////////////////////
            // HUD
            ///////////////////////////////////////////
            castGameOver["hud"] = new List<Actor>();

            ///////////////////////////////////////////
            _rooms["gameOver"] = castGameOver;
        }


        
    }
}