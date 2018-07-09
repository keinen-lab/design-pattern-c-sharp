using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designpatternAbstractFactory
{
    // https://ko.wikipedia.org/wiki/%EC%B6%94%EC%83%81_%ED%8C%A9%ED%86%A0%EB%A6%AC_%ED%8C%A8%ED%84%B4
    public enum Appearance
    {
        WIN,
        OSX
    }

    interface IButton
    {
        void Paint();
    }

    interface IGUIFactory
    {
        IButton CreateButton();
    }

    class GUIFactory
    {
        public static IButton CreateButton(Appearance appearance)
        {
            switch(appearance)
            {
                case Appearance.WIN:
                    Console.WriteLine("Make Win Button");
                    return new WinButton();
                case Appearance.OSX:
                    Console.WriteLine("Make OSX Button");
                    return new OSXButton();
                default:
                    throw new System.NotImplementedException();
            }
        }
    }

/* GUI Factory로 통합.
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
*/

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
        static void Main(string[] args)
        {
            var appearance = Appearance.WIN;

            IButton button = GUIFactory.CreateButton(appearance);

            /*
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
            */

            button.Paint();

            Console.ReadKey();
        }
    }
}