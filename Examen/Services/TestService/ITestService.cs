
using Examen.Data.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Services.TestService;

public interface ITestService
{
    Task<List<Autor>> GetAll();
    Task Create(Autor test);
    void Delete(Guid id);
    Task Update(Autor test);
    //Task UpdatePricesBy10Percent();
}