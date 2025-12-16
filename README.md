# Rick & Morty Episodes BFF API

Este projeto implementa um **Backend for Frontend (BFF)** em **ASP.NET Core**, responsável por intermediar o consumo da **Rick and Morty API** e expor um endpoint próprio, padronizado e otimizado para o front-end.

O objetivo é evitar que o front-end consuma diretamente a API externa, centralizando regras de negócio, normalização de dados e otimizações no backend.

---

## 📌 Conceito: Backend for Frontend (BFF)

O **BFF (Backend for Frontend)** é uma camada intermediária entre o front-end e APIs externas.

Neste projeto:

Front-end
↓
RickMortyZRP (BFF)
↓
Rick and Morty Public API

O BFF é responsável por:
- Centralizar a integração com a API externa
- Padronizar o formato de resposta
- Aplicar regras de negócio
- Otimizar chamadas externas
- Proteger o front-end de mudanças na API de terceiros

---

## 🚀 Funcionalidades

- Consumo de episódios da Rick and Morty API
- Retorno **apenas dos personagens do episódio**
- Busca de personagens em **batch** (1 request para vários IDs)
- Ordenação dos personagens **em ordem alfabética (A–Z)**
- Padronização da resposta para o front-end
- Cache em memória para reduzir chamadas externas
- Documentação interativa via Swagger

---

## 🧱 Arquitetura e Boas Práticas

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

Exemplo de Resposta
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


