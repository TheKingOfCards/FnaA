namespace FnaF;
using Raylib_cs;
using System.Numerics;
using System.Reflection.PortableExecutable;

public class Screens 
{
    protected Font _pixelFont = Raylib.LoadFont(@"Fonts\Minecraft.ttf");

    protected int _textSize = 60;
    protected int _textSpacing = 10;

    protected float _deltaTime;
    protected Vector2 _mousePos;
    protected List<Button> _buttons = new();

    public virtual void Update()
    {

    }


    public virtual void Draw()
    {

    }
}
