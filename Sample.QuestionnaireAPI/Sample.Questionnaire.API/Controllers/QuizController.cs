using Microsoft.AspNetCore.Mvc;
using Sample.Questionnaire.Bll.Services.Interfaces;
using Sample.Questionnaire.Common.RequestModels;

namespace Sample.Questionnaire.API.Controllers;

[ApiController]
[Route("api/quizzes")]
public class QuizController(IQuizService quizService) : ControllerBase
{
    private readonly IQuizService quizService = quizService;

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromQuery] int? userId, long id)
    {
        var quiz = await quizService.GetByIdAsync(userId, id);

        if (quiz is null)
        {
            return NotFound();
        }

        return Ok(quiz);
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] int? userId, [FromQuery] GetQuizzesByQuery query)
    {
        return Ok(await quizService.GetByAsync(userId, query));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] QuizRequestModel model)
    {
        await quizService.CreateAsync(model);

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromBody] QuizRequestModel model)
    {
        await quizService.UpdateAsync(model);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await quizService.DeleteAsync(id);

        return NoContent();
    }
}
