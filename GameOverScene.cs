using System;
using Raylib_cs;

namespace projectJuin;

public class GameOverScene : Scene
{

    public static IGameController gameController = Services.Get<IGameController>();
    public override void Unload()
    {
   
    }

    public override void Draw()
    {
        Raylib.DrawText("Drawing GameOverScene", 10, 10, 20, Color.Red);
        Raylib.DrawText($"Score: {gameController.GetScore()}", 100, 130, 20, Color.White);
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
        // Here you would typically handle input for restarting the game or going back to the menu
      
    }

}
