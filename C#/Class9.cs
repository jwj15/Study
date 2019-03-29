using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Study
{
    class Class9
    {
        // ui컨트롤은 다른 쓰레드에서 수정할 수 없다.
        // 따라서 dispatcher를 사용하여야 한다.
        // private void button1_Click(object sender, RoutedEventArgs e)
        // {
        //     // 작업쓰레드 생성
        //     Task.Factory.StartNew(Run);
        // }

        // private void Run()
        // {
        //     // 해당 쓰레드가 UI쓰레드인가?
        //     if (textBox1.Dispatcher.CheckAccess())
        //     {
        //         //UI 쓰레드인 경우
        //         textBox1.Text = "Data";
        //     }
        //     else
        //     {
        //         // 작업쓰레드인 경우 Dispatcher.BeginInvoke 사용
        //         textBox1.Dispatcher.BeginInvoke(new Action(Run));
        //     }
        // }

        // async ~ await
        // 메소드 앞에 async붙여주어 await가 있는걸 컴파일러에 알림
        // awiat는 일반적으로 Task / Task<T>와 사용된다
        public async void Run()
        {
            int sum = await calc();
            Console.WriteLine(sum);
        }

        async Task<int> calc()
        {
            int result = 0;
            int times = 10;
            for (int i = 0; i < times; i++)
            {
                result += i;
                await Task.Delay(200);
            }
            return result;
        }

        static void Main()
        {
            new Class9().Run(); // 루프가 10번 도므로 10초있다가 출력된다.
            Console.ReadLine();
            new Class9().Run1();
            Console.ReadLine();
            new Class9().Run2();
        }

        // lock 블럭
        // 하나의 쓰레드만 접근 가능하도록 락을 걸어준다
        // lock(this)와 같이 잘못사용하지 않게 주의
        private int counter = 1000;
        private object lockObj = new object();
        // lock 걸지않아 lockObj에 여러 쓰레드가 접근 가능
        public void Run1()
        {
            for (int i = 0; i < 10; i++)
            {
                new Thread(SafeCalc1).Start();
            }
        }
        public void SafeCalc1()
        {
            counter++;

            // 작업예제
            for (int i = 0; i < counter; i++)
                for (int j = 0; j < counter; j++) ;

            Console.WriteLine(counter);
        }

        // lockObj에 lock걸 경우
        public void Run2()
        {
            for (int i = 0; i < 10; i++)
            {
                new Thread(SafeCalc).Start();
            }
        }
        public void SafeCalc()
        {
            lock (lockObj)
            {
                counter++;

                // 작업예제
                for (int i = 0; i < counter; i++)
                    for (int j = 0; j < counter; j++) ;

                Console.WriteLine(counter);
            }
        }


    }
}