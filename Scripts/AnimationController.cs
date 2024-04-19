using System.Reflection.Metadata;
using FnaF;
using Raylib_cs;

public class AnimationController
{
    //* Make every frame as big as the screen and create them at (0, 0)
    int _currentFrameCount = -1;
    readonly float _timeBetweenFrames = 3;
    float _timer;
    Texture2D _currentFrame;
    public bool animationDone = false;
    List<Texture2D> _animation;


    public AnimationController(List<Texture2D> animation)
    {
        _timer = _timeBetweenFrames;
        _animation = animation;
    }

    public void PlayAnimation()
    {
        if (_timer >= _timeBetweenFrames)
        {
            _timer = 0;
            _currentFrameCount++;

            if (_currentFrameCount >= _animation.Count)
            {
                animationDone = true;
                _currentFrameCount = 0;
            }
        }
        else
        {
            _timer += GameFunctions.GetdeltaTime();
        }

        _currentFrame = _animation[_currentFrameCount];
        Raylib.DrawTexture(_currentFrame, 0, 0, Color.WHITE);
    }


    public static bool Test(List<Texture2D> animation) // ! Timer does not work - fix before using
    {
        float _timer = 0;
        int _currentFrameCount = 0;
        float _timeBetweenFrames = 3;
        Texture2D _currentFrame;

        if (_timer >= _timeBetweenFrames)
        {
            _timer = 0;
            _currentFrameCount++;
            if (_currentFrameCount > animation.Count) return true;
        }
        else
        {
            _timer += GameFunctions.GetdeltaTime();
        }

        _currentFrame = animation[_currentFrameCount];
        Raylib.DrawTexture(_currentFrame, 0, 0, Color.WHITE);

        return false;
    }
}