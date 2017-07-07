using LCSLottery.Core.Abstractions;
using LCSLottery.Core.Data;
using Xunit;

namespace LCSLottery.Tests
{
    public class OutputFormatterTests
    {
        private const int winningCount = 4;
        
        private ParticipantEntity winningParticipantEntity;

        private IOutputFormatter outputFormatter;

        public OutputFormatterTests()
        {
            winningParticipantEntity = new ParticipantEntity
            {
                FirstName = "Alison",
                LastName = "Alice",
                Country = "Austria",
                LotteryNumber = "1234567890"
            };
        }

        [Fact]
        public void
            Output_Formatter_Given_Participant_And_His_Credits_Winning_Credits_Should_Produce_Correct_Output_String()
        {
            const string correctOutputString = "Alison,Alice,Austria,4";
            var formattedString = outputFormatter.Format(winningParticipantEntity, winningCount);

            Assert.Equal(correctOutputString, formattedString);
        }
    }
}