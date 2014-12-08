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
                if (sprite1.GetGlobalBounds().Left + sprite1.GetGlobalBounds().Width > sprite2.GetGlobalBounds().Left && sprite1.GetGlobalBounds().Left + sprite1.GetGlobalBounds().Width < sprite2.GetGlobalBounds().Left + sprite2.GetGlobalBounds().Width)
                {
                    Console.WriteLine(CollisionSide.Right);
                    colSide = CollisionSide.Right;
                }
                if (sprite1.GetGlobalBounds().Left < sprite2.GetGlobalBounds().Left + sprite2.GetGlobalBounds().Width && sprite1.GetGlobalBounds().Left > sprite2.GetGlobalBounds().Left)
                {
                    Console.WriteLine(CollisionSide.Left);
                    colSide = CollisionSide.Left;
                }
                if (sprite1.GetGlobalBounds().Top + sprite1.GetGlobalBounds().Height > sprite2.GetGlobalBounds().Top && sprite1.GetGlobalBounds().Top + sprite1.GetGlobalBounds().Height < sprite2.GetGlobalBounds().Top + sprite2.GetGlobalBounds().Height)
                {
                    Console.WriteLine(CollisionSide.Bottom);
                    colSide = CollisionSide.Bottom;
                }
                if (sprite1.GetGlobalBounds().Top < sprite2.GetGlobalBounds().Top + sprite2.GetGlobalBounds().Height && sprite1.GetGlobalBounds().Top > sprite2.GetGlobalBounds().Top)
                {
                    Console.WriteLine(CollisionSide.Top);
                    colSide = CollisionSide.Top;
                }
                else
                {
                    colSide = CollisionSide.NoCol;
                }
            }
            return colSide;
        }
    }
}
