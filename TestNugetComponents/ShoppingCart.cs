using System.Linq;

namespace TestNugetComponents
{
    public class ShoppingCart
    {
        private IValueCalculator calculator;
        protected Product[] products;
        public ShoppingCart(IValueCalculator calcuParam)
        {
            calculator = calcuParam;
            products = new[] 
                {
                    new Product {Name = "Kayak", Price = 275M},
                    new Product {Name = "Lifejacket", Price = 48.95M},
                    new Product {Name = "Soccer ball", Price = 19.50M},
                    new Product {Name = "Stadium", Price = 79500M}
                };
        }

        public virtual decimal CalculateStockValue()
        {
            //define the set of products to sum
            

            //Calculate the total value of products
            decimal totalValue = calculator.ValueProducts(products);

            return totalValue;
        }

        public class LimitShoppingCart  : ShoppingCart
        {
            public LimitShoppingCart(IValueCalculator calcuParam) : base(calcuParam)
            {

            }

            public override decimal CalculateStockValue()
            {
                //filter out any items that are over the limit
                var filteredProducts = products
                    .Where(e => e.Price < ItemLimit);

                //Perform the calculation
                return calculator.ValueProducts(filteredProducts.ToArray());
            }

            public decimal ItemLimit { get; set; }
        }

        public class IterativeValueCalculator : IValueCalculator
        {
            public decimal ValueProducts(params Product[] products)
            {
                decimal totalValue = 0;
                foreach (var product in products)
                {
                    totalValue += product.Price;
                }
                return totalValue;
            }
        }
    }
}