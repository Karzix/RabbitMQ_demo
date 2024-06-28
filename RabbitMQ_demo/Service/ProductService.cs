using RabbitMQ_demo.Data;
using RabbitMQ_demo.Model;
using RabbitMQ_demo.RabbitMQ;

namespace RabbitMQ_demo.Service
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly IRabitMQProducer _rabitMQProducer;
        public ProductService(ApplicationDBContext dbContext, IRabitMQProducer rabitMQProducer)
        {
            _dbContext = dbContext;
            _rabitMQProducer = rabitMQProducer;
        }
        public IEnumerable<Product> GetProductList()
        {
            return _dbContext.Products.ToList();
        }
        public Product GetProductById(int id)
        {
            return _dbContext.Products.Where(x => x.ProductId == id).FirstOrDefault();
        }
        public Product AddProduct(Product product)
        {
            //var result = _dbContext.Products.Add(product);
            //_dbContext.SaveChanges();
            _rabitMQProducer.SendProductMessage(product, "product");
            return product;
        }
        public Product UpdateProduct(Product product)
        {
            var result = _dbContext.Products.Update(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }
        public bool DeleteProduct(int Id)
        {
            var filteredData = _dbContext.Products.Where(x => x.ProductId == Id).FirstOrDefault();
            var result = _dbContext.Remove(filteredData);
            _dbContext.SaveChanges();
            return result != null ? true : false;
        }
    }
}
