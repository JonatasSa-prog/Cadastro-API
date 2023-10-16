# Projeto API de Gerenciamento de Pessoas

Este é um projeto de API em C# que permite realizar operações básicas de gerenciamento de pessoas, incluindo GET, PUT e DELETE. Você pode usá esta API para criar, atualizar e excluir registros de pessoas em um banco de dados.

## Requisitos

Antes de iniciar o projeto, certifique-se de ter os seguintes requisitos instalados:

- [Visual Studio](https://visualstudio.microsoft.com/) ou [Visual Studio Code](https://code.visualstudio.com/) (ou qualquer ambiente de desenvolvimento C# de sua preferência)
- [ASP.NET Core SDK](https://dotnet.microsoft.com/download)
- [Banco de Dados SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

## Configuração

1. Clone o repositório:

```bash
git clone https://github.com/JonatasSa-prog/Cadastro-API.git
```

2. Abra o projeto em seu ambiente de desenvolvimento (Visual Studio ou Visual Studio Code).

3. Configure a string de conexão do banco de dados em `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "SuaStringDeConexao"
  }
}
```

4. Abra o Console do Gerenciador de Pacotes (Package Manager Console) no Visual Studio ou o terminal na raiz do projeto no Visual Studio Code e execute as migrações para criar o banco de dados:

```bash
dotnet ef database update
```

5. Inicie a aplicação:

```bash
dotnet run
```

A API estará disponível em `https://localhost:5001`.

## Endpoints

- `GET v1/person`: Retorna a lista de todas as pessoas no banco de dados.
- `GET v1/person/id/{id}`: Retorna os detalhes de uma pessoa específica pelo ID.
- `GET v1/person/name/{name}`: Retorna os detalhes de uma pessoa específica pelo Nome.
- `PUT v1/person/{id}`: Atualiza os detalhes de uma pessoa específica pelo ID.
- `PUT v1/person/activate/{id}`: Atualiza o status para ativo de uma pessoa específica pelo ID.
- `PUT v1/person/inactivate/{id}`: Atualiza o status para inativo de uma pessoa específica pelo ID.
- `DELETE v1/person/{id}`: Exclui uma pessoa específica pelo ID.

## Exemplo de Requisições

### GET /v1/person

Retorna a lista de todas as pessoas:

```http
GET https://localhost:5001/v1/person
```

### GET /v1/person/{id}

Retorna os detalhes de uma pessoa pelo ID:

```http
GET https://localhost:5001/v1/person/1
```

### PUT /v1/person/{id}

Atualiza os detalhes de uma pessoa pelo ID:

```http
PUT https://localhost:5001/v1/person/1

{
  "name": "Novo Nome",
  "sex": "M"
}
```

### DELETE /v1/person/{id}

Exclui uma pessoa pelo ID:

```http
DELETE https://localhost:5001/v1/person/1
```

## Contribuindo

Fique à vontade para contribuir para este projeto. Abra um problema (issue) ou envie uma solicitação de pull (pull request) com melhorias e correções.

---
