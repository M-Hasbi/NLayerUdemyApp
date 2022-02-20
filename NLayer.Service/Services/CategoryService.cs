using AutoMapper;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var category = await _categoryRepository.GetSingleCategoryWithProducts(categoryId);
            var categoryDto = _mapper.Map<CategoryWithProductDto>(category);
            return CustomResponseDto<CategoryWithProductDto>.Success(200, categoryDto);

        }
    }
}
