using System.IO;

namespace LCSLottery.Core.Data
{
    public class ParsedArguments
    {
        public FileStream InputFile { get; set; }

        public string WinningNumber { get; set; }
    }
}