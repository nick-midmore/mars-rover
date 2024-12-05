public class Rover
{
    public Position Position { get; set; }
    public Rover(Position position)
    {
        Position = position;
    }

    public void TakeInstructions(List<Instruction> instructions)
    {
        foreach(var i in instructions)
        {
            switch (i)
            {
                case Instruction.L:
                    TurnLeft();
                    break;
                case Instruction.R:
                    TurnRight();
                    break;
                case Instruction.M:
                    Move();
                    break;
            }
        }
    }

    public void TurnRight()
    {
        if(Position.Bearing == Bearing.W) Position.Bearing = Bearing.N;
        else Position.Bearing ++;
    }
    public void TurnLeft()
    {
        if(Position.Bearing == Bearing.N) Position.Bearing = Bearing.W;
        else Position.Bearing --;
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