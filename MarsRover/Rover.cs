public class Rover
{
    public Position Position { get; set; }
    public Rover(Position position)
    {
        Position = position;
    }

    public void TurnRight()
    {
        Position.Bearing ++;
    }
    public void TurnLeft()
    {
        Position.Bearing --;
    }
    public void Move()
    {
        switch(Position.Bearing)
        {
            case Bearing.N:
                Position.Y++;
                break;
            case Bearing.E:
                Position.X++;
                break;
            case Bearing.S:
                Position.Y--;
                break;
            case Bearing.W:
                Position.X--;
                break;
            default:
                break;
        }
    }
}