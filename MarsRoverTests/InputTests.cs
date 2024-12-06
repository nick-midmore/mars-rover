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

            Assert.That(parser.ParseInput(""), Is.EqualTo(null));
        }

        [Test]
        public void InputInvalidTest()
        {
            var p = new InputParser();

            p.ParseInput("hello").Should().Be(null); 
        }

        [Test]
        public void InputTooLongTest()
        {
            var p = new InputParser();

            p.ParseInput("1 2 N A").Should().Be(null);
        }

        [Test]
        public void InputTooShortTest()
        {
            var p = new InputParser();

            p.ParseInput("5 ").Should().Be(null);
        }

        [Test]
        public void PlateauValidInputTest()
        {
            var p = new InputParser();

            p.ParseInput("5 6").Should().BeOfType<PlateauParser>();
            p.ParseInput("8 16").Should().BeOfType<PlateauParser>();
            p.ParseInput("25 16").Should().BeOfType<PlateauParser>();

        }

        [Test]
        public void PositionValidInputTest()
        {
            var p = new InputParser();

            p.ParseInput("5 6 E").Should().BeOfType<PositionParser>();
            p.ParseInput("5 16 W").Should().BeOfType<PositionParser>();
            p.ParseInput("0 6 S").Should().BeOfType<PositionParser>();
        }

        [Test]
        public void InstructionValidInputTest()
        {
            var p = new InputParser();

            p.ParseInput("LMLRMMLMRLMRRMLR").Should().BeOfType<InstructionParser>();
            p.ParseInput("LMRLMRLMRLRMLRM").Should().BeOfType<InstructionParser>();
            p.ParseInput("RRRLRLRLRLMMMMLL").Should().BeOfType<InstructionParser>();
            p.ParseInput("LLLLRRMRMRMMMMM").Should().BeOfType<InstructionParser>();
        }
    }
}