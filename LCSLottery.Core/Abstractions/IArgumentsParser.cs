using LCSLottery.Core.Data;

namespace LCSLottery.Core.Abstractions
{
    public interface IArgumentsParser
    {
        Result<ParsedArguments> Read(string[] args);
    }
}