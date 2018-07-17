using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proxyPattern
{
    interface IImage
    {
        void Display();
    }

    class RealImage: IImage
    {
        public string FileName { get; private set; }
        public RealImage(string fileName)
        {
            FileName = fileName;
            LoadFromFile();
        }

        private void LoadFromFile()
        {
            Console.WriteLine("Loading " + FileName);
        }

        public void Display()
        {
            Console.WriteLine("Display " + FileName);
        }
    }

    class ProxyImage : IImage
    {
        public String FileName { get; private set; }
        private IImage image;

        public ProxyImage(string fileName)
        {
            FileName = fileName;
        }

        public void Display()
        {
            if (image == null)
            {
                image = new RealImage(FileName);
            }
            image.Display();
        }
    }

    class proxyPattern
    {
        public  static void Main(string[] args)
        {
            IImage image = new ProxyImage("HiRes_Image");
            for(int i =0; i<10; i++)
            {
                image.Display();
            }

            Console.ReadKey();
        }
    }
}
