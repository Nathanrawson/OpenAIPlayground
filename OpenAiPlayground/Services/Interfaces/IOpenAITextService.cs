using OpenAiPlayground.Services.ServiceModels.OpenAI;

namespace OpenAiPlayground.Services.Interfaces
{
    public interface IOpenAITextService
    {
        Task<CompletionResponse> CompletePrompt(CompletionRequest request);
    }
}
