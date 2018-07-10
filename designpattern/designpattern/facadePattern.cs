using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designpattern
{
    class SubSystemOne
    {
        public void MethodOne()
        {
            Console.WriteLine("Subsystem One Method");
        }
    }

    class SubSystemTwo
    {
        public void MethodTwo()
        {
            Console.WriteLine("Subsystem Two Method");
        }
    }

    class SubSystemThree
    {
        public void MethodThree()
        {
            Console.WriteLine("Subsystem Three Method");
        }
    }

    class SubSystemFour
    {
        public void MethodFour()
        {
            Console.WriteLine("Subsystem Four Method");
        }
    }

    // facade
    class Facade
    {
        SubSystemOne one;
        SubSystemTwo two;
        SubSystemThree three;
        SubSystemFour four;

        public Facade()
        {
            one = new SubSystemOne();
            two = new SubSystemTwo();
            three = new SubSystemThree();
            four = new SubSystemFour();
        }

            public void MethodA()
            {
                Console.WriteLine("\nMethodA() -----");
                one.MethodOne();
                two.MethodTwo();
                four.MethodFour();
            }

            public void MethodB()
            {
                Console.WriteLine("\nMethodB() ----");
                two.MethodTwo();
                three.MethodThree();
            }
    }

    class facadePattern
    {
        public static void Main(string[] args)
        {
            Facade facade = new Facade();

            facade.MethodA();
            facade.MethodB();

            Console.Read();
        }
    }
}
