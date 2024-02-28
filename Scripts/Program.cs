using Raylib_cs;

Raylib.InitWindow(1920, 1050, "FnaF");

// Raylib.SetExitKey(0);

GameManager gM = new();


while (!Raylib.WindowShouldClose())
{
    gM.Update();
}