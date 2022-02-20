using NLayer.Core.DTOs;
using NLayer.Core.Service;

namespace NLayer.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        public Task<CustomResponseDto<CategoryWithProductDto>> GetSingleCategoryWithProducts(int productId);
    }
}
