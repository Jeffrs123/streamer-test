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

# CHECK LIST API's

### COURSE API

| Controler | Status  | Método  | Path  | Observação  |
| :---:   | :-: | :-: | :-: | :-: |
| Course | OK | GetAll | URL/cursos  | Retorna lista com objetos do tipo 'Course'. |
| Course | OK | GetById | URL/cursos/{CourseId}  | Recebe um ID de um 'Course'.Retorna um objeto do tipo 'Course'. |
| Course | :-: | GetByCourse | URL/cursos/{CourseId}/projects  | Recebe um ID de um 'Course'. Retorna uma lista genérica de 'Project'.  |


### PROJECT API

| Controler | Status  | Método  | Path  | Observação  |
| :---:   | :-: | :-: | :-: | :-: |
| Project | OK | GetAll | URL/projetos/  | Retorna lista com objetos do tipo 'Project'. |
| Project | OK | GetById | URL/projetos/{ProjectId}  | Recebe um ID de um 'Project'.Retorna um objeto do tipo 'Project'. |
| Project | :-: | Update | URL/projetos/{ProjectId}  | Recebe um objeto do tipo 'Project' e realiza a atualização do mesmo. Retorna um valor booleano.  |
| Project | :-: | Delete | URL/projetos/{ProjectId}  | Recebe um ID de um 'Project' e realizar a remoção do mesmo. Retorna um valor booleano.  |
| Project | :-: | Create | URL/projetos  | Recebe um objeto do tipo Project e realiza a inserção no banco de dados. Retorna o Id do 'Project' inserido.  |

# Inicio do Teste

## BACK END

Com .Net Core criar template webapi

    dotnet new webapi -n Streamer.API

### Migrations

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


### Database

    dotnet ef database update


### Camadas (1 arquivo e 2 projetos)

Separar responsabilidades que se encontram dentro do projeto "Streamer.API"
Dividir a responsabilidades de acordo com o projeto.

1. Arquivo de Solução -
2. Camada de Domínio (Projeto) - Colocar entidades e relação de regra de negócio.
3. Camada de Repositório (Projeto) - Separar a responsabilidade de persistir os dados.
4. Camada de API (Projeto) - Onde colocamos os middleware.


#### Projeto de Domínio

Com terminal em:

    C:\Users\Micro\Documents\streamer>
    dotnet new classlib -n Streamer.Domain

Remover arquivo "Class1.cs"

    rm -R Streamer.Domain/Class1.cs

##### Projeto de Repositório

Com terminal em:

    C:\Users\Micro\Documents\streamer>
    dotnet new classlib -n Streamer.Repository
    
Remover arquivo "Class1.cs"

    rm -R Streamer.Repository/Class1.cs

##### Arquivo de solução

    dotnet new sln -n Streamer

#### Referenciar `Projeto de Domínio` no `Projeto de Repositório`

    dotnet add Streamer.Repository/Streamer.Repository.csproj reference Streamer.Domain/Streamer.Domain.csproj

#### Referenciar `Projeto de Domínio` e `Projeto de Repositório` no `Projeto da API`

    dotnet add Streamer.API/Streamer.API.csproj reference Streamer.Domain/Streamer.Domain.csproj

    E

    dotnet add Streamer.API/Streamer.API.csproj reference Streamer.Repository/Streamer.Repository.csproj


#### Referenciar `Projeto de Domínio` e `Projeto de Repositório` e `Projeto da API` no `Arquivo de Solução`

    dotnet sln Streamer.sln add Streamer.API/Streamer.API.csproj Streamer.Repository/Streamer.Repository.csproj Streamer.Domain/Streamer.Domain.csproj

#### PROJETOS REFERENCIADOS

Como os projetos estão referenciados na solução (Streamer.sln)
- Streamer.API/Streamer.API.csproj 
- Streamer.Repository/Streamer.Repository.csproj 
- Streamer.Domain/Streamer.Domain.csproj

Os arquivos/pastas internos **bin** e **obj** podem ser excluídos, que ao executar o build (comando abaixo). Vai encontrar tudo o que estiver referenciado na solução e então dará build nesses arquivos.

Terminal em

    C:\Users\Micro\Documents\streamer>  
    dotnet build  

Assim é garantido que qualquer pessoa que queira abri esse arquivo, conseguirá, executar sem problema algum.

O diretório/projeto da interface/front end (Streamer-App), não está referenciado em nossa solução dotnet porque ele não é um projeto dotnet, ele é um projeto de interface.

### Classes e Relações

No projeto **`Streamer.Domain`** criamos classes tanto para continuação do curso, como também para definir o projeto da Streamer. Seguem as relações abaixo.

#### Para Curso Udemy
- Evento.cs
- Lote.cs
- Palestrante.cs
- PalestranteEvento.cs
- RedeSocial

#### Para Teste Streamer
- Course.cs
- CourseProject.cs
- Project.cs


### Streamer.Repository - Migrations - Data/Streamer Context

No projeto **`Streamer.Repository`** criamos classe StreamerContext com referência para todas as entidades, tanto do curso como para do teste.
E também crianção de método, para que na criação das Entidades de Referência (CourseProject e PalestranteEvento) as **"chaves estrangeiras"** sejam usadas.

#### Gerar Migrations

Terminal em: 
    C:\Users\Micro\Documents\streamer\Streamer.Repository> 
    dotnet ef migrations add init

NÃO FUNCIONARÁ, Daí termos que usar:
    C:\Users\Micro\Documents\streamer\Streamer.Repository> 
    dotnet ef --startup-project ../Streamer.API migrations add init

e também

    C:\Users\Micro\Documents\streamer\Streamer.Repository> 
    dotnet ef --startup-project ../Streamer.API database update

### Streamer.Repository - Interface

Criação da interface (arquivo) "IStreamerRepository", para implementar a interface dos métodos de chamadas tanto para Evento quanto Palestrante.

Atualizar para as chamadas de acordo com o Solicitado pelo teste.


## FRONT END

### Instalar CLI Angular

    npm install -g @angular/cli

### Iniciar Projeto

    ng new nomeDoProjeto

# Techs utilizadas no Projeto


* [**`.Net Core`**](https://dotnet.microsoft.com/download) - Framework para desenvolver em C# o Back End.

* **`C#`** - Linguagem utilizada no Back End.

* [**`DB Browser for SQLite`**](https://sqlitebrowser.org/dl/) - Programa para manuseio de banco de dados SQL - Back End.

* [**`Angular`**](https://angular.io/) - Framework para desenvolver Front End SPA.

* [**`CLI Angular`**](https://cli.angular.io/) - Framework para desenvolver Front End SPA.

* [**`Angular Doc`**]() - Documentação do Framework Angular.

* **`JavaScript e TypeScript`** - Linguagem utilizada no Front End.

* [**`Bootstrap`**]() - Estilos de Aparência Pré Definidos e Customizados para o Front End.