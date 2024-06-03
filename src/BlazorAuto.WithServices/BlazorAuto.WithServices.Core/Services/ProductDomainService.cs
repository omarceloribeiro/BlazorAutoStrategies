using BlazorAuto.WithServices.Core.Interfaces.Repository;
using BlazorAuto.WithServices.Core.Interfaces.Services;
using BlazorAuto.WithServices.Core.Models;
using System.Net.Http.Headers;
using System.Reflection;

namespace BlazorAuto.WithServices.Core.Services
{
    public class ProductDomainService : CrudDomainServiceBase<Product>, IProductDomainService
    {
        public ProductDomainService(IProductRepository repository) : base(repository)
        {
        }

        public override Task<Product> Create(Product model)
        {
            ArgumentNullException.ThrowIfNull(model);
            ProductInvalidException.ValidatePriceNegative(model);
            
            return base.Create(model);
        }

        public override Task<Product> Update(Product model)
        {
            ArgumentNullException.ThrowIfNull(model);
            ProductInvalidException.ValidatePriceNegative(model);

            return base.Update(model);
        }
    }

    public class ProductInvalidException : ArgumentOutOfRangeException
    {
        public ProductInvalidException(string fieldName, string message) : base(fieldName, message)
        {   
        }

        public static void ValidatePriceNegative(Product product)
        {
            if (product.Price < 0)
                throw new ProductInvalidException("price", "Product price can't be negative");
        }
    }
    internal static class ProductValidations
    {
        public static void ValidateProductCreate(Product product)
        {
            if (product.Price < 0)
                throw new ArgumentOutOfRangeException("price", "Product price can't be negative");
        }
        public static void ValidateProductUpdate(Product product)
        {
            if (product.Price < 0)
                throw new ArgumentOutOfRangeException("price", "Product price can't be negative");
        }

        public static bool ValidatePriceNegative(decimal price) => price < 0;
        public static void ValidatePriceNegative(Product product)
        {
            if (product.Price < 0)
                throw new ArgumentOutOfRangeException("price", "Product price can't be negative");
        }
    }
}
