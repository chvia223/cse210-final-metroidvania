using System;
using System.Collections.Generic;
using cse210_final_metroidvania.Casting;
using cse210_final_metroidvania.Casting.EnvironmentElements;


namespace cse210_final_metroidvania
{
    public class CastPrepService
    {
        public CastPrepService()
        {

        }

        public Dictionary<string, List<Actor>> PopulateCast(Dictionary<string, Dictionary<string, List<Actor>>> map, string room_name)
        //  Hero hero)
        {
            Dictionary<string, List<Actor>> cast = new Dictionary<string, List<Actor>>();

            Console.WriteLine($"Room Name: {room_name}");

            if (map.ContainsKey(room_name))
            {
                foreach (KeyValuePair<string, List<Actor>> cast_type in map[room_name])
                {
                    Console.WriteLine($"Cast Type: {cast_type.Key}");
                    cast[cast_type.Key] = cast_type.Value;
                }
            }
            
            // cast["heros"].Add(hero);
            return cast;
        }
    }
}