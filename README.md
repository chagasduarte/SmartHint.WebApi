# SmartHint.WebApi

Api desenvolvida em c# com base de dados MySql.
O banco de dados MySql esta hospedado em uma instancia do railway com dados ja armazenados para teste.
## Índice

- [Visão Geral](#visão-geral)
- [Funcionalidades](#funcionalidades)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Pré-requisitos](#pré-requisitos)
- [Configuração do Banco de Dados](#configuração-do-banco-de-dados)
- [Instalação](#instalação)
- [Uso](#uso)
- [Endpoints](#endpoints)
- [Contribuição](#contribuição)
- [Licença](#licença)
- [Contato](#contato)

## Visão Geral

Esta API fornece um CRUD simples que faz parte de um sistema com mais duas camadas: Bando de dados e <a href="https://github.com/chagasduarte/SmartHint.UI">UI</a>.
## Funcionalidades

- Todas as funcionalidades solicitadas no <a href="./SmartHint - Teste desenvolvedor(a) .Net.pdf">arquivo</a>

## Tecnologias Utilizadas

- **C#**: Linguagem de Programação
- **.net Core**: FrameWork multiplataforma.
- **MySQL**: Banco de dados relacional usado.
- **Railway**: Plataforma para gerenciamento e hospedagem do banco de dados MySQL.
- **EntityFramWork**: ORM utilizado para gerenciar conexão com o banco de dados.
- **Design Paterns**: Padrões utilizados para melhor qualidade do código.
## Pré-requisitos

Certifique-se de ter as seguintes ferramentas instaladas:

- [.net core](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0) (versão 8)
- [MySQL](https://www.mysql.com/) (se desejar executar o banco de dados localmente, caso contrário, a instância do Railway será utilizada)

## Configuração do Banco de Dados
## Caso prefira utilizar o que já está configurado, fica a seu critério. As configurações do banco estão setadas no arquivo AppDbContext. caso contrário, só seguir o passo a passo
1. **Crie uma instância MySQL no Railway**:
   - Vá para [Railway](https://railway.app/) e crie um novo projeto.
   - Adicione um serviço MySQL ao seu projeto e anote a URL de conexão e as credenciais (host, usuário, senha e nome do banco de dados).

2. **Configuração no Projeto**:
   - Crie um arquivo `.env` na raiz do projeto e adicione as seguintes variáveis (substitua os valores pelos da sua instância Railway):

     ```env
     DB_HOST=host_da_instancia_railway
     DB_USER=usuario
     DB_PASSWORD=senha
     DB_NAME=nome_do_banco
     ```

## Instalação

1. Clone o repositório:

    ```bash
    git clone https://github.com/chagasduarte/Karaoke.WebApi.git
    ```

2. Instalar as dependicias do EntityFrameWork e do MySql

    ```bash
    dotnet add package <PACAGE_NAME>
    ```

3. Configurar DbContext

    ```bash
    dotnet ef migrations add 'MigrationName' -s SmartHint.WebApi -p SmartHint.Domain -c AppDbContext
    ```
#### O comando -s indica o projeto que inicializa, -p indica o projeto onde se encontra o arquivo dbContext e -c indica qual o nome do contexto, para caso haje mais de um.

4. Atualizar banco de dados
   ```bash
   dotnet ef database update --verbose --project SmartHint.Domain --startup-project SmartHint.WebApi
   ```

4. Configure as variáveis de ambiente conforme instruído na seção [Configuração do Banco de Dados](#configuração-do-banco-de-dados).

## Uso

Inicie o servidor:

```bash
npm start
