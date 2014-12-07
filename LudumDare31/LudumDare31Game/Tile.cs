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
        public Sprite Sprite { get; set; }

        public FloatRect TileBox { get; private set; }

        private Dictionary<WorldSetting, Texture> Textures;
        private Shader shader;

        public Tile(TileType tileType)
        {
            // TODO: Complete member initialization

            // ContentLoader.LoadDrawable(tiletype)
            this.Tiletype = tileType;
            Textures = new Dictionary<WorldSetting,Texture>();
            //Sprite = new Image("../../../Maps/testmap/Normal/" + Tiletype.ToString());
        }



        public void Load()
        {
            //Load All sprites with Tiletype = tileType
            //Texture tex = new Texture("../../../../Sprites/Normal/SurfaceTile.png");

            switch (this.Tiletype) 
            {
                case TileType.Surface:
                    this.Textures.Add(WorldSetting.Normal, new Texture("../../../../Sprites/Normal/SurfaceTile.png"));
                    this.Textures.Add(WorldSetting.Fire, new Texture("../../../../Sprites/Fire/SurfaceTile.png"));
                    this.Textures.Add(WorldSetting.Ice, new Texture("../../../../Sprites/Ice/SurfaceTile.png"));
                    break;
                case TileType.Underground:
                    this.Textures.Add(WorldSetting.Normal, new Texture("../../../../Sprites/Normal/UndergroundTile.png"));
                    this.Textures.Add(WorldSetting.Fire, new Texture("../../../../Sprites/Fire/UndergroundTile.png"));
                    this.Textures.Add(WorldSetting.Ice, new Texture("../../../../Sprites/Ice/UndergroundTile.png"));
                    break;
                default:
                    this.Textures.Add(WorldSetting.Normal, new Texture(32, 32));
                    this.Textures.Add(WorldSetting.Fire, new Texture(32, 32));
                    this.Textures.Add(WorldSetting.Ice, new Texture(32, 32));
                    break;
            }

            
            this.Sprite = new Sprite(new Texture(Textures[WorldSetting.Normal]));
            //Sets the position of the sprite
            this.Sprite.Position = new Vector2f(this.Position.X * 32, this.Position.Y * 32); ; //*32 because tilesize is 32 and the Position vector is in Tiles.

            
        }

        public void Update(Game g, int deltatime)
        {
            //Change sprite according to worldsetting
            this.Sprite.Texture = Textures[g.Gamemap.WorldSetting];
            this.Sprite.Position = new Vector2f(this.Position.X * 32, this.Position.Y * 32); ; //*32 because tilesize is 32 and the Position vector is in Tiles.
            TileBox = this.Sprite.GetGlobalBounds();
        }

        public void Draw(Game g)
        {
            g.RenderForm.Draw(this.Sprite);
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
