using System;
using Raylib_cs;
using static Raylib_cs.Color;

namespace cse210_final_metroidvania.Casting
{
    /// <summary>
    /// Base class for all actors in the game.
    /// </summary>
    public class Actor
    {
        protected Point _position;
        protected Point _velocity;
        protected bool _hasGravity;
        protected bool _canJump;
        protected bool _isMoving = false;
        protected bool _onGround;
        protected bool _canBounceOffEnv;
        protected bool _canCollide = true;

        protected int _width = 0;
        protected int _height = 0;

        protected string _text = "";
        private string _image = "";
        protected Color _color = BLUE;

        public Actor()
        {
            // Start these at 0, 0 by default
            _position = new Point(0, 0);
            _velocity = new Point(0, 0);
        }


        public void SetImage(string image)
        {
            _image = image;
        }

        public string GetImage()
        {
            return _image;
        }

        public bool HasImage()
        {
            return _image != "";
        }

        public bool HasText()
        {
            return _text != "";
        }

        public bool HasBox()
        {
            return _width > 0 && _height > 0;
        }

        public void SetColor(Color color)
        {
            _color = color;
        }

        public Color GetColor()
        {
            return _color;
        }

        public void SetGravity(bool hasGravity)
        {
            _hasGravity = hasGravity;
        }

        public bool HasGravity()
        {
            return _hasGravity;
        }

        public void SetCanJump(bool canJump)
        {
            _canJump = canJump;
        }

        public bool CanJump()
        {
            return _canJump;
        }
        public void SetOnGround(bool onGround)
        {
            _onGround = onGround;
        }

        public bool IsOnGround()
        {
            return _onGround;
        }

        public void SetIsMoving(bool isMoving)
        {
            _isMoving = isMoving;
        }

        public bool GetIsMoving()
        {
            return _isMoving;
        }

        public void SetCanBounceOffEnv(bool canBounceOffEnv)
        {
            _canBounceOffEnv = canBounceOffEnv;
        }

        public bool CanBounceOffEnv()
        {
            return _canBounceOffEnv;
        }

        public void SetCanCollide(bool canCollide)
        {
            _canCollide = canCollide;
        }

        public bool GetCanCollide()
        {
            return _canCollide;
        }

        public string GetText()
        {
            return _text;
        }

        public void SetText(string text)
        {
            _text = text;
        }

        public double GetX()
        {
            return _position.GetX();
        }

        public double GetY()
        {
            return _position.GetY();
        }

        public double GetLeftEdge()
        {
            return _position.GetX();
        }

        public double GetRightEdge()
        {
            return _position.GetX() + _width;
        }

        public double GetTopEdge()
        {
            return _position.GetY();
        }

        public double GetBottomEdge()
        {
            return _position.GetY() + _height;
        }

        public int GetWidth()
        {
            return _width;
        }

        public void SetWidth(int width)
        {
            _width = width;
        }

        public int GetHeight()
        {
            return _height;
        }

        public void SetHeight(int height)
        {
            _height = height;
        }

        public Point GetPosition()
        {
            return _position;
        }

        public void SetPosition(Point position)
        {
            _position = position;
        }

        public Point GetVelocity()
        {
            return _velocity;
        }

        public void SetVelocity(Point newVelocity)
        {
            _velocity = newVelocity;
        }

        public void MoveNext()
        {
            double x = _position.GetX();
            double y = _position.GetY();

            double dx = _velocity.GetX();
            double dy = _velocity.GetY();

            double newX = (x + dx) % Constants.MAX_X;
            double newY = (y + dy) % Constants.MAX_Y;

            if (newX < 0)
            {
                newX = Constants.MAX_X;
            }

            if (newY < 0)
            {
                newY = Constants.MAX_Y;
            }

            _position = new Point(newX, newY);
        }

        public override string ToString()
        {
            return $"Position: ({_position.GetX()}, {_position.GetY()}), Velocity({_velocity.GetX()}, {_velocity.GetY()})";
        }

    }

}