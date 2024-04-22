using System.Numerics;
using FnaF;
using Raylib_cs;

public class CameraLogic
{
    public string currentCamera;
    Texture2D cameraMap = Raylib.LoadTexture(@"CameraTextures\CAM-Map.png");
    float deltaTime;

    // Felix camera variabels
    float timerMax = 0.5f;
    float timer;
    int changeImgMax = 100;
    Texture2D latestFelixFrame;

    // Felix image variables
    Texture2D felixImage;

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
    }


    public void Update()
    {
        deltaTime = GameFunctions.GetdeltaTime();

        buttons.ForEach(b => b.Update());

        Draw();
    }


    static Image TintImage(int tintStrength)
    {
        Image image;
        if(GameFunctions.CheckRandom(0, 101, 5))
        {
            image = Raylib.LoadImage(@"AnimatronicImg\Felix2.png");
        }
        else
        {
            image = Raylib.LoadImage(@"AnimatronicImg\Felix1.png");
        }

        Raylib.ImageColorTint(ref image, new(tintStrength, tintStrength, tintStrength, 255));

        return image;
    }


    public void Draw()
    {
        if (currentCamera == "Felix")
        {
            if (timer >= timerMax)
            {
                timer = 0;

                if (GameFunctions.CheckRandom(0, changeImgMax + 1, changeImgMax / 2))
                {
                    latestFelixFrame = Textures.cameraTextures["FelixDark"];
                    felixImage = Raylib.LoadTextureFromImage(TintImage(100));
                }
                else
                {
                    latestFelixFrame = Textures.cameraTextures["FelixLight"];
                    felixImage = Raylib.LoadTextureFromImage(TintImage(150));
                }
            }
            else
            {
                timer += deltaTime;
            }
            
            Raylib.DrawTexture(latestFelixFrame, 0, 0, Color.WHITE);
            Raylib.DrawTexture(felixImage, 800, 200, Color.WHITE);
        }
        else
        {
            Raylib.DrawTexture(Textures.cameraTextures[currentCamera], 0, 0, Color.WHITE);
        }

        Raylib.DrawTexture(cameraMap, 150, 570, Color.WHITE);
    }
}