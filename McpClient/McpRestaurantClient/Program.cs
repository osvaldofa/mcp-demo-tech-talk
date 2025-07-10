using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using ModelContextProtocol.Client;
using FoodServices;
using Microsoft.SemanticKernel.Agents;

#pragma warning disable SKEXP0001
#pragma warning disable SKEXP0110

// Carrega as configurações do arquivo appsettings.json
var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

// Cria um Kernel builder e conecta ao Azure OpenAI
var builder = Kernel.CreateBuilder();
builder.AddAzureOpenAIChatCompletion(
    deploymentName: config["DEPLOYMENT_MODEL"],
    endpoint: config["AZURE_ENDPOINT"],
    apiKey: config["AZURE_AI_API_KEY"]);

Kernel kernel = builder.Build();
Console.WriteLine("---> Kernel created and connected to Azure OpenAI.");

// Cria um MCP Client
string projectPath = "C:\\Desenvolvimento\\Pessoais\\mcp-demo\\McpFoodServer\\McpFoodServer.Api";

await using IMcpClient mcpClient = await McpClientFactory.CreateAsync(new StdioClientTransport(new()
{
    Name = "McpRestaurantClient",
    Command = "dotnet",
    Arguments = ["run", "--project", projectPath],
}));
var tools = await mcpClient.ListToolsAsync().ConfigureAwait(false);
kernel.Plugins.AddFromFunctions("FoodServicePlugin", tools.Select(aiFunction => aiFunction.AsKernelFunction()));

Console.WriteLine("---> Tools loaded into the kernel.");

var foodAgent = FoodServiceAgent.CreateFoodAgent(kernel);

Console.WriteLine("---> Food Service Agent created with instructions and tools.");

AgentGroupChat chatService = new(foodAgent);

Console.WriteLine("---> Food Service Agent created. You can now start chatting with the agent.");

var originalForegroundColor = Console.ForegroundColor;

while (true)
{
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.Write("Prompt: ");

    chatService.AddChatMessage(
        new ChatMessageContent(
            role: AuthorRole.User,
            content: Console.ReadLine()
        ));

    Console.ForegroundColor = originalForegroundColor;
    var fullMessageBuilder = new System.Text.StringBuilder();
    await foreach (var content in chatService.InvokeAsync())
    {
        fullMessageBuilder.Append(content);
    }
    Console.WriteLine("Response: " + fullMessageBuilder.ToString());
    Console.WriteLine();
}