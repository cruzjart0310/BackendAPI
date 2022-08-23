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
    public class QuestionTypeController : ControllerBase
    {
        private readonly IQuestionTypeService _questionTypeService;
        public QuestionTypeController(IQuestionTypeService questionTypeService)
        {
            _questionTypeService = questionTypeService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<QuestionTypeDto>> Index([FromQuery] PaginationDto paginationDto)
        {
            var types = await _questionTypeService.GetAllAsync(paginationDto);
            var queryable = types.AsQueryable();
            HttpContext.ParameterPagination(queryable);
            return Ok(queryable);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] QuestionTypeDto questionTypeDto)
        {
            var types = await _questionTypeService.CreateAsync(questionTypeDto);

            return Ok(types);
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSurvey(int id, QuestionTypeDto questionTypeDto)
        {
            bool exist = await _questionTypeService.ExistAsync(id);
            if (!exist)
                return NotFound();

            await _questionTypeService
                .UpdateAsync(questionTypeDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurvey(int id)
        {
            bool exist = await _questionTypeService.ExistAsync(id);
            if (!exist)
                return NotFound();

            await _questionTypeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
