using Microsoft.AspNetCore.Mvc;
using Gemini_Entegre.Services;

namespace Gemini_Entegre.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeminiController : ControllerBase
    {
        private readonly GeminiService _geminiService;

        public GeminiController(GeminiService geminiService)
        {
            _geminiService = geminiService;
        }

        [HttpPost("generate")]
        public async Task<IActionResult> GenerateContent([FromBody] PromptRequest request)
        {
            var response = await _geminiService.GenerateContentAsync(request.Prompt);
            return Ok(new { response });
        }
    }

    public class PromptRequest
    {
        public string Prompt { get; set; } = string.Empty;
    }
} 