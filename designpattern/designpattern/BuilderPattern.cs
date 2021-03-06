﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designpatternBuilder
{
    // https://ko.wikipedia.org/wiki/%EB%B9%8C%EB%8D%94_%ED%8C%A8%ED%84%B4
    // product
    class Pizza
    {
        string dough;
        string sauce;
        string topping;

        public Pizza()
        {
        }

        public void SetDough(string d)
        {
            dough = d;
        }

        public void SetSauce(string s)
        {
            sauce = s;
        }

        public void SetTopping(string t)
        {
            topping = t;
        }

        public override string ToString()
        {
            return string.Format("Pizza dough : {0}, sauce ; {1}, topping : {2}", dough, sauce, topping);
        }
    }

    // Abstract Builder
    abstract class PizzaBuilder
    {
        protected Pizza pizza;
        public PizzaBuilder()
        {

        }

        public Pizza GetPizza()
        {
            return pizza;
        }

        public void CreateNewPizza()
        {
            pizza = new Pizza();
        }

        public abstract void BuildDough();
        public abstract void BuildSauce();
        public abstract void BuildTopping();
    }

    // Concreate Builder
    class HawaiianPizzaBuilder : PizzaBuilder
    {
        public override void BuildDough()
        {
            pizza.SetDough("cross");
        }

        public override void BuildSauce()
        {
            pizza.SetSauce("mild");
        }

        public override void BuildTopping()
        {
            pizza.SetTopping("ham+pineapple");
        }
    }

    // Concreate Builder
    class SpicyPizzaBuilder : PizzaBuilder
    {
        public override void BuildDough()
        {
            pizza.SetDough("pan baked");
        }

        public override void BuildSauce()
        {
            pizza.SetSauce("hot");
        }

        public override void BuildTopping()
        {
            pizza.SetTopping("pepparoni+salami");
        }
    }

    // Director
    class Waiter
    {
        private PizzaBuilder pizzaBuilder;

        public void SetPizzaBuilder(PizzaBuilder pb)
        {
            pizzaBuilder = pb;
        }

        public Pizza GetPizza()
        {
            return pizzaBuilder.GetPizza();
        }

        public void ConstructPizza()
        {
            pizzaBuilder.CreateNewPizza();
            pizzaBuilder.BuildDough();
            pizzaBuilder.BuildSauce();
            pizzaBuilder.BuildTopping();
        }
    }

    // A Customer ordering a pizza
    class BuilderPattern
    {
        public static void Main(string[] args)
        {
            Waiter waiter = new Waiter();
            PizzaBuilder hawaiianPizzaBuilder = new HawaiianPizzaBuilder();
            PizzaBuilder spicyPizzaBuilder = new SpicyPizzaBuilder();

            waiter.SetPizzaBuilder(spicyPizzaBuilder);
            waiter.ConstructPizza();
            Pizza pizza = waiter.GetPizza();

            Console.WriteLine(pizza.ToString());

            Console.ReadKey();
        }
    }
}
