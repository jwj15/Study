using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    class Class4
    {
        // enum 정의
        enum Day { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };

        // 배열 get set
        public struct Menu
        {
            private string[] beverages;

            public string this[int index] // beverages가 아닌 this[int index]
            {
                get { return this.beverages[index]; }
                set { this.beverages[index] = value; }
            }
            public Menu(int a)
            {
                beverages = new string[] { "Americano", "Café au Lait", "Café Macchiato",
                                            "Cappuccino", "Espresso" };
            }
            public int Length
            {
                get { return beverages.Length; }
            }
        }

        static void Main(string[] args)
        {
            // enum 사용법
            Day day1 = Day.Monday;
            Console.WriteLine(day1);
            Day day2 = (Day)1;
            Console.WriteLine(day2);

            Menu myMenu = new Menu(1);
            //배열 get
            string firstDrink = myMenu[0]; // beverages[0]
            Console.WriteLine(firstDrink);

            // arrayList java와 유사
            ArrayList list = new ArrayList();
            list.Add("Text");
            list.Add(1);
            // 리스트(권장)
            List<string> list2 = new List<string>();

            // foreach문
            foreach (var print in list)
            {
                Console.WriteLine(print);
            }
            
            // hashtable
            Hashtable hash = new Hashtable();
            hash.Add(1, "first");
            hash.Add(2, "second");
            hash.Add(3, "third");
            // dictionary(권장) ,java Map유사
            Dictionary<int, string> hash2 = new Dictionary<int, string>();

            if (hash.ContainsKey(1)) // 해당키 있는지 검사
            {
                Console.WriteLine(hash[1]); //hashtable명[key]로 불러온다
            }

            // LINQ
            // collection, database 데이터 검색 쿼리문
            //       from < variable names > in < data source >
            //      where < selection criteria >
            //    orderby < result ordering criteria>
            //     select < variable names >

            //hahstable linq 사용예
            var linqTest =
                from int hashValue in hash.Keys 
                where 1 == 1
                orderby hashValue ascending
                select hash[hashValue];
            foreach (var print in linqTest)
            {
                Console.WriteLine(print); // first \n second \n third
            }

            //collection 메소드
            hash2.FirstOrDefault();// 첫번째 요소 반환 혹은 값이 없으면 기본값
            hash2.Last();// 마지막 요소 반환
            hash2.Max();// 최대값 반환

        }
    }
}
