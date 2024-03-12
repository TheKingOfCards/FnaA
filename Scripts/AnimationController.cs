using System.Reflection.Metadata;
using FnaF;
using Raylib_cs;

public static class AnimationController
{
    //* Make every frame as big as the screen and create them at (0, 0)
    public static void PlayAnimation()
    {
        float timeBetweenFrames = 3;
        float timer = timeBetweenFrames;

        List<Texture2D> animation = new()
            {
                Raylib.LoadTexture(@"CameraTextures\AtleCloset.png"),
                Raylib.LoadTexture(@"CameraTextures\FelixGyattLight.png"),
                Raylib.LoadTexture(@"CameraTextures\Hallway.png")
            };

        for (int i = 0; i < animation.Count; i++)
        {
            bool frameHasBeenPlaced = false;

            float deltaTime;

            while (!frameHasBeenPlaced)
            {
                deltaTime = GameFunctions.GetdeltaTime();

                if (timer >= timeBetweenFrames)
                {
                    timer = 0;
                    frameHasBeenPlaced = true;
                    Raylib.DrawTexture(animation[i], 0, 0, Color.WHITE);
                }
                else
                {
                    timer += deltaTime;
                }
            }
        }
    }
}