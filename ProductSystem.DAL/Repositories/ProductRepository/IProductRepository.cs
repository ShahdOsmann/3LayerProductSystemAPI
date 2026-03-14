
using ProductSystem.Common;
using ProductSystem.Common.Pagination;

namespace ProductSystem.DAL
{
    public interface IProductRepository: IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllWithCategoryAsync();

        Task<Product?> GetByIdWithCategoryAsync(int productId);
        Task<PagedResult<Product>> GetProductsPagination
           (PaginationParameters? paginationParameters = null, ProductFilterParameters? productFilterParameters = null);
    }
}
