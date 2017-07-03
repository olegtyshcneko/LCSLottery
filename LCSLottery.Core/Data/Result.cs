using LCSLottery.Core.Data.Enums;

namespace LCSLottery.Core.Data
{
    public class Result<T>
    {
        public T Data { get; private set; }

        public string ErrorMessage { get; private set; }

        public ResultStatus Status { get; private set; }

        private Result()
        {
        }

        public static Result<T> FromSuccess(T data)
        {
            return new Result<T> { Data = data, Status = ResultStatus.Success };
        }

        public static Result<T> FromError(string errorMessage)
        {
            return new Result<T> { Status = ResultStatus.Error, ErrorMessage = errorMessage };
        }
    }
}