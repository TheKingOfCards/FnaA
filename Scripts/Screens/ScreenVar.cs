namespace FnaF;
using Raylib_cs;
using System.Numerics;

public class ScreenVar
{
    public Font pixelFont = Raylib.LoadFont(@"Fonts\Minecraft.ttf");

    public int textSize = 60;
    public int textSpacing = 10;

    public Vector2 mousePos;
    public List<Button> buttons = new();
}
