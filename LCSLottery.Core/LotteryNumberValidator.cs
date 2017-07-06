namespace LCSLottery.Core
{
    public static class LotteryNumberValidator
    {
        public static bool IsValid(string lotteryNumber)
        {
            double result;
            return double.TryParse(lotteryNumber, out result);
        }
    }
}