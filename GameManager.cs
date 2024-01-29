using System.Numerics;
using System.Reflection.Metadata;
using Raylib_cs;

public class GameManager
{
    Vector2 mousePos;

    Night night = new();

    List<Animatronic> allAnimatronics = new();


    public void Update()
    {
        float deltaTime = Raylib.GetFrameTime();
        mousePos = Raylib.GetMousePosition();
        
        night.Update(deltaTime, mousePos);


        DrawGame();
    }

    void StartNight()
    {
        SetAnimatronics();
    }


    void SetAnimatronics()
    {
        allAnimatronics.Clear();
    }

    public void DrawGame()
    {
        Raylib.BeginDrawing();

        night.Draw();        

        Raylib.EndDrawing();
    }


    public enum GameState
    {
        inNight,
        inStartScreen,
    }
}