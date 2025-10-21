using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public class Tile : GameObject
    {
        public bool HasCollision{get; protected set;}

        protected SpriteGameObject? sprite;

        public Rectangle BoundingBoxForCollisions
        {
            get
            {
                Rectangle bbox = new Rectangle();

                bbox.Width = 16;
                bbox.Height = 16;

                bbox.X = (int)LocalPosition.X;
                bbox.Y = (int)LocalPosition.Y;

                return bbox;
            }
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if(sprite != null)
                sprite.Draw(spriteBatch, gameTime);
        }

    }
}
