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
        {"OfficeL", new OfficeLeft()},
        {"Office", new Office()}
    };
    Dictionary<string, Texture2D> roomImg = new();
    float deltaTime;

    //Felix camera variabels
    float timerMax = 1;
    float timer;
    int changeImgMax = 1;

    Texture2D felixLight = Raylib.LoadTexture(@"CameraTextures\FCD-Dark.png");
    Texture2D felixDark = Raylib.LoadTexture(@"CameraTextures\FCD-Ligt.png");

    readonly Random random = new();

    List<Button> buttons = new();


    public CameraLogic()
    {
        currentCamera = "MainRoom";

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


    public void Update(Vector2 mousePos, float delta)
    {
        deltaTime = delta;

        buttons.ForEach(b => b.Update(mousePos));

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
    }


    public void Draw()
    {
        // ! Does not work
        if (currentCamera == "Felix")
        {
            if(timer > timerMax)
            {
                int i = random.Next(0, changeImgMax++);

                if (i == 0)
                {
                    Raylib.DrawTexture(felixDark, 0, 0, Color.WHITE);
                }
                else
                {
                    Raylib.DrawTexture(felixLight, 0, 0, Color.WHITE);
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