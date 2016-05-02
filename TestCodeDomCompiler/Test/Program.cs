/*
 * 由SharpDevelop创建。
 * 用户： ki
 * 日期: 2016/4/24
 * 时间: 22:17
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace Test
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			// TODO: Implement Functionality Here
			MM mm1=new MM();
			mm1.print();
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
		
		private class MM
		{
			public void print()
			{
				Console.WriteLine("this class is MM");
				
			}
		}
	}
}