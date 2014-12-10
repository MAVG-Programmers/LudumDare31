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
        private int playerSpeed = 5;

        public void Load()
        {

        }

        public void Update(Game g, int deltaTime)
        {
            if(Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                base.Position = new Vector2f(base.Position.X, base.Position.Y + playerSpeed * deltaTime);
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                base.Position = new Vector2f(base.Position.X - playerSpeed * deltaTime, base.Position.Y);
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                base.Position = new Vector2f(base.Position.X, base.Position.Y - playerSpeed * deltaTime);
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                base.Position = new Vector2f(base.Position.X + playerSpeed * deltaTime, base.Position.Y);
            }

        }

        public void Draw(Game g, int deltatime)
        {
            throw new NotImplementedException();
        }
    }
}
