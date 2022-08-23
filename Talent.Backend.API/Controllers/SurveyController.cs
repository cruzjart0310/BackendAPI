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
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _surveyService;
        private readonly IUriService _uriService;
        public SurveyController(ISurveyService surveyService, IUriService uriService)
        {
            _surveyService = surveyService;
            _uriService = uriService;
        }

        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] PaginationDto paginationDto)
        {
            var route = Request?.Path.Value; //Todo: Verify in unit test remove ?
            var survey = await _surveyService.GetAllAsync(paginationDto);
            var totalRecorsd = await _surveyService.GetTotalRecorsdAsync();
            var response = PaginationHelper.CreateResponse<SurveyDto>(survey.AsQueryable(), paginationDto, totalRecorsd, _uriService, route);
            return Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status201Created)] //, Type = typeof(SurveyDto)
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SurveyDto SurveyDto)
        {
            var survey = await _surveyService.CreateAsync(SurveyDto);

            return Ok(survey);
        }

        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSurvey(int id)
        {
            bool exist = await _surveyService.ExistAsync(id);
            if (!exist)
                return NotFound();

            var survey = await _surveyService.GetAsync(id);

            return Ok(new ResponseDto<SurveyDto>(survey));
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSurvey(int id, SurveyDto surveyDto)
        {
            bool exist = await _surveyService.ExistAsync(id);
            if (!exist)
                return NotFound();

            await _surveyService
                .UpdateAsync(surveyDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurvey(int id)
        {
            bool exist = await _surveyService.ExistAsync(id);
            if (!exist)
                return NotFound();

            await _surveyService.DeleteAsync(id);
            return NoContent();
        }
    }
}
