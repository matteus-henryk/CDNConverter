# CDNConverter API 

### Essa aplicação usa as seguintes tecnologias: .NET Core 2.1, Entity Framework Core, SQL Server, XUnit e Moq  🛠

Essa aplicação foi construida para converter logs do formato "MINHA CDN" para "AGORA"


#### Requisitos ✅

| Required  | Usage |
| ------------- | -------------- |
| .NET Core 2.1     | Para implantação local |
| Visual Studio 2022     | Para desenvolvimento e build |
| Entity Framework Core 2.1.1   | Para acesso ao banco de dados SQL Server |
| Swashbuckle 5.0.0   | Documentação da API com Swagger |
| FluentValidation 8.6.3   | Banco de dados utilizado |
| Moq 4.10.1    | Mocking de serviços e dependências |
| xUnit 2.4.1    | Banco de dados utilizado |
| SQL Server    | Framework de teste |

#### Funcionalidades  ✅

| Status | Requisitos |
| ------------- | -------------- |
| ✅     | Salvar log "MINHA CDN" |
| ✅    | Converter log "MINHA CDN" para "AGORA" por um arquivo .txt ou identificador existente na base |
| ✅    | Retornar logs "MINHA CDN" informações do banco ou arquivo .txt |
| ✅ | Retornar logs "AGORA" informações do banco ou arquivo .txt |
| ✅ | Retornar logs "AGORA" e "MINHA CDN" por identificador "AGORA" |


## Rodando a aplicação 

## 1. Clone o repositorio
```bash
git clone [URL_DO_REPOSITORIO]
cd CDNConverter
```

## 2. No arquivo `appsettings.json`, adicione a seguinte configuração para a connection string e outros parâmetros relevantes:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your-database-server;Database=your-database-name;User Id=your-username;Password=your-password;"
  }
}
```

## 3. Adicionar novas migrations
```bash
dotnet ef migrations add MigrationName
```
## 4. Adicionar novas migrations
```bash
dotnet ef database update
```

## 5. Compile e execute a aplicação:
```bash
dotnet run --project CDNConverter.API
```
## 6. Acesse a documentação Swagger:
```bash
https://localhost:44398/index.html
```
Se a aplicação estiver rodando corretamente, você verá a interface do Swagger

## Testes 
Com o uso do xUnit e Moq, você pode criar e rodar testes automatizados para garantir a qualidade do seu sistema.

Comandos para rodar testes:
```bash
dotnet test
```
