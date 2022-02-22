using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Services;

namespace NLayer.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, ICategoryService categoryService, IMapper mapper)
        {
            _productService = productService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _productService.GetProductsWithCategory());
        }

        public async Task<IActionResult> Save()
        {
            IEnumerable<Category>? categories = await _categoryService.GetAllAsync();
            List<CategoryDto>? categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());

            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {

                await _productService.AddAsync(_mapper.Map<Product>(productDto));
                return RedirectToAction(nameof(Index));
            }
            IEnumerable<Category>? categories = await _categoryService.GetAllAsync();
            List<CategoryDto>? categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());

            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name");

            return View();
        }
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            await _productService.Update(product);

            IEnumerable<Category>? categories = await _categoryService.GetAllAsync();
            List<CategoryDto>? categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());

            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name", product.CategoryId);

            return View(_mapper.Map<ProductDto>(product));
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                await _productService.AddAsync(_mapper.Map<Product>(productDto));
                return RedirectToAction(nameof(Index));
            }
            IEnumerable<Category>? categories = await _categoryService.GetAllAsync();
            List<CategoryDto>? categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());

            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name", productDto.CategoryId);

            return View(productDto);

        }


    }
}
