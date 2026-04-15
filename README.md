# Clean Architecture - Projeto de Gestão de Usuários

## 📋 Descrição

Este projeto é uma API REST construída com **Clean Architecture**, um padrão arquitetural que promove separação de responsabilidades, testabilidade e manutenibilidade do código. A aplicação permite gerenciar usuários através de operações CRUD.

---

## 🏗️ Padrão Arquitetural: Clean Architecture

### O que é Clean Architecture?

Clean Architecture é um padrão de design que organiza o código em camadas concêntricas independentes, onde cada camada tem uma responsabilidade específica. As dependências sempre apontam para o centro, nunca para fora.

### Estrutura de Camadas

```
┌─────────────────────────────────────────────────┐
│         API / Controllers (Presentation)         │
├─────────────────────────────────────────────────┤
│  Application (DTOs, Services, Validators)       │
├─────────────────────────────────────────────────┤
│      Domain (Entities, Interfaces)              │
├─────────────────────────────────────────────────┤
│  Infrastructure (Database, Repositories)        │
└─────────────────────────────────────────────────┘
```

### 📁 Estrutura de Pastas do Projeto

```
CleanArchitecture/
├── Api/
│   └── Controllers/
│       └── UserController.cs          # Endpoints HTTP
├── Application/
│   ├── Dtos/
│   │   └── UserDto.cs               # Data Transfer Objects
│   ├── Interfaces/
│   │   └── IUserService.cs          # Contrato de Serviços
│   ├── Services/
│   │   └── UserService.cs           # Lógica de Negócio
│   └── Validation/
│       └── UserDtoValidator.cs      # Validações com FluentValidation
├── Domain/
│   ├── AutoMapper/
│   │   └── MappingProfile.cs        # Configuração de Mapeamento
│   ├── Entities/
│   │   └── Users.cs                 # Modelos de Domínio
│   └── Interfaces/
│       └── IUserRepository.cs       # Contrato de Repositório
├── Infrastructure/
│   ├── Database/
│   │   └── AppDbContext.cs          # Contexto do Entity Framework
│   └── Repositories/
│       └── UserRepository.cs        # Implementação de Acesso a Dados
├── Migrations/                       # Histórico de Migrações do EF Core
├── appsettings.json                 # Configurações da Aplicação
├── appsettings.Development.json     # Configurações de Desenvolvimento
├── Program.cs                        # Configuração de Startup
└── CleanArchitecture.csproj         # Arquivo do Projeto
```

### 🎯 Princípios Implementados

1. **Dependency Inversion Principle (DIP)**: Dependências são injetadas via interfaces
2. **Separation of Concerns**: Cada camada tem uma responsabilidade clara
3. **Testability**: Facilita testes unitários e de integração
4. **Maintainability**: Código organizado e fácil de modificar
5. **Independência de Frameworks**: A lógica de negócio não depende de frameworks específicos

---

## 🔧 Tecnologias Utilizadas

- **.NET 10.0**: Framework web moderno
- **Entity Framework Core 10.0.6**: ORM para acesso a dados
- **PostgreSQL**: Banco de dados relacional
- **AutoMapper 16.1.1**: Mapeamento de objetos
- **FluentValidation 12.1.1**: Validação fluente
- **Swagger/OpenAPI**: Documentação interativa da API

---

## 🚀 Endpoints da API

A API está disponível na rota base: `api/users`

### 1️⃣ Obter todos os usuários

```http
GET /api/users
```

**Descrição**: Retorna uma lista de todos os usuários cadastrados.

**Resposta (200 OK)**:
```json
[
  {
    "nome": "João Silva",
    "telefone": "11999999999"
  },
  {
    "nome": "Maria Santos",
    "telefone": "21988888888"
  }
]
```

---

### 2️⃣ Obter usuário por ID

```http
GET /api/users/{id}
```

**Parâmetros**:
- `id` (int): ID do usuário

**Resposta (200 OK)**:
```json
{
  "nome": "João Silva",
  "telefone": "11999999999"
}
```

**Resposta (404 Not Found)**:
```json
{
  "message": "Usuário não encontrado!"
}
```

---

### 3️⃣ Criar novo usuário

```http
POST /api/users
Content-Type: application/json
```

**Body**:
```json
{
  "nome": "João Silva",
  "telefone": "11999999999"
}
```

**Resposta (200 OK)**:
```json
{
  "nome": "João Silva",
  "telefone": "11999999999"
}
```

**Resposta (400 Bad Request)**:
```json
{
  "errors": [
    {
      "propertyName": "Nome",
      "errorMessage": "O campo Nome é obrigatório"
    }
  ]
}
```

---

### 4️⃣ Atualizar usuário

```http
PUT /api/users/{id}
Content-Type: application/json
```

**Parâmetros**:
- `id` (int): ID do usuário

**Body**:
```json
{
  "nome": "João Silva Atualizado",
  "telefone": "11988888888"
}
```

**Resposta (204 No Content)**: Sem corpo

**Resposta (400 Bad Request)**:
```json
{
  "errors": [
    {
      "propertyName": "Telefone",
      "errorMessage": "O campo Telefone é obrigatório"
    }
  ]
}
```

---

### 5️⃣ Deletar usuário

```http
DELETE /api/users/{id}
```

**Parâmetros**:
- `id` (int): ID do usuário

**Resposta (204 No Content)**: Sem corpo

**Resposta (404 Not Found)**:
```json
{
  "message": "Usuário não encontrado!"
}
```

---

## 🔌 Como Executar o Projeto

### Pré-requisitos

- .NET 10.0 SDK instalado
- PostgreSQL em execução
- Entity Framework Core CLI (opcional, para migrations)

### Passo 1: Configurar a Connection String

Editar `appsettings.Development.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=5432;Database=usersDB;User Id=postgres;Password=sua_senha;"
  }
}
```

### Passo 2: Aplicar Migrations

```bash
dotnet ef database update
```

### Passo 3: Executar a Aplicação

```bash
dotnet run
```

A API estará disponível em: `https://localhost:5001`

### Passo 4: Acessar o Swagger

Navegue para: `https://localhost:5001/swagger/ui`

---

## 📦 Fluxo de Requisição

```
Controller (UserController)
    ↓
Service (UserService)
    ↓
Repository (UserRepository)
    ↓
Database (AppDbContext)
    ↓
PostgreSQL
```

1. **Controller**: Recebe a requisição HTTP e valida os dados
2. **Service**: Implementa a lógica de negócio
3. **Repository**: Acessa os dados do banco
4. **Database**: Contexto do Entity Framework
5. **PostgreSQL**: Banco de dados relacional

---

## 🧪 Padrões de Validação

As validações são implementadas com **FluentValidation**:

- Campos obrigatórios
- Formato de dados
- Regras de negócio personalizadas

As validações ocorrem na camada de aplicação antes de persistir dados.

---

## 🔄 Mapeamento de Objetos

O **AutoMapper** é utilizado para converter entre:
- `Users` (Entity) ↔ `UserDto` (Transfer Object)

Configurado em `Domain/AutoMapper/MappingProfile.cs`:

```csharp
CreateMap<Users, UserDto>().ReverseMap();
```

---

## 📝 Notas Importantes

- Use **PostMan** ou **Insomnia** para testar os endpoints
- O Swagger fornece documentação interativa e permite testar diretamente
- Verifique as validações antes de enviar requisições
- A aplicação utiliza **async/await** para operações não-bloqueantes

---

## 🤝 Contribuição

Para contribuir com o projeto:

1. Faça um fork
2. Crie uma branch para sua feature (`git checkout -b feature/nova-feature`)
3. Commit suas mudanças (`git commit -m 'Adiciona nova-feature'`)
4. Push para a branch (`git push origin feature/nova-feature`)
5. Abra um Pull Request

---

## 📄 Licença

Este projeto está sob licença MIT.

---

**Desenvolvido com ❤️ usando Clean Architecture**

