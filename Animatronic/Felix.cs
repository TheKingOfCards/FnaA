using FnaF;
using Raylib_cs;

public class Felix
{
    public float _timer;
    readonly float _timerMax = 20;
    float _timerAcceleration = 1.2f;

    Rectangle circleHitBox = new(1600, 450, 180, 180);

    public List<Texture2D> deathAnimation = new()
    {
        Raylib.LoadTexture(@"AnimatronicImg\FelixDeathAnimation\FelixDead.png"),
        Raylib.LoadTexture(@"AnimatronicImg\FelixDeathAnimation\FelixDead1.png"),
        Raylib.LoadTexture(@"AnimatronicImg\FelixDeathAnimation\FelixDead2.png"),
        Raylib.LoadTexture(@"AnimatronicImg\FelixDeathAnimation\FelixDead3.png"),
        Raylib.LoadTexture(@"AnimatronicImg\FelixDeathAnimation\FelixDead3.png"),
        Raylib.LoadTexture(@"AnimatronicImg\FelixDeathAnimation\FelixDead3.png")
    };

    bool _drawCircle = false;
    bool chargingCircle = false;

    public Felix()
    {
        _timer = _timerMax;
    }

    public void Update(string currentCamera, bool inCamera)
    {
        if (currentCamera == "Felix" && inCamera) // Checks if player is in Felixs camera and if player is using camera 
        {
            _drawCircle = true;

            if (Raylib.CheckCollisionPointRec(GameFunctions.GetMousePos(), circleHitBox) && Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT))
            {
                if (_timer <= _timerMax) // Adds to timer of player is in the circle and presses LMB
                {
                    _timer += GameFunctions.GetdeltaTime() * _timerAcceleration;
                }
                else
                {
                    _timer = _timerMax;
                }
                chargingCircle = true;
            }
        }
        else _drawCircle = false;

        if(!chargingCircle)
        {
            _timer -= GameFunctions.GetdeltaTime();
        }
    }


    public void Draw() // Draws cirecle in Felixs camera depending on if player is in and what timer is
    {
        if (_drawCircle)
        {
            int index = 0;

            if (_timer <= _timerMax - 3)
            {
                if (_timer <= _timerMax * 0.75f)
                {
                    if (_timer <= _timerMax / 2)
                    {
                        if (_timer <= _timerMax / 4)
                        {
                            if (_timer < 0) index = Textures.circleTextures.Count - 5;
                        }
                        else index = Textures.circleTextures.Count - 4;
                    }
                    else index = Textures.circleTextures.Count - 3;
                }
                else index = Textures.circleTextures.Count - 2;
            }
            else index = Textures.circleTextures.Count - 1;

            Raylib.DrawTexture(Textures.circleTextures[index], 1600, 450, Color.WHITE);
        }
    }
}