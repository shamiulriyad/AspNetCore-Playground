using System.Buffers;
using Microsoft.AspNetCore.Mvc;
using asp_net_ecommerce_web_api.Models;
using asp_net_ecommerce_web_api.DTOs;

namespace asp_net_ecommerce_web_api.Controllers
{
   [ApiController]
[Route("api/categories")]
public class CategoryController : ControllerBase
{
    private static List<Category> categories = new List<Category>(); 


    [HttpGet]
    // GET:/api/categories   ;; All categories with optional search
    public IActionResult GetCategories([FromQuery] string? searchValues)
    {
        if (!string.IsNullOrEmpty(searchValues))
        {
            var searchCategories = categories.Where(c => c.Name != null && c.Name.Contains(searchValues, StringComparison.OrdinalIgnoreCase)).ToList();
            return Ok(searchCategories);
        }

        return Ok(categories);
    }




[HttpPost]
// POST:/api/categories  ;; Create a new category
public IActionResult CreateCategories([FromBody] CategoryCreateDtos categoryData)
{
    if (string.IsNullOrEmpty(categoryData.Name))
    {
        return BadRequest("Category name is required.");
    }
    if (categoryData.Name.Length < 3)
    {
        return BadRequest("Category name must be at least 3 characters long.");
    }

    var category = new Category
    {
        CategoryId = Guid.NewGuid(),
        Name = categoryData.Name,
        Description = categoryData.Description,
        CreatedAt = DateTime.UtcNow
    };

    categories.Add(category);

    return Created($"/api/categories/{category.CategoryId}", category);
}


// DELETE:/api/categories/{id}  ;; Delete category by id
    [HttpDelete("{categoryId:guid}")]
public IActionResult DeleteCategoryById(Guid categoryId)
{
    var foundCategory = categories.FirstOrDefault(c => c.CategoryId == categoryId);
    
    if (foundCategory is null)
    {
        return NotFound("Category with this id not found.");
    }

    categories.Remove(foundCategory);
    return NoContent();
}

// PUT:/api/categories/{id}  ;; Update category by id
    [HttpPut("{categoryId:guid}")]
public IActionResult UpdateCategoryById(Guid categoryId, [FromBody] Category categoryData)
{
    var foundCategory = categories.FirstOrDefault(c => c.CategoryId == categoryId);

    if (foundCategory is null)
        return NotFound("Category not found.");

    if (string.IsNullOrEmpty(categoryData.Name))
        return BadRequest("Category name is required.");


    foundCategory.Name = categoryData.Name;
    foundCategory.Description = categoryData.Description;
    foundCategory.CreatedAt = foundCategory.CreatedAt; 

    return Ok(foundCategory);
}


}
}