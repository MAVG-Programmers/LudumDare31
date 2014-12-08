using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace LudumDare31Game
{
    public class PlayerCharacter : Transformable, Entity
    {
        private float playerSpeed = .1f;

        private Texture texture;
        private Sprite sprite;

        public void Load()
        {
            texture = new Texture("../../../../Sprites/Player/Trollman.png");
            sprite = new Sprite(texture);
            
            
            sprite.Position = new Vector2f(0, 0);
        }

        public void Update(Game g, int deltaTime)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                base.Position = new Vector2f(base.Position.X, base.Position.Y - playerSpeed * deltaTime);
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                base.Position = new Vector2f(base.Position.X - playerSpeed * deltaTime, base.Position.Y);
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                base.Position = new Vector2f(base.Position.X, base.Position.Y + playerSpeed * deltaTime);
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                base.Position = new Vector2f(base.Position.X + playerSpeed * deltaTime, base.Position.Y);
            }

            sprite.Position = base.Position;

            foreach(Tile t in g.Gamemap.Tiles.Tiles)
            {
                if (t.Tiletype != TileType.Empty)
                {
                    double a = sprite.Position.X - t.Sprite.Position.X;
                    double b = sprite.Position.Y - t.Sprite.Position.Y;

                    double distance = Math.Sqrt(a*a + b*b);
                    if(distance < 32)
                    {
                        if (Collision.CheckCollision(sprite, t.Sprite) == CollisionSide.Top)
                        {
                            base.Position = new Vector2f(1, 1);
                        }
                        if (Collision.CheckCollision(sprite, t.Sprite) == CollisionSide.Bottom)
                        {
                            base.Position = new Vector2f(1, 1);
                        }
                        if (Collision.CheckCollision(sprite, t.Sprite) == CollisionSide.Left)
                        {
                            base.Position = new Vector2f(1, 1);
                        }
                        if (Collision.CheckCollision(sprite, t.Sprite) == CollisionSide.Right)
                        {
                            base.Position = new Vector2f(1, 1);
                        }
                    }
                    
                }
            }
        }

        public void Draw(Game g, int deltatime)
        {
            g.RenderForm.Draw(sprite);
        }
    }
}
