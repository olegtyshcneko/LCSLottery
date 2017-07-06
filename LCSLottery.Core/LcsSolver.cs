using System;

namespace LCSLottery.Core
{
    public static class LcsSolver
    {
        private const string lotteryNumberNotValidExceptionMessage = "Lottery number is not valid.";
        
        public static int FindCount(string first, string second)
        {
            CheckLotteryNumbers(first, second);
            
            var lcs = new int[first.Length+1, second.Length+1];
            var solution = new string[first.Length + 1, second.Length + 1];

            for (var i = 0; i <= second.Length; i++)
            {
                lcs[0, i] = 0;
                solution[0, i] = "0";
            }

            for (var i = 0; i <= first.Length; i++)
            {
                lcs[i, 0] = 0;
                solution[i, 0] = "0";
            }

            for (int i = 1; i <= first.Length; i++)
            {
                for (int j = 1; j <= second.Length; j++)
                {
                    if (first[i - 1] == second[j - 1])
                    {
                        lcs[i, j] = lcs[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        lcs[i, j] = System.Math.Max(lcs[i - 1, j], lcs[i, j - 1]);
                    }
                }
            }


            return lcs[first.Length, second.Length];
        }
        
        private static void CheckLotteryNumbers(string first, string second)
        {
            var isFirstValid = LotteryNumberValidator.IsValid(first);
            var isSecondValid = LotteryNumberValidator.IsValid(second);

            if(!isFirstValid)
                throw new ArgumentException(lotteryNumberNotValidExceptionMessage, nameof(first));
            
            if(!isSecondValid)
                throw new ArgumentException(lotteryNumberNotValidExceptionMessage, nameof(second));
        }
    }
}