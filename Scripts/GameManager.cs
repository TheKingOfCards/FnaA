using System.Numerics;
using System.Reflection.Metadata;
using FnaF;
using Raylib_cs;

public class GameManager
{
    Vector2 mousePos;
    int currentNight = 1;

    Night night;
    StartScreen sS = new();
    DeathScreen dS = new();
    NightDoneScreen nightDoneScreen = new();

    GameState gameState = GameState.inStartScreen;

    List<Animatronic> allAnimatronics = new();


    public GameManager()
    {
        night = new Night(currentNight);
    }

    public void Update()
    {
        float deltaTime = Raylib.GetFrameTime();
        mousePos = Raylib.GetMousePosition();

        //Keeps track of the current state of the game
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
        else if(gameState == GameState.inDeathScreen)
        {
            dS.Update(mousePos);

            if(dS.restart)
            {
                gameState = GameState.inNight;
                StartNewNight();
            }
        }
        else if(gameState == GameState.inNightDoneScreen)
        {
            nightDoneScreen.Update(deltaTime);

            if(nightDoneScreen.sixYPos == nightDoneScreen.sixYEndPos)
            {
                gameState = GameState.inNight;
                StartNewNight();
            }
        }
        
        //Checks if player has completed the night
        if(night.currentTime == 6)
        {
            nightDoneScreen = new NightDoneScreen();
            gameState = GameState.inNightDoneScreen;
            
            night.currentTime = 0;
            currentNight++; 
        }

        //Checks if player is dead
        if(night.dead)
        {
            gameState = GameState.inDeathScreen;
            dS =  new DeathScreen(); 
        }


        DrawGame();
    }

    void StartNewNight()
    {
        night = new Night(currentNight);
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
        inDeathScreen,
        inNightDoneScreen
    }
}