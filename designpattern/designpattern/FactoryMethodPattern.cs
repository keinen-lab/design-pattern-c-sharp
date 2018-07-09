using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designpatternFactoryMethod
{
    // https://ko.wikipedia.org/wiki/%ED%8C%A9%ED%86%A0%EB%A6%AC_%EB%A9%94%EC%84%9C%EB%93%9C_%ED%8C%A8%ED%84%B4

    public enum PizzaType
    {
        HamNushroom, Deluxe, Seafood
    }

    public abstract class Pizza
    {
        public abstract decimal GetPrice();

        public static Pizza PizzaFactory(PizzaType pizzaType)
        {
            switch (pizzaType)
            {
                case PizzaType.HamNushroom:
                    return new HamAndMushroomPizza();
                case PizzaType.Deluxe:
                    return new DeluxePizza();
                case PizzaType.Seafood:
                    return new SeafoodPizza();
            }

            throw new System.NotSupportedException("The pizza type " + pizzaType.ToString() + " is not recognized");
        }
    }

    public class HamAndMushroomPizza : Pizza
    {
        private decimal price = 8.5M;
        public override decimal GetPrice()
        {
            return price;
        }
    }

    public class DeluxePizza : Pizza
    {
        private decimal price = 10.5M;
        public override decimal GetPrice()
        {
            return price;
        }
    }

    public class SeafoodPizza : Pizza
    {
        private decimal price = 11.5M;
        public override decimal GetPrice()
        {
            return price;
        }
    }
        
    class FactoryMethodPattern
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Pizza.PizzaFactory(PizzaType.Deluxe).GetPrice().ToString("C2"));
            Console.ReadKey();
        }
    }
}
