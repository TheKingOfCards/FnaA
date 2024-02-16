namespace FnaF;
using Raylib_cs;

public class Office
{
    float deltaTime;
    public bool usingPhone = false;

    //Office state bools
    bool inCamera = false;

    bool doorClosed = false;
    bool rightLightOn = false;
    bool leftLightOn = false;
    bool stateChange = false;
    public List<bool> stateBools = new() // [0] == Door [1] == LightR [2] == LightL [3] == MonitorUp
    {
        false,
        false,
        false,
        false
    };

    //Show power variebls
    public int firstNumb = 9;
    public int secoundNumb = 9;

    //Power variabels
    int power = 99;
    float powerTimer = 0;
    float powerTimerMax = 5;

    //Textures
    List<Texture2D> numbers = new();
    List<Texture2D> doorImg = new() //[0] == Closed [1] == Open
    {
        Raylib.LoadTexture(@"OfficeTextures\OfficeDoorClosed.png"),
        Raylib.LoadTexture(@"OfficeTextures\OfficeDoorOpen.png")
    };



    public Office()
    {
        LoadNumberTextures();
    }


    public void Update(float delta)
    {
        PowerLogic();
    }


    void Draw()
    {
        if (doorClosed)
        {
            Raylib.DrawTexture(doorImg[0], 0, 0, Color.WHITE);
        }
        else
        {
            Raylib.DrawTexture(doorImg[1], 0, 0, Color.WHITE);
        }

        if (rightLightOn)
        {

        }
        else
        {

        }

        if (leftLightOn)
        {

        }
        else
        {

        }
    }


    void PowerLogic() // Handels the logic of power percentage // ? Office class
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
        if (stateChange)
        {
            stateChange = false;

            int newUsage = 0;
            foreach (bool action in stateBools) // Checks if a action is false and adds more to timer if its true
            {
                if (!action)
                {
                    newUsage++;
                }
            }

            powerTimerMax = newUsage++;
        }
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
}
