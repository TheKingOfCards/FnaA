using System.Numerics;
using Raylib_cs;

namespace FnaF;

public static class GameFunctions
{
    public static bool CheckRandom(int min, int max, int check) // Randomizer for that uses parameters to use less code
    {
        Random random = new();

        int i = random.Next(min, max);

        if (i <= check) return true;

        else return false;
    }


    public static Vector2 GetMousePos()
    {
        Vector2 mousePos;

        mousePos = Raylib.GetMousePosition();

        return mousePos;
    }


    public static float GetdeltaTime()
    {
        float deltaTime;

        deltaTime = Raylib.GetFrameTime();

        return deltaTime;
    }
}
