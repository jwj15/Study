using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    class Class15
    {
        // 무명 메서드
        // 무명메서드 형식: delegate (파라미터들) { 실행문장들 };
        // Create a delegate.
        delegate void Del(int x);

        // Instantiate the delegate using an anonymous method.
        Del d = delegate (int k) { /* ... */ };

        // 람다 Synyax : (입력 파라미터) => { 문장블럭 };
        // str => { MessageBox.Show(str); }
        // () => Write("No");
        // (p) => Write(p);
        // (s, e) => Write(e);
        // (string s, int i) => Write(s, i);

        // 익명 타입 -> 클래스를 정의할 필요 없이 Type을 간단히 임시로 만들어 사용할 때 유용
        // 익명 타입 : new { 속성1=값, 속성2=값; }
        // ex) var t = new { Name = "홍길동", Age = 20 };

        static void Main()
        {
            string s = "This is a Test";

            // s객체 즉 String객체가
            // 확장메서드의 첫 파리미터임
            // 실제 ToChangeCase() 메서드는
            // 파라미터를 갖지 않는다.
            string s2 = s.ToChangeCase();

            // String 객체가 사용하는 확장메서드이며
            // z 값을 파라미터로 사용
            bool found = s.Found('z');
        }
    }
    static class subClass
    {
        // 확장 메서드
        // this 붙인 파라미터를 사용
        // 확장 메서드는 최상위 정적 클래스에 정의하여야 한다.
        public static string ToChangeCase(this String str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var ch in str)
            {
                if (ch >= 'A' && ch <= 'Z')
                    sb.Append((char)('a' + ch - 'A'));
                else if (ch >= 'a' && ch <= 'x')
                    sb.Append((char)('A' + ch - 'a'));
                else
                    sb.Append(ch);
            }
            return sb.ToString();
        }

        // 이 확장메서드는 파라미터 ch가 필요함
        public static bool Found(this String str, char ch)
        {
            int position = str.IndexOf(ch);
            return position >= 0;
        }

    }

}
