using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Input
{
    internal class PositionParser(List<string> input) : IParser
    {
        private List<string> _input = input;
        public Position ParsePosition()
        {
            int x = Convert.ToInt32(_input[0]);
            int y = Convert.ToInt32(_input[1]);
            Bearing b = _input[2] switch
            {
                "N" => Bearing.N,
                "E" => Bearing.E,
                "S" => Bearing.S,
                "W" => Bearing.W,
                _ => Bearing.N
            };
            return new Position(x, y, b);
        }
    }
}
