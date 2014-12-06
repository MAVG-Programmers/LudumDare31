using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LudumDare31Game
{
    public class Tilemap
    {
        public Tile[,] Tiles { get; set; }
        public int HorizontalSize { get; set; }
        public int VerticalSize { get; set; }

        public Tilemap(int xSize, int ySize)
        {
            Tiles = new Tile[16, 8];
            HorizontalSize = xSize;
            VerticalSize = ySize;
        }
        

        public static Tilemap FromFile(string filepath)
        {
            string[] lines = File.ReadAllLines(filepath);
            int xSize = int.Parse(lines[0]);
            int ySize = int.Parse(lines[1]);



            //x start index = 0
            //y start index = 2

            //x end index = lines[0] -1
            //y end index = lines[1] +2 -1

            Tilemap tm = new Tilemap(xSize, ySize);

            for (int y = 2; y < lines.Length-2; y++)
            {
                string[] cells = lines[y].Split(',');

                for (int x = 0; x < xSize; x++)
                {
                    tm.Tiles[x, y-2] = Tile.FromInt(int.Parse(cells[x]));
                }
            }

            return tm;
        }
    }
}
