using LCSLottery.Core.Abstractions;

namespace LCSLottery.Console.App
{
    public class LcsLotteryAppConfig
    {
        public IArgumentsParser ArgumentsParser { get; set; }
        
        public IInputReader InputReader { get; set; }
        
        public IOutputFormatter OutputFormatter { get; set; }
    }
}