using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Study
{
    class Class8
    {

        static void Run()
        {
            Console.WriteLine("Long running method");
        }

        static void Run(object data)
        {
            Console.WriteLine(data == null ? "NULL" : data);
        }

        static void Main()
        {
            // task 생성
            Task task1 = new Task(() => { Console.WriteLine("afaef"); });
            // Task task1 = new Task(new Action(Run)); 2번째 방법
            task1.Start(); // task 시작
            task1.Wait();  // task 작업 끝날때까지 기다림
            task1.ContinueWith(t => { t.Dispose(); });  //작업 종료 후 dispose

            // multiple task
            Task[] tasks = new Task[3]
            {
               Task.Run( () => { Console.WriteLine("afaef");}),
               Task.Run( () => { Console.WriteLine("afaef");}),
               Task.Run( () => { Console.WriteLine("afaef");})
            };

            Task.WaitAny(tasks);
            Task.WaitAll(tasks);

            // Task.Factory를 이용하여 쓰레드 생성과 시작 (많이 사용)
            Task[] tasks2 = new Task[3];
            tasks2[0] = Task.Factory.StartNew(new Action<object>(Run), null);
            tasks2[1] = Task.Factory.StartNew(new Action<object>(Run), "1st");
            tasks2[2] = Task.Factory.StartNew(Run, "2nd");

            Task.WaitAll(tasks2);
            // Console.Read(); wait 안할 시 결과값 보기 위해 입력

            // Task 리턴값 받기 Task<리턴타입>
            Task<string> task2 = Task.Run<string>(() => DateTime.Now.DayOfWeek.ToString());

            Thread.Sleep(1000); // 1초 딜레이

            Console.WriteLine(task2.Result); // 결과값 리턴 task.Result

            // task취소를 위한 token 생성
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken ct = cts.Token;

            Console.WriteLine(ct.IsCancellationRequested);  // false 
            cts.Cancel();                                  // 버튼 눌렀을 경우 토큰 상태 변경 메소드
            Console.WriteLine(ct.IsCancellationRequested); //  true 
            // ct.ThrowIfCancellationRequested();          // 토큰 상태 true 인경우만 예외 던진다.

            // 병렬 처리( task와 달리 적절한 수의 thread를 생성하여 작업을 할당한다)
            Parallel.Invoke(() => { Console.WriteLine("aaa\r\nbbb"); },
                            () => { Console.WriteLine("ccc\r\nddd"); },
                            () => { Console.WriteLine("eee\r\nfff"); });

            // 병렬 for 문
            // Parallel.For(시작,끝,index =>{});
            Parallel.For(0, 100, i => {Console.WriteLine("{0}: {1}",
                                      Thread.CurrentThread.ManagedThreadId, i);
            });

            // 병렬 foreach문
            // Parallel.ForEach(array변수, 받을 변수 => {Console.WriteLine(받을 변수)};);
            List<string> list = new List<string> { "a", "b", "c", "d", "e" };
            Parallel.ForEach(list, v => { Console.WriteLine(v);});

        }
    }
}
