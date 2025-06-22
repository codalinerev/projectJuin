using System;
using System.IO.Pipes;
using Raylib_cs;

namespace projectJuin;

public class GameOverScene : Scene
{

    public static IGameController gameController = Services.Get<IGameController>();
    public int apples;
    public override void Unload()
    {

    }

    public override void Draw()
    {
        Raylib.DrawText("Game Over", 300, 300, 50, Color.Red);
        Raylib.DrawText($"Score: {gameController.GetScore()}", 500, 400, 30, Color.Black);
        Raylib.DrawText($"{apples}", 600, 4900, 20, Color.DarkGray);
        // Here you would typically draw the game over screen, e.g., using Raylib
    }

    public override void Load()
    {}  
    

    public override void Update()
    {
        if (Raylib.IsKeyPressed(KeyboardKey.Enter))
        {
            var sm = Services.Get<IScenesManager>();
            sm.Load<MenuScene>();
        }
    
      
    }

}
