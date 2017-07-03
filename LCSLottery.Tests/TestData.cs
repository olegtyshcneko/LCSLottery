using System.Collections.Generic;

namespace LCSLottery.Tests
{
    public static class TestData
    {
        public const string CorrectFilePath = "correct_path.txt";
        public const string WrongFilePath = "wrong_path.txt";

        public const string CorrectWinningNumber = "456000123";

        public const string WrongWinningNumber = "4560c0123";

        public static readonly string[] CorrectInputFileData = new string[] 
        {
            "Alison,Alice,Austria,1234567890",
            "Bert,Bertram,Belgium,0987654321",
            "Alison,Alice,Austria,9988776655"
        };

        public static readonly string[] WrongInputFileDataAdditionalComma = new string[] 
        {
            "Alison,Alice,Austria,1234567890,",
        };

        public static readonly string[] WrongInputFileDataDuplicateLotteryNumber = new string[]  //how to react on duplicate?
        {
            "Alison,Alice,Austria,1234567890",
            "Alison,Alice,Austria,1234567890"
        };

        public static readonly string[] WrongInputFileDataNotAllDataIsProvided = new string[] 
        {
            "Alice,Austria,1234567890",
        };

        public static readonly string[] WrongInputFileDataIncorrectLotteryNumber = new string[] 
        {
            "Alison,Alice,Austria,12345b7890",
        };

        public static readonly string[] WrongInputFileDataNoLotteryNumber = new string[] 
        {
            "Alison,Alice,Austria",
        };
    }
}