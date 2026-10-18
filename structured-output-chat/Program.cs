using Azure.AI.OpenAI;
using Azure.Identity;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;

string review = "I'm happy with the product!";

IConfigurationRoot config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

string endpoint = config["AZURE_OPENAI_ENDPOINT"];
string tenantId = config["AZURE_TENANT_ID"];
string model = "gpt-5";

//endpoint = "https://openaiplayground1.openai.azure.com/";

DefaultAzureCredential credential =
    new DefaultAzureCredential(
    new DefaultAzureCredentialOptions()
    {
        TenantId = tenantId
    });

AzureOpenAIClient azureClient = new(new Uri(endpoint), credential);

IChatClient chatClient = azureClient
    .GetChatClient(deploymentName: model)
    .AsIChatClient();

var response = await chatClient.GetResponseAsync<Sentiment>($"What's the sentiment of this review? {review}");
Console.WriteLine($"Sentiment: {response.Result}");

string[] inputs = [
    "Best purchase ever!",
    "Returned it immediately.",
    "Hello",
    "It works as advertised.",
    "The packaging was damaged but otherwise okay."
];

foreach (var i in inputs)
{
    var response2 = await chatClient.GetResponseAsync<Sentiment>($"What's the sentiment of this review? {i}");
    Console.WriteLine($"Review: {i} | Sentiment: {response2.Result}");
}

var review3 = "This product worked okay.";
var response3 = await chatClient.GetResponseAsync<SentimentRecord>($"What's the sentiment of this review? {review3}");

Console.WriteLine($"Response text: {response3.Result.ResponseText}");
Console.WriteLine($"Sentiment: {response3.Result.ReviewSentiment}");

Console.ReadKey();

public enum Sentiment
{
    Positive,
    Negative,
    Neutral
};

record SentimentRecord(string ResponseText, Sentiment ReviewSentiment);