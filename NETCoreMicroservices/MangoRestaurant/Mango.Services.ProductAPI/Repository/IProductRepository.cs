namespace Mango.Services.ProductAPI.Repository
{
    using Dto = Mango.Services.ProductAPI.Dto;

    public interface IProductRepository
    {
        Task<IEnumerable<Dto.Product>> GetProducts();
        Task<Dto.Product> GetProductById(int productId);
        Task<Dto.Product> CreateOrUpdateProduct(Dto.Product product);
        Task<bool> DeleteProduct(int productId);
    }
}
