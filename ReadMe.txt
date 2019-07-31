

// CORE

1. Filters
	i)  Exception Filter (CustomExceptionFilter.cs)
	ii) Authorization  (CustomAuthorization.cs)

2. Middlewares
	i)  Exception Middleware (MyCustomExceptionMiddleware.cs)
	ii) Logger Middleware  (MyLoggerMiddleware.cs)

3. Entity Framework  -> DatabaseModels, DBContexts

	Package Manager Console
	$ Scaffold-DbContext "Server=###;database=#####;uid=####;pwd=###" Microsoft.EntityFrameworkCore.SqlServer -o DatabaseModels -tables "ClientUser" -contextdir DBContexts -context MyDbContext

	i) DatabaseModels
		a) Clientuser.cs (Get only one table from database)

	ii) DBContexts - generate context class for Clientuser table