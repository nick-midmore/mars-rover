using NUnit.Framework;
using FluentAssertions;

namespace MarsRoverTests
{
    public class RoverTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TurnLeftTest()
        {
            var r = new Rover(new Position(1, 1, Bearing.N));

            r.TurnLeft();
        
            r.Position.Bearing.Should().Be(Bearing.W);

            r.TurnLeft();
            r.TurnLeft();

            r.Position.Bearing.Should().Be(Bearing.E);
        }
    }
}