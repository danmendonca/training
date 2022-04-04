namespace Mango.Web.Services
{
    using System.Threading.Tasks;
    using Mango.Web.Models;

    public class ProductService : BaseService, IProductService
    {
        public ProductService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<T> CreateProductAsync<T>(Product product)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = ServiceDependencies.APIType.POST,
                Data = product,
                Url = ServiceDependencies.ProductAPIBase + "/api/products",
                AccessToken = string.Empty
            });
        }

        public async Task<T> DeleteProductAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = ServiceDependencies.APIType.DELETE,
                Url = ServiceDependencies.ProductAPIBase + "/api/products/" + id,
                AccessToken = string.Empty
            });
        }

        public async Task<T> GetAllProductsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = ServiceDependencies.APIType.GET,
                Url = ServiceDependencies.ProductAPIBase + "/api/products",
                AccessToken = string.Empty
            });
        }

        public async Task<T> GetProductByIdAsync<T>(int id)
        { 
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = ServiceDependencies.APIType.GET,
                Url = ServiceDependencies.ProductAPIBase + "/api/products/" + id,
                AccessToken = string.Empty
            });
        }

        public async Task<T> UpdateProductAsync<T>(Product product)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = ServiceDependencies.APIType.PUT,
                Data = product,
                Url = ServiceDependencies.ProductAPIBase + "/api/products",
                AccessToken = string.Empty
            });
        }
    }
}
