using AutoMapper;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;

namespace NLayer.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IGenericRepository<Category> repo, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository, IMapper mapper) : base(repo, unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<CategoryWithProductDto>> GetSingleCategoryWithProducts(int categoryId)
        {
            Category? category = await _categoryRepository.GetSingleCategoryWithProducts(categoryId);
            CategoryWithProductDto? categoryDto = _mapper.Map<CategoryWithProductDto>(category);
            return CustomResponseDto<CategoryWithProductDto>.Success(200, categoryDto);

        }
    }
}
