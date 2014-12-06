using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LudumDare31Game
{
    public class Tile
    {
        public DrawablePart Sprite { get; set; }
        public TileType Tiletype { get; set; }

        public void Load() 
        {
        
        }
        public void Update(Game g, int deltatime)
        {
            
        }
        public void Draw(Game g, int deltatime)
        {
            Sprite.Draw(g, deltatime, this.Tiletype);
        }
    }
}
