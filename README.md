# Aggregation Service

> There are only two hard things in Computer Science: cache invalidation and naming things.  
> -- Phil Karlton

A simple example of how to setup a Web API that fethces data from a 3rd party Data Service, does some (very simple) transformation, stores it in a local cache.

![Diagrams](/docs/aggragation-service.png)

Concepts in use:

- [Dependency Injection](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-9.0)
- [Caching](https://en.wikipedia.org/wiki/Cache_(computing))
- [Domain Transfer Objects](https://www.baeldung.com/java-dto-pattern)
- [Service Oriented Architecture](https://en.wikipedia.org/wiki/Service-oriented_architecture)