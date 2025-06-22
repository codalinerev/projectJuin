using System.Numerics;

public struct Coordinates

{
    public readonly int column { get; init; }

    public readonly int row { get; init; }
    public Coordinates(int column, int row)
    {
        this.column = column;
        this.row = row;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Coordinates other)
        {
            return column == other.column && row == other.row;
        }
        return false;
    }
    public override int GetHashCode()
    {
        return (column, row).GetHashCode();
    }
    public static bool operator ==(Coordinates a, Coordinates b)
    {
        if (a.GetHashCode() == b.GetHashCode())
        {
            return a.Equals(b);
        }
        return false;
    }
    public static bool operator !=(Coordinates a, Coordinates b)
    {
        return !a.Equals(b);
    }
    public static Coordinates operator +(Coordinates a, Coordinates b)
    {
        return new Coordinates(a.column + b.column, a.row + b.row);
    }
    public static Coordinates operator -(Coordinates a, Coordinates b)
    {
        return new Coordinates(a.column - b.column, a.row - b.row);
    }
    public static Coordinates operator -(Coordinates a)
    {
        return new Coordinates(-a.column, -a.row);
    }
    public static Coordinates operator *(Coordinates a, int scalar)
    {
        return new Coordinates(a.column * scalar, a.row * scalar);
    }
    public static Coordinates operator /(Coordinates a, int scalar)
    {
        if (scalar == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero.");
        }
        return new Coordinates(a.column / scalar, a.row / scalar);
    }
    public override string ToString()
    {
        return $"({column}, {row})";
    }
    public static double Distance(Coordinates a, Coordinates b)
    {
        return Math.Sqrt(Math.Pow(a.column - b.column, 2) + Math.Pow(a.row - b.row, 2));
    }
    public static double DistanceCarre(Coordinates a, Coordinates b)
    {
        return Math.Pow(a.column - b.column, 2) + Math.Pow(a.row - b.row, 2);
    }

    /// <summary>
    /// 
    /// </summary>
    /// 

    public static Coordinates[] vonNeumanNeighbors = {
        new Coordinates(0, -1), // Up
        new Coordinates(0, 1),  // Down
        new Coordinates(-1, 0), // Left
        new Coordinates(1, 0)   // Right
    };

    public static Coordinates[] moorNeighbors = {
        new Coordinates(0, -1),  // Up
        new Coordinates(0, 1),   // Down
        new Coordinates(-1, 0),  // Left
        new Coordinates(1, 0),   // Right
        new Coordinates(-1, -1), // Up-Left
        new Coordinates(-1, 1),  // Down-Left
        new Coordinates(1, -1),  // Up-Right
        new Coordinates(1, 1)    // Down-Right
    };
    public static Coordinates Zero => new Coordinates(0, 0);
    public static Coordinates One => new Coordinates(1, 1);
    public static Coordinates Up => new Coordinates(0, -1);
    public static Coordinates Down => new Coordinates(0, 1);
    public static Coordinates Left => new Coordinates(-1, 0);
    public static Coordinates Right => new Coordinates(1, 0);

    public Vector2 ToVector2()
    {
        return new Vector2(column, row);
    }
    public static Coordinates FromVector2(Vector2 vector)
    {
        return new Coordinates((int)Math.Floor(vector.X), (int)Math.Round(vector.Y));
    }

    public static Coordinates Random( int maxColumn,  int maxRow)
    {
        Random random = new Random();
        int column = random.Next(0,maxColumn);
        int row = random.Next(0,maxRow);
        return new Coordinates(column, row);
    }

}



