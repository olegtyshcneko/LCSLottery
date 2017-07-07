namespace LCSLottery.Core.Data.Constants
{
    public static class TextConstants
    {
        public const string NotAllArgumentsProvidedErrorMessage = "Not correct amount of arguments provided.\nYou should provide file path and winning number.";
        
        public const string FileDoesntExistsErrorMessage = "File on path provided doesn't exist";
        
        public const string WinningLotteryNumberNotValidMessage = "Winning lottery number provided is not valid. Should consist of only numbers.";

        public const string FileInputLineNoDataProvidedMessage = "No data in one of the lines is provided.";
        
        public const string FileInputLineNotCorrectlyFormattedMessage = "One of line in file provided is not correctly formatted, please check your input file.";

        public const string FileInputLineLotteryNumberNotValidMessage = "One of the lottery number provided in file is not correct.";

        public const string FileIsEmptyErrorMessage = "File provided is empty.";
    }
}