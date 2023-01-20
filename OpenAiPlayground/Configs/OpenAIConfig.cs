﻿namespace OpenAiPlayground.Configs
{
    public static class OpenAIConfig
    {
        public static string AuthSecret = Environment.GetEnvironmentVariable("openAiSecret") ?? throw new NullReferenceException(nameof(AuthSecret));
        public static string BaseAddress = "https://api.openai.com/v1/";
    }
}
