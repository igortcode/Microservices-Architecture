using ApiMS.Interface;
using ApiMS.Model;
using ApiMS.Settings;
using Microsoft.Extensions.Options;

namespace ApiMS.Repository
{
    public class ProductRepository : MongoDbRepository<Product>,  IProductRepository
    {
        public ProductRepository(IOptions<StoreDatabaseSettings> options) : base(options){}
    }
}
