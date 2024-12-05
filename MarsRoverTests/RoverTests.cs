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

        [Test]
        public void TurnRightTest()
        {
            var r = new Rover(new Position(1, 1, Bearing.W));

            r.TurnRight();

            r.Position.Bearing.Should().Be(Bearing.N);

            r.TurnRight();

            r.Position.Bearing.Should().Be(Bearing.E);
        }

        [Test]
        public void TurnRightAndLeftTest()
        {
            var r = new Rover(new Position(1, 1, Bearing.W));

            r.TurnRight();
            r.TurnLeft();
            r.TurnLeft();
            r.TurnLeft();

            r.Position.Bearing.Should().Be(Bearing.E);
            r.TurnLeft();
            r.TurnLeft();
            r.TurnRight();

            r.Position.Bearing.Should().Be(Bearing.N);
        }

        [Test]
        public void BasicMoveWestTest()
        {
            var r = new Rover(new Position(1, 1, Bearing.W));

            r.Move();

            r.Position.X.Should().Be(0);
        }

        [Test]
        public void BasicMoveEastTest()
        {
            var r = new Rover(new Position(1, 1, Bearing.E));

            r.Move();

            r.Position.X.Should().Be(2);
        }

        [Test]
        public void BasicMoveNorthTest()
        {
            var r = new Rover(new Position(1, 1, Bearing.N));

            r.Move();

            r.Position.Y.Should().Be(2);
        }

        [Test]
        public void BasicMoveSouthTest()
        {
            var r = new Rover(new Position(1, 1, Bearing.S));

            r.Move();

            r.Position.Y.Should().Be(0);
        }

        [Test]
        public void MoveMultipleTest()
        {
            var r = new Rover(new Position(1, 1, Bearing.N));

            r.Move();
            r.Move();

            r.Position.Y.Should().Be(3);
        }

        [Test]
        public void MoveAndTurnTest()
        {
            var r = new Rover(new Position(1, 1, Bearing.N));

            r.Move();

            r.TurnRight();

            r.Move();

            r.Position.X.Should().Be(2);
            r.Position.Y.Should().Be(2);
        }
    }
}