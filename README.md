# BANK-SYSTEM

A aplicação é um sistema de controle de conta bancária, sendo possível realizar transações e visualizar o histórico. As possíveis transações são:
* Saque
* Depósito
* Pagamento

![alt text](https://i.imgur.com/7lOOCJd.png)

## Começando
Para exeutar o projeto, será necessário instalar:
* [.NET Core 5.0](hhttps://dotnet.microsoft.com/download/dotnet/5.0)
* [MySQL](https://dev.mysql.com/downloads/mysql/)
* [Node](https://nodejs.org/en/download/)

## Para rodar a aplicação

```sh
$ git clone https://github.com/gabrielatomaz/bank-system.git
```

Informe a string de conexão do banco de dados em **appsettings.json**.

```
{
    "BankSystemDatabase": "server=localhost;database=bank_system;user={{seu_usuário}};password={{sua_senha}};"
}
```


### Backend
```sh
$ cd bank-system/back/src/BankSystem.Api
$ dotnet restore
$ dotnet run
```

### Frontend
```sh
$ cd ../../../front
$ npm install
$ npm run serve
```

Será possível acessar o backend nas portas **5000** (HTTP) e **5001** (HTTPS). Na rota **/swagger** será possível ver a documentação da API. Para acessar o frontend, basta utilizar a porta **8080** (HTTP).

## Testes

### Testes de Integração
```sh
$ cd back/tests/BankSystem.Api.Tests
$ dotnet test
```

### Testes Unitários
```sh
$ cd ../BankSystem.Domain.Tests
$ dotnet test
```

## Arquitetura

### Backend
A arquitetura do projeto é orientada a domínio, em inglês [Domain-Driven Design](https://www.devmedia.com.br/ddd-domain-driven-design-com-net/14416) (DDD).
* **BankSystem.Api** -> Controllers
* **BankSystem.Application** -> DTOs, Mappers, ApplicationServices
* **BankSystem.Domain** -> Entities
* **BankSystem.Domain.Core** -> Interfaces -> Repositories e Services
* **BankSystem.Services** -> Services
* **BankSystem.Infra** -> CrossCutting -> IOC, Migrations, Data -> Context, Mapping e Repositories

**Database**

![alt text](https://i.imgur.com/9dLex2Kl.png)

## Frontend
A aplicação frontend é uma simples [Single-Page Application](https://blog.schoolofnet.com/o-que-e-uma-spa-single-page-application/) (SPA).
* /clients
* /components 
* /services
* /views

## Tecnologias

### Backend

* [.NET Core 5.0](https://docs.microsoft.com/pt-br/dotnet/core/dotnet-five)
* [MySQL](https://www.mysql.com/)
* [Entity Framework Core](https://docs.microsoft.com/pt-br/ef/core/)
* [Swagger](https://swagger.io/)

### Frontend
* [Vue](https://vuejs.org/)
* [Bulma](https://bulma.io/)