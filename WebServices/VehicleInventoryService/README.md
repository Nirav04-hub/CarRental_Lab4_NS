# Vehicle Inventory Microservice

## Purpose
Car rental platform Inventory limited context. Administers vehicles, location assignment and status lifecycle policies.

## Clean Architecture Layers
- Domain: Vehicle aggregate, VehicleStatus, domain rules
- Application: use cases (Create/Get/UpdateStatus/Delete), DTOs, repository interface
- Infrastructure: EF Core DbContext + repository implementation + migrations
- WebAPI: REST endpoints + Swagger + DI

Dependency direction:
WebAPI → Application → Domain
Infrastructure → Application (+ Domain)

## Domain Rules
- A vehicle cannot be rented if it is already rented
- A vehicle cannot be rented if it is reserved
- A vehicle cannot be rented if it is under service
- Reserved cannot be marked Available without explicit release
- Invalid transitions throw domain exceptions

## How to Run
1. Update WebAPI/appsettings.json connection string if needed
2. Select NS_VehiicleInventory.WebAPI as startup project
3. Run WebAPI and open Swagger

## Endpoints
GET /api/vehicles
GET /api/vehicles/{id}
POST /api/vehicles
PUT /api/vehicles/{id}/status
DELETE /api/vehicles/{id}

## Known Limitations
- No authentication
- No pagination/search
- Basic validation via DataAnnotations
