using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Input
{
    internal class PlateauParser(List<string> input) : IParser
    {
        private readonly List<string> _input = input;
        public void ParsePlateau()
        {
            int x = Convert.ToInt32(_input[0]);
            int y = Convert.ToInt32(_input[1]);
            Plateau.InitSize(x, y);
        }
    }
}
