// See https://aka.ms/new-console-template for more information
using projectJuin;
using Raylib_cs;

class Program
{
    static private ScenesManager _scenesManager = new();
    static private GameController _gameController = new();
    static void Main()
    {
        Raylib.InitWindow(1200, 800, "Hello, Raylib!");

        Raylib.SetTargetFPS(60);

        _scenesManager.Load<SceneGame>();

        // Main game loop
        while (!Raylib.WindowShouldClose())
        {
            // Update logic here
            _scenesManager.Update();

            // Begin drawing
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.LightGray);
            _scenesManager.Draw();

            // Draw text
            //Raylib.DrawText("roblox is fun!", 350, 280, 20, Color.Red);
            //old debug Raylib.DrawText("X", 26, 3, 20, Color.Blue);

            // End drawing
            Raylib.EndDrawing();
        }

        // Close the window and unload resources
        Raylib.CloseWindow();
    }
}
