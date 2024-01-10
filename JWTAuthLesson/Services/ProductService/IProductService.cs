using JWTAuthLesson.Entities;

namespace JWTAuthLesson.Services.ProductService
{
    public interface IProductService
    {
        public ValueTask<Product> CreateProduct(ProductDTO productDTO);
        public ValueTask<bool> DeleteProduct(int Id);
        public ValueTask<Product> UpdateProduct(ProductDTO productDTO, int Id);
        public ValueTask<IEnumerable<Product>> GetAllProduct();
        public ValueTask<Product> GetProductById(int Id);
    }
}
