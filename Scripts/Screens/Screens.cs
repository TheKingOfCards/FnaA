namespace FnaF;
using Raylib_cs;
using System.Numerics;
using System.Reflection.PortableExecutable;

public class Screens // TODO Maybe change so that all screens can use the same variabel from this
{
    public Font pixelFont = Raylib.LoadFont(@"Fonts\Minecraft.ttf");

    public int textSize = 60;
    public int textSpacing = 10;

    public float deltaTime;
    public Vector2 mousePos;
    public List<Button> buttons = new();

    public virtual void Update()
    {

    }


    public virtual void Draw()
    {

    }
}
