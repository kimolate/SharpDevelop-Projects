/*
 * 由SharpDevelop创建。
 * 用户： ki
 * 日期: 2016/5/1
 * 时间: 17:44
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace TestHttpDownload
{
	class Program
	{
		//private DownLoadFile download;
		
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			// TODO: Implement Functionality Here
			DownLoadFile download=new DownLoadFile();
			bool OK=download.DeownloadFile("D:\\123.exe");
			Console.WriteLine(OK);
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		//public Program()
		//{
		//	download=new DownLoadFile();
		//}
	}
}