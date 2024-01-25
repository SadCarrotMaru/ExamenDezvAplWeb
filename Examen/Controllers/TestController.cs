
using Examen.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Services.TestService;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetTests()
        {
            return Ok(await _testService.GetAll());
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTest([FromBody] Autor test)
        {
            await _testService.Create(test);
            return Ok();
        }

        [HttpPatch("update")]
        public async Task<IActionResult> UpdateTest([FromBody] Autor test)
        {
            await _testService.Update(test);
            return Ok();
        }
        /*[HttpPost("update_2")]
        public async Task<IActionResult> UpdateTestBy10Percent()
        {
            await _testService.UpdatePricesBy10Percent();

            return Ok();
        } */

        [HttpDelete("delete/${id}")]
        public IActionResult DeleteTest(Guid id)
        {
            _testService.Delete(id);
            return Ok();
        }
    }
}