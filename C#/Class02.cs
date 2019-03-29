using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    class CPoint
    {
        private int x, y;
        public CPoint()
        {
            this.x = 0;
            this.y = 0;
        }
        public CPoint(int x_, int y_)
        {
            this.x = x_;
            this.y = y_;
        }
        public void Print()
        {
            Console.WriteLine("base:{0}", GetType().BaseType);
            Console.WriteLine("{0} {1}", x, y);
        }
    }
    struct SPoint // 기본생성자 생성 불가
    {
        public int x, y;
        public SPoint(int x_, int y_)
        {
            this.x = x_;
            this.y = y_;
        }
        public void Print()
        {
            Console.WriteLine("base:{0}", GetType().BaseType);
            Console.WriteLine("{0} {1}", x, y);
        }
    }

    class Program
    {
        static void Main()
        {
            CPoint cPoint = new CPoint(1, 1);
            cPoint.Print();

            SPoint sPoint = new SPoint(1, 1);
            sPoint.Print();

            //CPoint cpt; 
            //cpt.x = 1;  오류
            //cpt.y = 1; 
            //cpt.Print(); 

            SPoint spt; // 변수 선언이 곧 객체 생성이므로 당근 가능!!
            spt.x = 5; 
            spt.y = 5; 
            spt.Print();
        }
    }

}
