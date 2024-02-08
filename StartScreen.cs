using System.Numerics;
using FnaF;
using Raylib_cs;

public class StartScreen
{
    Font pixelFont = Raylib.LoadFont(@"Fonts\Minecraft.ttf");

    int textSize = 60;
    int textSpacing = 10;

    int arrowsYPos = 600;

    Vector2 mousePos;
    public bool startNewNight = false;

    //Buttons
    List<Button> buttons = new();


    public StartScreen()
    {
        buttons.Add(new Button(new Rectangle(200, 600, 310, 60), () => arrowsYPos = 600, () => startNewNight = true));
        buttons.Add(new Button(new Rectangle(200, 700, 310, 60), () => arrowsYPos = 700, () => startNewNight = false));
    }


    public void Update(Vector2 mP)
    {
        mousePos = mP;

        buttons.ForEach(b => b.Update(mousePos));
    }


    public void Draw()
    {
        Raylib.ClearBackground(Color.BLACK);

        Raylib.DrawTextEx(pixelFont, "Five", new Vector2(200, 100), textSize, textSpacing, Color.WHITE);
        Raylib.DrawTextEx(pixelFont, "Nights", new Vector2(200, 170), textSize, textSpacing, Color.WHITE);
        Raylib.DrawTextEx(pixelFont, "At", new Vector2(200, 240), textSize, textSpacing, Color.WHITE);
        Raylib.DrawTextEx(pixelFont, "{Placeholder}", new Vector2(200, 310), textSize, textSpacing, Color.WHITE);
        
        Raylib.DrawTextEx(pixelFont, "New Game", new Vector2(200, 600), textSize, textSpacing, Color.WHITE);
        Raylib.DrawTextEx(pixelFont, "Continue", new Vector2(200, 700), textSize, textSpacing, Color.WHITE);

        Raylib.DrawTextEx(pixelFont, ">>>", new Vector2(100, arrowsYPos), textSize, textSpacing, Color.WHITE);
    }
}