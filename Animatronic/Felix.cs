using FnaF;
using Raylib_cs;

public class Felix
{
    float _timer;
    float _timerMax = 20;

    bool _drawCircle = false;

    public Felix()
    {
        _timer = _timerMax;
    }

    public void Update(String currentCamera, bool inCamera)
    {
        if (currentCamera == "Felix" && inCamera) _drawCircle = true;
        else _drawCircle = false;

        _timer -= GameFunctions.GetdeltaTime();
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
            else index = Textures.circleTextures.Count -1;

            Raylib.DrawTexture(Textures.circleTextures[index], 1600, 450, Color.WHITE);
        }
    }
}