using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    class Class1
    {
        private int x;
        private int y;

        public Class1() : this(0, 0)
        { }
        public Class1(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void Print()
        {
            System.Console.WriteLine("{0} {1}", x, y);
        }
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

    }

    class Program
    {
        static void Main()
        {
            Class1 test = new Class1();
            test.Print(); // 0 0
            test.X = 5;
            test.Y = 10;
            test.Print(); // 5 10

            Class1 test2 = new Class1() { X = 100, Y = 433 };
            test2.Print(); // 100 433
        }

    }
}
