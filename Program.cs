// See https://aka.ms/new-console-template for more information
using projectJuin;
using Raylib_cs;

class Program
{
    static private ScenesManager _scenesManager = new();
    static private GameController _gameController = new();
    static private AssetsManager _assetsManager = new();
    static void Main()
    {
        Raylib.InitWindow(1200, 800, "Hello, Raylib!");

        Raylib.SetTargetFPS(60);

        _scenesManager.Load<MenuScene>();

        // Main game loop
        while (!Raylib.WindowShouldClose())
        {
            _scenesManager.Update();
           
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.LightGray);
            _scenesManager.Draw();
 
            Raylib.EndDrawing();
        }

        // Close the window and unload resources
        Raylib.CloseWindow();
    }
}
