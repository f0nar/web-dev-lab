using System.Threading.Tasks;

namespace CountriesGame.Bll.Infrastructure
{
    public interface IDataSeeder
    {
        Task SeedDataAsync();
    }
}
