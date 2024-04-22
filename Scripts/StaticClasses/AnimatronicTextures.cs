namespace FnaF;
using Raylib_cs;

public static class AnimatronicTextures
{
    // Felix
    public static Image felixScreen; 
    public static Image felixCameraStare; 
    // Felix end


    public static void LoadTexture()
    {
        felixScreen = Raylib.LoadImage(@"AnimatronicImg\Felix1.png");
        felixCameraStare = Raylib.LoadImage(@"AnimatronicImg\Felix2.png");
    }
}
