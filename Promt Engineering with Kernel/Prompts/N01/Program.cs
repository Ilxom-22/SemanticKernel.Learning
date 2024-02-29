using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;

// Create configurations
var configurationBuilder = new ConfigurationBuilder();
configurationBuilder.AddUserSecrets<Program>();
var configuration = configurationBuilder.Build();

// Create kernel builder
var kernelBuilder = Kernel.CreateBuilder();


Console.WriteLine(configuration["Hello:Hi"]!);



// Add OpenAI connector
kernelBuilder.AddOpenAIChatCompletion(modelId: "gpt-3.5 turbo", apiKey: configuration["OpenAiApiSettings:ApiKey"]!);

// Build kernel
var kernel = kernelBuilder.Build();

// Create simple prompt
Console.Write("Your request: ");
var request = Console.ReadLine();
var prompt = $"What is the intent of this request? {request}";

// Display request intent
Console.WriteLine(await kernel.InvokePromptAsync(prompt));