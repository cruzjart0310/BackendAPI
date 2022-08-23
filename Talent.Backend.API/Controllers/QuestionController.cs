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
    public class QuestionController : ControllerBase
    {
        private readonly IUriService _uriService;
        private readonly IManageAzureStorage _manageAzureStorage;
        private readonly IQuestionService _questionService;
        private readonly string container = "talent";

        public QuestionController(IQuestionService questionService, IUriService uriService, IManageAzureStorage manageAzureStorage)
        {
            _questionService = questionService;
            _uriService = uriService;
            _manageAzureStorage = manageAzureStorage;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<QuestionDto>> Index([FromQuery] PaginationDto paginationDto)
        {
            var route = Request.Path.Value;
            var questions = await _questionService.GetAllAsync(paginationDto);
            var totalRecorsd = await _questionService.GetTotalRecorsdAsync();
            var response = PaginationHelper.CreateResponse<QuestionDto>(questions.AsQueryable(), paginationDto, totalRecorsd, _uriService, route);
            return Ok(response);

        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("UploadFile")]
        public async Task<ActionResult> UploadFile([FromForm] IFormFile file)
        {
            if (file == null)
            {
                return BadRequest();
            }

            await _questionService.SaveDataFromFile(file);
            await _manageAzureStorage.SaveFile(container, file);

            return Ok();
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

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion(int id, QuestionDto questionDto)
        {
            bool exist = await _questionService.ExistAsync(id);
            if (!exist)
                return NotFound();

            await _questionService
                .UpdateAsync(questionDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            bool exist = await _questionService.ExistAsync(id);
            if (!exist)
                return NotFound();

            await _questionService.DeleteAsync(id);
            return NoContent();
        }
    }
}
