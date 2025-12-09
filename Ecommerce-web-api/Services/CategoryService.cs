using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using asp_net_ecommerce_web_api.Models;
using asp_net_ecommerce_web_api.DTOs;
using asp_net_ecommerce_web_api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using asp_net_ecommerce_web_api.Interfaces;
using AutoMapper;


namespace asp_net_ecommerce_web_api.Services
{
    public class CategoryService : ICategoryService
    {
      //  private static readonly List<Category> _categories = new List<Category>();
        private readonly AppDbContext _context = new AppDbContext(new DbContextOptions<AppDbContext>());
        private readonly IMapper _mapper;
        public CategoryService(AppDbContext appDbContext, IMapper mapper)
        {
            _context = appDbContext;
            _mapper = mapper;
        }

        public async Task<List<CategoryReadDtos?>> GetAllCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return _mapper.Map<List<CategoryReadDtos>>(categories);
        }
        public async Task<CategoryReadDtos?> GetCategoryById(Guid categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);
            if (category == null)
            {
                return null;
            }
            var categoryDto = _mapper.Map<CategoryReadDtos>(category);
            return categoryDto;
        }

        public async Task<CategoryReadDtos> CreateCategory(CategoryCreateDtos categoryData)
        {
            var category = _mapper.Map<Category>(categoryData);
            category.CategoryId = Guid.NewGuid();
            await _context.Categories.AddAsync(category);
            await  _context.SaveChangesAsync();
            var categoryDto = _mapper.Map<CategoryReadDtos>(category);
            return categoryDto;
        }

        public async Task<CategoryReadDtos?> UpdateCategoryById(Guid categoryId, CategoryUpdateDtos categoryData)
        {
            var category = await _context.Categories.FindAsync(categoryId);
            if (category == null)
            {
                return null;
            }
            _mapper.Map(categoryData, category);
            await _context.SaveChangesAsync();
            var categoryDto = _mapper.Map<CategoryReadDtos>(category);
            return categoryDto;
        }

        public async Task<bool> DeleteCategoryById(Guid categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);
            if (category == null)
            {
                return false;
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }

        
}
}