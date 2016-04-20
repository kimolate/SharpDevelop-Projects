/*
 * 由SharpDevelop创建。
 * 用户： ki
 * 日期: 2016/4/10
 * 时间: 19:46
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Threading;

namespace Tread_Test
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			// TODO: Implement Functionality Here
			Thread t1 = new Thread(new ThreadStart(Thread1));
			Thread t2 = new Thread(new ThreadStart(Thread2));
			//Thread t3 = new Thread(new ThreadStart(Thread1));
			//Thread t4 = new Thread(new ThreadStart(Thread1));
			//Thread t5 = new Thread(new ThreadStart(Thread1));
			//Thread t6 = new Thread(new ThreadStart(Thread1));

			t1.Priority = ThreadPriority.Highest ;
			t2.Priority = ThreadPriority.Lowest ;
			//t3.Priority = ThreadPriority.Normal;
			//t4.Priority = ThreadPriority.Normal;
			t1.Start();
			t2.Start();
			//t3.Start();
			//t4.Start();
			//t5.Start();
			//t6.Start();
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		public static void Thread1()
		{
			for (int i = 1; i < 1000; i++)
			{//每运行一个循环就写一个“1”
				dosth();
				Console.Write("1");
			}
		}
		public static void Thread2()
		{
			for (int i = 0; i < 1000; i++)
			{//每运行一个循环就写一个“2”
				dosth();
				Console.Write("2");
			}
		}
		public static void dosth()
		{//用来模拟复杂运算
			for (int j = 0; j < 10000000; j++)
			{
				int a=15;
				a = a*a*a*a;
			}
		}
	}
}