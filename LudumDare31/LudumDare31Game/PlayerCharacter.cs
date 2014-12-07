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
        private float playerSpeed = .5f;

        private Texture texture;
        private Sprite sprite;

        public FloatRect PlayerBox { get; private set; }

        private Collision col;

        public void Load()
        {
            texture = new Texture("../../../../Sprites/Player/Trollman.png");
            sprite = new Sprite(texture);

            PlayerBox = sprite.GetGlobalBounds();

            sprite.Position = new Vector2f(0, 0);

            col = new Collision();
        }

        public void Update(Game g, int deltaTime)
        {
            if(Keyboard.IsKeyPressed(Keyboard.Key.W))
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
                //col.CheckCollision(PlayerBox, t.TileBox);
                if (PlayerBox.Intersects(t.TileBox))
                {
                    Console.Write(11111111111111);
                }
            }
        }

        public void Draw(Game g, int deltatime)
        {
            g.RenderForm.Draw(sprite);
        }
    }
}
