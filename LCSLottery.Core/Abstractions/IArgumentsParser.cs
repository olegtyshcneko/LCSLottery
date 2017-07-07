using LCSLottery.Core.Data;

namespace LCSLottery.Core.Abstractions
{
    public interface IArgumentsParser
    {
        Result<ParsedArguments> Parse(string[] args);
    }
}