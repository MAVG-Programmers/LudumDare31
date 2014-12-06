using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudumDare31Game
{
    public class Map
    {
        public Tile[][] Tiles { get; set; }
        public List<Entity> Entities { get; set; }
        public WorldSetting WorldSetting { get; set; }
            
        public void Load()
        {
            //foreach tile do:
            //tiletype = Mapfile.LoadTile(xPos, yPos)
            //tile.Sprites = Mapfile.DeserializeSpriteDictionary(tiletype)
        }
        public void Update(Game g, int deltatime)
        {

        }
        public void Draw(Game g, int deltatime)
        {

        }
        public void LoadMapfile(string filepath) 
        {
            string[] lines = File.ReadAllLines(filepath);

            for (int y = 0; y < lines.Length; y++) 
            {
                string[] cols = lines[y].Split(',');
                for (int x = 0; x < cols.Length; x++) 
                {
                    Tiles[x][y] = Tile.FromInt(int.Parse(cols[x]));
                }
            }
        }
    }
}
