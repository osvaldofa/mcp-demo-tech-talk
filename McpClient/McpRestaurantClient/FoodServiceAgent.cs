using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Agents;
using Microsoft.SemanticKernel.Connectors.AzureOpenAI;

#pragma warning disable SKEXP0001

namespace FoodServices
{ 
    public class FoodServiceAgent
{
    private FoodServiceAgent() { }
    public static ChatCompletionAgent CreateFoodAgent(Kernel kernel)
    {
        string instrucoes = "Você é um agente de serviço de alimentação. Você pode ajudar os clientes a buscarem informações sobre os restaurantes disponíveis, o cardápio com os pratos, seus ingredieintes e preços, e também a fazer pedidos de comida. " +
        "Você pode usar ferramentas para buscar informações adicionais se necessário. Caso sejam feitas perguntas fora desse contexto, responda cordialmente que você não pode ajudar com isso. Sempre que for fazer um pedido novo, peça o nome do cliente para constar na solicitação de criação do pedido.";

        return new()
        {
            Instructions = instrucoes,
            Name = "FoodAgent",
            Kernel = kernel,
            Arguments = new KernelArguments(
                new AzureOpenAIPromptExecutionSettings()
                {
                    FunctionChoiceBehavior = FunctionChoiceBehavior.Auto(options: new() { RetainArgumentTypes = true })
                }
            )
        };

    }
}
}