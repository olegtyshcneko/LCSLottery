using System.IO;

namespace LCSLottery.Core.Abstractions
{
    public interface IFileOpener
    {
        Stream Open(string path);

        bool Exists(string path);
    }
}