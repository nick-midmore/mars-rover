using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using MarsRover.Input;
using NUnit.Framework;

namespace MarsRoverTests
{
    public class IntegrationTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ReturnCorrectParserTest()
        {
            string[] input = 
            {
                "5 5",
                "1 2 N",
                "LMLMLMLMM",
                "3 3 E",
                "MMRMMRMRRM"
            };

            var p = new InputParser();
            var r = new Rover(new Position(0, 0, Bearing.N));
            var ip = new List<IParser>();

            foreach (var item in input)
            {
                if(p.ParseInput(item) != null) ip.Add(p.ParseInput(item));
            }

            ip[0].Should().BeOfType<PlateauParser>();
            ip[1].Should().BeOfType<PositionParser>();
            ip[2].Should().BeOfType<InstructionParser>();
        }

        [Test]
        public void ReturnCorrectPlateauSizeTest()
        {
            var p = new InputParser();
            (p.ParseInput("5 5") as PlateauParser).ParsePlateau();

            Plateau.X.Should().Be(5);
        }
    }
}