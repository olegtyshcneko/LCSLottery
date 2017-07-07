using System;
using System.Linq;
using LCSLottery.Core;
using LCSLottery.Core.Abstractions;
using LCSLottery.Core.Data;
using LCSLottery.Core.Data.Enums;

namespace LCSLottery.Console.App
{
    //NOTE: it is best idea to write integration tests on this class, but to finish faster I've decided to proceed without it
    public class LcsLotteryApp
    {
        private readonly IArgumentsParser argumentsParser;
        private readonly IInputReader inputReader;
        private readonly IOutputFormatter outputFormatter;
        
        public LcsLotteryApp(LcsLotteryAppConfig appConfig)
        {
            argumentsParser = appConfig.ArgumentsParser;
            inputReader = appConfig.InputReader;
            outputFormatter = appConfig.OutputFormatter;
        }

        public void Run(string[] args)
        {
            var parsedArgsResult = argumentsParser.Parse(args);
            if (parsedArgsResult.Status == ResultStatus.Error)
            {
                System.Console.WriteLine(parsedArgsResult.ErrorMessage);
                return;
            }

            var inputReadResults = inputReader.ReadParticipants(parsedArgsResult.Data.InputFileReader);
            if (inputReadResults.Status == ResultStatus.Error)
            {
                System.Console.WriteLine(inputReadResults.ErrorMessage);
                return;
            }

            OutputResults(inputReadResults.Data, parsedArgsResult.Data.WinningNumber);
        }

        private void OutputResults(ParticipantEntity[] participants, string winningNumber)
        {
            //NOTE: this logic can be put in other class and tested, but to finish faster, I am grouping it here
            var groupedParticipants =
                participants.Select(p => MapResult(p, winningNumber))
                    .GroupBy(pt => pt.Item1.GetHashCode())
                    .Select(gr => Tuple.Create(gr.First().Item1, gr.Sum(s => s.Item2)));

           foreach (var participantResult in groupedParticipants)
           {
               var participant = participantResult.Item1;
               var participantCredits = participantResult.Item2;

               if(participantCredits > 0)
               {
                   System.Console.WriteLine(outputFormatter.Format(participant, participantCredits));
               }
           }
        }

        private Tuple<ParticipantEntity, int> MapResult(ParticipantEntity entity, string winningNumber)
        {
            return Tuple.Create(entity, LcsSolver.FindCount(entity.LotteryNumber, winningNumber));
        }
    }
}