using System.Numerics;
using System.Reflection.Metadata;
using Raylib_cs;

public class GameManager
{
    bool closed = false;

    Night currentNight;
    Player player = new();
    CameraLogic cameraLogic = new();

    List<Texture2D> numbers = new();

    Dictionary<string, Room> allRooms = new()
    {
        {"GroupRoom", new GroupRoom()},
        {"MainRoom", new MainRoom()},
        {"Hallway", new Hallway()},
        {"ToiletL", new ToiletLeft()},
        {"ToiletR", new ToiletRight()},
        {"BeforeOfficeR", new BeforeOfficeRight()},
        {"BeforeOfficeL", new BeforeOfficeLeft()},
        {"OfficeR", new OfficeRight()},
        {"OfficeL", new OfficeLeft()},
        {"Office", new Office()}
    };
    Dictionary<string, Texture2D> allTextures = new();

    List<Animatronic> allAnimatronics = new();

    Night night;


    public GameManager()
    {
        LoadTextures();
        cameraLogic.currentCamera = "MainRoom";

        night = new(allAnimatronics);
    }


    bool testLight = false;
    public void Update()
    {
        player.Update();
        cameraLogic.Update();
        night.Update(); //TODO Use bool closed for cheking door in night.Update()


        if (player.doorOverlap && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
        {
            closed = !closed;
        }

        if (player.lightROverlap && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
        {
            testLight = !testLight;
        }


        DrawGame();
    }


    void LoadTextures()
    {
        //Office textures
        allTextures.Add("OfficeDoorOpen", Raylib.LoadTexture(@"OfficeTextures\OfficeDoorOpen.png"));
        allTextures.Add("OfficeDoorClosed", Raylib.LoadTexture(@"OfficeTextures\OfficeDoorClosed.png"));
        allTextures.Add("CameraBar", Raylib.LoadTexture(@"OfficeTextures\CameraBar.png"));
        allTextures.Add("Phone", Raylib.LoadTexture(@"OfficeTextures\Phone.png"));

        //Numbers
        numbers.Add(Raylib.LoadTexture(@"TextUI\Zero.png"));
        numbers.Add(Raylib.LoadTexture(@"TextUI\One.png"));
        numbers.Add(Raylib.LoadTexture(@"TextUI\Two.png"));
        numbers.Add(Raylib.LoadTexture(@"TextUI\Three.png"));
        numbers.Add(Raylib.LoadTexture(@"TextUI\Four.png"));
        numbers.Add(Raylib.LoadTexture(@"TextUI\Five.png"));
        numbers.Add(Raylib.LoadTexture(@"TextUI\Six.png"));
        numbers.Add(Raylib.LoadTexture(@"TextUI\Seven.png"));
        numbers.Add(Raylib.LoadTexture(@"TextUI\Eight.png"));
        numbers.Add(Raylib.LoadTexture(@"TextUI\Nine.png"));

        //Camera textures
        allTextures.Add("CameraMap", Raylib.LoadTexture(@"CameraTextures\CAM-Map.png"));
        allTextures.Add("MainRoom", Raylib.LoadTexture(@"CameraTextures\MainRoom.png"));
        allTextures.Add("AtleCloset", Raylib.LoadTexture(@"CameraTextures\AtleCloset.png"));
        allTextures.Add("Felix", Raylib.LoadTexture(@"CameraTextures\FCD-Dark.png"));
        allTextures.Add("Hallway", Raylib.LoadTexture(@"CameraTextures\Hallway.png"));
        allTextures.Add("BeforeOfficeR", Raylib.LoadTexture(@"CameraTextures\BeforeRightOffice.png"));
        allTextures.Add("BeforeOfficeL", Raylib.LoadTexture(@"CameraTextures\BeforeLeftOffice.png"));
        allTextures.Add("OfficeR", Raylib.LoadTexture(@"CameraTextures\RightOffice.png"));
        allTextures.Add("OfficeL", Raylib.LoadTexture(@"CameraTextures\LeftOffice.png"));
    }


    void StartNight()
    {
        SetAnimatronics();
    }


    void SetAnimatronics()
    {
        allAnimatronics.Clear();
        if (player.currentNight == 1)
        {
            allAnimatronics.Add(new Atle(1, 20));
            allAnimatronics.Add(new Felix());
            allAnimatronics.Add(new Henry(1, 20));
            allAnimatronics.Add(new Hugo(1, 20));
            allAnimatronics.Add(new Leo(1, 20));
            allAnimatronics.Add(new Richard());
            allAnimatronics.Add(new Saga(1, 20));
        }
    }


    static void DrawCameraView(string cC, Dictionary<string, Texture2D> textures)
    {
        Raylib.DrawTexture(textures[cC], 0, 0, Color.WHITE);
    }

    static void DrawOfficeState(bool closed, Dictionary<string, Texture2D> textures)
    {
        if (!closed)
        {
            Raylib.DrawTexture(textures["OfficeDoorOpen"], 0, 0, Color.WHITE);
        }

        if (closed)
        {
            Raylib.DrawTexture(textures["OfficeDoorClosed"], 0, 0, Color.WHITE);
        }
    }


    public void DrawGame()
    {
        Raylib.BeginDrawing();

        if (player.currentState == Player.PlayerState.inOffice) //Draws everyting when the player is in the office
        {
            DrawOfficeState(closed, allTextures);
            Raylib.DrawTexture(allTextures["CameraBar"], 1920 / 2 + 45, 850, Color.WHITE);
            Raylib.DrawTexture(allTextures["CameraBar"], 1920 / 2 - 815, 850, Color.RED);

            if (testLight == true)
            {
                Raylib.DrawRectangle(1150, 350, 100, 200, Color.WHITE);
            }

            if (player.usingPhone)
            {
                Raylib.DrawTexture(allTextures["Phone"], (int)player.phonePos.X, (int)player.phonePos.Y, Color.WHITE);
            }

        }

        if (player.currentState == Player.PlayerState.inCamera) //When player is in cameras
        {
            DrawCameraView(cameraLogic.currentCamera, allTextures);
            Raylib.DrawTexture(allTextures["CameraBar"], 1920 / 2 + 45, 850, Color.WHITE);
            Raylib.DrawTexture(allTextures["CameraMap"], 150, 570, Color.WHITE);
            // Raylib.DrawRectangle(285, 586, 80, 50, Color.PURPLE); //Cam 1
            // Raylib.DrawRectangle(390, 660, 80, 50, Color.PURPLE); //Cam 3
            // Raylib.DrawRectangle(179, 660, 80, 50, Color.PURPLE); //Cam 4
        }

        if(player.currentState == Player.PlayerState.inOffice || player.currentState == Player.PlayerState.inCamera) //WHen player is in cameras and office
        {
            Raylib.DrawTexture(numbers[night.firstNumb], 100, 100, Color.WHITE);
            Raylib.DrawTexture(numbers[night.secoundNumb], 140, 100, Color.WHITE);
        }

        Raylib.EndDrawing();
    }
}