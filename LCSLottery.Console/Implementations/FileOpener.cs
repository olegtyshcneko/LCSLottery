using System.IO;
using LCSLottery.Core.Abstractions;

namespace LCSLottery.Console.Implementations
{
    public class FileOpener : IFileOpener
    {
        public Stream Open(string path)
        {
            return File.Open(path, FileMode.Open);
        }

        public bool Exists(string path)
        {
            return File.Exists(path);
        }
    }
}