namespace Mango.Web.Services
{
    using Mango.Web.Models;

    public interface IProductService : IBaseService
    {
        Task<T> GetAllProductsAsync<T>();
        Task<T> GetProductByIdAsync<T>(int id);
        Task<T> CreateProductAsync<T>(Product product);
        Task<T> UpdateProductAsync<T>(Product product);
        Task<T> DeleteProductAsync<T>(int id);
    }
}
