# CP2 - API RESTful com ASP.NET Core

> **Checkpoint 2 — FIAP**
>
> **Aluno:** Gustavo Gomes Martins
> **RM:** 555999
> **Turma:** 2TDSPO

---

## 📋 Descrição do Projeto

API RESTful desenvolvida em **ASP.NET Core (.NET 8)** com **Entity Framework Core** e banco de dados **Oracle**. O projeto expõe dois recursos principais — **Clientes** e **Produtos** — com CRUD completo, validações, uso correto de Status Codes e documentação via Swagger.

---

## 🛠️ Tecnologias Utilizadas

| Tecnologia | Versão |
|---|---|
| C# / .NET | 8.0 |
| ASP.NET Core Web API | 8.0 |
| Entity Framework Core | 8.x |
| Oracle Database | — |
| Oracle EF Core Provider | Oracle.EntityFrameworkCore |
| Swagger / OpenAPI | Swashbuckle |

---

## 📁 Estrutura do Projeto

```
CP2/
├── Controllers/
│   ├── ClientesController.cs
│   └── ProdutosController.cs
├── Entities/
│   ├── Cliente.cs
│   └── Produto.cs
├── Data/
│   └── ApplicationContext.cs
├── Migrations/
├── appsettings.json
└── Program.cs
```

---

## ⚙️ Como Rodar o Projeto

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Acesso a um banco de dados **Oracle** (local ou remoto)
- [dotnet-ef](https://learn.microsoft.com/ef/core/cli/dotnet) instalado globalmente

### 1. Clonar o repositório

```bash
git clone <url-do-repositorio>
cd CP2
```

### 2. Configurar a connection string

Edite o arquivo `CP2/appsettings.json` e informe sua string de conexão Oracle:

```json
{
  "ConnectionStrings": {
    "Oracle": "User Id=<usuario>;Password=<senha>;Data Source=<host>:<porta>/<service>"
  }
}
```

### 3. Aplicar as Migrations

```bash
dotnet ef database update --project CP2
```

### 4. Executar a aplicação

```bash
dotnet run --project CP2
```

### 5. Acessar o Swagger

Após iniciar, acesse a documentação interativa em:

```
http://localhost:<porta>/swagger
```

---

## 🗂️ Entidades

### Cliente

| Campo | Tipo | Descrição |
|---|---|---|
| Id | int | Identificador único (PK) |
| Nome | string | Nome do cliente |
| Email | string | E-mail do cliente |

### Produto

| Campo | Tipo | Descrição |
|---|---|---|
| Id | int | Identificador único (PK) |
| Nome | string | Nome do produto |
| Preco | decimal | Preço do produto |

---

## 🌐 Endpoints Disponíveis

### Clientes — `/api/clientes`

| Método | Rota | Descrição | Status de Retorno |
|---|---|---|---|
| GET | `/api/clientes` | Lista todos os clientes | 200 OK |
| GET | `/api/clientes/{id}` | Busca cliente por ID | 200 OK / 404 Not Found |
| GET | `/api/clientes/email/{email}` | Busca clientes por e-mail | 200 OK |
| POST | `/api/clientes` | Cria um novo cliente | 201 Created / 400 Bad Request |
| PUT | `/api/clientes/{id}` | Atualiza um cliente existente | 200 OK / 400 Bad Request / 404 Not Found |
| DELETE | `/api/clientes/{id}` | Remove um cliente | 204 No Content / 404 Not Found |

### Produtos — `/api/produtos`

| Método | Rota | Descrição | Status de Retorno |
|---|---|---|---|
| GET | `/api/produtos` | Lista todos os produtos | 200 OK |
| GET | `/api/produtos/{id}` | Busca produto por ID | 200 OK / 404 Not Found |
| GET | `/api/produtos/preco/{valor}` | Busca produtos pelo preço | 200 OK |
| POST | `/api/produtos` | Cria um novo produto | 201 Created / 400 Bad Request |
| PUT | `/api/produtos/{id}` | Atualiza um produto existente | 204 No Content / 400 Bad Request / 404 Not Found |
| DELETE | `/api/produtos/{id}` | Remove um produto | 204 No Content / 404 Not Found |

---

## 📨 Exemplos de Requisição (JSON)

### POST `/api/clientes`

```json
{
  "id": 0,
  "nome": "Gustavo Gomes",
  "email": "gustavo@email.com"
}
```

**Resposta — 201 Created:**
```json
{
  "id": 1,
  "nome": "Gustavo Gomes",
  "email": "gustavo@email.com"
}
```

---

### PUT `/api/clientes/1`

```json
{
  "id": 1,
  "nome": "Gustavo Gomes Martins",
  "email": "gustavo.martins@email.com"
}
```

**Resposta — 200 OK:**
```json
{
  "id": 1,
  "nome": "Gustavo Gomes Martins",
  "email": "gustavo.martins@email.com"
}
```

---

### POST `/api/produtos`

```json
{
  "id": 0,
  "nome": "Notebook",
  "preco": 3599.99
}
```

**Resposta — 201 Created:**
```json
{
  "id": 1,
  "nome": "Notebook",
  "preco": 3599.99
}
```

---

### PUT `/api/produtos/1`

```json
{
  "id": 1,
  "nome": "Notebook Gamer",
  "preco": 4999.99
}
```

**Resposta — 204 No Content**

---

## 📊 Status Codes Utilizados

| Status Code | Situação |
|---|---|
| 200 OK | Requisição bem-sucedida com retorno de dados |
| 201 Created | Recurso criado com sucesso |
| 204 No Content | Operação realizada sem retorno de corpo |
| 400 Bad Request | Dados inválidos ou ID inconsistente |
| 404 Not Found | Recurso não encontrado |
