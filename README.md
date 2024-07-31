# SmartHint.WebApi
### Api desenvolvida em c# com base de dados MySql.
### O banco de dados MySql esta hospedado em uma instancia do railway com dados ja armazenados para teste.

# Comandos necessários para rodar o projeto: 
### dotnet ef migrations add 'MigrationName' -s SmartHint.WebApi -p SmartHint.Domain -c AppDbContext
#### O comando -s indica o projeto que inicializa, -p indica o projeto onde se encontra o arquivo dbContext e -c indica qual o nome do contexto, para caso haje mais de um.
### dotnet ef database update --verbose --project SmartHint.Domain --startup-project SmartHint.WebApi
#### Comando para atualizar o entity framework com o banco de dados. Como mensionado anteriormente, o banco de dados é um instancia MySql que está ativa no railway, sendo necessário apenas executar os comandos anteriores para funcionar
