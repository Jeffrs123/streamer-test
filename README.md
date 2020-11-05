# FILES REQUIRED BY STREAMER TEST

| Atividade | Status  | Observação  |
| :---:   | :-: | :-: |
| Controler - Course | OK |  |
| Controler - Project | OK |  |
| ./Data | OK | Contexto do banco de dados |
| ./Model - Project | OK | Modelo da Entidade Project |
| ./Model - Course | OK | Modelo da Entidade Course |
| ./Services - Project | --- | CRUD |
| ./Services - Course | --- | CRUD |
|---|---|---|

## CHECK LIST - API

| Controler | Status  | Método  | Path  | Observação  |
| :---:   | :-: | :-: | :-: | :-: |
| Course | OK | GetAll | URL/cursos  | Retorna lista com objetos do tipo 'Course'. |
| Course | OK | GetById | URL/cursos/{CourseId}  | Recebe um ID de um 'Course'.Retorna um objeto do tipo 'Course'. |
| Course | :-: | GetByCourse | URL/cursos/{CourseId}/projects  | Recebe um ID de um 'Course'. Retorna uma lista genérica de 'Project'.  |
| Project | OK | GetAll | URL/projetos/  | Retorna lista com objetos do tipo 'Project'. |
| Project | OK | GetById | URL/projetos/{ProjectId}  | Recebe um ID de um 'Project'.Retorna um objeto do tipo 'Project'. |
| Project | :-: | Update | URL/projetos/{ProjectId}  | Recebe um objeto do tipo 'Project' e realiza a atualização do mesmo. Retorna um valor booleano.  |
| Project | :-: | Delete | URL/projetos/{ProjectId}  | Recebe um ID de um 'Project' e realizar a remoção do mesmo. Retorna um valor booleano.  |
| Project | :-: | Create | URL/projetos  | Recebe um objeto do tipo Project e realiza a inserção no banco de dados. Retorna o Id do 'Project' inserido.  |

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



