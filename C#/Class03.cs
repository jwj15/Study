using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console; // console 메소드 바로 사용가능

namespace TEST
{
    class class3
    {
        static void Main(string[] args)
        {
            int num;
            // 음수에서 양수 기본범위값 

            uint num1;

            // 타입앞에 u 붙으면 양수 범위만 사용
            // uint, ushort....

            string s1 = "first";
            string s2 = "second";
            string s3 = s1 + s2;// string 합치기 firstsecond;
            WriteLine(s3);

            StringBuilder s4 = new StringBuilder("hello!"); // 단순 string을 더하는 코드보다 오버헤드 적게 발생
            s4.Append(", haha"); // string 더하기 hello!, haha
            s4.Insert(6, "ㅋㅋㅋ");// 해당 인덱스에 문자열 추가 hello!ㅋㅋㅋ, haha
            s4.Remove(6, 3); // 해당 인덱스부터 지정한 문자수를 제거 6번째 인덱스 3개 문자 제거 hello!, haha
            s4.Replace("haha", "hhhhh"); // 문자 변경 haha를 hhhhh로 변경 hello!, hhhhh
            WriteLine(s4);

            // 파라미터 초기값 예제
            StopService(true); // true null 1 출력
            StopService(false, "aaa"); // false aaa 1 출력
            // StopService(true, 2); 오류 
            StopService(true, serviceId: 5); //해당 파라미터 명을 지정하여 값을 줄 수 있다. true null 5 출력

            // out 파라미터 예제
            IsOnline("abab", out string t);// or string t; IsOnline("", out t);
            WriteLine(t);// out Test 출력
            GetXY(out int x, out int y);

            // 여기서 x, y 를 사용할 수 있다.
            Console.WriteLine($"{x},{y}");

            // out var 를 사용한 표현
            GetXY(out var x1, out var y1);

            // 필요없는 out 파라미터에 _ 사용
            GetXY(out var x2, out _);

            //ref test
            int num2 = 5;
            int num3 = 4;
            add(ref num2, num3); // num2 주소 넘김, num3 값만 넘김
            WriteLine("{0}, {1}", num2, num3); // 6, 4 출력


            if (args.Length == 0)
            {
                Console.WriteLine("사용법:HelloWorld.exe <이름>");
                return;
            }

            WriteLine("Hello, {0}", args[0]);

        }

        // 파라미터 초기값을 설정
        static void StopService(bool forceStop, string serviceName = null, int serviceId = 1)
        {
            WriteLine("{0}, {1}, {2}", forceStop, serviceName, serviceId);
        }

        // 출력 파라미터
        // 리턴을 2개 이상 받고 싶은 때 사용
        static bool IsOnline(string name, out string message)
        {
            message = "out Test"; // out으로 지정한 값 리턴
            return true;
        }
        static void GetXY(out int x, out int y)
        {
            x = 1;
            y = 2;
        }
        


        // ref
        // ref를 붙일 경우 reference(값을 주소)를 받는다.
        // 따라서 넘겨준 값이 변함
        static int add(ref int a, int b)
        {
            a += 1; // 넘겨준 값 자체가 변함
            b += 1; // 넘어온 값만 변함
            return a + b;
        }



    }
}
