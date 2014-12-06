using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LudumDare31Game
{
    public interface GameState
    {
        public void Load();
        public void Update(Game g, int deltaTime);
        public void Draw(Game g, int deltaTime);
    }
}
