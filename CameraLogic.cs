using System.Numerics;
using Raylib_cs;

public class CameraLogic : Logic
{
    public string currentCamera;
    Vector2 mousePos;

    List<string> currentCameraHover = new()
    {
        "GroupRoom",
        "MainRoom",
        "Felix",
        "AtleCloset",
        "Hallway",
        "BeforeOfficeR",
        "BeforeOfficeL",
        "OfficeL",
        "OfficeR"
    };
    List<Rectangle> cameraHitbox = new()
    {
        new(100, 100, 1, 1), //Cam 1
        new(285, 625, 80, 50), //Cam 2 
        new(390, 625, 80, 50), //Cam 3
        new(179, 625, 85, 60), //Cam 4
        new(285, 695, 85, 60), //Cam 5
        new(345, 770, 85, 60), //Cam 6
        new(220, 770, 85, 60), //Cam 7
        new(220, 845, 85, 60), //Cam 8
        new(345, 845, 85, 60) //Cam 9
    };


    public override void Update(float deltaTime, Vector2 mousePos)
    {
        this.mousePos = mousePos;

        CheckCameraOverlap();
    }


    public override void Draw()
    {
        
    }


    public void CheckCameraOverlap() //Checks which camera the mouse is over
    {
        for (int i = 0; i < cameraHitbox.Count(); i++)
        {
            if (Raylib.CheckCollisionPointRec(mousePos, cameraHitbox[i]) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
            {
                currentCamera = currentCameraHover[i];
            }
        }
    }
}