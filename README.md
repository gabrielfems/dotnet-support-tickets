# dotnet-support-tickets

![.NET](https://img.shields.io/badge/.NET-10-purple)
![C#](https://img.shields.io/badge/C%23-13-blue)
![SQLite](https://img.shields.io/badge/SQLite-gray)
![EF Core](https://img.shields.io/badge/EF_Core-9-darkgreen)
![Swagger](https://img.shields.io/badge/Docs-Swagger-green)

API REST para gestão de tickets de suporte desenvolvida em C# com .NET Minimal API, Entity Framework Core e SQLite.

## Sobre

dotnet-support-tickets é uma aplicação backend construída com .NET Minimal API que permite criar, listar, atualizar e fechar tickets de suporte. Os tickets possuem prioridade e status, e o encerramento é feito via soft delete — o ticket é marcado como `Closed` e removido das listagens sem ser excluído do banco.

## Tecnologias

- .NET 10
- C# 13
- Entity Framework Core 9
- SQLite
- Swashbuckle (Swagger UI)

## Funcionalidades

- Criação de tickets com título, descrição e prioridade
- Listagem de tickets ativos (excluindo os fechados)
- Busca de ticket por ID
- Atualização de título, descrição e prioridade
- Encerramento de ticket via soft delete (status `Closed`)
- Enums persistidos como string no banco
- Documentação interativa via Swagger UI

## Endpoints

### Tickets

| Método | Rota | Descrição |
|--------|------|-----------|
| POST | `/ticket` | Cria um novo ticket |
| GET | `/ticket` | Lista todos os tickets ativos |
| GET | `/ticket/{id}` | Busca ticket por ID |
| PUT | `/ticket/{id}` | Atualiza um ticket |
| DELETE | `/ticket/{id}` | Encerra um ticket (soft delete) |

## Estrutura do Projeto

```
Person/
├── Data/
│   └── TicketContext.cs
├── Migrations/
├── Models/
│   ├── Ticket.cs
│   ├── TicketRequest.cs
│   ├── TicketResponse.cs
│   ├── Priority.cs
│   └── Status.cs
├── Routes/
│   └── TicketRoute.cs
├── Services/
│   └── TicketService.cs
└── Program.cs
```

## Como Rodar

### Pré-requisitos

- .NET 10 SDK

### Passos

```bash
# 1. Clone o repositório
git clone https://github.com/gabrielfems/dotnet-support-tickets.git
cd dotnet-support-tickets

# 2. Aplique as migrations
dotnet ef database update

# 3. Rode a aplicação
dotnet run
```

A API estará disponível em `http://localhost:5080`.

## Documentação da API

Documentação interativa disponível via Swagger UI em `http://localhost:5080/swagger` com a aplicação em execução.

## Exemplo de Request

```json
POST /ticket
{
  "title": "Bug no login",
  "description": "Usuário não consegue autenticar com Google",
  "priority": "High"
}
```

## Arquitetura

```
Request → Route → Service → Repository (EF Core) → SQLite
```

O soft delete é aplicado na camada de serviço — ao chamar `DELETE /ticket/{id}`, o ticket tem seu status alterado para `Closed` e deixa de aparecer nas listagens sem ser removido do banco de dados.
