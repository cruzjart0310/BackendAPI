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
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<QuestionDto>> Index([FromQuery]  PaginationDto paginationDto)
        {
            var Questions = await _questionService.GetAllAsync(paginationDto);
            var queryable = Questions.AsQueryable();
            HttpContext.ParameterPagination(queryable);
            return Ok(queryable);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] QuestionDto QuestionDto)
        {
            var Question = await _questionService.CreateAsync(QuestionDto);

            return Ok(Question);
        }
    }
}
