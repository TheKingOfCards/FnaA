using System.Numerics;
using FnaF;
using Raylib_cs;

public class StartScreen : Screens
{
    int arrowsYPos = 600;
    public bool startNewNight = false;


    public StartScreen()
    {
        buttons.Add(new Button(new Rectangle(200, 600, 310, 60), () => arrowsYPos = 600, () => startNewNight = true));
        buttons.Add(new Button(new Rectangle(200, 700, 310, 60), () => arrowsYPos = 700, () => startNewNight = false));
    }


    public override void Update()
    {
        mousePos = GameFunctions.GetMousePos();
        
        buttons.ForEach(b => b.Update(mousePos));

        Draw();
    }


    public void Draw()
    {
        Raylib.ClearBackground(Color.BLACK);

        Raylib.DrawTextEx(pixelFont, "Five", new Vector2(200, 100), textSize, textSpacing, Color.WHITE);
        Raylib.DrawTextEx(pixelFont, "Nights", new Vector2(200, 170), textSize, textSpacing, Color.WHITE);
        Raylib.DrawTextEx(pixelFont, "At", new Vector2(200, 240), textSize, textSpacing, Color.WHITE);
        Raylib.DrawTextEx(pixelFont, "Felix", new Vector2(200, 310), textSize, textSpacing, Color.WHITE);
        
        Raylib.DrawTextEx(pixelFont, "New Game", new Vector2(200, 600), textSize, textSpacing, Color.WHITE);
        Raylib.DrawTextEx(pixelFont, "Continue", new Vector2(200, 700), textSize, textSpacing, Color.WHITE);

        Raylib.DrawTextEx(pixelFont, ">>>", new Vector2(100, arrowsYPos), textSize, textSpacing, Color.WHITE);
    }
}