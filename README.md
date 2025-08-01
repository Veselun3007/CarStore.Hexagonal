# CarStore.Hexagonal

This repository contains a sample implementation of a Car Store system built following Hexagonal Architecture and DDD principles.

## Content

- [CarStore.Hexagonal](#carstorehexagonal)
- [Purpose & Learning Goals](#purpose--learning-goals)
- [Tasks](#tasks)
- [Domain Components Overview](#domain-components-overview)
  - [Base abstractions](#base-abstractions)
  - [Core Domain Entities](#core-domain-entities)
  - [Value Objects](#value-objects)
  - [Domain Events](#domain-events)
- [Persistence & EF Core Summary](#persistence--ef-core-summary)
- [CQRS & MediatR Integration Summary](#cqrs--mediatr-integration-summary)

## Purpose & Learning Goals

- Understand Hexagonal Architecture.
- Implement Dependency Injection with proper lifecycle management via extension methods for each layer.
- Practice EF Core Code-First Development including entity modeling, relationships, and migrations.
- Containerize the application with Docker and Docker Compose to simplify deployment and testing.

## Tasks

- Develop a solution according to Hexagonal (Ports & Adapters) architecture.
- Design application domain.
- Add CQRS to the application.


## Domain Components Overview

This section outlines the structure and behavior of core domain components based on Domain-Driven Design (DDD) principles.

### Base abstractions
| Name                 | Description                                                                        |
| -------------------- | ---------------------------------------------------------------------------------- |
| `AggregateRoot<TKey>`| Base class for aggregates that maintain domain invariants and handle domain events.|
| `Entity<TKey>`	   | Identity-based domain object.														|
| `IValueObject<T>`    | Interface for immutable, self-validating value objects.							|
| `IEventHandler`      | Internal domain event dispatcher.													|

### Core Domain Entities

#### `Car` *(Entity)*  
Represents a vehicle that can be listed for sale.

- **Properties**: `Make`, `Model`, `Vin (ValueObject)` , `Price (ValueObject)` 

---

#### `Listing` *(AggregateRoot)*  
Represents a car listed for sale.  
Acts as the transactional boundary and controls related entities (`Offer`, `TestDriveRequest`).

- **Properties**: `ListedPrice`, `Description`, `CreatedAt`, `Status`
- **Linked to**: `Car`, `Dealer`  
- **Contains**: `Offers`, `TestDriveRequests`  
- **Domain logic**: posting, canceling, reopening, accepting offers, test drives  
- **Emits domain events**: `OfferAccepted`

---

#### `Offer` *(Entity)*  
Represents a customer’s price proposal for a listing.

- **Properties**: `Price`, `CreatedAt`, `Status`  
- **Domain logic**: accept/decline offer, check offer freshness

---

#### `TestDriveRequest` *(Entity)*  
Represents a customer's test drive request for a listed car.

- **Properties**: `RequestedDate`, `CreatedAt`, `IsApproved`  
- **Domain logic**: validate request date, approve or reject

---

#### `User` *(Entity)*  
Represents a registered platform user.

- **Properties**: `FullName`, `Email (ValueObjects)` 

### Value Objects

| Name             | Description                                                                      |
| ---------------- | -------------------------------------------------------------------------------- |
| `VinCode`        | Ensures valid 17-character Vehicle Identification Number                         |
| `Money`          | Represents monetary value with currency, discount logic, and currency conversion |
| `CarDescription` | Ensures description is between 50 and 512 characters                             |
| `UserEmail`      | Validates email using `EmailAddressAttribute`                                    |
| `UserFullName`   | Validates full name using regex (e.g., "John Doe")                               |

### Domain Events

- **OfferAccepted:** emitted by Listing when an offer is accepted

## Persistence & EF Core Summary

The persistence layer uses Entity Framework Core to map domain models to a PostgreSQL database.

### What’s Implemented

- **Entity Mapping**  
  - Bidirectional mapping between domain models and database entities via Mapperly-based mappers.  
  - Custom mapping for Value Objects and Enums.

- **DbContext & Configuration**  
  - DbSets and Fluent API configurations with indexes for performance optimization.  
  - Entity configurations ensure schema consistency and use default constructors.

- **Data Access**  
  - Generic repository pattern with async CRUD operations.  
  - Related data loaded primarily through eager loading with.  

- **Migrations & Seeding**  
  - Database schema created and updated via EF Core migrations.  
  - Seed data added during migration for initial setup.

### Benefits

- Clear separation between domain and data concerns.  
- Efficient, maintainable data access layer with strong typing.  
- Performance improvements via indexing and explicit configuration.  
- Easy to extend, test, and maintain.


## CQRS & MediatR Integration Summary

The application now follows the CQRS (Command Query Responsibility Segregation) pattern using MediatR to decouple read and write operations and improve maintainability.

### What’s Implemented

- MediatR registration via assembly scanning.
- Structured application layer with grouped Commands and Queries.
- Implemented use cases for Listing, User, and Car aggregates, aligned with domain logic.

### Benefits

- Clear separation of read and write responsibilities.
- Commands encapsulate business rules and coordinate domain behavior.
- Improved maintainability, scalability, and testability.

