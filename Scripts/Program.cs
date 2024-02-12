using Raylib_cs;

Raylib.InitWindow(1920, 1050, "FnaA");

// Raylib.SetExitKey(0);

GameManager gM = new();

// 1920 1080


while (!Raylib.WindowShouldClose())
{
    gM.Update();
}