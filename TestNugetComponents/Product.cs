using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestNugetComponents
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }

    public interface IValueCalculator
    {
        decimal ValueProducts(params Product[] products);
    }

    public class LinQValueCalculator: IValueCalculator
    {
        private IDiscountHelper discounter;

        public LinQValueCalculator(IDiscountHelper discountParam)
        {
            discounter = discountParam;
        }

        public decimal ValueProducts(params Product[] products)
        {
            return discounter.ApplyDiscount(products.Sum(p => p.Price));
        }
    }

    public interface IDiscountHelper
    {
        decimal ApplyDiscount(decimal totalParam);
    }

    public class DefaultDiscountHelper : IDiscountHelper
    {
        //Adding a property to an Impletation Class
        //public decimal DiscountSize { get; set; }

        //Using Constructor Property in an Impletation class
        private decimal discountRate;

        public DefaultDiscountHelper(decimal discountParam)
        {
            discountRate = discountParam;
        }

        public decimal ApplyDiscount(decimal totalParam)
        {
            return (totalParam - (discountRate/100m*totalParam));
        }
    }

}
