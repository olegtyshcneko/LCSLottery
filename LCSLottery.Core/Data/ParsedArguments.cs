using System.IO;

namespace LCSLottery.Core.Data
{
    public class ParsedArguments
    {
        /// <summary>
        /// Reader of file containing LCS Lottery number
        /// NOTE: In general you should read file as soon as possible, so you won't hold resource for long
        /// so returning streams can be considered bad practice in such cases, but for separation concerns and because this file will read fast,
        /// I am returning this from argumentparser
        /// </summary>
        public StreamReader InputFileReader { get; set; }

        public string WinningNumber { get; set; }
    }
}