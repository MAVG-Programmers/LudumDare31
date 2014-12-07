using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML;
using SFML.Graphics;

namespace LudumDare31Game
{
    class Collision
    {
        public void CheckCollision(FloatRect rect1, FloatRect rect2)
        {
            if(rect1.Intersects(rect2))
            {
                Console.Write(11111111111111);
            }
        }
    }
}
