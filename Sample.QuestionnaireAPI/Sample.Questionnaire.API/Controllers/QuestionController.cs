using Microsoft.AspNetCore.Mvc;
using Sample.Questionnaire.Bll.Services.Interfaces;
using Sample.Questionnaire.Common.RequestModels;

namespace Sample.Questionnaire.API.Controllers;

[ApiController]
[Route("api/questions")]
public class QuestionController(IQuestionService questionService) : ControllerBase
{
    private readonly IQuestionService questionService = questionService;

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromQuery] int? userId, long id)
    {
        var question = await questionService.GetByIdAsync(userId, id);

        if (question is null)
        {
            return NotFound();
        }

        return Ok(question);
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] int? userId, [FromQuery] GetQuestionsByQuery query)
    {
        return Ok(await questionService.GetByAsync(userId, query));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] QuestionRequestModel model)
    {
        await questionService.CreateAsync(model);

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(long id, [FromBody] QuestionRequestModel model)
    {
        await questionService.UpdateAsync(id, model);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await questionService.DeleteAsync(id);

        return NoContent();
    }
}
