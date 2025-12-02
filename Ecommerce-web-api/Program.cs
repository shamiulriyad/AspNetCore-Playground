using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseHttpsRedirection();

// In-memory Category List
List<Category> categories = new List<Category>();

app.MapGet("/", () => "Hello World!");

// GET: All categories
app.MapGet("/api/categories", () => categories);

// POST: Create a new category
app.MapPost("/api/categories", (Category categoryData) =>
{
    if (string.IsNullOrEmpty(categoryData.Name))
        return Results.BadRequest("Category name is required.");

    var category = new Category
    {
        CategoryId = Guid.NewGuid(),
        Name = categoryData.Name,
        Description = categoryData.Description,
        CreatedAt = DateTime.UtcNow
    };

    categories.Add(category);

    return Results.Created($"/api/categories/{category.CategoryId}", category);
});

// DELETE: Delete category by id
app.MapDelete("/api/categories/{id}", (Guid id) =>
{
    var foundCategory = categories.FirstOrDefault(c => c.CategoryId == id);
    if (foundCategory == null)
    {
        return Results.NotFound("Category with this id not found.");
    }

    if (foundCategory is null)
        return Results.NotFound("Category not found.");

    categories.Remove(foundCategory);

    return Results.NoContent();
});

app.MapPut("/api/categories/{id}", (Guid id, Category categoryData) =>
{
    var foundCategory = categories.FirstOrDefault(c => c.CategoryId == id);

    if (foundCategory is null)
        return Results.NotFound("Category not found.");

    if (string.IsNullOrEmpty(categoryData.Name))
        return Results.BadRequest("Category name is required.");

    // Full update (PUT replaces everything)
    foundCategory.Name = categoryData.Name;
    foundCategory.Description = categoryData.Description;
    foundCategory.CreatedAt = foundCategory.CreatedAt; // Keep original created date

    return Results.Ok(foundCategory);
});

app.Run();

// Category Model
public record Category
{
    public Guid CategoryId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }=string.Empty;
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


