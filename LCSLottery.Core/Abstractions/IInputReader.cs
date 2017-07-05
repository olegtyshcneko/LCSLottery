using System.IO;
using LCSLottery.Core.Data;

namespace LCSLottery.Core.Abstractions
{
    public interface IInputReader
    {
        //NOTE: using streamreader not best design decision, because it can present leaks and excessive resource hold(usually you want to read something fast than validate)
        //but I've started with it and decided not to refactor to finish faster(and also present code design evolution and thinking process)
        Result<ParticipantEntity[]> ReadParticipants(StreamReader inputFileStream); 
    }
}