using System.Numerics;
using Raylib_cs;


public class Player
{
    //General variables
    public bool usingPhone = false;
    bool inCamera = false;
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
        if (inCamera)
        {
            cL.Update(mousePos, deltaTime);
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
        if (inCamera)
        {
            cL.Draw();
        }

        if (!inCamera) // Draws UI when player is in cameras
        {
            Raylib.DrawTexture(textures["CameraBar"], 1920 / 2 - 815, 850, Color.RED);

            if (usingPhone)
            {
                Raylib.DrawTexture(textures["Phone"], (int)phonePos.X, (int)phonePos.Y, Color.WHITE);
            }
        }

        Raylib.DrawTexture(textures["CameraBar"], 1920 / 2 + 45, 850, Color.WHITE);

    }


    bool CameraBarOverlap()
    {
        Rectangle rec = new(1920 / 2 + 30, 830, 750, 150);

        if (Raylib.CheckCollisionPointRec(mousePos, rec) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
        {
            // newAction = true;
            // playerActions[3] = !playerActions[3];
            return true;
        }
        else
        {
            return false;
        }
    }


    void OpenCloseMonitor()
    {
        monitorTimer -= deltaTime;

        if (monitorTimer <= 0)
        {
            if (CameraBarOverlap())
            {
                inCamera = !inCamera;
                monitorTimer = monitorTimerMax;
            }
        }
    }


    public void PhoneLogic()
    {
        Rectangle phoneBar = new(1920 / 2 - 830, 830, 750, 150);

        if (usingPhone)
            phonePos = new(mousePos.X - phone.Width / 2, mousePos.Y - phone.Height / 2);


        if (Raylib.CheckCollisionPointRec(mousePos, phoneBar) && !inCamera || Raylib.IsKeyPressed(KeyboardKey.KEY_E) && !inCamera)
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
}