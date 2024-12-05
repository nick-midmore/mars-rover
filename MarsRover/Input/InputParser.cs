using System.Text.RegularExpressions;
namespace MarsRover.Input;
public class InputParser
{
    private Regex rgPosition = new(@"(?i)^\d+\s\d+\s[NESW]$");
    private Regex rgPlateau = new(@"^\d+\s\d+$");
    private Regex rgMovement = new(@"^[LMRlmr]*$");
    public void ParseInput(string input)
    {
        var inputArr = input.Split(' ');
        if (String.IsNullOrEmpty(input)) Console.WriteLine("Input cannot be empty!");

        else if (rgPlateau.IsMatch(input)) Plateau.InitSize(Convert.ToInt32(inputArr[0]), Convert.ToInt32(inputArr[2]));

        else if (rgPosition.IsMatch(input)) Plateau.Rovers.Add(ParsePosition(input)); 

        else if (rgMovement.IsMatch(input)) input.ToCharArray();
    }

    public Rover ParsePosition(string input)
    {
        var inputArray = input.Split(' ');
        int x = Convert.ToInt32(inputArray[0]);
        int y = Convert.ToInt32(inputArray[1]); 
        Bearing b = inputArray[2].ToLower() switch
        {
            "n" => Bearing.N,
            "e" => Bearing.E,
            "s" => Bearing.S,
            "w" => Bearing.W,
            _ => Bearing.N
        };

        Position resultPosition = new(x, y, b);
        Rover rover = new(resultPosition);
        return rover;
    }

    public List<Instruction> ParseInstructions(string input) 
    {
        var instructions = new List<Instruction>();
        foreach(var c in input.ToLower())
        {
            switch(c)
            {
                case 'l':
                    instructions.Add(Instruction.L);
                    break;
                case 'r':
                    instructions.Add(Instruction.R);
                    break;
                case 'm':
                    instructions.Add(Instruction.M);
                    break;
            }
        }
        return instructions;
    }
}