using SFML.Window;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LudumDare31Game
{
    public class RectCollider
    {
        public Vector2f Postition { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public Entity Parent { get; set; }

        public RectCollider(Vector2f position, int height, int width, Entity parent, Game g)
        {
            this.Postition = position;
            this.Height = height;
            this.Width = width;
            this.Parent = parent;
            g.ColManager.RectColliders.Add(this);
        }

        public bool Intersects(RectCollider col)
        {
            if((Postition.X > col.Postition.X + col.Width) || (Postition.Y > col.Postition.Y + col.Height) || (Postition.X + Width < col.Postition.X) || (Postition.Y + Height < col.Postition.Y))
                return false;
            return true;
        }

        public void OnCollide(object sender, CollisionEventArgs e) 
        {
            if(Collision != null)
                Collision(sender, e);
        }

        public delegate void CollisionEventHandler(object sender, CollisionEventArgs e);

        public event CollisionEventHandler Collision;
    }
}
