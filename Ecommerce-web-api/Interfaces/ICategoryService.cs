using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using asp_net_ecommerce_web_api.DTOs;
using asp_net_ecommerce_web_api.Models;


namespace asp_net_ecommerce_web_api.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryReadDtos>> GetAllCategories();
        Task<CategoryReadDtos?> GetCategoryById(Guid categoryId);
        Task<CategoryReadDtos> CreateCategory(CategoryCreateDtos categoryData);
        Task<CategoryReadDtos?> UpdateCategoryById(Guid categoryId, CategoryUpdateDtos categoryData);
        Task<bool> DeleteCategoryById(Guid categoryId);



    }
}
