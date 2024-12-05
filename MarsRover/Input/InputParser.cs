using System.Text.RegularExpressions;
namespace MarsRover.Input;
public class InputParser  
{
    private Regex rgPosition = new(@"(?i)^\d+\s\d+\s[NESW]$");
    private Regex rgPlateau = new(@"^\d+\s\d+$");
    private Regex rgInstruction = new(@"^[LMRlmr]*$");
    public ParseResult ParseInput(string input)
    {
        if (String.IsNullOrEmpty(input)) return ParseResult.INVALID;

        else if (rgPlateau.IsMatch(input)) return ParseResult.PLATEAU;

        else if (rgPosition.IsMatch(input)) return ParseResult.POSITION;

        else if (rgInstruction.IsMatch(input)) return ParseResult.INSTRUCTION;

        else return ParseResult.INVALID;
    }

    public void ParsePlateau(string input)
    {
        var inputArr = input.Split(' ');
        int x = Convert.ToInt32(inputArr[0]);
        int y = Convert.ToInt32(inputArr[1]);
        Plateau.InitSize(x, y);
    }

    public Position ParsePosition(string input)
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

        return new Position(x, y, b);
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
