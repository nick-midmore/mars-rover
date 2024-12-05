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
        public void PlateauValidInputTest()
        {
            var p = new InputParser();

            p.ParseInput("5 6").Should().Be(ParseResult.PLATEAU);
            p.ParseInput("8 16").Should().Be(ParseResult.PLATEAU);
            p.ParseInput("25 16").Should().Be(ParseResult.PLATEAU);

        }

        [Test]
        public void PositionValidInputTest()
        {
            var p = new InputParser();

            p.ParseInput("5 6 E").Should().Be(ParseResult.POSITION);
            p.ParseInput("5 16 W").Should().Be(ParseResult.POSITION);
            p.ParseInput("0 6 S").Should().Be(ParseResult.POSITION);
        }

        [Test]
        public void InstructionValidInputTest()
        {
            var p = new InputParser();

            p.ParseInput("LMLRMMLMRLMRRMLR").Should().Be(ParseResult.INSTRUCTION);
            p.ParseInput("LMRLMRLMRLRMLRM").Should().Be(ParseResult.INSTRUCTION);
            p.ParseInput("RRRLRLRLRLMMMMLL").Should().Be(ParseResult.INSTRUCTION);
            p.ParseInput("LLLLRRMRMRMMMMM").Should().Be(ParseResult.INSTRUCTION);
        }
    }
}