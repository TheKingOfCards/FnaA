using FnaF;
using Raylib_cs;

public class Animatronic
{
    public string name = "";
    public string pathID = "";
    public int moveOp;

    Random random = new();

    //Timer variabels
    float deltaTime;
    float timer;
    public float timerMax;
    List<Texture2D> deathAnim;

    // Movement variabels
    int[,] map =
    {
        {0,0,0,0,0}, 
        {0,0,2,0,0}, // 2 == start room
        {0,0,1,0,0}, // Main room
        {0,1,1,1,0}, // Hallways and toilets
        {0,1,0,1,0}, // First office left and right
        {0,1,1,1,0}, // Outside office left and right and the office
        {0,0,0,0,0}, // Outside office left and right and the office
    };
    int yPos = 1;
    int xPos = 2;



    public void Update(float dT)
    {
        deltaTime = dT;

        Move();
    }


    public void LoadDeathAnim()
    {

    }

    void Move()
    {
        if (timer >= timerMax)
        {
            timer = 0;

            moveOp = 1;

            if (GameFunctions.CheckRandom(1, 21, moveOp)) // If true animatronic should move to a new room
            {
                int remove = 1;
                int searchAmount = 0;
                bool checkingY = true;

                while (searchAmount < 4) // Only searches for a room 4 times (each direction)
                {
                    if (searchAmount == 2) checkingY = false;

                    if (checkingY)
                    {
                        if (map[yPos - remove, xPos] == 1) // Checks if a room on the y axis is a 1
                        { 
                            // Make the new y pos for the animatronic if a CheckRandom() is true
                            if (GameFunctions.CheckRandom(1, 101, 75)) yPos -= remove;
                            
                        }
                    }
                    else // Same as before but on the x axis
                    {
                        if (map[yPos, xPos - remove] == 1)
                        {
                            if (GameFunctions.CheckRandom(1, 101, 75)) xPos -= remove;
                        }
                    }

                    remove *= -1;
                    searchAmount++;

                    Console.WriteLine("x = " + xPos);
                    Console.WriteLine("y = " + yPos);
                    Console.WriteLine("-");
                }
            }
        }
        else timer += deltaTime;  
    }
}