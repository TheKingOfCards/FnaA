using System.Reflection.Metadata;
using Raylib_cs;

public class Night
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
    float newTime;
    float oldTime = (float)Raylib.GetTime();
    float powerTimerMax = 5;

    List<bool> playerActions = new() //[0] Door, [1] Right light, [2] Left light, [3] Camera
    {
        false,
        false,
        false,
        false
    };



    public Night(List<Animatronic> currentAnimatronics)
    {
        allAnimatronics = currentAnimatronics;
    }


    public void Update()
    {

        DeltaTime();
        PowerLogic();
    }


    void DeltaTime() //Make a timer that uses real seconds
    {
        newTime = (float)Raylib.GetTime();
        deltaTime = newTime - oldTime;

        powerTimer = powerTimerMax - deltaTime;
    }


    void PowerLogic() // Handels the logic of power percentage
    {
        if (powerTimer <= 0) // Timer for the power
        {
            powerTimer = 0f;

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

            oldTime = (float)Raylib.GetTime();
        }

        if (power <= 0) // If the power reaches zero, player dies (maybe)
        {
            Console.WriteLine("Dead");
        }

        //Power usage logic 

    }


    void CheckPowerUsage()
    {
        foreach (bool action in playerActions)
        {
            
        }
    }
}