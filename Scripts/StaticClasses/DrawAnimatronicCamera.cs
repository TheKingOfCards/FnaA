using Raylib_cs;

namespace FnaF;

public class DrawAnimatronicCamera
{
    public static void DrawAnimantronicOnCamera(string currentCamera, Dictionary<string, Texture2D> animatronicTextures, int currentPos)
    {
        if(currentPos == 8 && currentCamera == "StartRoom")
        {
            Raylib.DrawTexture(animatronicTextures[currentCamera], 0, 0, Color.WHITE);
        }

        if(currentPos == 7 && currentCamera == "MainRoom")
        {
            Raylib.DrawTexture(animatronicTextures[currentCamera], 0, 0, Color.WHITE);
        }
    }
}
