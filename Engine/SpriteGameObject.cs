using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public class SpriteGameObject : GameObject
    {
        protected Texture2D Sprite{get; set;} 

        protected int SheetIndex{get; set;}
        
        public float Depth{get; set;}

        public int Width{get; set;}
        public int Height{get; set;}
        int rows;
        int columns;

        public SpriteGameObject(string spriteName, float depth, int sheetIndex = 0)
        {
            Sprite = ExtendedGame.AssetManager.LoadSprite(spriteName);
            Depth = depth;
            SheetIndex = sheetIndex;

            string[] nameSplit = spriteName.Split('@');
            if(nameSplit.Length > 1)
            {
                nameSplit = nameSplit[1].Split('x');
                if(nameSplit.Length == 1)
                    rows = 1;
                else
                    rows = int.Parse(nameSplit[1]);

                columns = int.Parse(nameSplit[0]);
            }
            else
            {
                columns = 1;
                rows = 1;
                SheetIndex = 0;
            }

            Width = Sprite.Width / columns;
            Height = Sprite.Height / rows;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(Sprite, GlobalPosition, DrawBox, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, Depth);
        }

        public Rectangle BoundingBox
        {
            get
            {
                Rectangle bbox = new Rectangle();
                
                bbox.Width = Width;
                bbox.Height = Height;

                bbox.X = (int) LocalPosition.X;
                bbox.Y = (int) LocalPosition.Y;

                return bbox;
            }
        }

        public Rectangle DrawBox
        {
            get
            {
                Rectangle dbox = BoundingBox;
                
                if(SheetIndex > 0 && SheetIndex < columns * rows)
                {
                    dbox.X = (SheetIndex % columns) * Width;
                    dbox.Y = (SheetIndex / columns) * Height;
                }
                else
                {
                    dbox.X = 0;
                    dbox.Y = 0;
                }

                return dbox;
            }
        }
    }
}


