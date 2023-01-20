using Microsoft.AspNetCore.Mvc;
using OpenAiPlayground.Services.Interfaces;
using OpenAiPlayground.Services.ServiceModels.OpenAI;

namespace OpenAiPlayground.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenAIController : ControllerBase
    {
        private readonly IOpenAITextService _openAIService;

        public OpenAIController(IOpenAITextService openAIService)
        {
            _openAIService = openAIService;
        }

        [HttpPost]
        public async Task<IActionResult> CompletePrompt([FromBody] CompletionRequest request)
        {
            var response = await _openAIService.CompletePrompt(request);

            if (response == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("spanish")]
        public async Task<IActionResult> ReturnSpanish([FromBody] string text)
        {
            var request = new CompletionRequest
            {
                Model = "text-davinci-003",
                Temperature = 0.7,
                Prompt = $"Return this text in spanish. Text: {text}",
                MaxTokens = 600
            };
            var response = await _openAIService.CompletePrompt(request);
            
            if (response == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(response);
        }
    }
}