## Libro Book Management System - Technical Design Document

> **Warning**
> If you need to show all commit which is not visible in the master branch you can access the notifications branch (all data is not visible in the master branch due to an error)

> **Note**
> Click here to view the documentation for this project
> <a href = "https://www.notion.so/Technical-Design-Document-Libro-Book-Management-System-3716ed2333eb4b3499d4edfe2a662162">Technical Design Document</a>

# Introduction
The Libro Book Management System is a web-based application designed to facilitate the management and discovery of books in a library setting. This technical design document provides an overview of the system's architecture, components, design patterns, database structure, authentication mechanisms, error handling, and other technical aspects.

# Project Overview
The Libro Book Management System offers various features such as user registration, book search and browsing, book transactions, patron profiles, and book and author management. The system aims to provide a user-friendly interface for both patrons and librarians/administrators.

# Scope
This technical design document covers the following aspects of the Libro Book Management System:

- Architecture: Clean Architecture, promoting modularity and testability.
- Design Patterns: CQRS (Command Query Responsibility Segregation), Domain-Driven Design (DDD), Service Pattern, Repository Pattern, and Unit of Work Pattern.
- Error Handling: Middleware-based logging for capturing and tracking important events, requests, and errors.
- Authentication: JWT (JSON Web Token) authentication for secure user authentication and authorization.
- Database Design: Utilizing a suitable database structure for storing book information, user profiles, and other relevant data.
- API Design: Designing and implementing the web APIs that support the system's functionality.
- Additional Features: Reading Lists, Book Reviews and Ratings, Notifications, and Book Recommendations.
# Clean Architecture
The Libro Book Management System follows the Clean Architecture principles. This architecture promotes modularity, maintainability, and testability by separating concerns and keeping the codebase flexible and adaptable to future changes. It consists of layers such as Domain, Application, Infrastructure, and Presentation, each with its own responsibilities and dependencies.

# CQRS (Command Query Responsibility Segregation)
CQRS is implemented in the Libro Book Management System to simplify complexity, improve scalability, and enhance performance. By separating read and write operations, the system can optimize each independently, resulting in better responsiveness and improved user experience. This approach allows for a more efficient and tailored architecture for handling commands (write operations) and queries (read operations).

# Domain-Driven Design (DDD)
Domain-Driven Design is employed in the Libro Book Management System to align the project with the business domain and promote a common language and understanding between developers and domain experts. This approach focuses on modeling core domain concepts and behaviors, resulting in a more robust and adaptable software system. It helps in creating flexible, maintainable, and testable code by emphasizing the domain's significance.

# Service Pattern
The Libro Book Management System utilizes the Service Pattern to encapsulate complex business logic and operations into reusable and cohesive service components. This pattern promotes modularity and separation of concerns, allowing for clean code organization, enhanced maintainability, and the composition of various services to achieve higher-level functionalities in the application.

# Repository Pattern
The Repository Pattern is employed in the Libro Book Management System to provide a layer of abstraction between the application and the data persistence layer. This pattern promotes separation of concerns and a cleaner code structure. It enables a consistent and standardized way of accessing and manipulating data, improving code maintainability, testability, and scalability.

# Unit of Work Pattern
The Unit of Work Pattern is utilized in the Libro Book Management System to manage transactions and ensure atomicity across multiple database operations. It provides a cohesive interface to perform multiple operations as a single unit, ensuring data consistency and integrity.

# Error Handling and Logging
The Libro Book Management System incorporates middleware-based logging to capture and track important events, requests, and errors throughout the application's execution. This approach enables centralized logging, easing debugging, monitoring, and analysis of application behavior, performance, and security. Middleware logging provides valuable insights for troubleshooting, auditing, and compliance purposes.

# FluentValidation Package
The FluentValidation package is used in the Libro Book Management System to simplify and enhance the validation process. It offers an easy and fluent syntax for defining validation rules, separating the validation logic from the domain models or view models. This separation of concerns promotes cleaner and more maintainable code. FluentValidation provides customizable error messages for validation failures, improving the user experience.

# Mapster Package
Mapster is employed in the Libro Book Management System to simplify the object mapping process. It offers a fluent and intuitive API for easily mapping objects between different types and structures. By automating the mapping process, Mapster reduces development time and effort, minimizing the need for writing repetitive mapping code manually.

# StackExchange.Redis Package
The StackExchange.Redis package is used in the Libro Book Management System to implement caching. Caching can significantly improve application performance by reducing the need to fetch data from slower data sources such as databases. It helps in handling high traffic loads and improves scalability. However, caching introduces additional complexity and requires careful management of cache expiration and invalidation strategies to ensure data consistency.

# Getting Started
To run the Libro Book Management System locally, follow the instructions below:

# Prerequisites
Docker: Install Docker on your machine.

# Steps
Clone the repository:
```https://github.com/alibarghouth/LibraryManagementSystem.git```

# Navigate to the project directory:
```cd LibraryManagementSystem```

# Build and run the Docker containers:
```docker-compose up --build```

