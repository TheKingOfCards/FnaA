using System.Numerics;
using System.Reflection.Metadata;
using Raylib_cs;

public class GameManager
{
    Vector2 mousePos;

    Night night = new();
    StartScreen sS = new();

    GameState gameState = GameState.inStartScreen;

    List<Animatronic> allAnimatronics = new();



    public void Update()
    {
        float deltaTime = Raylib.GetFrameTime();
        mousePos = Raylib.GetMousePosition();

        if(gameState == GameState.inNight)
        {
            night.Update(deltaTime, mousePos);
        }
        else if(gameState == GameState.inStartScreen)
        {
            sS.Update(mousePos);

            if(sS.startNewNight)
            {
                gameState = GameState.inNight;
            }
        }
        


        DrawGame();
    }

    void StartNight()
    {
        SetAnimatronics();
    }


    void SetAnimatronics()
    {
        allAnimatronics.Clear();
    }

    public void DrawGame()
    {
        Raylib.BeginDrawing();

        if(gameState == GameState.inNight)
        {
            night.Draw();        
        }
        else if(gameState == GameState.inStartScreen)
        {
            sS.Draw();
        }
        

        Raylib.EndDrawing();
    }


    public enum GameState
    {
        inNight,
        inStartScreen,
    }
}