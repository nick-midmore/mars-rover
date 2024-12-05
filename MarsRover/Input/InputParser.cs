using System.Text.RegularExpressions;
public class InputParser
{
    private Regex rgPosition = new(@"(?i)^\d+\s\d+\s[NESW]$");
    private Regex rgPlateau = new(@"^\d+\s\d+$");
    private Regex rgMovement = new(@"^[LMRlmr]*$");
    public void ParseInput(string input)
    {
        var inputArr = input.ToCharArray();
        if (String.IsNullOrEmpty(input)) Console.WriteLine("Input cannot be empty!");

        else if (rgPlateau.IsMatch(input)) Plateau.InitSize(inputArr[0], inputArr[2]);
        else if (rgPosition.IsMatch(input)) Plateau.Rovers.Add(new Rover(new Position(1, 1, Bearing.N)));
        else if (rgMovement.IsMatch(input)) input.ToCharArray();

    }
}