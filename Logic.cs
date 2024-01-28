using System.Numerics;
using Raylib_cs;

public abstract class Logic
{
    public abstract void Update(float deltaTime, Vector2 mousePos, Dictionary<string, Texture2D> textures);

    public abstract void Draw();
}
