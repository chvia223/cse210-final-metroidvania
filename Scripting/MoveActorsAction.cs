using System.Collections.Generic;
using cse210_final_metroidvania.Casting;
using cse210_final_metroidvania.Services;


namespace cse210_final_metroidvania.Scripting
{
    /// <summary>
    /// An action to move all actors forward according to their current velocities.
    /// </summary>
    public class MoveActorsAction : Action
    {

        public MoveActorsAction()
        {
        }

        public override string Execute(Dictionary<string, List<Actor>> cast)
        {
            foreach (List<Actor> group in cast.Values)
            {
                foreach (Actor actor in group)
                {
                    MoveActor(actor);
                }
            }

            return _newRoom;
        }
        
        private void MoveActor(Actor actor)
        {
            double x = actor.GetX();
            double y = actor.GetY();

            double dx = actor.GetVelocity().GetX();
            double dy = actor.GetVelocity().GetY();

            double newX = (x + dx);
            double newY = (y + dy);

            actor.SetPosition(new Point(newX, newY));
        }

    }
}