using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    delegate int CallbackDelegate();

    class Class5
    {
        // delegate 대리자
        delegate int DelegateTest(int a, int b); // 사용할 델리게이트 선언
        public static int Add(int a, int b) // 델리게이트로 사용할 함수 두개 파라미터 형식 같아야 함
        {
            return a + b;
        }

        // 콘솔에서 값입력받기 string -> int
        public static int ReturnInt()
        {
            return int.Parse(Console.ReadLine());
        }

        // 콜백함수 사용법
        // PrintSum함수는 델리게이트 함수를 호출한후 실행된다.
        public static void PrintSum(int a, CallbackDelegate dele)
        {
            Console.WriteLine(a + dele());
        }

        // 이벤트
        class EventTest
        {
            public EventArgs e;
            public delegate void TestHandler(Class5 c5, EventArgs args); //핸들러 선언
            public event TestHandler OutOfBeans; //이벤트 선언
            // public delegate void EventHandler(object sender, EventArgs e); 이벤트 데이터가 없는 이벤트를 처리할 메서드 제공
            public event EventHandler Event2; //위 핸들러 사용

            public void MouseButtonDown()
            {
                if (this.Event2 != null)
                {
                    Event2(this, e);
                }
            }
        }

        public void Run()
        {
            EventTest eTest = new EventTest();
            // 이벤트 핸들러 지정
            eTest.Event2 += new EventHandler(btn_Click);
            eTest.Event2 += HandleOutOfBeans;
            // 이벤트 핸들러 삭제
            eTest.Event2 -= HandleOutOfBeans;

        }

        void btn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("click");
        }

        public void HandleOutOfBeans(object sender, EventArgs args)
        {
            string coffeeBean = sender.ToString();
        }

        static void Main()
        {
            // 간단 사용법 (그냥 메소드 호출이랑 차이없음)
            DelegateTest AddDelegate = new DelegateTest(Add);
            int sumValue = AddDelegate(5, 10);
            Console.WriteLine(sumValue);

            // 콜백 예제 10+입력받은값 출력
            CallbackDelegate readText = new CallbackDelegate(ReturnInt);
            PrintSum(10, readText);




        }
    }
}
