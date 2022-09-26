using EnglishTeacher.Application.Words.Command.CreateWord;
using EnglishTeacher.Application.Words.Query.GetWordDetail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnglishTeacher.Api.Controllers
{
    [Route("api/words")]
    public class WordsController : BaseController
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
        [Route("{id}")]
        public async Task<ActionResult<WordDetialVm>> GetWord(int id)
        {
            var vm = await Mediator.Send(new GetWordDetailQuery() { WordId = id });
            return vm;
        }

        [HttpPost]
        public async Task<IActionResult> AddWord(CreateWordCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
