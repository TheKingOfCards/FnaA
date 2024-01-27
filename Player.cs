using System.Numerics;
using Raylib_cs;


public class Player : Logic
{
    //General variables
    public PlayerState currentState = PlayerState.inOffice;
    public int currentNight;
    public bool usingPhone = false;
    Texture2D phone = Raylib.LoadTexture(@"OfficeTextures\Phone.png");
    public bool newAction = false;

    // Bool overlaps
    public bool doorOverlap;
    public bool lightROverlap;
    public bool cameraBarOverlap;

    //Vector2s
    public Vector2 phonePos;
    Vector2 mousePos;

    public override void Update(float deltaTime, Vector2 mousePos)
    {
        mousePos = Raylib.GetMousePosition();


        CheckButtonOverlap();
        CameraBarOverlap();
        PhoneLogic();
    }


    public override void Draw()
    {
        
    }


    public void CheckButtonOverlap()
    {
        Rectangle doorButton = new(1565, 320, 100, 160);

        doorOverlap = Raylib.CheckCollisionPointRec(mousePos, doorButton);

        Rectangle lightR = new(1550, 510, 110, 165);

        lightROverlap = Raylib.CheckCollisionPointRec(mousePos, lightR);
    }


    public void CameraBarOverlap()
    {
        Rectangle cameraBar = new(1920 / 2 + 30, 830, 750, 150);

        cameraBarOverlap = Raylib.CheckCollisionPointRec(mousePos, cameraBar);


        if (cameraBarOverlap && currentState == PlayerState.inOffice && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON) || currentState == PlayerState.inOffice && Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
        {
            currentState = PlayerState.inCamera;
            newAction = true;
        }
        else if (cameraBarOverlap && currentState == PlayerState.inCamera && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON) || currentState == PlayerState.inCamera && Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
        {
            currentState = PlayerState.inOffice;
            newAction = true;
        }
    }


    public void PhoneLogic()
    {
        Rectangle phoneBar = new(1920 / 2 - 830, 830, 750, 150);

        if (usingPhone) { phonePos = new(mousePos.X - phone.Width / 2, mousePos.Y - phone.Height / 2); }


        if (Raylib.CheckCollisionPointRec(mousePos, phoneBar) && currentState == PlayerState.inOffice || Raylib.IsKeyPressed(KeyboardKey.KEY_E) && currentState == PlayerState.inOffice)
        {
            if (!usingPhone)
            {
                usingPhone = true;
                Raylib.DisableCursor();
                Raylib.SetMousePosition((int)mousePos.X, (int)mousePos.Y);
            }
        }


        if (usingPhone && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
        {
            usingPhone = false;
            Raylib.EnableCursor();
            Raylib.SetMousePosition((int)phonePos.X, (int)phonePos.Y);
        }


    }



    public enum PlayerState
    {
        inOffice,
        inCamera,
        inStartScreen,
        dead,
    }
}