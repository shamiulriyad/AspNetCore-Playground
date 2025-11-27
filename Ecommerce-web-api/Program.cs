using System;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseHttpsRedirection();

// In-memory Category List
List<Category> categories = new List<Category>();

app.MapGet("/", () => "Hello World!");

// GET: All categories
app.MapGet("/api/categories", () =>
{
    return categories;
});

// POST: Create a new category
app.MapPost("/api/categories", () =>
{
    var category = new Category
    {
        CategoryId = Guid.Parse("c8afa85f-0895-432b-8c78-3f9f6be36010"),
        Name = "Electronic",
        Description = "If you need it",
        CreatedAt = DateTime.UtcNow
    };

    categories.Add(category);

    return Results.Created($"/api/categories/{category.CategoryId}", category);
});




app.MapDelete("/api/categories", () =>
{

    var foundcategory=categories.FirstOrDefault(category=>category. CategoryId== Guid.Parse("c8afa85f-0895-432b-8c78-3f9f6be36010"));
     if (foundcategory is null)
        return Results.NotFound("Category not found");

    categories.Remove(foundcategory);

    return Results.NoContent();
});


app.Run();

// Category Model
public record Category
{
    public Guid CategoryId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime? CreatedAt { get; set; }
}

// category -> products 
//CRUD

//Create -> create a catagory -> post : /api/category
//Read -> Read a catagory -> GET  : /api/category
//Update ->Upadate a catagory -> put : /api/category
//Delete -> Delete a catagory -> Delete : /api/catego




//command
/*

 dotnet run --project Ecommerce-web-api
 http://localhost:5025/api/categories
 http://localhost:5025/api/categories

*/


