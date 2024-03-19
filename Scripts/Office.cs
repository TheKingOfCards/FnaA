namespace FnaF;

using System.Numerics;
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
    readonly int basePowerDrain = 2;
    float powerTimerMax = 0;

    //Textures
    Texture2D percent = Raylib.LoadTexture(@"TextUI\PowerPercent.png");
    List<Texture2D> numbers = new();
    List<Texture2D> doorImg = new() //[0] == Closed [1] == Open
    {
        Raylib.LoadTexture(@"OfficeTextures\DoorClosed.png"),
        Raylib.LoadTexture(@"OfficeTextures\DoorOpen.png")
    };

    Texture2D rightBlackout = Raylib.LoadTexture(@"OfficeTextures\RightBlackOut.png");
    Texture2D leftBlackout = Raylib.LoadTexture(@"OfficeTextures\LeftBlackOut.png");


    Vector2 mousePos;



    public Office()
    {
        powerTimerMax = basePowerDrain;
    }


    public void Update()
    {
        deltaTime = GameFunctions.GetdeltaTime();
        mousePos = GameFunctions.GetMousePos();

        PowerLogic();
        CheckButtons();
    }


    public void Draw()
    {
        if (doorClosed)
        {
            Raylib.DrawTexture(Textures.doorState[0], 0, 0, Color.WHITE);
        }
        else
        {
            Raylib.DrawTexture(Textures.doorState[1], 0, 0, Color.WHITE);
        }

        if (!rightLightOn)
        {
            Raylib.DrawTexture(Textures.rightBlackout, 1155, 284, Color.WHITE);
        }

        if (!leftLightOn)
        {
            Raylib.DrawTexture(Textures.leftBlackout, 625, 294, Color.WHITE);
        }
    }


    public void DrawUI() //Draws power UI
    {
        Raylib.DrawTexture(Textures.numbers[firstNumb], 1750, 70, Color.WHITE);
        Raylib.DrawTexture(Textures.numbers[secoundNumb], 1790, 70, Color.WHITE);
        Raylib.DrawTexture(percent, 1830, 69, Color.WHITE);
    }


    void CheckButtons()
    {
        if (Buttons(new Rectangle(1565, 320, 100, 160), 0))
        {
            doorClosed = !doorClosed;
        }

        if (Buttons(new Rectangle(1550, 510, 110, 165), 1)) //Right (int should be 1)
        {
            rightLightOn = !rightLightOn;
        }

        if (Buttons(new Rectangle(275, 520, 110, 165), 2)) //left (int should be 2)
        {
            leftLightOn = !leftLightOn;
        }
    }


    void PowerLogic() // Handels the logic of power percentage
    {
        if (powerTimer >= powerTimerMax) // Timer for the power
        {
            powerTimer = 0;

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
        }
        else
        {
            powerTimer += deltaTime;
        }


        if (power <= 0) // If the power reaches zero, player dies (maybe)
        {
            Console.WriteLine("Dead");
        }
 
        if (stateChange) // Power usage logic
        {
            NewPowerUsage();
        }
    }


    void NewPowerUsage() 
    {
        stateChange = false;

        int newUsage = 0;
        foreach (bool action in stateBools) // Checks if a action is true and adds more to timer if its true
        {
            if (!action)
            {
                newUsage++;
            }
        }

        powerTimerMax = newUsage + basePowerDrain;
    }


    public bool Buttons(Rectangle rec, int i)
    {
        //Checks collision between mouse pos and the rectangle and returns true if left mouse button is pressed 
        if (Raylib.CheckCollisionPointRec(mousePos, rec) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
        {
            stateChange = true;
            stateBools[i] = !stateBools[i];
            return true;
        }
        else
        {
            return false;
        }
    }
}
