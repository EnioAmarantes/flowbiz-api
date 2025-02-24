# FlowBiz API

A **FlowBiz API** é o coração do sistema de gestão integrada para Micro e Pequenas Empresas (MPEs). Desenvolvida em **.NET Core 8.0**, ela utiliza **MariaDB** como banco de dados e **Entity Framework** como ORM para garantir uma gestão eficiente e escalável dos dados. A API conecta o Sistema de Gestão ERP, o Site e os Marketplaces, garantindo a intercomunicação e sincronização de dados entre todos os módulos.

---

## Funcionalidades Principais

- **Gestão de Produtos:** CRUD de produtos, categorias e atributos.
- **Gestão de Clientes:** Cadastro e histórico de compras.
- **Gestão de Estoque:** Controle de entradas, saídas e alertas.
- **Gestão Financeira:** Contas a pagar/receber e relatórios.
- **Integração com Marketplaces:** Sincronização de produtos e pedidos.
- **Autenticação e Autorização:** Controle de acesso via JWT.
- **Emissão de Notas Fiscais:** Integração com APIs de emissão de notas fiscais.

---

## Tecnologias Utilizadas

- **Linguagem** [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
- **Framework:** [.NET Core 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- **Banco de Dados:** [MariaDB](https://mariadb.org/)
- **ORM:** [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- **Autenticação:** [JWT](https://jwt.io/)
- **Documentação da API:** [Swagger](https://swagger.io/)
- **Testes:** [xUnit](https://xunit.net/) ou [NUnit](https://nunit.org/)

---

## Como Executar o Projeto

### Pré-requisitos

- [.NET Core 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [MariaDB](https://mariadb.org/download/)
- [Git](https://git-scm.com/)

### Passos para Execução

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/EnioAmarantes/flowbiz-api.git
   cd flowbiz-api
   ```

1. **Configure o banco de dados:**
    - Crie um banco de dados no MariaDB.
    - Atualize a string de conexão no arquivo appsettings.json
    ```json
    "ConnectionStrings": {
        "DefaultConnection": "Server=seu_servidor;Database=flowbiz;User Id=seu_usuario;Password=sua_senha;"
    }
    ```

1. **Execute as migrações**
    ```bash
    dotnet ef database update
    ```

1. **Inicie o servidor:**
    ```bash
    dotnet run
    ```

1. **Acesse a documentação da API:**
    - Swagger: http://localhost:5000/swagger

---

## Estrutura do Projeto
    flowbiz-api/
    ├── Controllers/          # Controladores das rotas da API
    ├── Models/               # Modelos de domínio e entidades do banco de dados
    ├── Data/                 # Contexto do Entity Framework e configurações do banco de dados
    ├── Services/             # Lógica de negócio e serviços
    ├── DTOs/                 # Objetos de Transferência de Dados (DTOs)
    ├── Migrations/           # Migrações do Entity Framework
    ├── Properties/           # Configurações do projeto
    ├── appsettings.json      # Configurações do aplicativo (ex: conexão com o banco)
    ├── Program.cs            # Ponto de entrada da aplicação
    ├── Startup.cs            # Configurações de inicialização (middleware, serviços, etc.)
    ├── Tests/                # Testes automatizados
    └── README.md             # Este arquivo

### Endpoints Principais

Aqui estão alguns dos principais Endpoints da API:

**Autenticação**
- **POST/api/auth/login**

Autentica o usuário e retorna um token JWT.

**Produtos**

- **GET /api/products**

Retorna a lista de produtos.

- **POST /api/products**

Cria um novo produto.

- **PUT /api/products/{id}**

Atualiza um produto existente.

- **DELETE /api/products/{id}**

Remove um produto.

**Clientes**

- **GET /api/customers**

Retorna a lista de clientes.

- **POST /api/customers**

Cria um novo cliente.

- **PUT /api/customers/{id}**

Atualiza um cliente existente.

**Estoque**

- **GET /api/inventory**

Retorna o status atual do estoque.

- **POST /api/inventory**

Adiciona ou remove itens do estoque.

**Marketplaces**

- **POST /api/marketplaces/sync**

Sincroniza produtos e pedidos com marketplaces integrados.

### Testes

Para executar os testes automatizados, use o seguinte comando:

```bash
    dotnet test
```

### Contribuição

Contribuições são bem-vindas! Siga os passos abaixo:

1. Faça um fork do projeto.

1. Crie uma branch para sua feature (git checkout -b feature/nova-feature).

1. Commit suas mudanças (git commit -m 'Adiciona nova feature').

1. Push para a branch (git push origin feature/nova-feature).

1. Abra um Pull Request.

### Licença

Este projeto está licenciado sob a licença MIT. Veja o arquivo LICENSE para mais detalhes.

### Contato

Equipe FlowBiz

Email: contato@flowbiz.com

Site: https://flowbiz.com
