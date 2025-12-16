# Rick & Morty Episodes BFF API

Este projeto implementa um **Backend for Frontend (BFF)** em **ASP.NET Core**, responsável por intermediar o consumo da **Rick and Morty API** e expor um endpoint próprio, padronizado e otimizado para o front-end.

O objetivo é evitar que o front-end consuma diretamente a API externa, centralizando regras de negócio, normalização de dados e otimizações no backend.

---

## Conceito: Backend for Frontend (BFF)

O **BFF (Backend for Frontend)** é uma camada intermediária entre o front-end e APIs externas.

Neste projeto:

Front-end
→
RickMortyZRP (BFF)
→
Rick and Morty Public API

O BFF é responsável por:
- Centralizar a integração com a API externa
- Padronizar o formato de resposta
- Aplicar regras de negócio
- Otimizar chamadas externas
- Proteger o front-end de mudanças na API de terceiros

---

## Funcionalidades

- Consumo de episódios da Rick and Morty API
- Retorno **apenas dos personagens do episódio**
- Busca de personagens em **batch** (1 request para vários IDs)
- Ordenação dos personagens **em ordem alfabética (A–Z)**
- Padronização da resposta para o front-end
- Cache em memória para reduzir chamadas externas
- Documentação interativa via Swagger

---

## Arquitetura e Boas Práticas

Controllers/ → Camada HTTP (endpoints)
Services/ → Regras de negócio
Clients/ → Integração com APIs externas
Models/Api → Contratos de resposta da API
Models/External → DTOs da API externa


### Responsabilidades das camadas

- **Controllers**: expõem os endpoints HTTP e retornam status codes adequados
- **Services**: concentram a lógica do negócio e orquestram os dados
- **Clients**: encapsulam o consumo da Rick and Morty API
- **Models/Api**: definem o contrato estável retornado ao front-end
- **Models/External**: representam o formato da API de terceiros

---

## 🔗 Endpoint Disponível

### Buscar episódio com personagens ordenados

```http
GET /api/episodes/{id}
```

### Exemplo de Requisição

```http
GET /api/episodes/1

{
  "id": 1,
  "name": "Pilot",
  "airDate": "December 2, 2013",
  "episodeCode": "S01E01",
  "sourceSystem": "RickAndMorty",
  "characters": [
    {
      "id": 38,
      "name": "Beth Smith",
      "status": "Alive",
      "species": "Human",
      "image": "https://rickandmortyapi.com/api/character/avatar/38.jpeg"
    }
  ]
}

```

## Otimizações Implementadas

- **Batch request de personagens** utilizando o endpoint `/character/1,2,3`, reduzindo o número de chamadas externas
- **Cache em memória** com `IMemoryCache` para evitar chamadas repetidas à API externa
- Uso de **CancellationToken** para permitir o cancelamento de requisições
- **Separação entre DTOs externos e modelos de resposta da API**, evitando vazamento de contrato
- **Redução do acoplamento** com a API externa por meio da camada de Client

---

## Swagger

A API possui documentação interativa via Swagger.

Após rodar o projeto, acesse:
http://localhost:{porta}/swagger

---

### Tecnologias Utilizadas

### Frontend — React + TypeScript

O front-end foi desenvolvido em React com TypeScript, consumindo exclusivamente o BFF, sem acesso direto à API externa.

### Funcionalidades do Frontend
- Busca de episódios pelo ID
- Exibição das informações do episódio
- Listagem de personagens ordenados alfabeticamente
- Layout responsivo e organizado
- Destaque visual para status do personagem (Alive / Dead / Unknown)
- Tratamento de loading e erro
- Cancelamento automático de requisições

### Estrutura do Frontend

src/
├── components/   → Componentes visuais
├── hooks/        → Hooks de dados (useEpisode)
├── services/     → Client HTTP (fetch)
├── types/        → Contratos da API (BFF)
├── App.tsx
└── index.css

### Boas práticas utilizadas

- Separação de responsabilidades
- Tipagem forte com TypeScript
- Isolamento da comunicação HTTP
- Hooks para controle de estado assíncrono
- Layout simples e legível para avaliação técnica

## Como Executar o Projeto
Pré-requisitos

- .NET 8 ou superior
- Node.js 18+
- Conexão com a internet

Executar o Backend

```
cd backend
dotnet restore
dotnet run
```

Executar o Frontend

````
cd frontend
npm install
npm run dev
````

Tecnologias Utilizadas

BackEnd
- ASP.NET Core Web API
- HttpClientFactory
- IMemoryCache
- Swagger (Swashbuckle)

FrontEnd
- React
- TypeScript
- Vite
- Fetch API

### Observações Finais

- O front-end não consome diretamente a Rick and Morty API
- Qualquer mudança na API externa fica isolada no Client
- O contrato exposto pelo BFF permanece estável
- Projeto estruturado seguindo boas práticas de arquitetura
- Commits organizados e incrementais

### Autor
Projeto desenvolvido como desafio técnico, com foco em:

- Arquitetura limpa
- Boas práticas
- Integração com APIs externas
- Organização de código e commits
