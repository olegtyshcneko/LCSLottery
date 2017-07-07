using System.Collections.Generic;
using System.IO;

namespace LCSLottery.Tests.TestData
{
    public static class InputReaderTestData
    {
        public static new string[] CorrectInputFileData()
        {
            return new string[] 
            {
                "Alison,Alice,Austria,1234567890",
                "Bert,Bertram,Belgium,0987654321",
                "Alison,Alice,Austria,9988776655"
            };
        }

        public static string[] EmptyInputFileData()
        {
            return new string[0];
        }

        public static string[] WrongInputFileDataAdditionalComma()
        {
            return new string[]
            {
                "Alison,Alice,Austria,1234567890,",
            };
        }

        public static string[] WrongInputFileDataDuplicateLotteryNumber()
        {
            return new string[]
            {
                "Alison,Alice,Austria,1234567890",
                "Alison,Alice,Austria,1234567890"
            };
        }

        public static string[] WrongInputFileDataNotAllDataIsProvided()
        {
            return new string[]
            {
                "Alice,Austria,1234567890",
            };
        }

        public static string[] WrongInputFileDataIncorrectLotteryNumber()
        {
            return new string[]
            {
                "Alison,Alice,Austria,12345b7890",
            };
        }

        public static string[] WrongInputFileDataNoLotteryNumber()
        {
            return new string[]
            {
                "Alison,Alice,Austria,",
            };
        }
        
        public static StreamReader CreatedMockedStreamReader(string[] data)
        {
            var memoryStream = new MemoryStream();
            var streamWriter = new StreamWriter(memoryStream);

            foreach(var s in data)
            {
                streamWriter.WriteLine(s);
            }
            
            streamWriter.Flush();
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new StreamReader(memoryStream);
        }
    }
}