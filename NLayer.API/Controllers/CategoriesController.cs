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
        private readonly IMapper _mapper;
        private readonly IService<Category> _service;
        private readonly ICategoryService _categoryService;
        public CategoriesController(IMapper mapper, IService<Category> service, ICategoryService categoryService)
        {
            _mapper = mapper;
            _service = service;
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
