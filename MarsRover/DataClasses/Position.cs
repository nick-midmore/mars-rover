public class Position
{
    public int X { get; set; }
    public int Y { get; set; }
    public Bearing Bearing { get; set; }

    public Position(int x, int y, Bearing bearing)
    {
        X = x;
        Y = y;
        Bearing = bearing;
    }
    
}