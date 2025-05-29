# GerenciamentoEsportivoAPI

API RESTful em ASP.NET Core para gerenciamento de esportes, times e jogadores. Todos os dados são armazenados em arquivos `.txt`, sem uso de banco de dados.

## 🚀 Funcionalidades

- 📋 CRUD completo de:
  - Esportes
  - Times
  - Jogadores
- 🧾 Armazenamento em arquivos de texto (`.txt`) na pasta `/Data`
- 🧪 Documentação interativa com **Swagger**

## 🔧 Tecnologias

- ASP.NET Core 8.0
- C#
- Swagger / Swashbuckle

## 🧠 Endpoints

| Entidade | Endpoint Base    |
| -------- | ---------------- |
| Esporte  | `/api/esportes`  |
| Time     | `/api/times`     |
| Jogador  | `/api/jogadores` |

### Exemplos

- `GET /api/times` - Lista todos os times
- `POST /api/esportes` - Cria um novo esporte
- `PUT /api/jogadores/3` - Atualiza o jogador com ID 3

## ▶️ Executando o Projeto

### Pré-requisitos

- [.NET 8 SDK ou superior](https://dotnet.microsoft.com/download)

### Passos

```bash
# Restaura as dependências
dotnet restore

# Compila o projeto
dotnet build

# Executa a API
dotnet run
```

Abra o navegador em:  
👉 [http://localhost:5000/swagger](http://localhost:5000/swagger) (ou a porta configurada) para testar via Swagger.

## 📂 Arquivos gerados

Ao executar a aplicação, serão criados os seguintes arquivos automaticamente (caso não existam):

- `Data/esportes.txt`
- `Data/times.txt`
- `Data/jogadores.txt`

Esses arquivos armazenam os dados persistidos em formato `CSV` simples (`;` como separador).

## ✅ Contribuição

Sinta-se à vontade para contribuir criando issues ou pull requests.

---

**Autor:** João Alexandre Vilaruel Dos Santos
**coautores:** Caio Voitena Roupa e  
📅 Projeto desenvolvido em 2025
