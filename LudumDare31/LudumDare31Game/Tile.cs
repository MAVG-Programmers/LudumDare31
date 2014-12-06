using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LudumDare31Game
{
    public class Tile
    {
        private TileType tileType;

        public Tile(TileType tileType)
        {
            // TODO: Complete member initialization

            // ContentLoader.LoadDrawable(tiletype)
            this.tileType = tileType;
        }
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

        public static Tile FromInt(int p)
        {
            switch (p)
            {
                case 0:
                    return new Tile(TileType.Empty);
                case 1:
                    return new Tile(TileType.Surface);
                case 2:
                    return new Tile(TileType.Underground);
                default:
                    return new Tile(TileType.Empty);
            }
        }
    }
}
