using System.Numerics;
using System.Reflection.Metadata;
using Raylib_cs;

public class Night
{
    //General varibels
    List<Animatronic> allAnimatronics = new();
    int power = 99;
    Player player = new();

    bool doorClosed = false;
    List<Texture2D> doorImg = new() //[0] == Closed [1] == Open
    {
        Raylib.LoadTexture(@"OfficeTextures\OfficeDoorClosed.png"),
        Raylib.LoadTexture(@"OfficeTextures\OfficeDoorOpen.png")
    };

    //Show power variebls
    public int firstNumb = 9;
    public int secoundNumb = 9;

    //Timer varibels
    float deltaTime;
    float powerTimer;
    float powerTimerMax = 5;

    Vector2 mousePos;



    public Night()
    {
        powerTimer = powerTimerMax;
    }


    public void Update(float deltaTime, Vector2 mousePos)
    {
        this.deltaTime = deltaTime;
        this.mousePos = mousePos;

        player.Update(mousePos);

        if (player.DoorButtonOverlap() && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
        {
            doorClosed = !doorClosed;
        }

        PowerLogic();
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

    }
}