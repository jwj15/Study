using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    class Class6
    {
        // 인터페이스 정의
        public interface ITestInterface
        {
            int a { get; }
            void Print();
            string Message(string id);
        }

        // sealed 붙으면 상속 불가
        public sealed class NoInheritance
        {
        }

        // 인터페이스 구현 -> 클래스 뒤에 : 으로 구현한다
        public class InterfaceTest : ITestInterface // 여러개 구현할 경우 , 구현할 인터페이스 순으로 나열한다
        {
            public int a { get; }

            public string Message(string id)
            {
                return string.Format("하이! {0}", id);
            }

            public void Print()
            {
                Console.WriteLine("Hi!!");
            }
        }

        static void Main()
        {
            // casting, as, is
            object a = "a";
            object b = "1";
            InterfaceTest t1 = (InterfaceTest)a; // 강제 형변환
            InterfaceTest t2 = a as InterfaceTest; // as -> Reference형 형변환
            if (b is int) // is -> value형 형변환이 가능한지 리턴
            {
                int i1 = (int) b;
            }
        }


    }
}
