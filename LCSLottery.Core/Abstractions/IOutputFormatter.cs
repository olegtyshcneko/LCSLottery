using LCSLottery.Core.Data;

namespace LCSLottery.Core.Abstractions
{
    public interface IOutputFormatter
    {
        string Format(ParticipantEntity winningParticipantEntity, int winningCount);
    }
}