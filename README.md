Este projeto é uma aplicação ASP.NET Core desenvolvida em C# .NET SDK 8 com Entity Framework e SQL Server. 
A aplicação gerencia dados de lojas, produtos, estoques, preços, usuários e descontos, com funcionalidades de CRUD (Create, Read, Update, Delete) e outras operações.

## Tecnologias:

C# .NET SDK 8
ASP.NET Core
Entity Framework Core
SQL Server
## Requisitos:

.NET SDK 8 instalado
Visual Studio Community 2022
SQL Server Management Studio (SSMS)
Banco de dados SQL Server

## Instalação:

Clone o repositório para o seu computador.
Abra o Visual Studio Community 2022.
Abra a solução DesafioFarmacia.sln.
Restaure os pacotes NuGet.
Configure a string de conexão do banco de dados no arquivo appsettings.json.
Executando a aplicação:

Pressione F5 no Visual Studio para iniciar a aplicação.
A aplicação estará disponível em https://localhost:<port> (substitua <port> pelo número da porta).
Documentação da API:

A documentação da API está disponível em Swagger em https://localhost:<port>/swagger.

## Funcionalidades:

CRUD de lojas, produtos, estoques, preços, usuários e descontos:
Crie, consulte, atualize e exclua dados de cada entidade.
Buscar produtos por loja:
Encontre produtos específicos em uma loja.
Descontos:
Aplique descontos no preço de um produto para um usuário específico.
Usuários podem visualizar os descontos disponíveis.
