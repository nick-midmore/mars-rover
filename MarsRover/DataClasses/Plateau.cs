public static class Plateau
{
    public static int X { get; private set; }
    public static int Y { get; private set; }
    public static List<Rover> Rovers { get; private set; } = new List<Rover>();
    public static void InitSize(int x, int y)
    {
        X = x;
        Y = y;
    }
}