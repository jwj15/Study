using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    class Class16
    {
        // 널 조건 연산자(Null-conditional operator)
        // rows가 NULL이면 cnt 도 NULL
        // rows가 NULL이 아니면 cnt는 실제 rows 갯수
        int? cnt = rows?.Count;

        // customers 컬렉션이 NULL이면 c는 NULL
        // 아니면, c는 첫번째 배열요소
        Customer c = customers?[0];

        // customers가 널인지 체크하고
        // 다시 customers[0]가 널인지 체크
        int? age = customers?[0]?.Age;

        // rows가 NULL이면 cnt = 0
        // 아니면 cnt는 실제 rows 갯수
        // 널을 리턴하면 안될경우 사용
        int cnt = rows?.Count ?? 0;

        // 문자열 포맷팅
        // 1. string.Format()사용
        // 2. $를 앞에 붙여 {}안에 직접 입력

        string s = $"넓이는 = {r.Height} *{r.Width}";

        // 튜플 사용
        // 리턴값을 여러개 받을 수 있다
        // 리턴타입의 변수명을 지정안하면 r.item1, r.item2와 같은 식으로 받는다.

        (int count, int sum, double average) Calculate(List<int> data) //튜플 리턴타입
        {
            int cnt = 0, sum = 0;
            double avg = 0;

            foreach (var i in data)
            {
                cnt++;
                sum += i;
            }

            avg = sum / cnt;

            return (cnt, sum, avg); //튜플 리터럴
        }

        private void Run()
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };

            var r = Calculate(list);  // 튜플 결과
            Console.WriteLine($"{r.count}, {r.sum}, {r.average}");
            Console.WriteLine($"{r.Item1}, {r.Item2}, {r.Item3}");
        }

        // Expression-bodied 표현
        // 생성자
        public Employee(int id) => this.id = id;

        // Finalizer
        ~Employee() => Debug.Write("~Employee()");

        // 속성 accessor (getter/setter)
        public int Id
        {
            get => this.id;   // getter
            set => this.id = value > 0 ? value : 0;  // setter
        }

        // 인덱서 accessor (getter/setter)
        public string this[int index]
        {
            // 타당성 체크 생략
            get => tags[index];
            set => tags[index] = value;
        }

        // 이벤트 accessor
        private EventHandler notified;
        public event EventHandler Notified
        {
            add => this.notified += value;
            remove => this.notified -= value;
        }


    }


}
