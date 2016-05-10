/*
 * 由SharpDevelop创建。
 * 用户： ki
 * 日期: 2016/5/9
 * 时间: 23:42
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;
namespace CompressPic
{
	/// <summary>
	/// Description of Form1.
	/// </summary>
	public partial class Form1 : Form
	{
		
		Compress CPress;
       

        public Form1()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Button1Click(object sender, EventArgs e)
		{

			try
			{
                CPress = new Compress(ComprePathTB.Text, SavePathTB.Text);
                List<string> fileUnit = Compress.CreateFileParam();
				int count=0;
               foreach(string path in fileUnit)
                {
                   
                    CPress.compress(path, count);
                  
                    count++;


                }
				
				
				
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
			
		}
		
		void Form1Load(object sender, EventArgs e)
		{
			ComprePathTB.Text="C:\\Users\\ki\\OneDrive";//初始化路径
			SavePathTB.Text="C:\\Users\\ki\\Documents\\PicBackUp";
			//CPress=new Compress(ComprePathTB.Text,SavePathTB.Text);
			
		}
	}
}
