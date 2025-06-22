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
        Raylib.DrawText("Draw scene menu", 10, 10, 20, Color.Black);
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
            Raylib.DrawText("Load Scene Game", 200, 200, 20, Color.Gold);
        }
    } 
}
