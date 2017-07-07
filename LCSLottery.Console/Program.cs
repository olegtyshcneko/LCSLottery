using System;
using LCSLottery.Console.App;
using LCSLottery.Console.Implementations;
using LCSLottery.Core.Implementations;

namespace LCSLottery.Console
{
    static class Program
    {
        static void Main(string[] args)
        {
            var appConfig = CreateAppConfig();
            
            var app = new LcsLotteryApp(appConfig);
            app.Run(args);
        }

        private static LcsLotteryAppConfig CreateAppConfig()
        {
            //NOTE: in real apps I am using IoC containers 
            return new LcsLotteryAppConfig
            {
                ArgumentsParser = new ArgumentsParser(new FileOpener()),
                InputReader = new InputReader(),
                OutputFormatter = new OutputFormatter()
            };
        }
    }
}