# MangaDB V2

Uma API REST para gerenciamento de mangás, autores e arcos, desenvolvida em ASP.NET Core 8.0 com MongoDB.

## 📋 Descrição

O MangaDB V2 é um sistema de gerenciamento de mangás que permite organizar informações sobre:
- **Autores**: Criadores dos mangás
- **Mangás**: Obras criadas pelos autores
- **Arcos**: Divisões narrativas dentro dos mangás

## 🛠️ Tecnologias Utilizadas

- **Framework**: ASP.NET Core 8.0
- **Banco de Dados**: MongoDB
- **Driver**: MongoDB.Driver 3.2.0
- **API Documentation**: Swagger/OpenAPI
- **Linguagem**: C# (.NET 8.0)

## 📁 Estrutura do Projeto

```
MangaDB_V2/
├── Models/
│   ├── Autor.cs        # Modelo do autor
│   ├── Manga.cs        # Modelo do mangá
│   └── Arco.cs         # Modelo do arco
├── Services/
│   └── MongoDbService.cs   # Serviço de conexão com MongoDB
├── Repositore/
│   ├── AutorRepository.cs  # Repositório de autores
│   ├── MangaRepository.cs  # Repositório de mangás
│   └── ArcoRepository.cs   # Repositório de arcos
├── Program.cs             # Configuração da aplicação
└── appsettings.json      # Configurações da aplicação
```

## 🗃️ Modelos de Dados

### Autor
- **Id**: Identificador único (ObjectId)
- **Nome**: Nome do autor
- **Idade**: Idade do autor
- **Mangas**: Lista de mangás criados pelo autor

### Manga
- **Id**: Identificador único (ObjectId)
- **Titulo**: Título do mangá
- **AutorId**: Referência ao autor (ObjectId)
- **Arcos**: Lista de arcos do mangá

### Arco
- **Id**: Identificador único (ObjectId)
- **Nome**: Nome do arco
- **QuantidadedeCapitulos**: Número de capítulos no arco
- **MangaId**: Referência ao mangá (ObjectId)

## 🚀 Como Executar

### Pré-requisitos
- .NET 8.0 SDK
- MongoDB Server (local ou remoto)

### Configuração

1. **Clone o repositório**
   ```bash
   git clone <url-do-repositorio>
   cd MangaDB_V2
   ```

2. **Configure o MongoDB**
   
   Edite o arquivo `appsettings.json` com suas configurações:
   ```json
   {
     "MongoDB": {
       "ConnectionString": "mongodb://localhost:27017",
       "DatabaseName": "MangaDB"
     }
   }
   ```

3. **Execute a aplicação**
   ```bash
   dotnet run
   ```

4. **Acesse a documentação da API**
   - Swagger UI: `https://localhost:7000/swagger` (HTTPS)
   - Swagger UI: `http://localhost:5000/swagger` (HTTP)

## 📚 Endpoints da API

### Autores

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/autores` | Lista todos os autores |
| GET | `/autores/{id}` | Busca autor por ID |
| POST | `/autores` | Cria novo autor |
| PUT | `/autores/{id}` | Atualiza autor existente |
| DELETE | `/autores/{id}` | Remove autor |

### Exemplo de Payload - Autor
```json
{
  "nome": "Eiichiro Oda",
  "idade": 48,
  "mangas": []
}
```

## 🔧 Funcionalidades

- ✅ CRUD completo para Autores
- 🔄 CRUD para Mangás (em desenvolvimento)
- 🔄 CRUD para Arcos (em desenvolvimento)
- 📖 Documentação automática com Swagger
- 🔗 Relacionamentos entre entidades
- 🛡️ Validação de dados
- 🗃️ Persistência em MongoDB

## 📝 Notas de Desenvolvimento

- A aplicação utiliza o padrão Repository para acesso aos dados
- Injeção de dependência configurada para todos os repositórios
- Swagger habilitado apenas em ambiente de desenvolvimento
- Suporte a HTTPS e redirecionamento automático

## 🤝 Contribuição

1. Faça um fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo `LICENSE` para mais detalhes.
