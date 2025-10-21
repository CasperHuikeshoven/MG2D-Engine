using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public class GameState : GameObjectList
    {
        protected GameStateManager GameStateManager{get; set;}

        public GameState(GameStateManager gameStateManager)
        {
            GameStateManager = gameStateManager;
        }
    }
}


