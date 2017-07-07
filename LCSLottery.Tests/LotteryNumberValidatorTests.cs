using LCSLottery.Core;
using LCSLottery.Tests.TestData;
using Xunit;

namespace LCSLottery.Tests
{
    public class LotteryNumberValidatorTests
    {
        [Theory]
        [InlineData(LotteryNumbersData.TwoCreditsLotteryNumber)]
        public void Lottery_Number_Is_Valid_If_Consists_Of_Only_Numbers(string lotteryNumber)
        {
            var isNumberValid = LotteryNumberValidator.IsValid(lotteryNumber);
            Assert.True(isNumberValid);
        }

        [Theory]
        [InlineData("")]
        public void Lottery_Number_Is_Not_Valid_If_Empty(string lotteryNumber)
        {
            var isNumberValid = LotteryNumberValidator.IsValid(lotteryNumber);
            Assert.False(isNumberValid);
        }

        [Theory]
        [InlineData(LotteryNumbersData.IncorrectLotteryNumber)]
        public void Lottery_Number_Is_Not_Valid_If_Not_All_Numbers(string lotteryNumber)
        {
            var isNumberValid = LotteryNumberValidator.IsValid(lotteryNumber);
            Assert.False(isNumberValid);
        }
    }
}