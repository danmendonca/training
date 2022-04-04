namespace Mango.Services.ProductAPI.Controllers
{
    using Mango.Services.ProductAPI.Repository;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/products")]
    public class ProductAPIController : ControllerBase
    {
        protected Dto.Response response;
        private readonly IProductRepository productRepository;

        public ProductAPIController(IProductRepository productRepository)
        {
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.response = new Dto.Response();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                var products = await this.productRepository.GetProducts();
                this.response.Result = products;
            }
            catch (Exception ex)
            {
                this.response.Succeeded = false;
                this.response.ErrorMessages = new List<string> { ex.Message };
            }

            return this.response;
        }

        [HttpGet]
        [Route("{productId}")]
        public async Task<object> Get(int productId)
        {
            try
            {
                this.response.Result = await this.productRepository.GetProductById(productId);                
            }
            catch (Exception ex)
            {
                this.response.Succeeded = false;
                this.response.ErrorMessages = new List<string> { ex.Message };
            }

            return this.response;
        }

        [HttpPost]
        public async Task<object> Update([FromBody] Dto.Product product)
        {
            try
            {
                this.response.Result = await this.productRepository.CreateOrUpdateProduct(product);
            }
            catch (Exception ex)
            {
                this.response.Succeeded = false;
                this.response.ErrorMessages = new List<string> { ex.Message };
            }

            return this.response;
        }

        [HttpPut]
        public async Task<object> Create([FromBody] Dto.Product product)
        {
            try
            {
                this.response.Result = await this.productRepository.CreateOrUpdateProduct(product);
            }
            catch (Exception ex)
            {
                this.response.Succeeded = false;
                this.response.ErrorMessages = new List<string> { ex.Message };
            }

            return this.response;
        }

        [HttpDelete]
        [Route("{productId}")]
        public async Task<object> Delete(int productId)
        {
            try
            {
                this.response.Result = await this.productRepository.DeleteProduct(productId);
            }
            catch (Exception ex)
            {
                this.response.Succeeded = false;
                this.response.ErrorMessages = new List<string> { ex.Message };
            }

            return this.response;
        }

    }
}
