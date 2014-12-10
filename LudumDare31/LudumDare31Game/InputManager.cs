﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;
using SFML;

namespace LudumDare31Game
{
    public class InputManager
    {
        Dictionary<Keyboard.Key, bool> _keyStates;
        Dictionary<Keyboard.Key, bool> _previousKeyStates;
        IEnumerable<Keyboard.Key> keysEnum = Enum.GetValues(typeof(Keyboard.Key)).Cast<Keyboard.Key>();

        Dictionary<Mouse.Button, bool> _buttonStates;
        Dictionary<Mouse.Button, bool> _previousButtonStates;
        IEnumerable<Mouse.Button> buttonEnum = Enum.GetValues(typeof(Mouse.Button)).Cast<Mouse.Button>();

        public event Action<object, MouseWheelEventArgs> OnWheelScroll;
        public event Action<object, MouseWheelEventArgs> OnWheelScrollUp;
        public event Action<object, MouseWheelEventArgs> OnWheelScrollDown;

        private Game game;

        public bool this[Keyboard.Key k]
        {
            get { return IsKeyDown(k); }
        }

        public bool this[Mouse.Button b]
        {
            get { return IsKeyDown(b); }
        }

        public int ScrollWheelDelta { get; set; }
        public bool ScrollWheelMoved
        {
            get { return (ScrollWheelDelta != 0); }
        }

        public Vector2i MousePosition
        {
            get { return Mouse.GetPosition(game.RenderForm); }
            set { Mouse.SetPosition(value); }
        }

        public InputManager(Game g)
        {
            game = g;
            game.RenderForm.MouseWheelMoved += _OnWheelScroll;
            _keyStates = new Dictionary<Keyboard.Key, bool>();
            _previousKeyStates = new Dictionary<Keyboard.Key, bool>();
            _buttonStates = new Dictionary<Mouse.Button, bool>();
            _previousButtonStates = new Dictionary<Mouse.Button, bool>();

            foreach (Keyboard.Key key in keysEnum)
            {
                _keyStates.Add(key, false);
                _previousKeyStates.Add(key, false);
            }

            foreach (Mouse.Button button in buttonEnum)
            {
                _buttonStates.Add(button, false);
                _previousButtonStates.Add(button, false);
            }
        }

        public void Update()
        {
            ScrollWheelDelta = 0;
            _previousKeyStates.Clear();
            _previousButtonStates.Clear();
            //Can't do like below because a Dictionary is passed by reference
            //_previousKeyStates = _keyStates;
            foreach (KeyValuePair<Keyboard.Key, bool> valuePair in _keyStates)
            {
                _previousKeyStates.Add(valuePair.Key, valuePair.Value);
            }
            foreach (KeyValuePair<Mouse.Button, bool> pair in _buttonStates)
            {
                _previousButtonStates.Add(pair.Key, pair.Value);
            }

            _keyStates.Clear();
            _buttonStates.Clear();
            foreach (Keyboard.Key key in keysEnum)
            {
                _keyStates.Add(key, CheckKey(key));
            }
            foreach (Mouse.Button button in buttonEnum)
            {
                _buttonStates.Add(button, CheckKey(button));
            }
        }

        private bool CheckKey(Keyboard.Key k)
        {
            return Keyboard.IsKeyPressed(k);
        }

        private bool CheckKey(Mouse.Button b)
        {
            return Mouse.IsButtonPressed(b);
        }

        private void _OnWheelScroll(object sender, MouseWheelEventArgs args)
        {
            ScrollWheelDelta = args.Delta;

            Action<object, MouseWheelEventArgs> ws = OnWheelScroll;
            Action<object, MouseWheelEventArgs> wsu = OnWheelScrollUp;
            Action<object, MouseWheelEventArgs> wsd = OnWheelScrollDown;

            if (ws != null)
                ws(sender, args);

            if (args.Delta > 0 && wsu != null)
                wsu(sender, args);

            else if (args.Delta < 0 && wsd != null)
                wsd(sender, args);
        }

        /// <summary>
        /// Returns all the keyboard keys that were pressed in the current frame
        /// </summary>
        /// <returns></returns>
        public Keyboard.Key[] GetPressedKeys()
        {
            return (from key in _keyStates where key.Value select key.Key).ToArray();
        }

        /// <summary>
        /// Returns all the keyboard keys that were pressed in the last frame
        /// </summary>
        /// <returns></returns>
        public Keyboard.Key[] GetLastFramePressedKeys()
        {
            //<3 LINQ
            return (from key in _previousKeyStates where key.Value select key.Key).ToArray();
        }


        /// <summary>
        /// Checks if the specified key was down and is now up
        /// </summary>
        /// <param name="key">The desired keyboard key</param>
        /// <returns></returns>
        public bool IsKeyReleased(Keyboard.Key key)
        {
            return WasKeyDown(key) && IsKeyUp(key);
        }

        /// <summary>
        /// Checks if the specified key was down and is now up
        /// </summary>
        /// <param name="button">The desired mouse button</param>
        /// <returns></returns>
        public bool IsKeyReleased(Mouse.Button button)
        {
            return WasKeyDown(button) && IsKeyUp(button);
        }

        /// <summary>
        /// Checks if the specified key was up and is now down
        /// </summary>
        /// <param name="key">The desired key</param>
        /// <returns></returns>
        public bool IsKeyPressed(Keyboard.Key key)
        {
            return IsKeyDown(key) && WasKeyUp(key);
        }

        /// <summary>
        /// Checks if the specified key was up and is now down
        /// </summary>
        /// <param name="button">The desired mouse button</param>
        /// <returns></returns>
        public bool IsKeyPressed(Mouse.Button button)
        {
            return IsKeyDown(button) && WasKeyUp(button);
        }

        /// <summary>
        /// Checks if the key was up(not pressed) on the last frame
        /// </summary>
        /// <param name="key">The desired key</param>
        /// <returns></returns>
        public bool WasKeyUp(Keyboard.Key key)
        {
            return !WasKeyDown(key);
        }

        /// <summary>
        /// Checks if the key was up(not pressed) on the last frame
        /// </summary>
        /// <param name="button">The desired mouse button</param>
        /// <returns></returns>
        public bool WasKeyUp(Mouse.Button button)
        {
            return !WasKeyDown(button);
        }

        /// <summary>
        /// Checks if the key was down(pressed) on the last frame
        /// </summary>
        /// <param name="key">The desired key</param>
        /// <returns></returns>
        public bool WasKeyDown(Keyboard.Key key)
        {
            return _previousKeyStates[key];
        }

        /// <summary>
        /// Checks if the key was down(pressed) on the last frame
        /// </summary>
        /// <param name="button">The desired mouse button</param>
        /// <returns></returns>
        public bool WasKeyDown(Mouse.Button button)
        {
            return _previousButtonStates[button];
        }

        /// <summary>
        /// Checks if the key is up(not pressed)
        /// </summary>
        /// <param name="key">The desired key</param>
        /// <returns></returns>
        public bool IsKeyUp(Keyboard.Key key)
        {
            return !IsKeyDown(key);
        }

        /// <summary>
        /// Checks if the key is up(not pressed)
        /// </summary>
        /// <param name="button">The desired mouse button</param>
        /// <returns></returns>
        public bool IsKeyUp(Mouse.Button button)
        {
            return !IsKeyDown(button);
        }

        public bool IsKeyDown(Mouse.Button button)
        {
            return _buttonStates[button];
        }

        public bool IsKeyDown(Keyboard.Key key)
        {
            return _keyStates[key];
        }
    }
}