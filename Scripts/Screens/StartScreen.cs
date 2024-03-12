using System.Numerics;
using FnaF;
using Raylib_cs;

public class StartScreen : Screens
{
    int arrowsYPos = 600;
    public bool startNewNight = false;


    public StartScreen()
    {
        _buttons.Add(new Button(new Rectangle(200, 600, 310, 60), () => arrowsYPos = 600, () => startNewNight = true));
        _buttons.Add(new Button(new Rectangle(200, 700, 310, 60), () => arrowsYPos = 700, () => startNewNight = false));
    }


    public override void Update()
    {
        _mousePos = GameFunctions.GetMousePos();

        _buttons.ForEach(b => b.Update(_mousePos));

        Draw();
    }


    public void Draw()
    {
        Raylib.ClearBackground(Color.BLACK);

        Raylib.DrawTextEx(_pixelFont, "Five", new Vector2(200, 100), _textSize, _textSpacing, Color.WHITE);
        Raylib.DrawTextEx(_pixelFont, "Nights", new Vector2(200, 170), _textSize, _textSpacing, Color.WHITE);
        Raylib.DrawTextEx(_pixelFont, "At", new Vector2(200, 240), _textSize, _textSpacing, Color.WHITE);
        Raylib.DrawTextEx(_pixelFont, "Felix", new Vector2(200, 310), _textSize, _textSpacing, Color.WHITE);
        
        Raylib.DrawTextEx(_pixelFont, "New Game", new Vector2(200, 600), _textSize, _textSpacing, Color.WHITE);
        Raylib.DrawTextEx(_pixelFont, "Continue", new Vector2(200, 700), _textSize, _textSpacing, Color.WHITE);

        Raylib.DrawTextEx(_pixelFont, ">>>", new Vector2(100, arrowsYPos), _textSize, _textSpacing, Color.WHITE);
    }
}