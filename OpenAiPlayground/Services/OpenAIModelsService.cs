using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using OpenAiPlayground.Services;

public class OpenAIModelsService : BaseOpenAIService
{
    private readonly HttpClient _httpClient;

    public OpenAIModelsService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<OpenAIModelsResponse> GetModels()
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

        var response = await _httpClient.GetAsync("https://api.openai.com/v1/models");
        var responseContent = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<OpenAIModelsResponse>(responseContent);
    }
}

public class OpenAIModelsResponse
{
    public class Model
    {
        public string Id { get; set; }
        public string Object { get; set; }
        public string OwnedBy { get; set; }
        public object[] Permission { get; set; }
    }

    public Model[] Data { get; set; }
    public object Object { get; set; }
}