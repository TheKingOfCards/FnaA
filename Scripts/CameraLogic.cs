using System.Numerics;
using FnaF;
using Raylib_cs;

public class CameraLogic
{
    public string currentCamera;
    Texture2D cameraMap = Raylib.LoadTexture(@"CameraTextures\CAM-Map.png");
    float deltaTime;

    //Felix camera variabels
    float timerMax = 0.5f;
    float timer;
    int changeImgMax = 100;
    Texture2D latestFelixFrame;

    readonly Random random = new();

    List<Button> buttons = new();


    public CameraLogic()
    {
        currentCamera = "StartRoom";

        timer = timerMax;

        //Cam 1
        buttons.Add(new Button(new Rectangle(285, 585, 80, 50), () => { }, () => currentCamera = "StartRoom"));
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

        // LoadCameraTextures();
    }


    public void Update()
    {
        deltaTime = GameFunctions.GetdeltaTime();

        buttons.ForEach(b => b.Update(GameFunctions.GetMousePos()));

        Draw();
    }


    public void Draw()
    {
        if (currentCamera == "Felix")
        {
            // Raylib.DrawRectangle(1600, 450, 180, 180, Color.WHITE);

            if (timer >= timerMax)
            {
                timer = 0;

                if (GameFunctions.CheckRandom(0, changeImgMax + 1, changeImgMax / 2))
                {
                    latestFelixFrame = Textures.cameraTextures["FelixDark"];
                }
                else
                {
                    latestFelixFrame = Textures.cameraTextures["FelixLight"];
                }
            }
            else
            {
                timer += deltaTime;
            }

            Raylib.DrawTexture(latestFelixFrame, 0, 0, Color.WHITE);
        }
        else
        {
            Raylib.DrawTexture(Textures.cameraTextures[currentCamera], 0, 0, Color.WHITE);
        }

        Raylib.DrawTexture(cameraMap, 150, 570, Color.WHITE);
    }
}