namespace Mango.Web.Controllers
{
    using Mango.Web.Models;
    using Mango.Web.Services;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

    public class ProductController : Controller
    {
        IProductService ProductService;

        public ProductController(IProductService productService)
        {
            this.ProductService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public async Task<IActionResult> ProductIndex()
        {
            List<Product> products = new List<Product>();
            var response = await ProductService.GetAllProductsAsync<Response>();
            if (response != null && response.Succeeded)
            {
                products = JsonConvert.DeserializeObject<List<Product>>(Convert.ToString(response.Result));
            }

            return View(products);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductCreate(Product model)
        {
            if (ModelState.IsValid)
            {
                var response = await ProductService.CreateProductAsync<Response>(model);
                if (response != null && response.Succeeded)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }

            return View(model);
        }

        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        public async Task<IActionResult> ProductEdit(int productId)
        {
            var response = await ProductService.GetProductByIdAsync<Response>(productId);
            if (response != null && response.Succeeded)
            {
                var product = JsonConvert.DeserializeObject<Product>(Convert.ToString(response.Result));
                return View(product);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductEdit(Product model)
        {
            if (ModelState.IsValid)
            {
                var response = await ProductService.UpdateProductAsync<Response>(model);
                if (response != null && response.Succeeded)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }

            return View(model);
        }

        public async Task<IActionResult> ProductDelete(int productId)
        {
            var response = await ProductService.GetProductByIdAsync<Response>(productId);
            if (response != null && response.Succeeded)
            {
                var product = JsonConvert.DeserializeObject<Product>(Convert.ToString(response.Result));
                return View(product);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductDelete(Product model)
        {
            var response = await ProductService.DeleteProductAsync<Response>(model.ProductId);
            if (response.Succeeded)
            {
                return RedirectToAction(nameof(ProductIndex));
            }

            return View(model);
        }
    }
}
