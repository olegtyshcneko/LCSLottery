using System;
using LCSLottery.Core;
using Xunit;
using LCSLottery.Tests.TestData;

namespace LCSLottery.Tests
{
    public class LcsSolverTests
    {
        [Theory]
        [InlineData(LotteryNumbersData.WinningNumber, LotteryNumbersData.SixCreditsLotteryNumber)]
        public void LcsSolver_Should_Find_Subset_Of_Six_Elements(string winningNumber, string lotteryNumber)
        {
            var lcsLength = LcsSolver.FindCount(lotteryNumber, winningNumber);
            Assert.Equal(6, lcsLength);
        }

        [Theory]
        [InlineData(LotteryNumbersData.WinningNumber, LotteryNumbersData.FourCreditsLotteryNumber)]
        public void LcsSolver_Should_Find_Subset_Of_Four_Elements(string winningNumber, string lotteryNumber)
        {
            var lcsLength = LcsSolver.FindCount(lotteryNumber, winningNumber);
            Assert.Equal(4, lcsLength);
        }

        [Theory]
        [InlineData(LotteryNumbersData.WinningNumber, LotteryNumbersData.TwoCreditsLotteryNumber)]
        public void LcsSolver_Should_Find_Subset_Of_Two_Elements(string winningNumber, string lotteryNumber)
        {
            var lcsLength = LcsSolver.FindCount(lotteryNumber, winningNumber);
            Assert.Equal(2, lcsLength);
        }

        [Theory]
        [InlineData(LotteryNumbersData.WinningNumber, LotteryNumbersData.ZeroCreditsLottery)]
        public void LcsSolver_Should_Not_Find_Subset(string winningNumber, string lotteryNumber)
        {
            var lcsLength = LcsSolver.FindCount(lotteryNumber, winningNumber);
            Assert.Equal(0, lcsLength);
        }

        [Theory]
        [InlineData(LotteryNumbersData.WinningNumber, LotteryNumbersData.IncorrectLotteryNumber)]
        public void LcsSolver_Should_Throw_Exception_If_Lottery_Number_Not_Valid(string winningNumber, string lotteryNumber)
        {
            Assert.Throws(typeof(ArgumentException), 
                () => LcsSolver.FindCount(lotteryNumber, winningNumber));

            Assert.Throws(typeof(ArgumentException), 
                () => LcsSolver.FindCount(winningNumber, lotteryNumber));
        }

        [Theory]
        [InlineData(LotteryNumbersData.WinningNumber, LotteryNumbersData.SixCreditsLotteryNumber)]
        public void Solving_Order_Should_Not_Matter(string winningNumber, string sixCreditsNumber)
        {
            var lcsLength = LcsSolver.FindCount(sixCreditsNumber, winningNumber);
            var lcsLength2 = LcsSolver.FindCount(winningNumber, sixCreditsNumber);
            Assert.True(lcsLength == lcsLength2);
        }
    }
}