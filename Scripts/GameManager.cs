using System.Numerics;
using System.Reflection.Metadata;
using FnaF;
using Raylib_cs;

public class GameManager
{
    int currentNight = 1;
    int nightDoneTime = 6;
    bool inCamera;

    Night night;
    CameraLogic cameraLogic;

    Felix felix = new();


    StartScreen startScreen = new();
    DeathScreen deathScreen;
    NightDoneScreen nightDoneScreen;

    AnimationController animationController; // ! Try to make AnimationController static
    
    // States 
    GameState gameState = GameState.inStartScreen;
    InNightState inNightState = InNightState.inOffice;

    List<Animatronic> allAnimatronics = new();

    Button cameraBar;

    // TODO Draw animatronics in camera - take player currenct camera and animatronic posistion draw
    public GameManager()
    {
        allAnimatronics.Add(new Henry(20, 3));

        cameraBar = new Button(new Rectangle(1920 / 2 + 30, 830, 750, 150), () => { }, () => inCamera = !inCamera);

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
            allAnimatronics.ForEach(a => a.Update()); // Updates all animatronics
            cameraBar.Update(GameFunctions.GetMousePos());
            felix.Update(cameraLogic.currentCamera, inCamera);

            if (inCamera) inNightState = InNightState.inCamera;
            else inNightState = InNightState.inOffice;

            NightStateMachine();

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_A)) // ! Test
            {
                inNightState = InNightState.jumpscare;
                animationController = new();
            }

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
                StartNewNight();
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


    void NightStateMachine()
    {
        if (inNightState == InNightState.jumpscare)
        {
            if (animationController.animationDone) // Checks if jumpscare animation is done
            {
                inNightState = InNightState.inOffice;
                gameState = GameState.inDeathScreen;
                deathScreen = new();
            }
        }

        if (inNightState == InNightState.inCamera) // If player is in camera
        {
            cameraLogic.Update();
        }
    }


    void StartNewNight()
    {
        night = new(currentNight);
        cameraLogic = new();

        allAnimatronics.Clear();
        allAnimatronics.Add(new Henry(20, 4));

        night = new Night(currentNight);
    }

    public void DrawGame()
    {
        Raylib.BeginDrawing();

        if (gameState == GameState.inNight)
        {
            night.Draw();

            if (inNightState == InNightState.jumpscare)
            {
                animationController.PlayAnimation(allAnimatronics[0].deathAnimation);
            }

            if (inNightState == InNightState.inCamera)
            {
                cameraLogic.Draw();
                felix.Draw();
                foreach (Animatronic animatronic in allAnimatronics)
                {
                    DrawAnimatronicCamera.DrawAnimantronicOnCamera(cameraLogic.currentCamera, animatronic.cameraImg, animatronic.currentPosition);
                }
            }

            if (inNightState == InNightState.inOffice)
            {
                Raylib.DrawTexture(Textures.cameraBar, 130, 830, Color.RED);
            }

            Raylib.DrawTexture(Textures.cameraBar, 1920 / 2 + 30, 830, Color.WHITE);
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