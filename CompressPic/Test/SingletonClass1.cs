/*
 * 由SharpDevelop创建。
 * 用户： ki
 * 日期: 2016/5/9
 * 时间: 23:47
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace Test
{
	/// <summary>
	/// Description of SingletonClass1.
	/// </summary>
	public sealed class SingletonClass1
	{
		private static SingletonClass1 instance = new SingletonClass1();
		
		public static SingletonClass1 Instance {
			get {
				return instance;
			}
		}
		
		private SingletonClass1()
		{
		}
	}
}
