using System.Numerics;
using Raylib_cs;

public class CameraLogic
{
    public string currentCamera;
    Vector2 mousePos;
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
    List<string> currentCameraHover = new()
    {
        "GroupRoom",
        "MainRoom",
        "Felix",
        "AtleCloset",
        "Hallway",
        "BeforeOfficeR",
        "BeforeOfficeL",
        "OfficeL",
        "OfficeR"
    };
    List<Rectangle> cameraHitbox = new()
    {
        new(100, 100, 1, 1), //Cam 1
        new(285, 625, 80, 50), //Cam 2 
        new(390, 625, 80, 50), //Cam 3
        new(179, 625, 85, 60), //Cam 4
        new(285, 695, 85, 60), //Cam 5
        new(345, 770, 85, 60), //Cam 6
        new(220, 770, 85, 60), //Cam 7
        new(220, 845, 85, 60), //Cam 8
        new(345, 845, 85, 60) //Cam 9
    };

    public CameraLogic()
    {
        currentCamera = "MainRoom";

        LoadCameraTextures();
    }


    public void Update(Vector2 mousePos)
    {
        this.mousePos = mousePos;

        CheckCameraOverlap();

        Draw();
    }


    void LoadCameraTextures()
    {
        roomImg.Add("CameraMap", Raylib.LoadTexture(@"CameraTextures\CAM-Map.png"));
        roomImg.Add("MainRoom", Raylib.LoadTexture(@"CameraTextures\MainRoom.png"));
        roomImg.Add("AtleCloset", Raylib.LoadTexture(@"CameraTextures\AtleCloset.png"));
        roomImg.Add("Felix", Raylib.LoadTexture(@"CameraTextures\FCD-Dark.png"));
        roomImg.Add("Hallway", Raylib.LoadTexture(@"CameraTextures\Hallway.png"));
        roomImg.Add("BeforeOfficeR", Raylib.LoadTexture(@"CameraTextures\BeforeRightOffice.png"));
        roomImg.Add("BeforeOfficeL", Raylib.LoadTexture(@"CameraTextures\BeforeLeftOffice.png"));
        roomImg.Add("OfficeR", Raylib.LoadTexture(@"CameraTextures\RightOffice.png"));
        roomImg.Add("OfficeL", Raylib.LoadTexture(@"CameraTextures\LeftOffice.png"));
    }


    public void Draw()
    {
        Raylib.DrawTexture(roomImg[currentCamera], 0, 0, Color.WHITE);
        
        Raylib.DrawTexture(cameraMap, 150, 570, Color.WHITE);
    }


    public void CheckCameraOverlap() //Checks which camera the mouse is over
    {
        for (int i = 0; i < cameraHitbox.Count(); i++)
        {
            if (Raylib.CheckCollisionPointRec(mousePos, cameraHitbox[i]) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
            {
                currentCamera = currentCameraHover[i];
            }
        }
    }
}