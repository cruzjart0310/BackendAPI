using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talent.Backend.API.Extensions;
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

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<SurveyDto>> Index([FromQuery]  PaginationDto paginationDto)
        {
            var route = Request.Path.Value;
            var survey = await _surveyService.GetAllAsync(paginationDto);
            var totalRecorsd = await _surveyService.GetTotalRecorsdAsync();
            var response = PaginationHelper.CreateResponse<SurveyDto>(survey.AsQueryable(), paginationDto, totalRecorsd, _uriService, route);
            return Ok(response);
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
        public async Task<ActionResult> GetSurvey(string id)
        {
            var survey = await _surveyService.GetAsync(id);

            if (survey == null) 
                return NotFound();

            return Ok(survey);
        }
    }
}
