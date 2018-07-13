using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flyweightPattern
{
    class GraphicChar
    {
        char c;
        string fontFace;
        public GraphicChar(char c, string fontFace)
        {
            this.c = c;
            this.fontFace = fontFace;
        }
        public static void printAtPosition(GraphicChar c, int x, int y)
        {
            Console.WriteLine("Printing '{0}' in '{1}' at position {2}:{3}.", c.c, c.fontFace, x, y);
        }
    }

    class GraphicCharFactory
    {
        Hashtable pool = new Hashtable();

        public int getNum() 
        {
            return pool.Count;
        }

        public GraphicChar get(char c, string fontFace)
        {
            GraphicChar gc;
            string key = c.ToString() + fontFace;
            gc = pool[key] as GraphicChar;

            if(gc == null)
            {
                gc = new GraphicChar(c, fontFace);
                pool.Add(key, gc);
            }

            return gc;
        }
    }

    class flyweightPattern
    {
        public static void Main(string[] args)
        {
            GraphicCharFactory cf = new GraphicCharFactory();

            List<GraphicChar> text = new List<GraphicChar>();
            text.Add(cf.get('H', "Arial"));
            text.Add(cf.get('e', "Arial"));
            text.Add(cf.get('I', "Arial"));
            text.Add(cf.get('I', "Arial"));
            text.Add(cf.get('o', "Times"));

            Console.WriteLine("CharFactory created only {0} objects for {1} characters.", cf.getNum(), text.Count());

            int x = 0, y = 0;
            foreach(GraphicChar c in text)
            {
                GraphicChar.printAtPosition(c, x++, y);
            }

            Console.ReadKey();
        }
    }
}
