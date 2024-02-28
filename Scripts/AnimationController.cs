using Raylib_cs;

public class AnimationController
{
    // TODO *Make it take in a list of "frames" and plays them with a set amount of time between each frame
    // TODO *Make each logic class have its on animation controller, and animations that just it should use
    // TODO *Make each of the animatroncics have its on death animation
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

            while(timer >= 0) // TODO Make better timer (better everything)
            {
                timer -= deltaTime;
            }

            timer = timeBetweenFrames;
        }
    }
}