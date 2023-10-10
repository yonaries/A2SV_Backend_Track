# Clean architecture
Clean architecture is a domain-centric approach to organizing dependencies, emphasizing clean separation of concerns. It encourages dependency inversion, focusing on interfaces over concrete dependencies, and minimizing direct dependencies on infrastructure.

Clean architecture is best suited for applications with complex business logic, aligned with domain-driven design. It helps keep the domain model pure and free from dependencies. However, it might be overkill for simple CRUD applications or projects with minimal conditional logic in the domain model.

The architecture consists of three main projects:

1. **Domain:** Contains business logic, including entities, value objects, domain services, custom exceptions, domain events, and specifications.

2. **Infrastructure:** Handles external dependencies and implementations of abstractions, such as data access (e.g., BlogContext), caching, third-party APIs, file system operations.

3. **Web:** An ASP.Net Core project serving as the entry point. It includes API endpoints, controllers, views, DTOs, request/response models, filters, and other ASP.Net Core components.

4. **Application:** Contains application logic, such as commands, queries, and handlers. It also includes application services that orchestrate domain logic and infrastructure components.