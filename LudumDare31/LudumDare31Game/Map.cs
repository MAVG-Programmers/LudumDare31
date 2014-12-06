using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudumDare31Game
{
    public class Map
    {
        public Tilemap Tiles { get; set; }
        public List<Entity> Entities { get; set; }
        public WorldSetting WorldSetting { get; set; }
            
        public void Load()
        {
            //foreach tile do:
            //tiletype = Mapfile.LoadTile(xPos, yPos)
            //tile.Sprites = Mapfile.DeserializeSpriteDictionary(tiletype)

            this.Tiles = Tilemap.FromFile("test.map");
            this.Entities = new List<Entity>();
        }

        public void Update(Game g, int deltatime)
        {

        }

        public void Draw(Game g, int deltatime) 
        {
            Tiles.Draw(g, deltatime);
        }
    }
}