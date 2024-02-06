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

    List<Button> buttons = new();


    public CameraLogic()
    {
        currentCamera = "MainRoom";

        //Cam 2
        buttons.Add(new Button(new Rectangle(285, 625, 80, 50), () => Console.WriteLine(""), () => currentCamera = "MainRoom"));
        //Cam 3
        buttons.Add(new Button(new Rectangle(390, 625, 80, 50), () => Console.WriteLine(""), () => currentCamera = "Felix"));
        //Cam 4
        buttons.Add(new Button(new Rectangle(179, 625, 85, 60), () => Console.WriteLine(""), () => currentCamera = "AtleCloset"));
        //Cam 5
        buttons.Add(new Button(new Rectangle(285, 695, 85, 60), () => Console.WriteLine(""), () => currentCamera = "Hallway"));
        //Cam 6
        buttons.Add(new Button(new Rectangle(345, 770, 85, 60), () => Console.WriteLine(""), () => currentCamera = "BeforeOfficeR"));
        //Cam 7
        buttons.Add(new Button(new Rectangle(220, 770, 85, 60), () => Console.WriteLine(""), () => currentCamera = "BeforeOfficeL"));
        //Cam 8
        buttons.Add(new Button(new Rectangle(220, 845, 85, 60), () => Console.WriteLine(""), () => currentCamera = "OfficeL"));
        //Cam 9
        buttons.Add(new Button(new Rectangle(345, 845, 85, 60), () => Console.WriteLine(""), () => currentCamera = "OfficeR"));

        LoadCameraTextures();
    }


    public void Update(Vector2 mousePos)
    {
        buttons.ForEach(b => b.Update(mousePos));

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
}