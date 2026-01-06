using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.UI;

public class Button : SpriteGameObject
{
    public bool Pressed { get; protected set; }

    private CustomTextGameObject _text;
    public string Text { set { _text.Text = value; } }

    public Button(string spriteName) : base(spriteName, .8f)
    {
        _text = new CustomTextGameObject(Depth + 0.05f, alignment: CustomTextGameObject.Alignment.Center);
        _text.Parent = this;
        _text.LocalPosition = new Vector2(Sprite.Width / 2, Sprite.Height / 2 - 3);
    }

    public override void HandleInput(InputHelper inputHelper)
    {
        Pressed = inputHelper.LeftMouseButtonPressed && BoundingBox.Contains(inputHelper.MousePositionWorld);
    }

    public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        base.Draw(spriteBatch, gameTime);
        _text.Draw(spriteBatch, gameTime);
    }
}
