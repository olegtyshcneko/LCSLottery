using LCSLottery.Core.Abstractions;
using LCSLottery.Core.Data;

namespace LCSLottery.Core.Implementations
{
    public class OutputFormatter : IOutputFormatter
    {
        public string Format(ParticipantEntity winningParticipantEntity, int winningCount)
        {
            //NOTE: as example of potential bad code, 
            //we are depending on property of other class which can change how this mtehod behaves
            return $"{winningParticipantEntity.FormattedParticipant},{winningCount}";
        }
    }
}