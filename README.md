# CDNConverter API 
### Essa aplicação usa as seguintes tecnologias: .NET Core 2.1, Entity Framework Core, SQL Server, XUnit e Moq  🛠
A aplicação foi construida com conceitos de Clean Architecture, SOLID e POO
Essa aplicação foi construida para converter logs do formato "MINHA CDN" para "AGORA"

#### Requisitos ✅

| ------------- | -------------- |

| .NET Core 2.1     | Para implantação local |  
| Visual Studio 2022     | Para desenvolvimento e build |  
| Entity Framework Core 2.1.1   | Para acesso ao banco de dados SQL Server |  
| Swashbuckle 5.0.0   | Documentação da API com Swagger |  
| FluentValidation 8.6.3   | Framework para validações |  
| Moq 4.10.1    | Mocking de serviços e dependências |  
| xUnit 2.4.1    | Framework de testes |  
| SQL Server    | Banco de dados utilizado |  
| Docker-Compose   | para virtualização e orquestração |  

#### Funcionalidades  ✅

| ------------- | -------------- |

| ✅ | Salvar log "MINHA CDN" |  
| ✅ | Converter log "MINHA CDN" para "AGORA" por um arquivo .txt ou identificador existente na base |  
| ✅ | Retornar logs "MINHA CDN" informações do banco ou arquivo .txt |  
| ✅ | Retornar logs "AGORA" informações do banco ou arquivo .txt |  
| ✅ | Retornar logs "AGORA" e "MINHA CDN" por identificador "AGORA" |  

## Rodando a aplicação 

## 1. Clone o repositorio
```bash
git clone https://github.com/matteus-henryk/CDNConverter.git
cd CDNConverter
```
## 2. No arquivo `appsettings.json`, modifique as credencias para conectar no banco de dados:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your-database-server;Database=your-database-name;User Id=your-username;Password=your-password;"
  }
}
```
## 3. Compile e execute a aplicação:

```bash
dotnet run --project CDNConverter.API
```
Pode ser compilado e executado pelo Visual Studio

## 4. Aplicar as migrations
Feito de forma automatica pela aplicação

## 5. Acesse a documentação Postman:

```bash
https://documenter.getpostman.com/view/12668698/2sAYkErfZ4
```
Se a aplicação estiver rodando corretamente, você verá a interface do Swagger

Comando para rodar testes:
```bash
dotnet test
```
Pode ser executado via Visual Studio
