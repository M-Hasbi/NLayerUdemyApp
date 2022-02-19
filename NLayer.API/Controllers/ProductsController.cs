using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Service;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Product> _service;
        public ProductsController(IMapper mapper, IService<Product> service)
        {
            _mapper = mapper;
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<Product>? products = await _service.GetAllAsync();
            List<ProductDto>? productsDtos = _mapper.Map<List<ProductDto>>(products.ToList());
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productsDtos));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Product? product = await _service.GetByIdAsync(id);
            ProductDto? productsDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productsDto));
        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            Product? product = await _service.AddAsync(_mapper.Map<Product>(productDto));
            ProductDto? productsDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, productsDto));
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {
            await _service.Update(_mapper.Map<Product>(productDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetByIdAsync(id);
            await _service.Delete(product);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
