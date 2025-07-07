# 🧩 Microservices App – UserService & ProjectService (.NET 8)

This repository contains two containerized .NET 8 Web API microservices:

- **UserService** – Manages users and subscriptions using PostgreSQL.
- **ProjectService** – Manages projects and user settings using MongoDB.

The microservices communicate over HTTP and are containerized using Docker. ProjectService includes an analytics endpoint to retrieve the top 3 most used trading indicators for users with a specific subscription type.

---

## 🧱 Tech Stack

| Component        | Technology                      |
|------------------|----------------------------------|
| Framework        | .NET 8 Web API                   |
| Data Storage     | PostgreSQL (EF Core), MongoDB    |
| Communication    | HttpClient                       |
| Containerization | Docker + Docker Compose          |
| Config Management| `appsettings.json`               |

---

## 📁 Project Structure

- **docker-compose.yml**
- **UserService/**
    - `Controllers/`
    - `Services/`
    - `Repositories/`
    - `Dtos/`
    - `Models/`
    - `Data/`
    - `Program.cs`
    - `appsettings.json`
- **ProjectService/**
    - `Controllers/`
    - `Services/`
    - `Repositories/`
    - `Dtos/`
    - `Models/`
    - `Program.cs`
    - `appsettings.json`

---

## 🚀 Getting Started

### 🧰 Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- Docker + Docker Compose

---

### ▶ Run the Application

```bash
docker-compose up --build
```


### ✨ Absolutely! Here's an extended version of the **✨ Improvements** section with more technical suggestions — covering architecture, observability, security, developer experience, performance, and scalability.

---

### ✨ Improvements (Optional Enhancements)

#### 🔁 Communication & Resilience

* **Add `Polly`** for retry, timeout, and circuit breaker policies in `HttpClient`
* Use `IHttpClientFactory` (already used) with named or typed clients for multiple service calls
* Add **request correlation IDs** for tracing cross-service calls (`X-Correlation-ID` headers)

#### 🔧 Configuration & Environment

* Use `.env` file with Docker Compose for centralized environment variables
* Separate configuration per environment:

    * `appsettings.Development.json`
    * `appsettings.Production.json`
* Use `IOptionsSnapshot<T>` or strongly-typed settings for reloadable configs

#### 🚨 Observability & Health

* Add **health check endpoints** using `AspNetCore.HealthChecks.UI`

    * `/health`, `/health/startup`, `/health/liveness`, `/health/readiness`
* Add **structured logging** (e.g., **Serilog**, **Seq**, or **ELK Stack**)
* Add **distributed tracing** (e.g., **OpenTelemetry**, **Jaeger**, or **Zipkin**)

#### ⚡ Performance

* Replace in-memory filtering with MongoDB `$in` query:

  ```csharp
  var filter = Builders<Project>.Filter.In(p => p.UserId, userIds);
  var projects = await _collection.Find(filter).ToListAsync();
  ```
* Add **indexes** in MongoDB for `userId`, `charts.indicators.name` if needed for frequent queries

#### 🧠 Data Improvements

* Normalize project schema or use references if project data grows large
* Add **data validation** using `FluentValidation` for DTOs
* Use **DTO versioning** (e.g., `V1`, `V2`) for long-term compatibility

#### 🧰 Developer Experience

* Add Swagger annotations + examples using `[ProducesResponseType]`, XML comments
* Add **Docker Dev Profiles** with preloaded data
* Add a **Postman collection** or OpenAPI schema for sharing

#### 🔐 Security

* Add **JWT authentication** and `[Authorize]` filters on sensitive endpoints
* Implement **role-based access control** (RBAC) per route if needed
* Add **rate limiting** middleware (e.g., `AspNetCoreRateLimit`)

#### 🔄 Deployment & CI/CD

* Add a **GitHub Actions** or **GitLab CI** pipeline to:

    * Build & test on push
    * Build Docker images and publish to Docker Hub or GitHub Container Registry
* Use **Docker healthcheck** in `docker-compose.yml`:

  ```yaml
  healthcheck:
    test: ["CMD", "curl", "-f", "http://localhost/health"]
    interval: 30s
    timeout: 10s
    retries: 3
  ```

#### 🔭 Architecture

* Split shared DTOs/interfaces into a **shared NuGet package**
* Consider using **API Gateway** (YARP or Ocelot) if more services are added
* Consider migrating to **gRPC** if services need low-latency communication
# testTaskApp
