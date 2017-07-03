using System.IO;

namespace LCSLottery.Core.Data
{
    public class ParsedArguments
    {
        public StreamReader InputFileReader { get; set; }

        public string WinningNumber { get; set; }
    }
}