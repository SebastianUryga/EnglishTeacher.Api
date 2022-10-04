using EnglishTeacher.Application.Words.Command.CreateWord;
using EnglishTeacher.Application.Words.Command.DeleteWord;
using EnglishTeacher.Application.Words.Query.GetWordDetail;
using EnglishTeacher.Application.Words.Query.GetWords;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnglishTeacher.Api.Controllers
{
    [Route("api/words")]
    [Authorize]
    public class WordsController : BaseController
    {
        public WordsController()
        {

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("list")]
        public async Task<ActionResult<WordsVm>> GetList()
        {
            var vm = await Mediator.Send(new GetWordsQuery());
            return vm;
        }

        [HttpGet]
        [Route("random")]
        public async Task<ActionResult<WordDto>> GetWord()
        {
            await Task.FromResult(Task.CompletedTask);
            return new WordDto();
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        [HttpDelete]
        public async Task<IActionResult> DeleteWord(int id)
        {
            var resut = await Mediator.Send(new DeleteWordCommand() { WordId = id });
            return Ok(resut);
        }
    }
}
