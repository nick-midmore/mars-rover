using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Input
{
    internal class InstructionParser(List<char> input) : IParser
    {
        private List<char> _input = input;

        public List<Instruction> ParseInstructions()
        {
            var instructions = new List<Instruction>();
            foreach (var c in _input)
            {
                switch (c)
                {
                    case 'L':
                        instructions.Add(Instruction.L);
                        break;
                    case 'R':
                        instructions.Add(Instruction.R);
                        break;
                    case 'M':
                        instructions.Add(Instruction.M);
                        break;
                }
            }
            return instructions;
        }
    }
}
