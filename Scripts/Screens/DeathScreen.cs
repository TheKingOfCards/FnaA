namespace FnaF;

using System.Numerics;
using Raylib_cs;

public class DeathScreen : Screens
{
    int arrowsXPos = 1920/2 - 450;

    public bool restart = false;

    public DeathScreen()
    {
        _buttons.Add(new Button(new Rectangle(1920/2 - 350, 1050/2 - 50, 265, 60), () => arrowsXPos = 510, () => restart = true ));
        _buttons.Add(new Button(new Rectangle(1920/2 + 150, 1050/2 - 50, 125, 60), () => arrowsXPos = 1010, () => Environment.Exit(0)));
    }

    public override void Update()
    {
        _mousePos = GameFunctions.GetMousePos();

        _buttons.ForEach(b => b.Update(_mousePos));

        Draw();
    }


    void Draw()
    {
        Raylib.ClearBackground(Color.BLACK);

        Raylib.DrawTextEx(_pixelFont, "You Died", new Vector2(1920/2 - 150, 1050/2 - 200), _textSize, _textSpacing, Color.RED);
        Raylib.DrawTextEx(_pixelFont, "Restart", new Vector2(1920/2 - 350, 1050/2 - 50), _textSize, _textSpacing, Color.WHITE);
        Raylib.DrawTextEx(_pixelFont, "Quit", new Vector2(1920/2 + 150, 1050/2 - 50), _textSize, _textSpacing, Color.WHITE);
    
        Raylib.DrawTextEx(_pixelFont, ">>>", new Vector2(arrowsXPos, 1050/2 - 50), _textSize, _textSpacing, Color.WHITE);
    }
}
