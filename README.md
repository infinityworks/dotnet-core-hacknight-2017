# dotnet-core-hacknight-2017

# Run the Web template

```
dotnet new web
```

# Run it

```
dotnet restore
dotnet run
```

# Add MVC

```
dotnet package add Microsoft.AspNetCore.Mvc
dotnet restore
```

* Add `services.AddMvc();` to the `ConfigureServices` method.
* Add `app.UseMvcWithDefaultRoute();` to the `Configure` method.

* Create a `Home` controller and `Index` action.

### ./Controllers/HomeController.cs

```C#
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller 
{
    public ActionResult Index()
    {
        return View();
    }
}
```

### ./Views/Home/Index.cshtml

Use HTML 5 for fun. ;)

```HTML
<!DOCTYPE html>
<title>Hello World</title>
<p>Hello World
</html>
```

# Create a CatApi project

```
dotnet new library
dotnet add package System.Xml.XmlSerializer
dotnet restore
```

# Setup a solution to link everything together

```
dotnet new sln
dotnet sln add ./src/Web/Web.csproj
dotnet sln add ./src/CatApi/CatApi.csproj
```

# Create the API library code

See commit.
