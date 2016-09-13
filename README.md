# Server side development standards - data api

This repository holds the example defining server side development standards for a data API

##Principles

1. Stateless services
2. Keep it simple - crud services have no domain model, just a repository
3. Composition over inheritence
4. Paging for lists - limit list of data with links to next, prev
5. Ioc the IoC container :)
6. Onion architecture - domain model has no dependencies, repo and api and host on outside

##Technologies

- ORM: Dapper
- IoC: Autofac ?
- Unit Testing: Xunit
- Middleware: WebApi

###Use paging extension in controller
```CSharp
int offset = page * pageSize;
var results = await _contactRepository.GetContactsAsync(offset, pageSize);
            
var responseBody = results.GetResponseBody(Request.RequestUri.AbsolutePath, page, pageSize);

return Ok(responseBody);
```

###Extension code
```CSharp
 public static object GetResponseBody<T>(this IEnumerable<T> data, string basePath, int page, int pageSize) {

    int prevPage = page == 0 ? 0 : page - 1;

    // if the row count is less than page size assume this is the last page
    int nextPage = data.Count() < pageSize ? page : page + 1;

    string prevArgs = $"?page={prevPage}&pageSize={pageSize}";
    string nextArgs = $"?page={nextPage}&pageSize={pageSize}";

    var responseBody = new {
        data = data,
        links = new {
            previous = basePath + prevArgs,
            next = basePath + nextArgs
        }
    };

    return responseBody;

}
```