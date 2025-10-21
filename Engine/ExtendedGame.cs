using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Engine
{
    public class ExtendedGame : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public static GameStateManager GameStateManager{get; set;}

        public static AssetManager AssetManager{get; set;}

        private InputHelper inputHelper; 

        public static Random Random{get; set;}

        protected static Point WorldSize {get; set;}
        protected static Point WindowSize {get; set;}
        Matrix spriteScale;

        public ExtendedGame()
        {
            inputHelper = new InputHelper(this);
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            GameStateManager = new GameStateManager();
            AssetManager = new AssetManager(Content);

            WorldSize = new Point(320, 192);
            WindowSize = new Point(1280, 768);

            ChangeScreen(false);

            Random = new Random();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            inputHelper.Update(gameTime);
            HandleInput(inputHelper);
            
            GameStateManager.Update(gameTime);
        }

        protected virtual void HandleInput(InputHelper inputHelper)
        {
            GameStateManager.HandleInput(inputHelper);

            // Change screen to fullscreen or unfullscreen by pressing f5
            if(inputHelper.KeyPressed(Keys.F5))
                ChangeScreen(!IsFullScreen);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.FrontToBack, null, SamplerState.PointClamp, null, null, null, spriteScale);
            
            GameStateManager.Draw(spriteBatch, gameTime);

            spriteBatch.End();
        }

        /// <summary>
        /// Property for setting and getting the value of fullscreen
        /// </summary>
        protected bool IsFullScreen
        {
            get
            {
                return graphics.IsFullScreen;
            }
            set
            {
                graphics.IsFullScreen = value;
            }
        }

        protected void ChangeScreen(bool fullscreen)
        {
            IsFullScreen = fullscreen;

            Point screenSize;

            if(!IsFullScreen)
            {
                screenSize.X = WindowSize.X;
                screenSize.Y = WindowSize.Y; 
            } 
            else
            {
                screenSize = new Point(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height);
            }

            graphics.PreferredBackBufferWidth = screenSize.X;
            graphics.PreferredBackBufferHeight = screenSize.Y;

            graphics.ApplyChanges();

            GraphicsDevice.Viewport = CalculateViewport(screenSize);

            spriteScale = Matrix.CreateScale((float)GraphicsDevice.Viewport.Width / WorldSize.X, (float)GraphicsDevice.Viewport.Height / WorldSize.Y, 1);
        }

        Viewport CalculateViewport(Point windowSize)
        {
            // create a Viewport object
            Viewport viewport = new Viewport();

            // calculate the two aspect ratios
            float gameAspectRatio = (float)WorldSize.X / WorldSize.Y;
            float windowAspectRatio = (float)windowSize.X / windowSize.Y;

            // if the window is relatively wide, use the full window height
            if (windowAspectRatio > gameAspectRatio)
            {
                viewport.Width = (int)(windowSize.Y * gameAspectRatio);
                viewport.Height = windowSize.Y;
            }
            // if the window is relatively high, use the full window width
            else
            {
                viewport.Width = windowSize.X;
                viewport.Height = (int)(windowSize.X / gameAspectRatio);
            }

            // calculate and store the top-left corner of the viewport
            viewport.X = (windowSize.X - viewport.Width) / 2;
            viewport.Y = (windowSize.Y - viewport.Height) / 2;

            return viewport;
        }

        public Vector2 ScreenToWorld(Vector2 screenPosition)
        {
            Vector2 viewportTopLeft = new Vector2(GraphicsDevice.Viewport.X, GraphicsDevice.Viewport.Y);
            float screenToWorld = WorldSize.X / (float) GraphicsDevice.Viewport.Width;
            return (screenPosition - viewportTopLeft) * screenToWorld;
        }
    }
}