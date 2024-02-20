using System.Numerics;
using System.Reflection.Metadata;
using FnaF;
using Raylib_cs;

public class Night
{
    //General varibels
    List<Animatronic> allAnimatronics = new();
    Player player = new();

    float deltaTime;

    //Textures
    List<Texture2D> doorImg = new() //[0] == Closed [1] == Open
    {
        Raylib.LoadTexture(@"OfficeTextures\OfficeDoorClosed.png"),
        Raylib.LoadTexture(@"OfficeTextures\OfficeDoorOpen.png")
    };

    List<Texture2D> numbers = new();
    Texture2D AImg = Raylib.LoadTexture(@"TextUI\A.png");
    Texture2D MImg = Raylib.LoadTexture(@"TextUI\M.png");


    //Time variabels
    int currentTime = 1;
    float timeTimer;
    float changeHour = 10;

    Office office = new(); // TODO Change so that a new office is made every new night 


    public Night()
    {
        LoadNumberTextures();
    }

    void LoadNumberTextures() // ? Office class
    {
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


    public void Update(float deltaTime, Vector2 mousePos)
    {
        this.deltaTime = deltaTime;

        player.Update(mousePos, deltaTime);

        office.Update(mousePos, deltaTime);

        TimeLogic();
    }


    public void Draw()
    {
        office.Draw();
        
        player.Draw();

        office.DrawUI();

        DrawUI();
    }


    void DrawUI() 
    {
        //Draw time UI
        Raylib.DrawTexture(numbers[currentTime], 100, 70, Color.WHITE);
        Raylib.DrawTexture(AImg, 140, 70, Color.WHITE);
        Raylib.DrawTexture(MImg, 180, 70, Color.WHITE);
    }

    void TimeLogic()
    {
        timeTimer += deltaTime;

        if (timeTimer >= changeHour)
        {
            changeHour += changeHour;
            currentTime++;
        }
    }
}