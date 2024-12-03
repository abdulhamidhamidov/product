
using Infrostruckture.Commond;
using Infrostruckture.Models;
using Infrostruckture.Services;

SqlHellpers sqlHellpers = new SqlHellpers();


ProductServices productServices = new ProductServices();

Console.WriteLine(productServices.Delete(2));

