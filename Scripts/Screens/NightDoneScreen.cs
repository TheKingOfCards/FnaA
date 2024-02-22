namespace FnaF;

using System.ComponentModel;
using System.Numerics;
using Raylib_cs;

public class NightDoneScreen : ScreenVar
{
    float fiveYPos = 470f;
    public float sixYPos = 570f;
    public float sixYEndPos = 460f;

    //Timer variables
    float timer = 0f;
    float timerMax = 0.5f;

    float iniatalTimer = 0f;


    public NightDoneScreen()
    {
        timer = timerMax;
    }


    public void Update(float deltaTime)
    {
        if (iniatalTimer >= 1.5f) //Small timer so that player can understand where they are
        {
            if (timer >= timerMax && sixYPos != sixYEndPos) //Timer so that the 6 goes up and 5 disappears
            {
                sixYPos -= 10;
                fiveYPos -= 10;

                timer = 0;
            }
            else
            {
                timer += deltaTime;
            }
        }
        else
        {
            iniatalTimer += deltaTime;
        }

        Draw();
    }

    void Draw()
    {
        Raylib.ClearBackground(Color.BLACK);

        Raylib.DrawTextEx(pixelFont, "AM", new Vector2(980, 470), 100, textSpacing, Color.WHITE);
        Raylib.DrawTextEx(pixelFont, "5", new Vector2(890, fiveYPos), 100, textSpacing, Color.WHITE);
        Raylib.DrawTextEx(pixelFont, "6", new Vector2(890, sixYPos), 100, textSpacing, Color.WHITE);

        Raylib.DrawRectangle(860, 370, 100, 100, Color.BLACK);
        Raylib.DrawRectangle(860, 570, 100, 100, Color.BLACK);
    }
}
