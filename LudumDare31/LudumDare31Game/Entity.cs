using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LudumDare31Game
{
    public interface Entity
    {
        void Load(InputManager inputManager);
        void Update(Game g, int deltatime);
        void Draw(Game g, int deltatime);
    }
}
