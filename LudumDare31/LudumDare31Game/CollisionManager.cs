using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudumDare31Game
{
    public class CollisionManager
    {
        public List<RectCollider> RectColliders { get; set; }

        public void Update(Game g, int deltatime) 
        {
            for (int i = 0; i < RectColliders.Count; i++) 
            {
                for (int j = i + 1; j < RectColliders.Count; j++) 
                {
                    if (RectColliders[i].Intersects(RectColliders[j]))
                    {
                        RectColliders[i].OnCollide(this, new CollisionEventArgs(RectColliders[j].Parent));
                        RectColliders[j].OnCollide(this, new CollisionEventArgs(RectColliders[i].Parent));
                    }
                }
            }
        }
    }
}
