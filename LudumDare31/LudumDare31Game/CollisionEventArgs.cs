using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LudumDare31Game
{
    public class CollisionEventArgs
    {
        public Entity Collider { get; set; }

        public CollisionEventArgs(Entity collider) 
        {
            Collider = collider;
        }
    }
}
