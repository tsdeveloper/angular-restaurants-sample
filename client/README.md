# Instruções:

## Requisitos de ambiente necessários para compilar e rodar o software
1 - Pode rodar em ambientes Linux e Windows 10. 
2 - É necessário instalar o  .NET Core SDK 3.1

## Instruções de como utilizar o sistema.
1 - Instalar o dotnet 3.1 conforme instruções da Microsoft seguindo as orientações conforme o seu sistema operacional [DOTNET SDK](https://dotnet.microsoft.com/download).

2 - Instalar o NodeJS conforme instruções da  [Node JS](https://nodejs.org/en/download/).

3 - Instalar o Angular conforme instruções da  [Angular CLI](https://cli.angular.io/).

4 - Abra a pasta do projeto Restaurant.API e altere as configurações de banco de dados no arquivo `appsettings.json`  `appsettings.Development.json`

5 - Abra a pasta do projeto Restaurant.API no terminal e execute os comandos  `dotnet restore`,
 `dotnet build`, `dotnet ef database update -s Restaurant.API`.
 
6 - Adicionei manualmente no banco de dados alguns registros na tabela `Restaurants`.
 
7 - Execute a API localizada na pasta Restaurant.API.

8 - Abra a pasta client no terminal e execute o comando `ng serve`.



## O que vale destacar no código implementado?

Projeto utilizando bons Design Pattern e aplicação de clean code com SOLID. Fácil de manutenção, baixo acoplamento, dependência e 
fácil de extender suas funcionalidades

## O que poderia ser feito para melhorar o sistema?

Projeto poderia ser criado em ambiente Docker, e também implementação de testes TDD, Testes de Integração.
Além de criação de um deploy com CI e CD para automatização de tarefas.
Também poderia ser implementado no Back End autenticação e autorização com Identity. Além disso implementação do OAuth2 no login com Angular.
Implementação do CRUD do projeto no front end.
