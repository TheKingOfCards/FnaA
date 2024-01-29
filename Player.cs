using System.Numerics;
using Raylib_cs;


public class Player
{
    //General variables
    public PlayerState currentState = PlayerState.inOffice;
    public int currentNight;
    public bool usingPhone = false;
    Texture2D phone = Raylib.LoadTexture(@"OfficeTextures\Phone.png");
    

    // Monitor variables
    float monitorTimer;
    float monitorTimerMax = 0.5f;

    CameraLogic cL = new();

    Dictionary<string, Texture2D> textures = new();

    float deltaTime;

    //Vector2s
    public Vector2 phonePos;
    Vector2 mousePos;


    public Player()
    {
        LoadTextures();
    }


    public void Update(Vector2 mousePos, float deltaTime)
    {
        this.mousePos = mousePos;
        this.deltaTime = deltaTime;

        OpenCloseMonitor();
        if (currentState == PlayerState.inCamera)
        {
            cL.Update(mousePos);
        }

        PhoneLogic();
    }

    void LoadTextures()
    {
        textures.Add("CameraBar", Raylib.LoadTexture(@"OfficeTextures\CameraBar.png"));
        textures.Add("Phone", Raylib.LoadTexture(@"OfficeTextures\Phone.png"));
    }


    public void Draw()
    {
        if (currentState == PlayerState.inCamera)
        {
            cL.Draw();
        }

        if (currentState == PlayerState.inOffice) // Draws UI when player is in cameras
        {
            Raylib.DrawTexture(textures["CameraBar"], 1920 / 2 - 815, 850, Color.RED);

            if (usingPhone)
            {
                Raylib.DrawTexture(textures["Phone"], (int)phonePos.X, (int)phonePos.Y, Color.WHITE);
            }
        }

        if (currentState == PlayerState.inOffice || currentState == PlayerState.inCamera)
        {
            Raylib.DrawTexture(textures["CameraBar"], 1920 / 2 + 45, 850, Color.WHITE);
        }

    }

    public bool DoorButtonOverlap()
    {
        Rectangle doorButtonRec = new(1565, 320, 100, 160);

        if(Raylib.CheckCollisionPointRec(mousePos, doorButtonRec) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
        {
            return true;
        }
        else
        {
            return false;
        }

        // return Raylib.CheckCollisionPointRec(mousePos, doorButtonRec);
    }


    public bool CheckRLightOverlap()
    {
        Rectangle lightRRec = new(1550, 510, 110, 165);

        return Raylib.CheckCollisionPointRec(mousePos, lightRRec);
    }


    bool CameraBarOverlap()
    {
        Rectangle cameraBarRec = new(1920 / 2 + 30, 830, 750, 150);

        return Raylib.CheckCollisionPointRec(mousePos, cameraBarRec);
    }


    void OpenCloseMonitor()
    {
        monitorTimer -= deltaTime;

        if (monitorTimer <= 0)
        {
            if (CameraBarOverlap() && currentState == PlayerState.inOffice && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON) || currentState == PlayerState.inOffice && Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                currentState = PlayerState.inCamera;
                monitorTimer = monitorTimerMax;
            }
            else if (CameraBarOverlap() && currentState == PlayerState.inCamera && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON) || currentState == PlayerState.inCamera && Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                currentState = PlayerState.inOffice;
                monitorTimer = monitorTimerMax;
            }
        }
    }


    public void PhoneLogic()
    {
        Rectangle phoneBar = new(1920 / 2 - 830, 830, 750, 150);

        if (usingPhone)
            phonePos = new(mousePos.X - phone.Width / 2, mousePos.Y - phone.Height / 2);


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