using System.Numerics;
using System.Reflection.Metadata;
using FnaF;
using Raylib_cs;

public class Night
{
    //General varibels
    Player player = new();

    float deltaTime;

    // Textures
    List<Texture2D> numbers = new();
    Texture2D AImg = Raylib.LoadTexture(@"TextUI\A.png");
    Texture2D MImg = Raylib.LoadTexture(@"TextUI\M.png");


    //Time variabels
    public int currentTime = 1;
    float timeTimer;
    float changeHour = 20;

    Office office;


    public Night(int cN)
    {
        office = new Office();

        LoadNumberTextures();
    }

    void LoadNumberTextures()
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


    public void Update()
    {
        deltaTime = GameFunctions.GetdeltaTime();

        player.Update();

        office.Update();

        TimeLogic(); 
    }


    public void Draw()
    {
        office.Draw();

        player.Draw();

        office.DrawUI();

        DrawUI();
    }


    void DrawUI() // Draw time UI
    {
        Raylib.DrawTexture(numbers[currentTime], 100, 70, Color.WHITE);
        Raylib.DrawTexture(AImg, 140, 70, Color.WHITE);
        Raylib.DrawTexture(MImg, 180, 70, Color.WHITE);
    }

    void TimeLogic() // Handels the logic of time for the night
    {
        if (timeTimer >= changeHour)
        {
            currentTime++;
            timeTimer = 0;
        }
        else
        {
            timeTimer += deltaTime;
        }
    }
}