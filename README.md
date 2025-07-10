# MCP Demo Tech Talk

Uma demonstração prática do Model Context Protocol (MCP) para apresentação técnica.

## 🎯 Sobre o Projeto

Este repositório contém uma demonstração do Model Context Protocol (MCP), apresentando suas principais funcionalidades e casos de uso através de exemplos práticos desenvolvidos para uma tech talk.

## 🚀 Tecnologias Utilizadas

- **MCP (Model Context Protocol)**: Protocol para comunicação entre modelos de IA e aplicações
- **OpenAI GPT 3.5 Turbo**: Modelo de linguagem para processamento de chat
- **C#**: Linguagem principal para o DemoService
- **.NET**: Framework para desenvolvimento do sistema de restaurantes
- **REST API**: Comunicação entre MCP Server e App Consultor de Restaurantes
- **Node.js/TypeScript**: Para a execução do Inspector para testes com o MCP Server

## 📋 Pré-requisitos

Antes de executar o projeto, certifique-se de ter instalado:

- **.NET SDK** (versão 6.0 ou superior)
- **Node.js** (versão 16 ou superior)
- **Chave da API OpenAI** (para GPT 3.5 Turbo)
- **Visual Studio** ou **VS Code** (recomendado)
- **npm** ou **yarn**

## 🛠️ Instalação e Execução

```bash
# Clone o repositório
git clone https://github.com/osvaldofa/mcp-demo-tech-talk.git

# Navegue até o diretório
cd mcp-demo-tech-talk

# 1. Execute o DemoService (App Consultor de Restaurantes)
cd DemoService
dotnet restore
dotnet run

# 2. Em outro terminal, execute o Chat Consultor (McpClient)
cd ../McpClient
# Configure sua chave OpenAI no arquivo de configuração
dotnet run

# 3. CASO QUEIRA TESTAR O MCP SERVER SEPARADAMENTE - Em outro terminal, execute o MCP Server
cd ../McpServer
npm install @modelcontextprotocol/inspector
npx @modelcontextprotocol/inspector dotnet run


```

## ⚙️ Configuração

1. **Chave OpenAI**: Configure sua chave da API OpenAI para o GPT 3.5 Turbo no McpClient
2. **Endpoints**: Certifique-se de que o MCP Server consegue acessar as APIs REST do DemoService
3. **Protocolo MCP**: Verifique se o Chat Consultor conecta corretamente com o MCP Server

## 📁 Estrutura do Projeto

```
mcp-demo-tech-talk/
├── DemoService/                          # App Consultor de Restaurantes - APIs REST (C#)
├── McpFoodServer/McpFoodServer.Api       # MCP Server - Bridge entre chat e sistema de restaurantes
├── McpClient/                            # Chat Consultor do App de Comida - Interface + GPT 3.5 Turbo
├── .gitignore
└── README.md
```

## 🔧 Arquitetura e Funcionalidades

### 🏗️ Arquitetura do Sistema

```
👤 Usuário → [Chat] → Chat Consultor do App de Comida → [MCP] → MCP Server → [REST] → App Consultor de Restaurantes
                                      ↓
                                LLM (GPT 3.5 Turbo)
```

**Fluxo de Comunicação:**
1. **Usuário** interage via chat natural
2. **Chat Consultor** processa a mensagem e integra com LLM (GPT 3.5 Turbo)
3. **MCP Server** recebe solicitações via protocolo MCP
4. **App Consultor de Restaurantes** executa operações via APIs REST

### 📋 Funcionalidades por Componente

**McpClient - Chat Consultor do App de Comida**
- Interface de chat para interação com usuário
- Integração com LLM (GPT 3.5 Turbo) da OpenAI
- Processamento de linguagem natural para pedidos de comida
- Experiência conversacional intuitiva

**McpServer - MCP Server**
- Bridge entre o chat e o sistema de restaurantes
- Implementa protocolo MCP para comunicação
- Gerencia tools disponíveis para o agente de IA
- Traduz solicitações do chat para chamadas REST

**DemoService - App Consultor de Restaurantes**
- Sistema mock de gestão de restaurantes (estilo iFood)
- APIs RESTful para operações do sistema
- Funcionalidades disponíveis:
  - Buscar por lista de restaurantes, incluindo tipo de comida (ex: japonês, italiano, etc)
  - Buscar pelo menu de um restaurante, incluindo ingredientes de cada prato
  - Fazer um pedido de uma lista de pratos no restaurante

## 📖 Documentação

Para mais informações sobre o Model Context Protocol, consulte:

- [Documentação oficial do MCP](https://docs.anthropic.com/claude/docs/mcp)
- [Especificação técnica](https://spec.modelcontextprotocol.io/)
- [OpenAI API Documentation](https://platform.openai.com/docs)

## 🎤 Apresentação

Esta demonstração foi criada para a tech talk sobre MCP. Os slides e materiais complementares estão disponíveis em:

- [Link para slides] (se aplicável)
- [Vídeo da apresentação] (se aplicável)

## 🤝 Contribuindo

Contribuições são bem-vindas! Para contribuir:

1. Faça um fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/nova-feature`)
3. Commit suas mudanças (`git commit -m 'Adiciona nova feature'`)
4. Push para a branch (`git push origin feature/nova-feature`)
5. Abra um Pull Request

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

## 👤 Autor

**Osvaldo**

- GitHub: [@osvaldofa](https://github.com/osvaldofa)
- [Adicione outros contatos se desejar]

## 📞 Contato

Se você tiver alguma dúvida ou sugestão, sinta-se à vontade para abrir uma issue ou entrar em contato.

---

⭐ Se este projeto te ajudou, considere dar uma estrela!
