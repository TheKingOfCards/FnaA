using System.Numerics;
using System.Reflection.Metadata;
using Raylib_cs;

public class Night
{
    //General varibels
    List<Animatronic> allAnimatronics = new();
    int power = 99;
    Player player = new();

    float deltaTime;
    bool doorClosed = false;

    //Textures
    List<Texture2D> doorImg = new() //[0] == Closed [1] == Open
    {
        Raylib.LoadTexture(@"OfficeTextures\OfficeDoorClosed.png"),
        Raylib.LoadTexture(@"OfficeTextures\OfficeDoorOpen.png")
    };

    List<Texture2D> numbers = new();
    Texture2D percent = Raylib.LoadTexture(@"TextUI\PowerPercent.png");
    Texture2D AImg = Raylib.LoadTexture(@"TextUI\A.png");
    Texture2D MImg = Raylib.LoadTexture(@"TextUI\M.png");

    //Show power variebls
    public int firstNumb = 9;
    public int secoundNumb = 9;

    //Power variabels
    float powerTimer = 0;
    float powerTimerMax = 5;

    //Time variabels
    int currentTime = 1;
    float timeTimer;
    float changeHour = 10;

    Vector2 mousePos;



    public Night()
    {
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


    public void Update(float deltaTime, Vector2 mousePos)
    {
        this.deltaTime = deltaTime;
        this.mousePos = mousePos;

        player.Update(mousePos, deltaTime);

        if (player.DoorButtonOverlap())
        {
            doorClosed = !doorClosed;
        }

        PowerLogic();
        TimeLogic();
    }


    public void Draw()
    {
        if (doorClosed)
        {
            Raylib.DrawTexture(doorImg[0], 0, 0, Color.WHITE);
        }
        else
        {
            Raylib.DrawTexture(doorImg[1], 0, 0, Color.WHITE);
        }

        player.Draw();

        DrawUI();
    }


    void DrawUI()
    {
        //Draws power UI
        Raylib.DrawTexture(numbers[firstNumb], 1750, 70, Color.WHITE);
        Raylib.DrawTexture(numbers[secoundNumb], 1790, 70, Color.WHITE);
        Raylib.DrawTexture(percent, 1830, 69, Color.WHITE);

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


    void PowerLogic() // Handels the logic of power percentage
    {
        powerTimer -= deltaTime;

        if (powerTimer <= 0) // Timer for the power
        {
            powerTimer = powerTimerMax;

            if (secoundNumb == 0)
            {
                secoundNumb = 9;

                firstNumb--;
                if (firstNumb <= 0)
                {
                    secoundNumb = 0;
                    firstNumb = 0;
                }
            }
            else
            {
                secoundNumb--;
            }

            power--;
            powerTimer = powerTimerMax;
        }

        if (power <= 0) // If the power reaches zero, player dies (maybe)
        {
            Console.WriteLine("Dead");
        }

        //Power usage logic 
        if (player.newAction)
        {
            player.newAction = false;

            int newUsage = 0;
            foreach (bool action in player.playerActions) // Checks if a action is false and adds more to timer if its true
            {
                if (!action)
                {
                    newUsage++;
                }
            }

            powerTimerMax = newUsage++;
        }
    }
}