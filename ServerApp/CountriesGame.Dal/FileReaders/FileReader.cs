using System;
using System.IO;
using System.Threading.Tasks;
using CountriesGame.Dal.FileReaders.Interfaces;

namespace CountriesGame.Dal.FileReaders
{
    public class FileReader : IFileReader
    {
        public async Task<byte[]> ReadBytes(string path)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException(nameof(path));

            return await File.ReadAllBytesAsync(path);;
        }
    }
}