using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;

namespace TestNugetComponents
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IValueCalculator>().To<LinQValueCalculator>();
            //kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WithPropertyValue("DiscountSize",50M);
            //kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WithConstructorArgument("discountParam", 50M);
            //kernel.Bind<ShoppingCart>().To<ShoppingCart.LimitShoppingCart>().WithPropertyValue("ItemLimit", 200M);
            kernel.Bind<IValueCalculator>()
    .ToSelf<IterativeValueCalculator>()
    .WhenInjectedInto<LimitShoppingCart>(); 


//            //Get the interface implementation
//            IValueCalculator calcuImple = kernel.Get<IValueCalculator>();
//
//            //Create the instance of ShoppingCart and inject the dependency
//            ShoppingCart cart = new ShoppingCart(calcuImple);

            ShoppingCart cart = kernel.Get<ShoppingCart>();

            //Perform the calculation and write out the result
            Console.WriteLine("Total :{0:c}", cart.CalculateStockValue());

        }
    }
}
