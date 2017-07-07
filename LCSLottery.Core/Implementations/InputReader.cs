using System;
using System.Collections.Generic;
using System.IO;
using LCSLottery.Core.Abstractions;
using LCSLottery.Core.Data;
using LCSLottery.Core.Data.Constants;

namespace LCSLottery.Core.Implementations
{
    public class InputReader : IInputReader
    {
        public Result<ParticipantEntity[]> ReadParticipants(StreamReader inputFileStream)
        {
            var resultList = new List<ParticipantEntity>();
            SetStreamAtStartIfNeeded(inputFileStream);

            if (inputFileStream.EndOfStream)
            {
                return Result<ParticipantEntity[]>.FromError(TextConstants.FileIsEmptyErrorMessage);
            }
            
            while (!inputFileStream.EndOfStream)
            {
                var inputLine = inputFileStream.ReadLine();
                var lineValidation = ValidateLine(inputLine);
                
                if (lineValidation.Item2)
                {
                    resultList.Add(ParseLine(inputLine));
                }
                else
                {
                    return Result<ParticipantEntity[]>.FromError(lineValidation.Item1);
                }
            }
            
            return Result<ParticipantEntity[]>.FromSuccess(resultList.ToArray());
        }

        private ParticipantEntity ParseLine(string inputLine)
        {
            var dividedLine = inputLine.Split(',');

            return new ParticipantEntity
            {
                FirstName = dividedLine[0],
                LastName = dividedLine[1],
                Country = dividedLine[2],
                LotteryNumber = dividedLine[3]
            };
        }

        private Tuple<string, bool> ValidateLine(string inputLine)
        {
            if (string.IsNullOrWhiteSpace(inputLine))
            {
                return Tuple.Create(TextConstants.FileInputLineNoDataProvidedMessage, false);
            }
            
            var dividedLine = inputLine.Split(',');
            if (dividedLine.Length != 4)
            {
                return Tuple.Create(TextConstants.FileInputLineNotCorrectlyFormattedMessage, false);
            }

            var lotteryNumber = dividedLine[3];
            if (!LotteryNumberValidator.IsValid(lotteryNumber))
            {
                return Tuple.Create(TextConstants.FileInputLineLotteryNumberNotValidMessage, false);
            }
            
            return Tuple.Create(string.Empty, true);
        }

        private void SetStreamAtStartIfNeeded(StreamReader inputFileStream)
        {
            if (inputFileStream.EndOfStream)
            {
                inputFileStream.BaseStream.Seek(0, SeekOrigin.End);
            }
        }
    }
}