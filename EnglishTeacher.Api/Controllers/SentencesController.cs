using EnglishTeacher.Application.Sentences.Command.AddSentence;
using EnglishTeacher.Application.Sentences.Command.DeleteSentences;
using EnglishTeacher.Application.Sentences.Query.GetSentenceDetail;
using EnglishTeacher.Application.Sentences.Query.GetSentenceExamples;
using EnglishTeacher.Application.Sentences.Query.GetSentences;
using EnglishTeacher.Application.Words.Command.DeleteWord;
using EnglishTeacher.Application.Words.Command.GiveAnswer;
using EnglishTeacher.Application.Words.Command.UpdateWord;
using EnglishTeacher.Application.Words.Query.GetWordDetail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EnglishTeacher.Api.Controllers
{
    [Route("api/sentences")]
    [Authorize]
    public class SentencesController : BaseController
    {
        public SentencesController()
        {

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("list")]
        public async Task<ActionResult<SentencesVm>> GetList()
        {
            var vm = await Mediator.Send(new GetSentencesQuery());
            return vm;
        }

        [HttpGet]
        [Route("examples/{word}")]
        public async Task<ActionResult<string[]>> GetExamples(string word)
        {
            var vm = await Mediator.Send(new GetSentenceExamplesQuery() { Word = word});
            return vm;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("{id}")]
        public async Task<ActionResult<SentenceDetailVm>> GetSentence(int id)
        {
            var vm = await Mediator.Send(new GetSentenceDetailQuery(){ Id = id });
            return vm;
        }

        [HttpPost]
        public async Task<IActionResult> AddSentence(AddSentenceCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSentences(int id)
        {
            var result = await Mediator.Send(new DeleteSentencesCommand(){SentenceId = id});

            return Ok(result);
        }
    }
}
