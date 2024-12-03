using Infrostruckture.Models;

namespace Infrostruckture.Interface;

interface IProduct
{
    bool CreateProduct(Product product);
    List<Product> GetProducts();
    Product GetByIdProduct(int id);
    bool Update(Product product);
    bool Delete(int id);
}