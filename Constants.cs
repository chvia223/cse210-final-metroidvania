using System;

namespace cse210_final_metroidvania
{
    /// <summary>
    /// This is a set of program wide constants to be used in other classes.
    /// </summary>
    public static class Constants
    {
        public const int MAX_X = 1200;
        public const int MAX_Y = 675;
        public const int FRAME_RATE = 60;

        public const int DEFAULT_SQUARE_SIZE = 20;
        public const int DEFAULT_FONT_SIZE = 20;
        public const int DEFAULT_TEXT_OFFSET = 4;

        public const string IMAGE_BRICK = "./Assets/brickWall_sized.png";
        public const string IMAGE_GRASS = "./Assets/grass_sized.png";
        public const string IMAGE_CASTLEWALLROUND = "./Assets/castle_sized.png";
        public const string IMAGE_CASTLEWALLSQUARE = "./Assets/castleCenter_sized.png";
        public const string IMAGE_WOODEN_CRATE = "./Assets/box_sized.png";
        public const string IMAGE_HERO = "./Assets/hero_temp.png";
        public const string IMAGE_GAME_OVER = "./Assets/game_over.png";

        public const string SOUND_START = "./Assets/Audio/start.wav";
        public const string SOUND_OVER = "./Assets/Audio/over.wav";
        public const string SOUND_JUMP = "./Assets/Audio/jump.wav";
        public const string SOUND_LAND_ON_GRASS = "./Assets/Audio/land_on_grass.wav";
        public const string SOUND_LAND_ON_STONE = "./Assets/Audio/land_on_stone.wav";
        public const string SOUND_PICK_UP_HEALTH_PACK = "./Assets/Audio/picked_up_health.wav";
        public const string SOUND_PICK_UP_ITEM = "./Assets/Audio/picked_up_gun.wav";

        public const string SOUND_GOT_HIT_BY_ENEMY = "./Assets/Audio/hit_by_enemy_alt.wav";
        public const string SOUND_HIT_ENEMY = "./Assets/Audio/hit_enemy.wav";


        // Should be 25, but I goofed resizing the textures
        public const int ENV_ELEMENT_WIDTH = 50;
        public const int ENV_ELEMENT_HEIGHT = 50;

        public const int HERO_WIDTH = 24;
        public const int HERO_HEIGHT = 24;
        // was -8.0
        public const double HERO_JUMP_ACCELERATION = -11.0;
        public const double HERO_SPEED = 3.5;

        public const int ENEMY_WIDTH = 18;
        public const int ENEMY_HEIGHT = 30;
        public const double ENEMY_SPEED = 1.5;

        public const double BASIC_ENEMY_HIT_KNOCKBACK = 5.0;

        public const double GRAVITY = .5;
        public const double TERMINAL_VELOCITY = 25;
        public const double AIR_RESISTANCE = .1;
    }

}