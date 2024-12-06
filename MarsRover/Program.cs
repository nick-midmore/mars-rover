using MarsRover.Input;

string[] input = {
    "5 5",
    "1 2 N",
    "LMLMLMLMM",
    "3 3 E",
    "MMRMMRMRRM"
};

var p = new InputParser();
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
        Plateau.Rovers.Add(new Rover(b.ParsePosition()));
    }
    else if(s is InstructionParser c)
    {
        Plateau.Rovers[0].TakeInstructions(c.ParseInstructions());
    }
}



