using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Talent.Backend.API.Helpers;
using Talent.Backend.Service.Contracts;
using Talent.Backend.Service.Dtos;

namespace Talent.Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IUriService _uriService;
        private readonly IAnswerService _answerService;

        public AnswerController(IAnswerService answerService, IUriService uriService)
        {
            _answerService = answerService;
            _uriService = uriService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<AnswerDto>> Index([FromQuery] PaginationDto paginationDto)
        {
            var route = Request.Path.Value;
            var answers = await _answerService.GetAllAsync(paginationDto);
            var totalRecorsd = await _answerService.GetTotalRecorsdAsync();
            var response = PaginationHelper.CreateResponse<AnswerDto>(answers.AsQueryable(), paginationDto, totalRecorsd, _uriService, route);
            return Ok(response);

        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] AnswerDto answerDto)
        {
            var answers = await _answerService.CreateAsync(answerDto);

            return Ok(answers);
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSurvey(int id, AnswerDto answerDto)
        {
            bool exist = await _answerService.ExistAsync(id);
            if (!exist)
                return NotFound();

            await _answerService
                .UpdateAsync(answerDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurvey(int id)
        {
            bool exist = await _answerService.ExistAsync(id);
            if (!exist)
                return NotFound();

            await _answerService.DeleteAsync(id);
            return NoContent();
        }
    }
}
