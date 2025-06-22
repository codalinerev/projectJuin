using System;
using Raylib_cs;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices;

namespace projectJuin;

public class Grid
{
    public int cellSize { get; private set; }
    public Vector2 position = Vector2.Zero;
    public int columns { get; private set; }
    public int rows { get; private set; }

    public Grid(int columns = 50, int rows = 40, int cellSize = 20)
    {
        this.columns = columns;
        this.rows = rows;
        this.cellSize = cellSize;
    }


    public Vector2 GridToWorld(Coordinates coordinates)
    {
        return new Vector2(coordinates.column * cellSize, coordinates.row * cellSize);
    }

    public Coordinates WorldToGrid(Vector2 position)
    {
        return new Coordinates((int)(position.X / cellSize), (int)(position.Y / cellSize));
    }

    public void Draw()
    {
        for (int col = 0; col < columns; col++)
        {
            for (int row = 0; row < rows; row++)
            {
                Vector2 pos = GridToWorld(new Coordinates(col, row));
                Raylib.DrawRectangleLines((int)pos.X, (int)pos.Y, cellSize - 1, cellSize - 1, Color.White);
                //Raylib.DrawText((pos/cellSize).ToString(), (int)pos.X, (int)pos.Y, 10, Color.Black);
            }
        }
    }

    public void DrawMini() 
    // c'était un test , pas utilisé dans ce jeu
    {
        for (int col = 0; col < columns; col++)
        {
            for (int row = 0; row < rows; row++)
            {
                Vector2 pos = GridToWorld(new Coordinates(col, row)/10);
                //pos += posMini + (Vector2)(1010, 500); // Offset to position the mini grid
                Raylib.DrawRectangleLines((int)pos.X + 1010, (int)pos.Y + 200, cellSize / 10, cellSize / 10, Color.Black);
            }
        }
    }
        
    public bool IsInBounds(Coordinates coordinates)
    {
        return coordinates.column >= 0 && coordinates.column < columns &&
               coordinates.row >= 0 && coordinates.row < rows;
    }
    
}
