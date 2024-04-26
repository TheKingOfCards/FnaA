using System.Numerics;
using System.Reflection.Metadata;
using FnaF;
using Raylib_cs;

public class GameManager
{
    int _currentNight = 1;
    readonly int _nightDoneTime = 6;
    bool inCamera;

    List<LogicClass> logicClasses = new()
    {

    };

    Felix _felix = new();

    // ! Test (REMOVE WHEN DONE)
    Texture2D leoTest = Raylib.LoadTexture(@"AnimatronicImg\LeoOfficeLeft1.png");


    StartScreen startScreen = new();
    DeathScreen deathScreen;
    NightDoneScreen nightDoneScreen;

    AnimationController animationController; // ! Try to make AnimationController static

    // States 
    GameState gameState = GameState.inStartScreen;
    InNightState inNightState = InNightState.inOffice;

    List<Animatronic> allAnimatronics = new();

    Button cameraBar;

    // TODO | Wont exit camera during jumpscare
    // TODO | Change phone logic to this class, make it it's on class first 
    public GameManager()
    {
        logicClasses.Add(new Office());
        logicClasses.Add(new Night());
        logicClasses.Add(new CameraLogic());

        allAnimatronics.Add(new Henry(20, 3));

        cameraBar = new Button(new Rectangle(1920 / 2 + 30, 830, 750, 150), () => { }, () => inCamera = !inCamera);
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
            logicClasses.ForEach(logicClasses => logicClasses.Update());
            // _night.Update();
            // _office.Update();
            cameraBar.Update();
            allAnimatronics.ForEach(a => a.Update()); // Updates all animatronics
            _felix.Update(logicClasses.OfType<CameraLogic>().FirstOrDefault().currentCamera, inCamera);

            // Sets night state if player is in camera or not
            if (inCamera) inNightState = InNightState.inCamera;
            else if (!inCamera && inNightState != InNightState.jumpscare) inNightState = InNightState.inOffice;

            NightStateMachine();

            if (_felix._timer <= 0 && inNightState != InNightState.jumpscare) // Checks if Felixs timer is 0 and jumpscares 
            {
                inNightState = InNightState.jumpscare;
                inCamera = false;
                animationController = new(_felix.deathAnimation, 0.25f);
            }

            foreach (Animatronic animatronic in allAnimatronics) // Checks if palyer is in camera and a animatronic is outside office
            {
                if (animatronic.currentPosition == 0 && inNightState == InNightState.inCamera)
                {
                    inNightState = InNightState.jumpscare;
                    inCamera = false;
                    animationController = new(animatronic.deathAnimation, 3);
                }
            }

            if (logicClasses.OfType<Night>().FirstOrDefault().currentTime == _nightDoneTime) // Checks if player has completed the night
            {
                logicClasses.OfType<Night>().FirstOrDefault().currentTime = 0;
                nightDoneScreen = new NightDoneScreen();
                gameState = GameState.inNightDoneScreen;
                _currentNight++;
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
    }


    void StartNewNight()
    {
        logicClasses.Add(new Office());
        logicClasses.Add(new Night());
        logicClasses.Add(new CameraLogic());

        _felix = new();
        gameState = GameState.inNight;
        inNightState = InNightState.inOffice;

        allAnimatronics.Clear();
        allAnimatronics.Add(new Henry(1, 4));
    }

    public void DrawGame()
    {
        Raylib.BeginDrawing();

        if (gameState == GameState.inNight)
        {
            foreach (LogicClass logicClass in logicClasses)
            {
                if (logicClass is CameraLogic cameraLogic && inNightState == InNightState.inCamera)
                {
                    cameraLogic.Draw();

                    _felix.Draw();
                    // Draws animatronic position
                    foreach (Animatronic animatronic in allAnimatronics)
                    {
                        DrawAnimatronicCamera.DrawAnimantronicOnCamera(logicClasses.OfType<CameraLogic>().FirstOrDefault().currentCamera, animatronic.cameraImg, animatronic.currentPosition);
                    }
                }
                else if (logicClass is Night night && inNightState == InNightState.inOffice)
                {
                    night.Draw();
                }
                else if (logicClass is Office office && inNightState == InNightState.inOffice)
                {
                    office.Draw();
                }
            }

            if (inNightState == InNightState.jumpscare && !animationController.animationDone)
            {
                logicClasses.OfType<Office>().FirstOrDefault()?.Draw();
                animationController.PlayAnimation();
            }

            if (inNightState == InNightState.inOffice)
            {
                Raylib.DrawTexture(Textures.cameraBar, 130, 830, Color.RED);

                if (logicClasses.OfType<Office>().FirstOrDefault().leftLightOn) { Raylib.DrawTexture(leoTest, 0, 0, Color.WHITE); }
            }

            // For textures that need to be drawn in bot camera and office 
            if (inNightState == InNightState.inCamera || inNightState == InNightState.inOffice)
            {
                Raylib.DrawTexture(Textures.cameraBar, 1920 / 2 + 30, 830, Color.WHITE);
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