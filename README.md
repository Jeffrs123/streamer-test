## Inicio do Teste

Com .Net Core criar template webapi

    dotnet new webapi -n Streamer.API

## Migrations

    dotnet ef migrations add init

Qual campo que vc adicionou e onde?
Quais foram os comandos que precisou rodar para que o banco de dados fosse atualizado?

---
    No MODEL > *.cs - inserir o campo:

    public string Name { get; set; }

---

    No CDM rodar os comandos:

    dotnet ef migrations add 'qualquer coisa'

    dotnet ef database update

---


## Database

    dotnet ef database update



