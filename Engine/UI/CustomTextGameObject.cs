using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.UI;

/// <summary>
/// A game object that shows text (instead of an image).
/// </summary>
public class CustomTextGameObject : GameObject
{
    /// <summary>
    /// The text that this object should draw on the screen.
    /// </summary>
    public string Text { set { sheetNums = StringToText(value); } }

    /// <summary>
    /// The font to use.
    /// </summary>
    protected SpriteGameObject font;
    List<List<int>> sheetNums;

    /// <summary>
    /// The depth (between 0 and 1) at which this text should be drawn.
    /// A larger value means that the text will be drawn on top.
    /// </summary>
    protected float depth;
    float offset;

    /// <summary>
    /// An enum that describes the different ways in which a text can be aligned horizontally.
    /// </summary>
    public enum Alignment
    {
        Left,
        Right,
        Center
    }

    int size;

    /// <summary>
    /// The horizontal alignment of this text.
    /// </summary>
    protected Alignment alignment;

    /// <summary>
    /// Creates a new TextGameObject with the given details.
    /// </summary>
    /// <param name="fontName">The name of the font to use.</param>
    /// <param name="depth">The depth at which the text should be drawn.</param>
    /// <param name="color">The color with which the text should be drawn.</param>
    /// <param name="alignment">The horizontal alignment to use.</param>

    public CustomTextGameObject(float depth, int size = 6, Alignment alignment = Alignment.Left)
    {
        sheetNums = [];
        this.size = size;
        if (size == 4)
            font = new SpriteGameObject("UI/spr_font4x4@41x1", depth);
        else
            font = new SpriteGameObject("UI/spr_font6x6@41x1", depth);
        font.Parent = this;
        font.Color = Color.Black;
        this.depth = depth;
        this.alignment = alignment;
        Text = "";
    }

    /// <summary>
    /// Draws this TextGameObject on the screen.
    /// </summary>
    /// <param name="gameTime">An object containing information about the time that has passed in the game.</param>
    /// <param name="spriteBatch">A sprite batch object used for drawing sprites.</param>
    public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        if (alignment == Alignment.Left)
            offset = 0;
        if (alignment == Alignment.Center)
            offset = sheetNums[0].Count * (size + 1) / 2;
        if (alignment == Alignment.Right)
            offset = sheetNums[0].Count * (size + 1);

        // draw the text
        for (int i = 0; i < sheetNums.Count; i++)
        {
            for (int j = 0; j < sheetNums[i].Count; j++)
            {
                font.SheetIndex = sheetNums[i][j];
                font.LocalPosition = new Vector2((size + 1) * j - offset, i * (size + 1));
                font.Draw(spriteBatch, gameTime);
            }
        }
    }

    List<List<int>> StringToText(string text)
    {
        List<List<int>> ints = new List<List<int>>();
        List<int> sheetnums = new List<int>();
        ints.Add(sheetnums);

        for (int i = 0; i < text.Length; i++)
        {
            char c = Char.ToUpper(text[i]);

            switch (c)
            {
                case 'A':
                    sheetnums.Add(0);
                    break;
                case 'B':
                    sheetnums.Add(1);
                    break;
                case 'C':
                    sheetnums.Add(2);
                    break;
                case 'D':
                    sheetnums.Add(3);
                    break;
                case 'E':
                    sheetnums.Add(4);
                    break;
                case 'F':
                    sheetnums.Add(5);
                    break;
                case 'G':
                    sheetnums.Add(6);
                    break;
                case 'H':
                    sheetnums.Add(7);
                    break;
                case 'I':
                    sheetnums.Add(8);
                    break;
                case 'J':
                    sheetnums.Add(9);
                    break;
                case 'K':
                    sheetnums.Add(10);
                    break;
                case 'L':
                    sheetnums.Add(11);
                    break;
                case 'M':
                    sheetnums.Add(12);
                    break;
                case 'N':
                    sheetnums.Add(13);
                    break;
                case 'O':
                    sheetnums.Add(14);
                    break;
                case 'P':
                    sheetnums.Add(15);
                    break;
                case 'Q':
                    sheetnums.Add(16);
                    break;
                case 'R':
                    sheetnums.Add(17);
                    break;
                case 'S':
                    sheetnums.Add(18);
                    break;
                case 'T':
                    sheetnums.Add(19);
                    break;
                case 'U':
                    sheetnums.Add(20);
                    break;
                case 'V':
                    sheetnums.Add(21);
                    break;
                case 'W':
                    sheetnums.Add(22);
                    break;
                case 'X':
                    sheetnums.Add(23);
                    break;
                case 'Y':
                    sheetnums.Add(24);
                    break;
                case 'Z':
                    sheetnums.Add(25);
                    break;
                case '0':
                    sheetnums.Add(26);
                    break;
                case '1':
                    sheetnums.Add(27);
                    break;
                case '2':
                    sheetnums.Add(28);
                    break;
                case '3':
                    sheetnums.Add(29);
                    break;
                case '4':
                    sheetnums.Add(30);
                    break;
                case '5':
                    sheetnums.Add(31);
                    break;
                case '6':
                    sheetnums.Add(32);
                    break;
                case '7':
                    sheetnums.Add(33);
                    break;
                case '8':
                    sheetnums.Add(34);
                    break;
                case '9':
                    sheetnums.Add(35);
                    break;
                case '.':
                    sheetnums.Add(36);
                    break;
                case '!':
                    sheetnums.Add(37);
                    break;
                case ':':
                    sheetnums.Add(38);
                    break;
                case '?':
                    sheetnums.Add(39);
                    break;
                case ' ':
                    sheetnums.Add(40);
                    break;
                case '|':
                    sheetnums = new List<int>();
                    ints.Add(sheetnums);
                    break;
                default:
                    sheetnums.Add(40);
                    break;

            }
        }

        return ints;
    }
}