# FSBR_Processos
# Documentação do Desafio: Cadastro de Processos

## Descrição do Desafio

Este projeto implementa uma aplicação web para cadastro, listagem, edição, exclusão e visualização de processos, integrando com a API do IBGE para informações de municípios. A aplicação foi desenvolvida em C# utilizando .NET 8, Entity Framework, e MVC, seguindo os critérios de aceite definidos no desafio original.

## Critérios de Aceite

* Implementação completa do CRUD de processos.
* Validação do formato do NPU.
* Integração com a API do IBGE para obtenção de municípios.
* Paginação na listagem de processos.
* Registro da data e hora de visualização do processo.
* Persistência dos dados em um banco de dados SQL.

## Premissas Assumidas

* O usuário possui conhecimento básico de .NET, Entity Framework e SQL Server.
* A aplicação não requer autenticação.
* A responsabilidade pela criação do banco de dados e execução das migrations é do usuário.

## Instruções de Instalação

### Banco de Dados

1. Instale o SQL Server (versão compatível com .NET 8).
2. Crie um novo banco de dados.
3. Execute os scripts SQL fornecidos na pasta `scripts` do repositório para criar as tabelas.
4. Configure a string de conexão no arquivo `appsettings.json` com as informações do seu banco de dados. Exemplo:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=SeuNomeDoBancoDeDados;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}

```

### Aplicação

1.  Clone o repositório: `git clone https://github.com/WeslleyPAndrade/FSBR_Processos`
2.  Navegue até o diretório do projeto no terminal.
3.  Execute o comando: `dotnet restore` para instalar as dependências.
4.  Execute o comando: `dotnet ef database update` para aplicar as migrations.
5.  Execute o comando: `dotnet run` para iniciar a aplicação.

## Considerações

Desenvolver este projeto foi uma experiência enriquecedora. A estrutura do projeto foi cuidadosamente planejada, seguindo as melhores práticas do MVC para garantir organização e manutenibilidade. A estrutura de pastas e arquivos foi escolhida para facilitar a navegação e o entendimento do código, mesmo para projetos simples. A implementação buscou atender a todos os critérios de aceite, com foco na clareza e eficiência do código.

## Possíveis Erros

-   **Erro ao executar `update-database`:** Certifique-se de ter o Entity Framework Core Tools instalado globalmente. Instale-o usando o comando: `dotnet tool install --global dotnet-ef`. Verifique também se a string de conexão no arquivo `appsettings.json` está correta.
-   **Erros de compilação:** Certifique-se de ter o .NET 8 SDK instalado e que a versão do SQL Server é compatível.
-   **Erros de conexão com o banco de dados:** Verifique se o SQL Server está em execução e se as credenciais na string de conexão estão corretas. Verifique também se as portas necessárias estão abertas no firewall.