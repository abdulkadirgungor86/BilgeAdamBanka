# Bank API - Credit Card Management System

This repository contains a **Bank API** developed with a layered architecture. The API manages credit card information with operations such as creating, retrieving, updating, and deleting data. Below is an overview of the project structure and its components.

---

## Project Architecture

The project follows a clean and organized layered architecture with the following components:

### 1. **ENTITIES**
   - **Purpose**: Represents the core domain models.
   - **Details**: Defines the structure and properties of database entities (e.g., `UserCardInfo`, `CreditCard`).

### 2. **DTO (Data Transfer Objects)**
   - **Purpose**: Encapsulates data and minimizes data exposure.
   - **Details**: Contains lightweight objects (e.g., `UserCardInfoDTO`) used for transferring data between layers.

### 3. **DAL (Data Access Layer)**
   - **Purpose**: Handles database interactions.
   - **Details**: Contains repositories and database access methods to perform CRUD operations.

### 4. **CONF (Configuration Layer)**
   - **Purpose**: Centralizes configuration settings for the application.
   - **Details**: Includes configurations like dependency injection, middleware, and other setup settings.

### 5. **BLL (Business Logic Layer)**
   - **Purpose**: Contains the business rules and logic.
   - **Details**: Handles the core logic for managing credit cards, such as validation and processing.

### 6. **APIMODEL**
   - **Purpose**: Contains request and response models for API endpoints.
   - **Details**: Defines structured models for data exchange, e.g., `CheckCreditCardRequestModel`, `AddCreditCardResponseModel`.

### 7. **IOC (Inversion of Control Layer)**
   - **Purpose**: Manages dependency injection and service lifetimes.
   - **Details**: Registers services (e.g., `IUserCardInfoManager`) and their implementations in the DI container.

### 8. **MAP (Mapping Layer)**
   - **Purpose**: Maps objects between different layers.
   - **Details**: Uses libraries like **AutoMapper** to transform data between entities, DTOs, and API models.

### 9. **UI (User Interface Layer)**
   - **Purpose**: Frontend components for interaction.
   - **Details**: Can contain a web-based or desktop interface interacting with the API.

### 10. **VALIDATION**
   - **Purpose**: Enforces data validation rules.
   - **Details**: Implements validation logic for request models (e.g., `CheckCreditCardRequestModel`).

---

## API Endpoints

### 1. `GET api/CreditCard/GetActiveCreditCards`
   - **Description**: Retrieves all active credit cards.
   - **Response**: Returns a list of active credit cards or a 404 error if none are found.

### 2. `GET api/CreditCard/GetActiveCreditCard`
   - **Description**: Retrieves details of a specific active credit card.
   - **Request Parameter**: `id` (integer)
   - **Response**: Returns credit card details or a 404 error if not found.

### 3. `POST api/CreditCard/CheckCreditCard`
   - **Description**: Validates credit card information.
   - **Request Body**: `CheckCreditCardRequestModel`
   - **Response**: Confirmation or an error message.

### 4. `POST api/CreditCard/AddCreditCard`
   - **Description**: Adds a new credit card.
   - **Request Body**: `AddCreditCardRequestModel`
   - **Response**: Success or failure message.

### 5. `PUT api/CreditCard/UpdateCreditCard`
   - **Description**: Updates credit card information.
   - **Request Body**: `UpdateCreditCardRequestModel`
   - **Response**: Success or failure message.

### 6. `DELETE api/CreditCard/DeleteCreditCard`
   - **Description**: Deletes a credit card asynchronously.
   - **Request Parameter**: `CreditCardNumber` (string)
   - **Response**: Confirmation or an error message.

### 7. `DELETE api/CreditCard/DestroyCreditCard`
   - **Description**: Permanently removes a credit card.
   - **Request Parameter**: `CreditCardNumber` (string)
   - **Response**: Confirmation or an error message.

---

## Technologies Used

- **.NET Core**: Framework for building the API.
- **AutoMapper**: Simplifies object-to-object mapping.
- **Entity Framework**: Facilitates database interactions.
- **SOLID Principles**: Ensures scalable and maintainable code.
- **Dependency Injection**: Manages service lifetimes and resolves dependencies.

---

## How to Run

1. Clone the repository.
2. Configure the connection string in the configuration file.
3. Run database migrations to set up the database schema.
4. Start the application using your preferred IDE or CLI.

---

This API is designed to be extendable, maintainable, and efficient, following industry best practices. Let me know if you need any additional details or modifications!
