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
        private int playerSpeed = 1;

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
        }

        public void Draw(Game g, int deltatime)
        {
            g.RenderForm.Draw(sprite);
        }
    }
}
