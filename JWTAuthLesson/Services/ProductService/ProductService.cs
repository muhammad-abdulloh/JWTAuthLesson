using JWTAuthLesson.DataAccess;
using JWTAuthLesson.Entities;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JWTAuthLesson.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly AuthDbContext _authDbContext;

        public ProductService(AuthDbContext authDbContext)
        {
            _authDbContext = authDbContext;
        }

        public async ValueTask<Product> CreateProduct(ProductDTO productDTO)
        {
            Product product = new Product()
            {
                ProductName = productDTO.ProductName,
                Category = productDTO.Category,
                Comment = productDTO.Comment,
                Price = productDTO.Price,
                Date = productDTO.Date,
                Condition = productDTO.Condition,
            };

            await _authDbContext.Products.AddAsync(product);
            var x = await _authDbContext.SaveChangesAsync();
            if (x >= 1)
            {
                return product;
            }
            throw new Exception("Product Not Saved in Database, Check your date");

        }

        public async ValueTask<bool> DeleteProduct(int Id)
        {
            Product product = await _authDbContext.Products.FirstOrDefaultAsync(x => x.Id == Id);

            if (product != null)
            {
                _authDbContext.Products.Remove(product);
                await _authDbContext.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async ValueTask<IEnumerable<Product>> GetAllProduct()
        {
            var products = await _authDbContext.Products.ToListAsync();

            return products;
        }

        public async ValueTask<Product> GetProductById(int Id)
        {
            Product product = await _authDbContext.Products.FirstOrDefaultAsync(x => x.Id == Id);
            
            return product;
        }

        public async ValueTask<Product> UpdateProduct(ProductDTO productDTO, int Id)
        {
            Product product = await _authDbContext.Products.FirstOrDefaultAsync(x => x.Id == Id);

            if (product != null)
            {
                product.ProductName = productDTO.ProductName;
                product.Category = productDTO.Category;
                product.Comment = productDTO.Comment;
                product.Price = productDTO.Price;
                product.Date = productDTO.Date;
                product.Condition = productDTO.Condition;

                _authDbContext.Products.Update(product);
                await _authDbContext.SaveChangesAsync();

                return product;
            }

            throw new Exception("Not changed product items");

        }
    }
}
