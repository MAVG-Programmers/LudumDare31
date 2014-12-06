using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;

namespace LudumDare31Game
{
    public class Tile
    {
        public TileType Tiletype { get; set; }
        public Vector2f Position { get; set; }
        public Image Sprite { get; set; }



        public Tile(TileType tileType)
        {
            // TODO: Complete member initialization

            // ContentLoader.LoadDrawable(tiletype)
            this.Tiletype = tileType;
            //Sprite = new Image("../../../Maps/testmap/Normal/" + Tiletype.ToString());
        }



        public void Load()
        {
            //Load All sprites with Tiletype = tileType
        }
        public void Update(Game g, int deltatime)
        {
            
        }
        public void Draw(Game g, int deltatime)
        {
            
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




        public void DebugDraw(Game g)
        {
            switch (this.Tiletype)
            {
                case TileType.Empty:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("0");
                    break;
                case TileType.Surface:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("1");
                    break;
                case TileType.Underground:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("2");
                    break;
            }
        }
    }
}
