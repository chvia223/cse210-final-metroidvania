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
            int x1 = (int)Math.Ceiling(first.GetX());
            int y1 = (int)Math.Ceiling(first.GetY());
            int width1 = first.GetWidth();
            int height1 = first.GetHeight();

            Raylib_cs.Rectangle rectangle1
                = new Raylib_cs.Rectangle(x1, y1, width1, height1);

            int x2 = (int)Math.Ceiling(second.GetX());
            int y2 = (int)Math.Ceiling(second.GetY());
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


        /// <summary>
        /// Collision with the top of the second actor.
        /// </summary>
        public void HandleTopCollision(Actor first, Actor second)
        {
            first.SetVelocity(new Point(first.GetVelocity().GetX(), 0));
            first.SetPosition(new Point(first.GetPosition().GetX(), second.GetTopEdge() - first.GetHeight()));
        }

        /// <summary>
        /// Collision with the bottom of the second actor.
        /// </summary>
        public void HandleBottomCollision(Actor first, Actor second)
        {
            first.SetVelocity(new Point(first.GetVelocity().GetX(), 0));
            first.SetPosition(new Point(first.GetPosition().GetX(), second.GetBottomEdge()));
        }

        /// <summary>
        /// Collision with the left of the second actor
        /// </summary>
        public void HandleLeftCollision(Actor first, Actor second)
        {
            first.SetVelocity(new Point(0, first.GetVelocity().GetY()));
            first.SetPosition(new Point(second.GetLeftEdge() - first.GetWidth(), first.GetPosition().GetY()));
        }

        /// <summary>
        /// Collision with the right of the second actor
        /// </summary>
        public void HandleRightCollision(Actor first, Actor second)
        {
                first.SetVelocity(new Point(0, first.GetVelocity().GetY()));
                first.SetPosition(new Point(second.GetRightEdge(), first.GetPosition().GetY()));
        }

        public void ChangeAcceleration(Actor actor, double dv, string axis)
        {
            Point velocity = actor.GetVelocity();
            double dx = velocity.GetX();
            double dy = velocity.GetY();

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


        public Point GetCollisionOverlap(Actor first, Actor second)
        {
            double firstHalfWidth = first.GetWidth() / 2;
            double firstHalfHeight = first.GetHeight() / 2;
            double secondHalfWidth = second.GetWidth() / 2;
            double secondHalfHeight = second.GetHeight() / 2;

            double firstCenterX = first.GetPosition().GetX() + firstHalfWidth;
            double firstCenterY = first.GetPosition().GetY() + firstHalfHeight;
            double secondCenterX = second.GetPosition().GetX() + secondHalfWidth;
            double secondCenterY = second.GetPosition().GetY() + secondHalfHeight;

            double diffX = firstCenterX - secondCenterX;
            double diffY = firstCenterY - secondCenterY;

            double distanceToOverlapX = firstHalfWidth + secondHalfWidth;
            double distanceToOverlapY = firstHalfHeight + secondHalfHeight;

            double depthX = Math.Abs(distanceToOverlapX) - Math.Abs(diffX);
            double depthY = Math.Abs(distanceToOverlapY) - Math.Abs(diffY);

            if (diffX > 0)
            {
                depthX *= -1;
            }

            if (diffY > 0)
            {
                depthY *= -1;
            }

            return new Point(depthX, depthY);
        }
    }

}