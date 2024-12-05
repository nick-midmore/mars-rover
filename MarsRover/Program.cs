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

foreach(var s in input)
{
    switch(p.ParseInput(s))
    {
        case ParseResult.INVALID:
            Console.WriteLine("Invalid input");
            break;
        case ParseResult.PLATEAU:
            p.ParsePlateau(s);
            break;
        case ParseResult.POSITION:
            r.Position = p.ParsePosition(s);
            break;
        case ParseResult.INSTRUCTION:
            r.TakeInstructions(p.ParseInstructions(s));
            break;
    }
}
Console.WriteLine($"{r.Position.X} {r.Position.Y} {r.Position.Bearing.ToString()}");