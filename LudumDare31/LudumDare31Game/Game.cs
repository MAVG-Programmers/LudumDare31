﻿﻿using SFML.Graphics;
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
        public bool IsPaused { get; set; }
        public Gamestate Gamestate { get; set; }

        public InputManager inputManager { get; set; }

        public PlayerCharacter player { get; private set; }

        public void Run()
        {
            RenderForm = new RenderWindow(new VideoMode(800, 600), "Notaripoff - The Game");
            RenderForm.SetFramerateLimit(120);
            RenderForm.Closed += RenderForm_Closed;

            Gamemap = new Map();
            Gamemap.Load();

            inputManager = new InputManager(this);

            player = new PlayerCharacter();
            player.Load();

            //Gamemap.DebugDraw(this);

            while (RenderForm.IsOpen())
            {
                RenderForm.Clear(Color.Magenta);

                RenderForm.DispatchEvents();

                int deltatime = (int)sw.ElapsedMilliseconds;
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
            if (this.Gamestate == Gamestate.InGame)
            {
                Gamemap.Update(this, deltatime);
            }
            //Add code for Menu and WorldSelector

            player.Update(this, deltatime);
        }

        public void Draw(int deltatime)
        {
            if (this.Gamestate == Gamestate.InGame)
            {
                RenderForm.SetView(RenderForm.DefaultView); //this should only be done if the gamestate changes
                Gamemap.Draw(this, deltatime);

                player.Draw(this, deltatime);
            }
            //if gamestate = menu
            //view = default view
            //draw menu

            //if gamestate = selector
            //4+ views (1 for each world)
            //draw selector
        }

        public void Dispose()
        {

        }
    }
}