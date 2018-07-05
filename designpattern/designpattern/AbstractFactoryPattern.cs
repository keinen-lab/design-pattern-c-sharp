using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designpattern
{
    // https://ko.wikipedia.org/wiki/%EC%B6%94%EC%83%81_%ED%8C%A9%ED%86%A0%EB%A6%AC_%ED%8C%A8%ED%84%B4
    interface IButton
    {
        void Paint();
    }

    interface IGUIFactory
    {
        IButton CreateButton();
    }

    class WinFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            Console.WriteLine("WinFactory");
            return new WinButton();
        }
    }

    class OSXFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            Console.WriteLine("OSXFactory");
            return new OSXButton();
        }
    }

    class WinButton : IButton
    {
        public void Paint()
        {
            Console.WriteLine("Paint : WinButton");
        }
    }

    class OSXButton : IButton
    {
        public void Paint()
        {
            Console.WriteLine("Paint : OSXButton");
        }
    }

    class AbstractFactoryPattern
    {
        public enum Appearance
        {
            WIN,
            OSX
        }
        static void Main(string[] args)
        {
            var appearance = Appearance.WIN;

            IGUIFactory factory;

            switch(appearance)
            {
                case Appearance.WIN:
                    factory = new WinFactory();
                    break;
                case Appearance.OSX:
                    factory = new OSXFactory();
                    break;
                default:
                    throw new System.NotImplementedException();
            }

            var button = factory.CreateButton();
            button.Paint();

            Console.ReadKey();
        }
    }
}
