# Rick & Morty Episodes BFF API

This project implements a **Backend for Frontend (BFF)** using **ASP.NET Core**. It acts as an intermediary for consuming the **Rick and Morty API**, exposing a standardized and optimized endpoint specifically tailored for the frontend.

The primary goal is to prevent the frontend from consuming the external API directly, centralizing business logic, data normalization, and performance optimizations within the backend.

---

## Concept: Backend for Frontend (BFF)

A **BFF (Backend for Frontend)** is an intermediate layer between the frontend and external APIs.

In this project:
`Frontend` → `RickAndMortyBFF (This Project)` → `Rick and Morty Public API`

The BFF is responsible for:
- **Centralizing integration** with the external API.
- **Standardizing** the response format for the UI.
- **Applying business logic** (e.g., sorting and filtering).
- **Optimizing external calls** (batching and caching).
- **Decoupling** the frontend from third-party API changes.

---

##  Features

- **Episode Consumption**: Fetches episode data from the Rick and Morty API.
- **Character Filtering**: Returns only the characters relevant to a specific episode.
- **Batch Processing**: Retrieves characters using batch requests (1 request for multiple IDs) to improve performance.
- **Alphabetical Sorting**: Automatically sorts characters from **A to Z**.
- **Data Normalization**: Provides a clean, standardized contract to the frontend.
- **Memory Caching**: Implements `IMemoryCache` to reduce redundant external calls.
- **Interactive Documentation**: Full Swagger/OpenAPI support.

---

##  Architecture & Best Practices

The project follows a layered architecture to ensure separation of concerns:

- **Controllers/**: HTTP Layer (Endpoints).
- **Services/**: Business logic and data orchestration.
- **Clients/**: Encapsulation of external API consumption (HttpClient).
- **Models/Api**: Stable response contracts returned to the frontend.
- **Models/External**: DTOs representing the third-party API schema.

---

## 🔗 Available Endpoint

### Fetch Episode with Sorted Characters

```http
GET /api/episodes/{id}
````
Sample Request
```http
GET /api/episodes/1
````

Sample Response
JSON
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
      "image": "[https://rickandmortyapi.com/api/character/avatar/38.jpeg](https://rickandmortyapi.com/api/character/avatar/38.jpeg)"
    }
  ]
}
⚡ Performance Optimizations
Batch Character Requests: Utilizes the /character/1,2,3 endpoint to minimize round-trips.

In-Memory Cache: Uses IMemoryCache to store frequent results and respect external API rate limits.

Cancellation Tokens: Supports CancellationToken to allow requests to be aborted, saving server resources.

Contract Isolation: Strict separation between external DTOs and internal API models prevents breaking changes if the third-party API updates its schema.

⚛️ Frontend — React + TypeScript
The frontend was developed using React and TypeScript, designed to consume only the BFF.

Frontend Features
Dynamic Search: Fetch episodes by ID.

Detailed View: Displays episode info and a list of sorted characters.

Visual Indicators: Color-coded status (Alive / Dead / Unknown).

State Management: Handles loading, error states, and empty results.

Responsive Design: Mobile-friendly layout.

Frontend Structure
Plaintext
src/
├── components/   # UI Components
├── hooks/        # Custom hooks (e.g., useEpisode)
├── services/     # HTTP Client (Fetch/Axios wrapper)
├── types/        # TypeScript Interfaces (BFF Contracts)
├── App.tsx
└── index.css
🚀 Getting Started
Prerequisites
.NET 8 SDK or higher

Node.js 18+

Running the Backend
Bash
cd backend
dotnet restore
dotnet run
Running the Frontend
Bash
cd frontend
npm install
npm run dev
🛠️ Tech Stack
Backend

ASP.NET Core Web API

HttpClientFactory

IMemoryCache

Swagger / OpenAPI

Frontend

React

TypeScript

Vite

CSS Modules / Tailwind

📝 Final Remarks
This project was built focusing on Clean Architecture and Scalability. By isolating external communication within a BFF, the frontend remains lightweight and resilient to external API fluctuations.

Author: Developed as a technical challenge focused on high-quality integration and architectural best practices.
