using System.Numerics;
using FnaF;
using Raylib_cs;

public class CameraLogic
{
    public string currentCamera;
    Texture2D cameraMap = Raylib.LoadTexture(@"CameraTextures\CAM-Map.png");
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
        {"OfficeL", new OfficeLeft()}
    };
    Dictionary<string, Texture2D> roomImg = new();
    float deltaTime;

    //Felix camera variabels
    float timerMax = 0.5f;
    float timer;
    int changeImgMax = 100;
    Texture2D latestFelixFrame;

    Texture2D felixLight = Raylib.LoadTexture(@"CameraTextures\FelixGyattDark.png");
    Texture2D felixDark = Raylib.LoadTexture(@"CameraTextures\FelixGyattLight.png");

    readonly Random random = new();

    List<Button> buttons = new();


    public CameraLogic()
    {
        currentCamera = "MainRoom";

        latestFelixFrame = felixDark;

        //Cam 1
        buttons.Add(new Button(new Rectangle(285, 585, 80, 50), () => {}, () => currentCamera = "StartRoom") );
        //Cam 2
        buttons.Add(new Button(new Rectangle(285, 660, 80, 50), () => { }, () => currentCamera = "MainRoom"));
        //Cam 3
        buttons.Add(new Button(new Rectangle(391, 660, 80, 50), () => { }, () => currentCamera = "Felix"));
        //Cam 4
        buttons.Add(new Button(new Rectangle(179, 660, 80, 50), () => { }, () => currentCamera = "AtleCloset"));
        //Cam 5
        buttons.Add(new Button(new Rectangle(285, 735, 80, 50), () => { }, () => currentCamera = "Hallway"));
        //Cam 6
        buttons.Add(new Button(new Rectangle(348, 807, 80, 50), () => { }, () => currentCamera = "BeforeOfficeR"));
        //Cam 7
        buttons.Add(new Button(new Rectangle(221, 807, 80, 50), () => { }, () => currentCamera = "BeforeOfficeL"));
        //Cam 8
        buttons.Add(new Button(new Rectangle(223, 882, 80, 50), () => { }, () => currentCamera = "OfficeL"));
        //Cam 9
        buttons.Add(new Button(new Rectangle(348, 882, 80, 50), () => { }, () => currentCamera = "OfficeR"));

        LoadCameraTextures();
    }


    public void Update()
    {
        deltaTime = GameFunctions.GetdeltaTime();

        buttons.ForEach(b => b.Update(GameFunctions.GetMousePos()));

        Draw();
    }


    void LoadCameraTextures()
    {
        roomImg.Add("CameraMap", Raylib.LoadTexture(@"CameraTextures\CAM-Map.png"));
        roomImg.Add("MainRoom", Raylib.LoadTexture(@"CameraTextures\MainRoom.png"));
        roomImg.Add("AtleCloset", Raylib.LoadTexture(@"CameraTextures\AtleCloset.png"));
        roomImg.Add("Hallway", Raylib.LoadTexture(@"CameraTextures\Hallway.png"));
        roomImg.Add("BeforeOfficeR", Raylib.LoadTexture(@"CameraTextures\BeforeRightOffice.png"));
        roomImg.Add("BeforeOfficeL", Raylib.LoadTexture(@"CameraTextures\BeforeLeftOffice.png"));
        roomImg.Add("OfficeR", Raylib.LoadTexture(@"CameraTextures\RightOffice.png"));
        roomImg.Add("OfficeL", Raylib.LoadTexture(@"CameraTextures\LeftOffice.png"));
        roomImg.Add("StartRoom", Raylib.LoadTexture(@"CameraTextures\StartRoom.png"));
    }


    public void Draw()
    {
        if (currentCamera == "Felix")
        {
            Raylib.DrawTexture(latestFelixFrame, 0, 0, Color.WHITE);

            if(timer >= timerMax)
            {
                timer = 0;
                
                int i = random.Next(0, changeImgMax++);

                if (i >= changeImgMax/2)
                {
                    latestFelixFrame = felixDark;
                }
                else
                {
                    latestFelixFrame = felixLight;
                }
            }
            else
            {
                timer += deltaTime;
            }
        }
        else
        {
            Raylib.DrawTexture(roomImg[currentCamera], 0, 0, Color.WHITE);
        }

        Raylib.DrawTexture(cameraMap, 150, 570, Color.WHITE);
    }
}