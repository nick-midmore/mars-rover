using MarsRover.Input;

string[] input = {
    "5 5",
    "1 2 N",
    "LMLMLMLMM",
    "3 3 E",
    "MMRMMRMRRM"
};

var p = new InputParser();
var r = new Rover(new Position(0, 0, Bearing.N));
var parsers = new List<IParser>();

foreach(var s in input)
{
    if(p.ParseInput(s) != null) parsers.Add(p.ParseInput(s));
}

foreach(var s in parsers)
{
    if(s is PlateauParser a)
    {
        a.ParsePlateau();
    }
    else if(s is PositionParser b)
    {
        b.ParsePosition();
    }
    else if(s is InstructionParser c)
    {
        c.ParseInstructions();
    }
}
