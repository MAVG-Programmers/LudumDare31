using SFML.Graphics;
using SFML.Window;
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
            this.Tiles = Tilemap.FromFile("Maps/testmap/testmap.map");
            this.Entities = new List<Entity>();

            //Load the Entities
            foreach (Entity entity in Entities)
            {
                //Load entities from file somewhere?!
                entity.Load();
            }
        }

        public void Update(Game g, int deltatime)
        {
<<<<<<< HEAD
            if (g.inputManager.IsKeyPressed(Keyboard.Key.Tab) && this.WorldSetting == WorldSetting.Normal) 
=======
            Console.WriteLine(deltatime);

            

            if (g.InputManager.IsKeyPressed(Keyboard.Key.Tab) && this.WorldSetting == WorldSetting.Normal) 
>>>>>>> 64b9739c7dfbcc281cb98f8a925acd969364097a
            {
                this.WorldSetting = WorldSetting.Fire;
            }
            else if (g.InputManager.IsKeyPressed(Keyboard.Key.Tab) && this.WorldSetting == WorldSetting.Fire)
            {
                this.WorldSetting = WorldSetting.Ice;
            }
            else if (g.InputManager.IsKeyPressed(Keyboard.Key.Tab) && this.WorldSetting == WorldSetting.Ice)
            {
                this.WorldSetting = WorldSetting.Normal;
            }


            Tiles.Update(g, deltatime);
            //Update the Entities
            foreach (Entity entity in Entities)
            {
                entity.Update(g, deltatime);
            }
        }

        public void Draw(Game g, int deltatime)
        {
            //Draw the Tilemap
            Tiles.Draw(g);

            //Draw the Entities
            foreach (Entity entity in Entities) 
            {
                entity.Draw(g, deltatime);
            }
        }
    }
}