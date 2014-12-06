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
        
        /// <summary>
        /// Generates a Tilemap datastructure from a textfile
        /// </summary>
        /// <param name="filepath">the mapfile</param>
        /// <returns>The generated tilemap</returns>
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

            for (int y = 2; y < lines.Length; y++)
            {
                string[] cells = lines[y].Split(',');

                for (int x = 0; x < xSize; x++)
                {
                    tm.Tiles[x, y-2] = Tile.FromInt(int.Parse(cells[x]));
                }
            }

            return tm;
        }

        public void Draw(Game g, int deltatime) 
        {
            
        }


        public void DebugDraw(Game g)
        {
            Console.Clear();

            for (int y = 0; y < VerticalSize; y++)
            {
                for (int x = 0; x < HorizontalSize; x++)
                {
                    Tiles[x, y].DebugDraw(g);
                }
                Console.WriteLine();
            }
        }
    }
}
