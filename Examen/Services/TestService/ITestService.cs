
using Examen.Data.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Services.TestService;

public interface ITestService
{
    Task<List<TestModel>> GetAll();
    Task Create(TestModel test);
    void Delete(Guid id);
    Task Update(TestModel test);
    Task UpdatePricesBy10Percent();
}