using MarsRover.Input;
using FluentAssertions;

namespace MarsRoverTests
{
    [TestFixture]
    public class InputTests
    {
        [SetUp]
        public void Setup()
        {
            var parser = new InputParser();
        }

        [Test]
        public void InputEmptyTest()
        {
            var parser = new InputParser();

            Assert.That(parser.ParseInput(""), Is.EqualTo(ParseResult.INVALID));
        }

        [Test]
        public void InputInvalidTest()
        {
            var p = new InputParser();

            p.ParseInput("hello").Should().Be(ParseResult.INVALID); 
        }

        [Test]
        public void InputTooLongTest()
        {
            var p = new InputParser();

            p.ParseInput("1 2 N A").Should().Be(ParseResult.INVALID);
        }

        [Test]
        public void InputTooShortTest()
        {
            var p = new InputParser();

            p.ParseInput("5 ").Should().Be(ParseResult.INVALID);
        }

        [Test]
        public void PlateauInputTest()
        {
            var p = new InputParser();

            p.ParseInput("5 6").Should().Be(ParseResult.PLATEAU);
        }

        [Test]
        public void PositionInputTest()
        {
            var p = new InputParser();

            p.ParseInput("5 6 E").Should().Be(ParseResult.POSITION);
        }

        [Test]
        public void InstructionInputTest()
        {
            var p = new InputParser();

            p.ParseInput("LMLRMMLMRLMRRMLR").Should().Be(ParseResult.INSTRUCTION);
        }
    }
}