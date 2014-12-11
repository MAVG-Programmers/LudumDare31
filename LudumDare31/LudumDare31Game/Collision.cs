using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML;
using SFML.Graphics;

namespace LudumDare31Game
{
    public enum CollisionSide
    {
        Left,
        Right,
        Top,
        Bottom,
        NoCol
    }

    class Collision
    {
        public static CollisionSide CheckCollision(Sprite sprite1, Sprite sprite2)
        {
            CollisionSide colSide = CollisionSide.NoCol;
            if (sprite1.GetGlobalBounds().Intersects(sprite2.GetGlobalBounds()))
            {
                
            }
            return colSide;
        }
    }
}
