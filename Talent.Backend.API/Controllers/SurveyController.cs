using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Talent.Backend.API.Extensions;
using Talent.Backend.Service.Contracts;
using Talent.Backend.Service.Dtos;

namespace Talent.Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _surveyService;
        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<SurveyDto>> Index([FromQuery]  PaginationDto paginationDto)
        {
            var surveys = await _surveyService.GetAllAsync(paginationDto);
            var queryable = surveys.AsQueryable();
            HttpContext.ParameterPagination(queryable);
            return Ok(queryable);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] SurveyDto SurveyDto)
        {
            var survey = await _surveyService.CreateAsync(SurveyDto);

            return Ok(survey);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetSurvey(int id)
        {
            var survey = await _surveyService.GetAsync(id);

            return Ok(survey);
        }
    }
}
