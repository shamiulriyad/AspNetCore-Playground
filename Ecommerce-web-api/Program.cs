using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

app.UseHttpsRedirection();

// In-memory Category List


app.MapGet("/", () => "Hello World!");


app.MapControllers();
app.Run();

// Category Model


// category -> products 
//CRUD

//Create -> create a catagory -> post : /api/category
//Read -> Read a catagory -> GET  : /api/category
//Update ->Upadate a catagory -> put : /api/category
//Delete -> Delete a catagory -> Delete : /api/category

//MVC = Model View Controller





//command
/*

 dotnet run --project Ecommerce-web-api
 http://localhost:5025/api/categories
 http://localhost:5025/api/categories

*/


