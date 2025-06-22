using Raylib_cs;


namespace projectJuin;

public class MenuScene : Scene
{
    public override void Load()
    {
        Console.WriteLine("Load scene menu");
    }
    public override void Draw()
    {
        Raylib.DrawText("Snake", 300, 300, 60, Color.Green);
        Raylib.DrawText("Press enter to start", 500, 300, 20, Color.Black);
    }
    
    public override void Unload()
    {
        Console.WriteLine("Unload scene menu");
    }

    public override void Update()
    {
        if (Raylib.IsKeyPressed(KeyboardKey.Enter))
        {
            var sm = Services.Get<IScenesManager>();
            sm.Load<SceneGame>();
            Raylib.DrawText("Scene Game", 200, 200, 20, Color.Gold);
        }
    } 
}
