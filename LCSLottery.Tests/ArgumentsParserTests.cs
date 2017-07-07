using System;
using Xunit;
using System.Collections.Generic;
using System.IO;
using LCSLottery.Core.Abstractions;
using LCSLottery.Core.Data.Enums;
using LCSLottery.Tests.TestData;

namespace LCSLottery.Tests 
{
    public class ArgumentsParserTests
    {
        private IArgumentsParser argumentsParser;

        public ArgumentsParserTests()
        {
        }

        [Theory]
        [InlineData(ArgumentsTestData.CorrectFilePath, ArgumentsTestData.CorrectWinningNumber)]
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
        [InlineData(ArgumentsTestData.CorrectFilePath, ArgumentsTestData.CorrectWinningNumber)]
        public void If_Arguments_Parse_Success_InputFileReader_Encoding_Should_Be_UTF8(string filePath, string winningNumber)
        {
            var args = new string[] { filePath, winningNumber };
            var argumentsReadResult = argumentsParser.Parse(args);

            Assert.NotNull(argumentsReadResult?.Data?.InputFileReader);

            var inputFileReader = argumentsReadResult.Data.InputFileReader;
            Assert.Equal(inputFileReader.CurrentEncoding, System.Text.Encoding.UTF8);
        }

        [Theory]
        [InlineData(ArgumentsTestData.CorrectFilePath, ArgumentsTestData.WrongWinningNumber)]
        public void Should_Return_Incorrect_Winning_Number_Error_If_It_Is_Not_Correct(string filePath, string winningNumber)
        {
            var args = new string[] { filePath, winningNumber };
            var argumentsReadResult = argumentsParser.Parse(args);

            Assert.True(argumentsReadResult.Status == ResultStatus.Error);
            Assert.Null(argumentsReadResult.Data);
            Assert.False(string.IsNullOrWhiteSpace(argumentsReadResult.ErrorMessage));
        }

        [Theory]
        [InlineData(ArgumentsTestData.WrongFilePath, ArgumentsTestData.CorrectWinningNumber)]
        public void Should_Return_File_Read_Error_If_File_Reading_Went_Wrong(string filePath, string winningNumber)
        {
            var args = new string[] { filePath, winningNumber };
            var argumentsReadResult = argumentsParser.Parse(args);
            
            Assert.True(argumentsReadResult.Status == ResultStatus.Error);
            Assert.Null(argumentsReadResult.Data);
            Assert.False(string.IsNullOrWhiteSpace(argumentsReadResult.ErrorMessage));
        }
        
        [Fact]
        public void Should_Return_Error_If_There_Is_Less_Than_Two_Arguments()
        {
            var args = new string[] { "arg" };
            var argumentsReadResult = argumentsParser.Parse(args);
            
            Assert.True(argumentsReadResult.Status == ResultStatus.Error);
            Assert.False(string.IsNullOrWhiteSpace(argumentsReadResult.ErrorMessage));
        }
        
        [Fact]
        public void Should_Return_Error_If_There_Is_More_Than_Two_Arguments()
        {
            var args = new string[] { "arg", "arg2", "arg3" };
            var argumentsReadResult = argumentsParser.Parse(args);
            
            Assert.True(argumentsReadResult.Status == ResultStatus.Error);
            Assert.False(string.IsNullOrWhiteSpace(argumentsReadResult.ErrorMessage));
        }
    }
}