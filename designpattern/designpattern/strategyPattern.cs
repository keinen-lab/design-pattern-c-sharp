using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strategyPattern
{
    interface IBillingStrategy
    {
        double GetActPrice(double rawPrice);
    }

    class NormalStrategy : IBillingStrategy
    {
        public double GetActPrice(double rawPrice)
        {
            return rawPrice;
        }
    }

    class HappyHourStarategy : IBillingStrategy
    {
        public double GetActPrice(double rawPrice)
        {
            return rawPrice  * 0.5;
        }
    }

    class Customer
    {
        private IList<double> drinks;

        // get/set strategy
        public IBillingStrategy Strategy { get; set; }

        public Customer(IBillingStrategy strategy)
        {
            this.drinks = new List<double>();
            this.Strategy = strategy;
        }

        public void Add(double price, int quantity)
        {
            drinks.Add(Strategy.GetActPrice(price * quantity));
        }

        public void PrintBill()
        {
            double sum = 0;

            foreach(double i in drinks)
            {
                sum += i;
            }

            Console.WriteLine("Total due: " + sum);
            drinks.Clear();
        }
    }



    class strategyPattern
    {
        public static void Main(String[] args)
        {
            Customer firstCustomer = new Customer(new NormalStrategy());

            firstCustomer.Add(1.0, 1);

            firstCustomer.Strategy = new HappyHourStarategy();
            firstCustomer.Add(1.0, 2);

            Customer secondCustomer = new Customer(new HappyHourStarategy());
            secondCustomer.Add(0.8, 1);

            firstCustomer.PrintBill();

            secondCustomer.Strategy = new NormalStrategy();
            secondCustomer.Add(1.3, 2);
            secondCustomer.Add(2.5, 1);
            secondCustomer.PrintBill();

            Console.ReadLine();
        }
    }
}
