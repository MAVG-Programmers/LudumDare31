using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudumDare31Game
{
    public class Game : IDisposable
    {
        private Stopwatch sw = new Stopwatch();

        public RenderWindow RenderForm { get; set; }
        public Map Gamemap { get; set; }

        private InputManager inputManager;

        public void Run() 
        {
            RenderForm = new RenderWindow(new VideoMode(800, 600), "Notaripoff - The Game");

            RenderForm.Closed += RenderForm_Closed;

            Gamemap = new Map();
            Gamemap.Load();

            //Gamemap.DebugDraw(this);

            while (RenderForm.IsOpen())
            {
                RenderForm.Clear(Color.Magenta);

                RenderForm.DispatchEvents();

                int deltatime = (int) sw.ElapsedMilliseconds;
                sw.Restart();

                Update(deltatime);
                Draw(deltatime);

                RenderForm.Display();
            }
        }

        void RenderForm_Closed(object sender, EventArgs e)
        {
            RenderForm.Close();
        }


        public void Load() 
        {
        
        }
        public void Update(int deltatime)
        {
            inputManager.Update();
        }

        public void Draw(int deltatime) 
        {
            //Gamemap.Draw(this, deltatime);
        }

        public void Pause() 
        {
            
        }

        public void Unpause() 
        {
            
        }

        public void Dispose()
        {

        }
    }
}
