using Raylib_cs;


public class Henry : Animatronic
{
    public Henry(int moveOp, int timerMax)
    {
        _moveOp = moveOp;
        _timerMax = timerMax;

        //Add positions
        _positions.Add(7);
        _positions.Add(5);
        _positions.Add(2);
        _positions.Add(1);
        _positions.Add(0);
        //Add death animation
        deathAnimation.Add(Raylib.LoadTexture(@"CameraTextures\AtleCloset.png"));
        deathAnimation.Add(Raylib.LoadTexture(@"CameraTextures\FelixGyattLight.png"));
        deathAnimation.Add(Raylib.LoadTexture(@"CameraTextures\Hallway.png"));
        //Add camera textures
        cameraImg.Add("StartRoom", Raylib.LoadTexture(@"AnimatronicImg\Henry-StartRoom.png"));
        cameraImg.Add("MainRoom", Raylib.LoadTexture(@"AnimatronicImg\Henry-MainRoom.png"));
    }

    

    // public override void Move()
    // {
    //     base.Move();
    // }
}