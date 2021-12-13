using System;
using System.IO;
using System.Threading.Tasks;
using CountriesGame.Dal.FileReaders.Interfaces;

namespace CountriesGame.Dal.FileReaders
{
    public class FileReader : IFileReader
    {
        private const string AssemblyPath = "../CountriesGame.Dal";

        private readonly string _currentDirectory;

        public FileReader()
        {
            _currentDirectory = Directory.GetCurrentDirectory();
        }

        public async Task<byte[]> ReadBytes(string path)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException(nameof(path));

            string fullPath = Path.Combine(_currentDirectory, AssemblyPath, path);

            return await File.ReadAllBytesAsync(fullPath);
        }
    }
}