using System.Numerics;
using System.Reflection.Metadata;
using Raylib_cs;

public class Night : Logic
{
    //General varibels
    List<Animatronic> allAnimatronics = new();
    int power = 99;

    //Show power variebls
    public int firstNumb = 9;
    public int secoundNumb = 9;

    //Timer varibels
    float deltaTime;
    float powerTimer;
    float powerTimerMax = 5;

    List<bool> playerActions = new() //[0] Door, [1] Right light, [2] Left light, [3] Camera
    {
        false,
        false,
        false,
        false
    };



    public Night()
    {
        powerTimer = powerTimerMax;
    }


    public override void Update(float deltaTime, Vector2 mousePos)
    {
        this.deltaTime = deltaTime; 
        PowerLogic();
    }


    public override void Draw()
    {

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


    void CheckPowerUsage()
    {

    }
}