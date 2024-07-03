
# Agenda Blue

Este projeto é uma aplicação web para gerenciar uma lista de contatos. 

O front-end é desenvolvido utilizando Vue.js, enquanto o back-end é implementado com .NET. 

A aplicação permite aos usuários criar, visualizar, editar e excluir contatos.

## Instalação

Front

- Rode os seguintes comandos na ordem:

```bash
  npm i
  npm run dev
```

Back

(Caso esteja inicializando pela 1ª vez)
- Inicializa o banco local SQLServer;
- Adiciona os dados para ```ConnectionString``` no arquibo ```appsettings.json```;
- Rode a migration para criar as devidas tabelas usando o comando: ```dotnet ef database update```
- Inicializa o servidor da API rodando o comando: ```dotnet run```


## Stack utilizada

**Front-end:** vuejs

**Back-end:** .net, sqlserver


## Rodando os testes

Para rodar os testes, rode o seguinte comando dentro da pasta agenda_api.Tests

```bash
  dotnet test
```


## Roadmap

- Docker
- phone mask
- testes de integração
- RabbitMQ

