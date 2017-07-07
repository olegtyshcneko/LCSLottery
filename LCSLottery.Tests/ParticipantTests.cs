using LCSLottery.Core.Data;
using Xunit;

namespace LCSLottery.Tests
{
    public class ParticipantTests
    {
        private ParticipantEntity firstParticipant;
        private ParticipantEntity equalToFirstParticipant;
        
        private ParticipantEntity duplicateToFirstParticipant;

        private ParticipantEntity secondParticipant;

        public ParticipantTests()
        {
            firstParticipant = new ParticipantEntity
            {
                FirstName = "Alison",
                LastName = "Alice",
                Country = "Austria",
                LotteryNumber = "1234567890"
            };

            equalToFirstParticipant = new ParticipantEntity
            {
                FirstName = "Alison",
                LastName = "Alice",
                Country = "Austria",
                LotteryNumber = "9988776655"
            };

            duplicateToFirstParticipant = new ParticipantEntity
            {
                FirstName = "Alison",
                LastName = "Alice",
                Country = "Austria",
                LotteryNumber = "1234567890"
            };

            secondParticipant = new ParticipantEntity
            {
                FirstName = "Carlson",
                LastName = "Cynthia",
                Country = "China",
                LotteryNumber = "1234567890"
            }; 
        }


        [Fact]
        public void If_Participant_Have_Same_Name_And_City_They_Should_Be_Equal_But_Not_Duplicate()
        {
            var isEquals = firstParticipant.IsEquals(equalToFirstParticipant);

            Assert.True(isEquals);
        }

        [Fact]
        public void If_Participant_Have_Different_Name_Or_City_They_Should_Not_Be_Equal()
        {
            var isEquals = firstParticipant.IsEquals(secondParticipant);

            Assert.False(isEquals);
        }

        [Fact]
        public void If_Participants_Equal_And_Have_Same_Lottery_Number_They_Should_Be_Duplicate()
        {
            var isDuplicate = firstParticipant.IsDuplicate(duplicateToFirstParticipant);

            Assert.True(isDuplicate);
        }
    }
}