using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;

namespace EnglishTeacher.Api.Controllers
{
    /// <summary>
    /// Descripion of HelthChecksController
    /// </summary>
    [Route("api/hc")]
    [ApiController]
    [EnableCors("myPolicy")]
    public class HealthChecksController : ControllerBase
    {
        /// <summary>
        /// Descripion of endpoint
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<string>> GetAsync()
        {
            await Task.CompletedTask;
            return "Healthy";
        }
    }
}
