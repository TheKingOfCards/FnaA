namespace FnaF;

using System.Numerics;
using Raylib_cs;

public class DeathScreen : ScreenVar
{
    int arrowsXPos = 1920/2 - 450;

    public bool restart = false;

    public DeathScreen()
    {
        buttons.Add(new Button(new Rectangle(1920/2 - 350, 1050/2 - 50, 265, 60), () => arrowsXPos = 510, () => restart = true ));
        buttons.Add(new Button(new Rectangle(1920/2 + 150, 1050/2 - 50, 125, 60), () => arrowsXPos = 1010, () => Environment.Exit(0)));
    }

    public void Update(Vector2 mP)
    {
        buttons.ForEach(b => b.Update(mP));

        Draw();
    }


    void Draw()
    {
        Raylib.ClearBackground(Color.BLACK);

        Raylib.DrawTextEx(pixelFont, "You Died", new Vector2(1920/2 - 150, 1050/2 - 200), textSize, textSpacing, Color.RED);
        Raylib.DrawTextEx(pixelFont, "Restart", new Vector2(1920/2 - 350, 1050/2 - 50), textSize, textSpacing, Color.WHITE);
        Raylib.DrawTextEx(pixelFont, "Quit", new Vector2(1920/2 + 150, 1050/2 - 50), textSize, textSpacing, Color.WHITE);
    
        Raylib.DrawTextEx(pixelFont, ">>>", new Vector2(arrowsXPos, 1050/2 - 50), textSize, textSpacing, Color.WHITE);
    }
}
