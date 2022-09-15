using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnglishTeacher.Api.Controllers
{
    [Route("api/words")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        public WordsController()
        {

        }
        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<List<WordDto>>> GetList()
        {
            await Task.FromResult(Task.CompletedTask);
            return new List<WordDto>();
        }

        [HttpGet]
        [Route("random")]
        public async Task<ActionResult<WordDto>> GetWord()
        {
            await Task.FromResult(Task.CompletedTask);
            return new WordDto();
        }

        [HttpGet]
        [Route("/{id}")]
        public async Task<ActionResult<WordDto>> GetWord(Guid id)
        {
            await Task.FromResult(Task.CompletedTask);
            return new WordDto();
        }

        [HttpPost]
        public async Task<ActionResult<WordDto>> AddWord()
        {
            await Task.FromResult(Task.CompletedTask);
            return new WordDto();
        }
    }
}
