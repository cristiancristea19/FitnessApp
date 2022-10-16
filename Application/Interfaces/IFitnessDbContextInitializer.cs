using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IFitnessDbContextInitializer
    {
        public Task SeedAsync();
    }
}