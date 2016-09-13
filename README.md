# Server side development standards - data api

This repository holds the example defining server side development standards for a data API

## Principles

1. Stateless services
2. Keep it simple - crud services have no domain model, just a repository
3. Composition over inheritence
4. Paging for lists - limit list of data with links to next, prev
5. Ioc the IoC container :)
6. Onion architecture - domain model has no dependencies, repo and api and host on outside

## Technologies

- ORM: Dapper
- IoC: Autofac ?
- Unit Testing: Xunit
- Middleware: WebApi