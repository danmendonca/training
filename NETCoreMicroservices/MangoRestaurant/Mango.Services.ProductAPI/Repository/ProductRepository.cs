namespace Mango.Services.ProductAPI.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Mango.Services.ProductAPI.DBContexts;
    using Mango.Services.ProductAPI.Dto;
    using Microsoft.EntityFrameworkCore;

    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Product> CreateOrUpdateProduct(Product product)
        {
            var productModel = this.mapper.Map<Models.Product>(product);
            if (product.ProductId > 0)
            {
                this.db.Products.Update(productModel);
            }
            else
            {
                this.db.Products.Add(productModel);
            }

            await this.db.SaveChangesAsync();

            return this.mapper.Map<Product>(productModel);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                var product = await this.db.Products.Where(p => p.ProductId == productId).FirstOrDefaultAsync();

                if (product != null)
                {
                    this.db.Products.Remove(product);
                    await this.db.SaveChangesAsync();

                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Product> GetProductById(int productId)
        {
            var product = await this.db.Products.Where(p => p.ProductId == productId).FirstOrDefaultAsync();
            return this.mapper.Map<Product>(product);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await this.db.Products.ToListAsync();
            return this.mapper.Map<List<Product>>(products);
        }
    }
}
