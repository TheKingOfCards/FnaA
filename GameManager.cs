using System.Numerics;
using System.Reflection.Metadata;
using Raylib_cs;

public class GameManager
{
    bool closed = false;
    Vector2 mousePos;


    List<Texture2D> numbers = new();

    Night night = new();

    Dictionary<string, Texture2D> allTextures = new();

    List<Animatronic> allAnimatronics = new();



    public GameManager()
    {
        LoadTextures();
        
    }


    bool testLight = false;
    public void Update()
    {
        float deltaTime = Raylib.GetFrameTime();
        mousePos = Raylib.GetMousePosition();
        
        night.Update(deltaTime, mousePos);


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
    }


    void StartNight()
    {
        SetAnimatronics();
    }


    void SetAnimatronics()
    {
        allAnimatronics.Clear();
    }

    public void DrawGame()
    {
        Raylib.BeginDrawing();

        night.Draw();        

        Raylib.EndDrawing();
    }
}