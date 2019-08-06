

// CORE

1. Filters
	i)  Exception Filter (CustomExceptionFilter.cs)
	ii) Authorization  (CustomAuthorization.cs)

2. Middlewares
	i)  Exception Middleware (MyCustomExceptionMiddleware.cs)
	ii) Logger Middleware  (MyLoggerMiddleware.cs)

3. Entity Framework  -> DatabaseModels, DBContexts

	Package Manager Console
	$ Scaffold-DbContext "Server=00.0.00.000;database=xxxxxxxxxxxxx;uid=xxxxxxxxxxxxx;pwd=xxxxxxxxxxxxx" Microsoft.EntityFrameworkCore.SqlServer -o DatabaseModels -tables "Customer" -contextdir DBContexts -context MyDbContext
						//Server=00.0.00.000;database=xxxxxxxxxxxxx;persist security info=True;Integrated Security=SSPI;" Microsoft.EntityFrameworkCore.SqlServer -o DatabaseModels -tables "customer" -contextdir DBContexts -context MyDbContext -Force
	i) DatabaseModels
		a) Clientuser.cs (Get only one table from database)

	ii) DBContexts - generate context class for Clientuser table