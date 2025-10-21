using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public class GameObjectList : GameObject
    {
        private List<GameObject> gameObjects;

        public GameObjectList()
        {
            gameObjects = new List<GameObject>();
        }

        public void AddChild(GameObject obj)
        {
            gameObjects.Add(obj);
        }

        public void RemoveChild(GameObject obj)
        {
            gameObjects.Remove(obj);
        }

        public override void Update(GameTime gameTime)
        {
            foreach(GameObject obj in gameObjects)
            {
                obj.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach(GameObject obj in gameObjects)
            {
                obj.Draw(spriteBatch, gameTime);
            }
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            foreach(GameObject obj in gameObjects)
            {
                obj.HandleInput(inputHelper);
            }
        }
    }
}


