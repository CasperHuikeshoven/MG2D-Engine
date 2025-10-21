using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public class GameStateManager
    {
        Dictionary<string, GameState> gameStates;
        GameState? activeState;

        public GameStateManager()
        {
            gameStates = new Dictionary<string, GameState>();
        }

        public void Update(GameTime gameTime)
        {
            if(activeState != null)
                activeState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if(activeState != null)
                activeState.Draw(spriteBatch, gameTime);
        }

        public void HandleInput(InputHelper inputHelper)
        {
            if(activeState != null)
                activeState.HandleInput(inputHelper);
        }

        public void SwitchState(string name)
        {
            activeState = gameStates[name];
        }

        public void AddGameState(GameState gameState, string name)
        {
            gameStates[name] = gameState;
        }

        public void RemoveGameState(string name)
        {
            //gameStates[name] = null;
        }
    }
}


