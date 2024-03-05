using System.Numerics;
using System.Reflection.Metadata;
using FnaF;
using Raylib_cs;

public class GameManager
{
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
        StateMachine();
        
        if (night.currentTime == 6) //Checks if player has completed the night
        {
            nightDoneScreen = new NightDoneScreen();
            gameState = GameState.inNightDoneScreen;

            currentNight++;
        }

        if (night.dead) // Checks if player is dead
        {
            gameState = GameState.inDeathScreen;
            dS = new DeathScreen();
        }


        DrawGame();
    }


    void StateMachine() // Keeps track of the current state of the game
    {
        if (gameState == GameState.inNight)
        {
            night.Update();
        }
        else if (gameState == GameState.inStartScreen)
        {
            if (sS.startNewNight)
            {
                gameState = GameState.inNight;
            }
        }
        else if (gameState == GameState.inDeathScreen)
        {
            dS.Update();

            if (dS.restart)
            {
                gameState = GameState.inNight;
                StartNewNight();
            }
        }
        else if (gameState == GameState.inNightDoneScreen)
        {
            nightDoneScreen.Update();

            if (nightDoneScreen.sixYPos == nightDoneScreen.sixYEndPos)
            {
                gameState = GameState.inNight;
                StartNewNight();
            }
        }
    }


    void StartNewNight() => night = new Night(currentNight);
    

    public void DrawGame()
    {
        Raylib.BeginDrawing();

        if (gameState == GameState.inNight)
        {
            night.Draw();
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