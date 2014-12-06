﻿using SFML.Graphics;
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
        public Stack<GameState> Gamestates { get; set; }

        public void Run() 
        {
            RenderForm = new RenderWindow(new VideoMode(200, 200), "gamename");

            RenderForm.Closed += RenderForm_Closed;

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
            Gamestates.Peek().Update(this, deltatime);
        }

        public void Draw(int deltatime) 
        {
            Gamestates.Peek().Draw(this, deltatime);
        }

        public void Dispose()
        {
            
        }
    }
}
