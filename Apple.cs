namespace projectJuin;
using System;
using System.Formats.Asn1;
using System.Numerics;
using Raylib_cs;
using static Snake;


public class Apple
{
    public Coordinates coordinates { get; private set; }
    private Grid grid;
    private bool surprise = false;
    Texture2D appleNormal = Raylib.LoadTexture("assets/apple_basic.png");
    Texture2D appleCrazy = Raylib.LoadTexture("assets/apple_fuzzy.png");
    Texture2D texApple;

    //public string typeApple = "Normal";
    //public string lastApple = "Normal";


    public enum appleType { Normal, Crazy };
    public appleType typeApple = appleType.Normal;
    

    public Apple(Grid grid)
    {
        this.grid = grid;
        coordinates = Coordinates.Random(grid.columns, grid.rows);
    }

    public appleType RandomType()
    {
        Random randomIndex = new Random(2);
        int i = randomIndex.Next();
        if (i == 0) return appleType.Normal;
        return appleType.Crazy; // for now, only two types of apples, Normal and Crazy     
    } 

    public void Respawn()
    {
        coordinates = Coordinates.Random(grid.columns-1, grid.rows-1);
        typeApple = RandomType();       
    }

    public void Draw()
    {
        var pos = grid.GridToWorld(coordinates);
       
        texApple = appleNormal;
        if (typeApple == appleType.Crazy) texApple = appleCrazy;
        Raylib.DrawTexture(texApple, (int)pos.X, (int)pos.Y, Color.White);      
        
    }
}
