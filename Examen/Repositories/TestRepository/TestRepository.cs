
using Repositories.GenericRepository;
using Examen.Data;
using Examen.Data.Models;

namespace Repositories.TestRepository;

public class TestRepository : GenericRepository<TestModel>, ITestRepository
{
    public TestRepository(ExamenContext dbContext) : base(dbContext) { }
}