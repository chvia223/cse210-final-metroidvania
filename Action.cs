using System;
using System.Collections.Generic;
using cse210_final_metroidvania.Casting;

namespace cse210_final_metroidvania
{
    /// <summary>
    /// The base class of all other actions.
    /// </summary>
    public abstract class Action
    {
        public abstract void Execute(Dictionary<string, List<Actor>> cast);
    }
}