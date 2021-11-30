using System;
using Raylib_cs;
using cse210_final_metroidvania.Casting;

namespace cse210_final_metroidvania.Services
{
    /// <summary>
    /// Handles all the physics related parts of the game such as
    /// determining collisions.
    /// </summary>
    public class PhysicsService
    {
        public PhysicsService()
        {

        }

        /// <summary>
        /// Returns true if the two actors overlap.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public bool IsCollision(Actor first, Actor second)
        {
            int x1 = first.GetX();
            int y1 = first.GetY();
            int width1 = first.GetWidth();
            int height1 = first.GetHeight();

            Raylib_cs.Rectangle rectangle1
                = new Raylib_cs.Rectangle(x1, y1, width1, height1);

            int x2 = second.GetX();
            int y2 = second.GetY();
            int width2 = second.GetWidth();
            int height2 = second.GetHeight();

            Raylib_cs.Rectangle rectangle2
                = new Raylib_cs.Rectangle(x2, y2, width2, height2);

            

            return Raylib.CheckCollisionRecs(rectangle1, rectangle2);
        }

        // public bool IsHorizontalWallCollision(Actor actor)
        // {
        //     return (actor.GetRightEdge() >= Constants.MAX_X || actor.GetLeftEdge() <= 0);
        // }

        // public bool IsTopWallCollision(Actor actor)
        // {
        //     return actor.GetTopEdge() <= 0;
        // }

        // public bool IsBottomWallCollision(Actor actor)
        // {
        //     return actor.GetBottomEdge() >= Constants.MAX_Y;
        // }

        public bool IsBottomCollision(Hero hero, Actor actor)
        {
            return (hero.GetBottomEdge() + hero.GetVelocity().GetY() >= actor.GetTopEdge() && hero.GetBottomEdge() <= actor.GetTopEdge() + (actor.GetHeight()/2));
        }


        public void HeroBottomToTopCollision(Hero hero, Actor actor)
        {
            Console.WriteLine("Hero fell On Something");
            hero.SetVelocity(new Point(hero.GetVelocity().GetX(), 0));
            hero.SetPosition(new Point(hero.GetPosition().GetX(), actor.GetTopEdge() - hero.GetHeight()));
        }

        public bool IsTopCollision(Hero hero, Actor actor)
        {
            return (hero.GetTopEdge() - 3 <= actor.GetBottomEdge() && hero.GetTopEdge() >= actor.GetBottomEdge() - (actor.GetHeight()/3));
        }

        public void HeroTopToBottomCollision(Hero hero, Actor actor)
        {
            Console.WriteLine("Hero bonk their head on something");
            hero.SetVelocity(new Point(hero.GetVelocity().GetX(), 0));
            hero.SetPosition(new Point(hero.GetPosition().GetX(), actor.GetBottomEdge()));
        }

        public bool IsRightCollision(Hero hero, Actor actor)
        {
            return ((hero.GetRightEdge() + 3 >= actor.GetLeftEdge() && hero.GetRightEdge() <= actor.GetLeftEdge() + (actor.GetWidth()/3)));
        }

        public void HeroRightToLeftCollision(Hero hero, Actor actor)
        {
            Console.WriteLine("Hero bonked on their right");
            hero.SetVelocity(new Point(0, hero.GetVelocity().GetY()));
            hero.SetPosition(new Point(actor.GetLeftEdge() - hero.GetWidth(), hero.GetPosition().GetY()));
        }

        public bool IsLeftCollision(Hero hero, Actor actor)
        {
            return ((hero.GetLeftEdge() - 3 <= actor.GetRightEdge() && hero.GetLeftEdge() >= actor.GetRightEdge() - (actor.GetWidth()/3)));
        }

        public void HeroLeftToRightCollision(Hero hero, Actor actor)
        {
                Console.WriteLine("Hero bonked on their left");
                hero.SetVelocity(new Point(0, hero.GetVelocity().GetY()));
                hero.SetPosition(new Point(actor.GetRightEdge() + 1, hero.GetPosition().GetY()));
        }

        public void ChangeAcceleration(Actor actor, int dv, string axis)
        {
            Point velocity = actor.GetVelocity();
            int dx = velocity.GetX();
            int dy = velocity.GetY();

            if (axis == "x")
            {
                dx = dx + dv;
                actor.SetVelocity(new Point(dx, dy));
            }
            else if (axis == "y")
            {
                dy = dy + dv;
                actor.SetVelocity(new Point(dx, dy));
            }
            else if (axis == "xy")
            {
                dx = dx + dv;
                dy = dy + dv;
                actor.SetVelocity(new Point(dx, dy));
            }
        }
    }

}