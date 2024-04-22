using FnaF;
using Raylib_cs;

Raylib.InitWindow(1920, 1050, "FnaF");

// Raylib.SetExitKey(0);

GameManager gM = new();

Textures.LoadTextures();
AnimatronicTextures.LoadTexture();

while (!Raylib.WindowShouldClose())
{
	gM.Update();
}

/* The map that the animatronics use to move
    7 
    5 6
  2   4
  1 0 3
*/