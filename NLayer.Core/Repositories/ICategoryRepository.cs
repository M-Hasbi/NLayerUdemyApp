namespace NLayer.Core.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetSingleCategoryWithProducts(int categoryId);
    }
}
