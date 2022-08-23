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
    public class UserAnswersController : ControllerBase
    {
        private readonly IUserAnswerService _userAnswerService;
        private readonly IUserService _userService;
        private readonly IUriService _uriService;
        public UserAnswersController(IUserAnswerService userAnswerService, IUserService userService, IUriService uriService)
        {
            _userAnswerService = userAnswerService;
            _userService = userService;
            _uriService = uriService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<UserAnswerDto>> Index([FromQuery] PaginationDto paginationDto)
        {
            var route = Request.Path.Value;
            var userAnswer = await _userAnswerService.GetAllAsync(paginationDto);
            var totalRecorsd = await _userAnswerService.GetTotalRecorsdAsync();
            var response = PaginationHelper.CreateResponse<UserAnswerDto>(userAnswer.AsQueryable(), paginationDto, totalRecorsd, _uriService, route);
            return Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("{id}/answer")]
        public async Task<ActionResult> Create([FromBody] UserAnswerDto userAnswerDto)
        {
            var userAnswers = await _userAnswerService.CreateAsync(userAnswerDto);

            return Ok(new ResponseDto<UserAnswerDto>(userAnswers));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{userId}/survey/{surveyId}")]
        public async Task<ActionResult> GetPoints(string userId, int surveyId)
        {
            var data = await _userAnswerService.GetPointsAsync(userId, surveyId);

            return Ok(data);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetSurvey(int id)
        {
            bool exist = await _userAnswerService.ExistAsync(id);
            if (!exist)
                return NotFound();

            var userAnswers = await _userAnswerService.GetAsync(id);

            return Ok(new ResponseDto<UserAnswerDto>(userAnswers));
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSurvey(int id, UserAnswerDto surveyDto)
        {
            bool exist = await _userAnswerService.ExistAsync(id);
            if (!exist)
                return NotFound();

            await _userAnswerService
                .UpdateAsync(surveyDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurvey(int id)
        {
            bool exist = await _userAnswerService.ExistAsync(id);
            if (!exist)
                return NotFound();

            await _userAnswerService.DeleteAsync(id);
            return NoContent();
        }
    }
}
