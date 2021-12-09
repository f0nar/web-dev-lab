using System.Threading.Tasks;

namespace CountriesGame.Dal.FileReaders.Interfaces
{
    public interface IFileReader
    {
        Task<byte[]> ReadBytes(string path);
    }
}