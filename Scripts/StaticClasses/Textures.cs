using Raylib_cs;

namespace FnaF;

public static class Textures
{
    // Camera textures
    public static Dictionary<string, Texture2D> cameraTextures;
    public static List<Texture2D> circleTextures;
    public static Texture2D cameraBar;
    // Camera textures end

    //Office textures
    public static List<Texture2D> doorState;
    public static Texture2D rightBlackout;
    public static Texture2D leftBlackout;
    public static Texture2D percent;
    //Office textures end

    

    public static List<Texture2D> numbers;

    public static void LoadTextures()
    {
        // Load camera textures
        cameraTextures = new()
        {
            { "CameraMap", Raylib.LoadTexture(@"CameraTextures\CAM-Map.png") },
            { "MainRoom", Raylib.LoadTexture(@"CameraTextures\MainRoom.png") },
            { "AtleCloset", Raylib.LoadTexture(@"CameraTextures\AtleCloset.png") },
            { "Hallway", Raylib.LoadTexture(@"CameraTextures\Hallway.png") },
            { "BeforeOfficeR", Raylib.LoadTexture(@"CameraTextures\BeforeRightOffice.png") },
            { "BeforeOfficeL", Raylib.LoadTexture(@"CameraTextures\BeforeLeftOffice.png") },
            { "OfficeR", Raylib.LoadTexture(@"CameraTextures\RightOffice.png") },
            { "OfficeL", Raylib.LoadTexture(@"CameraTextures\LeftOffice.png") },
            { "StartRoom", Raylib.LoadTexture(@"CameraTextures\StartRoom.png") },
            { "FelixLight", Raylib.LoadTexture(@"CameraTextures\FelixGyattLight.png") },
            { "FelixDark", Raylib.LoadTexture(@"CameraTextures\FelixGyattDark.png") }
        };

        circleTextures = new()
        {
            Raylib.LoadTexture(@"CameraTextures\EmptyCircle.png"),
            Raylib.LoadTexture(@"CameraTextures\QuarterCircle.png"),
            Raylib.LoadTexture(@"CameraTextures\HalfCircle.png"),
            Raylib.LoadTexture(@"CameraTextures\AlmostCircle.png"),
            Raylib.LoadTexture(@"CameraTextures\FullCircle.png")
        };

        cameraBar = Raylib.LoadTexture(@"OfficeTextures\CameraBar.png");
        // Load camera textures end

        // Load Office textures
        doorState = new()
        {
            Raylib.LoadTexture(@"OfficeTextures\DoorClosed.png"),
            Raylib.LoadTexture(@"OfficeTextures\DoorOpen.png")
        };

        rightBlackout = Raylib.LoadTexture(@"OfficeTextures\RightBlackOut.png");
        leftBlackout = Raylib.LoadTexture(@"OfficeTextures\LeftBlackOut.png");
        percent = Raylib.LoadTexture(@"TextUI\PowerPercent.png");
        // Load Office textures

        numbers = new()
        {
            Raylib.LoadTexture(@"TextUI\Zero.png"),
            Raylib.LoadTexture(@"TextUI\One.png"),
            Raylib.LoadTexture(@"TextUI\Two.png"),
            Raylib.LoadTexture(@"TextUI\Three.png"),
            Raylib.LoadTexture(@"TextUI\Four.png"),
            Raylib.LoadTexture(@"TextUI\Five.png"),
            Raylib.LoadTexture(@"TextUI\Six.png"),
            Raylib.LoadTexture(@"TextUI\Seven.png"),
            Raylib.LoadTexture(@"TextUI\Eight.png"),
            Raylib.LoadTexture(@"TextUI\Nine.png")
        };
    }
}
