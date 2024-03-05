using Raylib_cs;

public class AnimationController
{
    float timeBetweenFrames = 3;
    float timer;
    

    public AnimationController()
    {
        timer = timeBetweenFrames;
    }

    public void PlayAnimation(List<Texture2D> animation, float deltaTime)
    {
        for (int i = 0; i < animation.Count; i++)
        {
            //* Make every frame as big as the screen and create them at (0, 0)

            Raylib.DrawTexture(animation[i], 0, 0, Color.WHITE);

            while(timer >= 0) // Timer so that each frame is out for x amount of secounds 
            {
                timer -= deltaTime;
            }

            timer = timeBetweenFrames;
        }
    }
}