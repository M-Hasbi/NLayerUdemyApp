using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Service;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    public class CategoriesController : ControllerBaseController
    {
        
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            
            _categoryService = categoryService;
        }

        //GET api/categories/GetSingleCategoryWithProducts/2
        [HttpGet("[action]/{categoryId}")]
        public async Task<IActionResult> GetSingleCategoryWithProducts(int categoryId)
        {
            return CreateActionResult(await _categoryService.GetSingleCategoryWithProducts(categoryId));
        }

        



    }
}
