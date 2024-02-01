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

    //Bools
    public bool startCurrentNight = false;
    public bool startNewNight = false;

    //Buttons
    List<Button> buttons = new();


    public StartScreen()
    {
        buttons.Add(new Button(new Rectangle(200, 600, 310, 60), () => arrowsYPos = 600, () => startNewNight = true));
        buttons.Add(new Button(new Rectangle(200, 700, 310, 60), () => arrowsYPos = 700, () => startCurrentNight = true));
    }


    public void Update(Vector2 mP)
    {
        mousePos = mP;

        buttons.ForEach(b => b.Update(mousePos));

        Console.WriteLine(startNewNight);
    }

    bool CheckNewGameOverlap()
    {
        Rectangle rec = new(200, 600, 310, 60);

        return Raylib.CheckCollisionPointRec(mousePos, rec);
    } 

    bool CheckContinueOverlap()
    {
        Rectangle rec = new(200, 700, 310, 60);
        
        return Raylib.CheckCollisionPointRec(mousePos, rec);
    }


    public void Draw()
    {
        Raylib.ClearBackground(Color.BLACK);

        Raylib.DrawRectangle(200, 600, 310, 60, Color.PURPLE);

        Raylib.DrawTextEx(pixelFont, "Five", new Vector2(200, 100), textSize, textSpacing, Color.WHITE);
        Raylib.DrawTextEx(pixelFont, "Nights", new Vector2(200, 170), textSize, textSpacing, Color.WHITE);
        Raylib.DrawTextEx(pixelFont, "At", new Vector2(200, 240), textSize, textSpacing, Color.WHITE);
        Raylib.DrawTextEx(pixelFont, "Actic", new Vector2(200, 310), textSize, textSpacing, Color.WHITE);
        
        Raylib.DrawTextEx(pixelFont, "New Game", new Vector2(200, 600), textSize, textSpacing, Color.WHITE);
        Raylib.DrawTextEx(pixelFont, "Continue", new Vector2(200, 700), textSize, textSpacing, Color.WHITE);

        Raylib.DrawTextEx(pixelFont, ">>>", new Vector2(100, arrowsYPos), textSize, textSpacing, Color.WHITE);
    }
}