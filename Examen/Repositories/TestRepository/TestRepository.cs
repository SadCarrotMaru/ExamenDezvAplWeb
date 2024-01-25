
using Repositories.GenericRepository;
using Examen.Data;
using Examen.Data.Models;

namespace Repositories.TestRepository;

public class TestRepository : GenericRepository<Autor>, ITestRepository
{
    public TestRepository(ExamenContext dbContext) : base(dbContext) { }
}