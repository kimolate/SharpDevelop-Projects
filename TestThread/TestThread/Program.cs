using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Semaphore1
{
    class Program
    {
        //我设置一个最大允许5个线程允许的信号量
        //并将它的计数器的初始值设为0
        //这就是说除了调用该信号量的线程都将被阻塞
        static Semaphore semaphore = new Semaphore(0, 2);

        static void Main(string[] args)
        {
            for (int i = 1; i <= 5; i++)
            {
                Thread thread = new Thread(new ParameterizedThreadStart(work));

                thread.Start(i);
            }

            Thread.Sleep(2000);
            Console.WriteLine("Main thread over!");

            //释放信号量，将初始值设回5，你可以将
            //将这个函数看成你给它传的是多少值，计数器
            //就会加多少回去，Release()相当于是Release(1)
            semaphore.Release(2);
        }

        static void work(object obj)
        {
            semaphore.WaitOne();

            Console.WriteLine("Thread {0} start!",obj);
            Thread.Sleep(2000);
            
            semaphore.Release();
        }
    }
}