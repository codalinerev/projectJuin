using System;
using System.IO.Pipes;
using Raylib_cs;

namespace projectJuin;

class Snake
{
    Grid grid;

    Queue<Coordinates> body = new Queue<Coordinates>();
    Coordinates direction = Coordinates.Right;
    Coordinates nextDirection = Coordinates.Right;
    public int Length => body.Count();

    public bool isFuzzy = false;
    public float timerFuzzy = 0;

    public Coordinates Head
    {
        get { return body.Last(); }
        private set { } // Head is always the last element in the body queue
    }
    public double moveSpeed = 0.3f;
    private bool isGrowing = false;

    public Snake(Coordinates start, Grid grid, int startsize = 3)
    {
        this.grid = grid;
        for (int i = startsize - 1; i >= 0; i--)
            body.Enqueue(start - direction * i);
    }

    public void Move()
    {
        direction = nextDirection;      
        body.Enqueue(body.Last() + direction);
        if (!isGrowing) body.Dequeue();
        else isGrowing = false;
        
        Console.WriteLine("Snake moved to: " + Head);

    }

    public void ChangeDirection(Coordinates newDirection)
    {
        if ((newDirection == Coordinates.Zero) || (newDirection == -direction)) return; // Ignore invalid directions
        nextDirection = newDirection;
    }

    public void Draw()
    {
        foreach (var segment in body)
        {
            var posit = grid.GridToWorld(segment);
            Raylib.DrawRectangle((int)posit.X, (int)posit.Y, grid.cellSize, grid.cellSize, Color.Green);
            // Update Head to the last segment in the body
            //Raylib.DrawRectangle((int)Head.Get().column, (int)Head.Get().row, grid.cellSize, grid.cellSize, Color.Maroon);
        }
        var position = grid.GridToWorld(Head);
        Raylib.DrawRectangle((int)position.X, (int)position.Y, grid.cellSize, grid.cellSize, Color.Maroon);
    }

    public bool IsCollidingWithApple(Apple apple)
    {
        return Head == apple.coordinates;
        
        
    }

    public bool IsCollidingWithItself()
    {
        return body.Count != body.Distinct().Count();
    }

    public bool IsOutOfBounds()
    {
        return !grid.IsInBounds(Head);
    }

    public void Grow()
    {
        isGrowing = true;
    }

    public void SpeedUp()
    {
        moveSpeed *= 0.9f; // Increase speed by reducing the move interval
    }



}
