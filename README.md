# dotnet-core-hacknight-2017

# Run the Web template and run the output

```
dotnet new web
dotnet restore
dotnet run
```

[View Changes]([https://github.com/infinityworksltd/dotnet-core-hacknight-2017/commit/15597acf351f6324a8b8571b8eedfbbad0c269ef)

# Add MVC

```
dotnet add package Microsoft.AspNetCore.Mvc
dotnet restore
```

* Add `services.AddMvc();` to the `ConfigureServices` method.
* Add `app.UseMvcWithDefaultRoute();` to the `Configure` method.

* Create a `Home` controller and `Index` action.

[View Changes](https://github.com/infinityworksltd/dotnet-core-hacknight-2017/commit/6d54f19d869e01b959030caf6d50c12b61fd768d)

# Create a CatApi project & setup a solution to link everything together

```
dotnet new library
dotnet add package System.Xml.XmlSerializer
dotnet restore
```
```
dotnet new sln
dotnet sln add ./src/Web/Web.csproj
dotnet sln add ./src/CatApi/CatApi.csproj
```

[View Changes](https://github.com/infinityworksltd/dotnet-core-hacknight-2017/commit/a0ed7f07e2b57f17a681900fee30cad5de97a488)

# Create the API library code

[View Changes](https://github.com/infinityworksltd/dotnet-core-hacknight-2017/commit/a0ed7f07e2b57f17a681900fee30cad5de97a488)

# Add a reference to the API library from the MVC project

```
dotnet add reference ../CatApi/CatApi.csproj
```

[View Changes](https://github.com/infinityworksltd/dotnet-core-hacknight-2017/commit/6af7c482cb01cd94e442ffe16be88bf637e13c84)

# Configure MVC to automatically inject the new service into a controller

```
dotnet restore
dotnet run
```

[View Changes](https://github.com/infinityworksltd/dotnet-core-hacknight-2017/commit/76655424731fffac5dca31bc9d998ce62c91a765)

# View random cats

Add logging to the API client to help with debugging.

```
dotnet add package Microsoft.Extensions.Logging
```

Add a ViewModel, call the API etc., add a View to display everything.

[View Changes](https://github.com/infinityworksltd/dotnet-core-hacknight-2017/commit/a35b8fddab5499c0918189b009b1f2b3b00e5cbc)

# Add tests

```
dotnet new xunit
dotnet add reference ../../src/CatApi/CatApi.csproj
dotnet restore
```

Don't forget to add it to the solution.

```
dotnet test ./tests/CatApiTests/CatApiTests.csproj
```

[View Changes](https://github.com/infinityworksltd/dotnet-core-hacknight-2017/commit/253737f9dfd3e05ba22d8e98f1f19bbbedc6d40a)
