using System;
using Xunit;
using System.Collections.Generic;
using System.IO;
using LCSLottery.Core.Abstractions;
using LCSLottery.Core.Data.Enums;

namespace LCSLottery.Tests 
{
    public class ArgumentsParserTests
    {
        private IArgumentsParser argumentsParser;

        public ArgumentsParserTests()
        {
        }

        [Theory]
        [InlineData(TestData.CorrectFilePath, TestData.CorrectWinningNumber)]
        public void Should_Return_Success_And_Data_If_File_Can_Be_Read_And_Winning_Number_Is_Correct(string filePath, string winningNumber)
        {
            var args = new string[] { filePath, winningNumber };
            var argumentsReadResult = argumentsParser.Parse(args);

            Assert.True(argumentsReadResult.Status == ResultStatus.Success);
            Assert.Null(argumentsReadResult.ErrorMessage);

            Assert.NotNull(argumentsReadResult?.Data?.InputFileReader);
            Assert.False(string.IsNullOrWhiteSpace(argumentsReadResult?.Data?.WinningNumber));
        }

        [Theory]
        [InlineData(TestData.CorrectFilePath, TestData.WrongWinningNumber)]
        public void Should_Return_Incorrect_Winning_Number_Error_If_It_Is_Not_Correct(string filePath, string winningNumber)
        {
            var args = new string[] { filePath, winningNumber };
            var argumentsReadResult = argumentsParser.Parse(args);

            Assert.True(argumentsReadResult.Status == ResultStatus.Error);
            Assert.Null(argumentsReadResult.Data);
            Assert.False(string.IsNullOrWhiteSpace(argumentsReadResult.ErrorMessage));
        }

        [Theory]
        [InlineData(TestData.WrongFilePath, TestData.CorrectWinningNumber)]
        public void Should_Return_File_Read_Error_If_File_Reading_Went_Wrong(string filePath, string winningNumber)
        {
            var args = new string[] { filePath, winningNumber };
            var argumentsReadResult = argumentsParser.Parse(args);

            Assert.True(argumentsReadResult.Status == ResultStatus.Error);
            Assert.Null(argumentsReadResult.Data);
            Assert.False(string.IsNullOrWhiteSpace(argumentsReadResult.ErrorMessage));
        }
    }
}