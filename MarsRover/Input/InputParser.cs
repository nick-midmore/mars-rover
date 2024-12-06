using System.Text.RegularExpressions;
namespace MarsRover.Input;
public class InputParser : IParser
{
    private Regex rgPosition = new(@"(?i)^\d+\s\d+\s[NESW]$");
    private Regex rgPlateau = new(@"^\d+\s\d+$");
    private Regex rgInstruction = new(@"^[LMR]*$");

    public IParser? ParseInput(string input)
    {
        var inputUpper = input.ToUpper();
        if (String.IsNullOrEmpty(inputUpper)) return null;

        else if (rgPlateau.IsMatch(inputUpper)) return new PlateauParser(inputUpper.Split(' ').ToList());

        else if (rgPosition.IsMatch(inputUpper)) return new PositionParser(inputUpper.Split(' ').ToList());

        else if (rgInstruction.IsMatch(inputUpper)) return new InstructionParser(inputUpper.ToCharArray().ToList());

        else return null;
    }
}
