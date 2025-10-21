using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public class GameObject
    {

        public GameObject Parent{get; set;}
        public Vector2 LocalPosition{get{return localPosition;} set{localPosition = value;}}
        protected Vector2 localPosition;
        public Vector2 GlobalPosition
        {
            get
            {
                if(Parent != null)
                {
                    return Parent.LocalPosition + this.LocalPosition;
                }
                return this.LocalPosition;
            }
        }
        public Vector2 Velocity{get{return velocity;}}
        protected Vector2 velocity;

        public GameObject()
        {

        }

        public virtual void Update(GameTime gameTime)
        {
            LocalPosition += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public virtual void HandleInput(InputHelper inputHelper)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            
        }
    }
}