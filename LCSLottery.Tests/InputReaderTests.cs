using LCSLottery.Tests.TestData;
using Xunit;
using LCSLottery.Core.Data;
using LCSLottery.Core.Data.Enums;
using LCSLottery.Core.Abstractions;
using LCSLottery.Core.Implementations;

namespace LCSLottery.Tests
{
    public class InputReaderTests
    {
        private IInputReader inputReader;

        public InputReaderTests()
        {
            inputReader = new InputReader();
        }

        [Fact]
        public void If_Input_Is_Correctly_Formatted_Return_Parsed_Array_Of_Participants()
        {
            var correctStream =
                InputReaderTestData.CreatedMockedStreamReader(InputReaderTestData.CorrectInputFileData());
            var participantsResult = inputReader.ReadParticipants(correctStream);
            var participants = participantsResult.Data;

            Assert.True(participantsResult.Status == ResultStatus.Success);
            Assert.NotEmpty(participants);
        }

        [Fact]
        public void If_Input_Is_Empty_Return_Error()
        {
            var emptyStream = InputReaderTestData.CreatedMockedStreamReader(InputReaderTestData.EmptyInputFileData());
            var participantsResult = inputReader.ReadParticipants(emptyStream);

            Assert.True(IsErrorAssert(participantsResult));
        }

        [Fact]
        public void If_Input_Is_Not_Correctly_Formatted_Should_Return_Error_Additional_Comma_Case()
        {
            var incorrectlyFormattedStream =
                InputReaderTestData.CreatedMockedStreamReader(InputReaderTestData.WrongInputFileDataAdditionalComma());
            var participantsResult = inputReader.ReadParticipants(incorrectlyFormattedStream);

            Assert.True(IsErrorAssert(participantsResult));
        }

        [Fact]
        public void If_Input_Is_Not_Correctly_Formatted_Should_Return_Error_Not_All_Data_Provided()
        {
            var incorrectlyFormattedStream =
                InputReaderTestData.CreatedMockedStreamReader(
                    InputReaderTestData.WrongInputFileDataNotAllDataIsProvided());
            var participantsResult = inputReader.ReadParticipants(incorrectlyFormattedStream);

            Assert.True(IsErrorAssert(participantsResult));
        }

        [Fact]
        public void If_Input_Is_Not_Correctly_Formatted_Should_Return_Error_Lottery_Number_Not_Provided()
        {
            var incorrectlyFormattedStream =
                InputReaderTestData.CreatedMockedStreamReader(InputReaderTestData.WrongInputFileDataNoLotteryNumber());
            var participantsResult = inputReader.ReadParticipants(incorrectlyFormattedStream);

            Assert.True(IsErrorAssert(participantsResult));
        }

        [Fact]
        public void If_Lottery_Number_Is_Not_Valid_Should_Return_Error()
        {
            var incorrectlyFormattedStream =
                InputReaderTestData.CreatedMockedStreamReader(InputReaderTestData
                    .WrongInputFileDataIncorrectLotteryNumber());
            var participantsResult = inputReader.ReadParticipants(incorrectlyFormattedStream);

            Assert.True(IsErrorAssert(participantsResult));
        }

        public bool IsErrorAssert(Result<ParticipantEntity[]> participantsResult)
        {
            //NOTE: I don't check error message contents, because it can vary or be localized
            return participantsResult.Status == ResultStatus.Error &&
                   (!string.IsNullOrWhiteSpace(participantsResult.ErrorMessage)) &&
                   (participantsResult.Data == null);
        }

        //TODO: Duplicates is obvious case here, but in such cases someone responsible from business should decide
        //what to do with duplicates, so I ask our business analytic(or product owner) what I should do in such cases
        //for now I've decided just leave duplicates
        public void If_Input_Has_Duplicates_TODO()
        {

        }
    }
}