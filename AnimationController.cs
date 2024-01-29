using Raylib_cs;

public class AnimationController
{
    List<Texture2D> animation = new();
    // TODO *Make it take in a list of "frames" and plays them with a set amount of time between each frame
    // TODO *Make each logic class have its on animation controller, and animations that just it should use
    // TODO *Make each of the animatroncics have its on death animation

    public void PlayAnimation(List<Texture2D> anim)
    {
        animation = anim;
    }
}