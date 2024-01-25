
using Examen.Data;
using Examen.Data.Models;
using Repositories.TestRepository;

namespace Services.TestService;

public class TestService : ITestService
{
    private readonly ITestRepository _testRepository;
    private readonly ExamenContext _context;

    public TestService(ITestRepository testRepository, ExamenContext tablecontext)
    {
        _testRepository = testRepository;
        _context = tablecontext;
    }
    

    public async Task<List<Autor>> GetAll()
    {
        return await _testRepository.GetAllAsync();
    }

    public async Task Create(Autor test)
    {
        await _testRepository.CreateAsync(test);
        await _testRepository.SaveAsync();
    }

    public void Delete(Guid id)
    {
        _testRepository.DeleteById(id);
        _testRepository.SaveAsync();
    }

    public async Task Update(Autor test)
    {
        _testRepository.Update(test);
        await _testRepository.SaveAsync();
    }

    /*
    public async Task UpdatePricesBy10Percent()
    {
        var allTests = await _testRepository.GetAllAsync();
        var sum = 0;

        
        foreach (var test in allTests)
        {
            test.Price += 10;
            sum += test.Price;
        }
        
        //update all prices by 10%
        foreach (var ent in _context.ToList())
        {
            ent.Price+=10;
            _context.SaveChanges();
        }
        //allTests.ForEach(test => test.Price += 10);
        //sum all prices
        //sum = allTests.Sum(test => test.Price);
        System.Diagnostics.Debug.WriteLine(sum);
        await _testRepository.SaveAsync();
        
    }
        */
}