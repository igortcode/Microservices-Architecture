using ApiMS.Model;

namespace ApiMS.Interface
{
    public interface IProductRepository : IMongoDbRepository<Product>
    {
    }
}
