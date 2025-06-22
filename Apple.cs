namespace projectJuin;
using System;
using System.Numerics;
using Raylib_cs;


public class Apple
{
    public Coordinates coordinates { get; private set; }
    private Grid grid;
    private bool surprise = false;

    private string typeApple = "Normal";

    public static string[] typesApple =
    {
        "Normal", "Double", "Explosion", "Music", "Speed", "Slow", "Crazy", "Lose","Magic", "Color", "Surprise"};

    public Apple(Grid grid)
    {
        this.grid = grid;
        coordinates = Coordinates.Random(grid.columns, grid.rows);
    }

    public string RandomType()
    {
        Random randomT = new Random();
        int i = randomT.Next(11);
        return typesApple[i];       
    } 

    public void Respawn()
    {
        coordinates = Coordinates.Random(grid.columns, grid.rows);
        typeApple = RandomType();       
    }

    public void Draw()
    {
        var pos = grid.GridToWorld(coordinates);
        pos += new Vector2(grid.cellSize * 0.5f, grid.cellSize * 0.5f);
        Raylib.DrawCircle((int)pos.X, (int)pos.Y, grid.cellSize * 0.5f, Color.Red);
        Raylib.DrawText($"Apple type is {typeApple}", 1010, 500, 15, Color.Black);
     }

}
