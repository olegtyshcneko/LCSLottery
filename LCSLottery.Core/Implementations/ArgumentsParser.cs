using System;
using System.IO;
using LCSLottery.Core.Abstractions;
using LCSLottery.Core.Data;
using LCSLottery.Core.Data.Constants;

namespace LCSLottery.Core.Implementations
{
    public class ArgumentsParser : IArgumentsParser
    {
        private readonly IFileOpener fileOpener;

        public ArgumentsParser(IFileOpener fileOpener)
        {
            this.fileOpener = fileOpener;
        }
        
        public Result<ParsedArguments> Parse(string[] args)
        {
            var validationResult = ValidateArguments(args);
            if (!validationResult.Item2)
            {
                return Result<ParsedArguments>.FromError(validationResult.Item1);
            }

            var parsedArgData = new ParsedArguments
            {
                InputFileReader = OpenFileStream(args[0]),
                WinningNumber = args[1]
            };

            return Result<ParsedArguments>.FromSuccess(parsedArgData);
        }

        private Tuple<string, bool> ValidateArguments(string[] args)
        {
            if (!IsLengthOfArgumentsValid(args))
            {
                return Tuple.Create(TextConstants.NotAllArgumentsProvidedErrorMessage, false);
            }

            if (!fileOpener.Exists(args[0]))
            {
                return Tuple.Create(TextConstants.FileDoesntExistsErrorMessage, false);
            }

            if (!LotteryNumberValidator.IsValid(args[1]))
            {
                return Tuple.Create(TextConstants.WinningLotteryNumberNotValidMessage, false);
            }
            
            return Tuple.Create(string.Empty, true);
        }

        private bool IsLengthOfArgumentsValid(string[] args)
        {
            return args.Length == 2;
        }
        
        private StreamReader OpenFileStream(string s)
        {
            var stream = fileOpener.Open(s);
            return new StreamReader(stream);
        }
    }
}