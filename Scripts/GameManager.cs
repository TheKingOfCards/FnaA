using System.Numerics;
using System.Reflection.Metadata;
using FnaF;
using Raylib_cs;

public class GameManager
{
    int currentNight = 1;
    int nightDoneTime = 6;

    Night night;


    StartScreen startScreen = new();
    DeathScreen deathScreen;
    NightDoneScreen nightDoneScreen;
    // States 
    GameState gameState = GameState.inStartScreen;
    InNightState inNightState = InNightState.inOffice;

    List<Animatronic> allAnimatronics = new();


    public GameManager()
    {
        night = new Night(currentNight);

        allAnimatronics.Add(new Henry(20, 3));

        Console.WriteLine(allAnimatronics[0].currentPosition);
    }

    public void Update()
    {
        StateMachine();

        DrawGame();
    }


    void StateMachine() // Keeps track of the current state of the game
    {
        if (gameState == GameState.inNight)
        {
            night.Update();

            if (inNightState == InNightState.inCamera) // If player is in camera
            {

            }

            if (allAnimatronics.Any(a => a.currentPosition == 0)) // Checks if a animatronic has reached the office
            {
                inNightState = InNightState.jumpscare;
            }

            allAnimatronics.ForEach(a => a.Update()); // Updates all animatronics


            if (night.currentTime == nightDoneTime) //Checks if player has completed the night
            {
                night.currentTime = 0;
                nightDoneScreen = new NightDoneScreen();
                gameState = GameState.inNightDoneScreen;

                currentNight++;
            }
        }
        else if (gameState == GameState.inStartScreen)
        {
            startScreen.Update();

            if (startScreen.startNewNight)
            {
                gameState = GameState.inNight;
            }
        }
        else if (gameState == GameState.inDeathScreen)
        {
            deathScreen.Update();

            if (deathScreen.restart)
            {
                gameState = GameState.inNight;
                StartNewNight();
            }
        }
        else if (gameState == GameState.inNightDoneScreen)
        {
            nightDoneScreen.Update();

            if (nightDoneScreen.sixYPos <= nightDoneScreen.sixYEndPos)
            {
                gameState = GameState.inNight;
                StartNewNight();
            }
        }
    }


    void StartNewNight()
    {
        allAnimatronics.Clear();
        allAnimatronics.Add(new Henry(20, 3));

        night = new Night(currentNight);
    }

    public void DrawGame()
    {
        Raylib.BeginDrawing();

        if (gameState == GameState.inNight)
        {
            night.Draw();

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_A))
            {
                AnimationController.PlayAnimation();
            }

            if (allAnimatronics.Any(a => a.currentPosition == 0))
            {
                // AnimationController.PlayAnimation();
            }
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

    enum InNightState
    {
        inCamera,
        inOffice,
        jumpscare
    }
}