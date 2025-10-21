using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Engine
{
    public class InputHelper
    {

        MouseState currentMouseState, previousMouseState;
        KeyboardState currentKeyboardState, previousKeyboardState;
        ExtendedGame game;

        public InputHelper(ExtendedGame game) 
        {
            this.game = game;
        }

        public void Update(GameTime gameTime)
        {
            previousMouseState = currentMouseState;
            previousKeyboardState = currentKeyboardState;
            currentMouseState = Mouse.GetState();
            currentKeyboardState = Keyboard.GetState();
        }

        public Vector2 MousePositionScreen
        {
            get { return new Vector2(currentMouseState.X, currentMouseState.Y); }
        }

        public Vector2 MousePositionWorld
        {
            get { return game.ScreenToWorld(MousePositionScreen); }
        }

        public bool LeftMouseButtonPressed
        {
            get
            {
                return currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released;
            }
        }

        public bool LeftMouseButtonDown
        {
            get
            {
                return currentMouseState.LeftButton == ButtonState.Pressed;
            }
        }

        public bool RightMouseButtonPressed
        {
            get
            {
                return currentMouseState.RightButton == ButtonState.Pressed && previousMouseState.RightButton == ButtonState.Released;
            }
        }

        public bool RightMouseButtonDown
        {
            get
            {
                return currentMouseState.RightButton == ButtonState.Pressed;
            }
        }

        public bool KeyPressed(Keys k)
        {
            return currentKeyboardState.IsKeyDown(k) && previousKeyboardState.IsKeyUp(k);
        }

        public bool KeyDown(Keys k)
        {
            return currentKeyboardState.IsKeyDown(k);
        }


    }
}
