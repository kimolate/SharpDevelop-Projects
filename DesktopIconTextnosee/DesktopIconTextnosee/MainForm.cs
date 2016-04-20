/*
 * 由SharpDevelop创建。
 * 用户： ki
 * 日期: 2016/4/10
 * 时间: 16:34
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DesktopIconTextnosee
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		 [DllImport("user32.dll")]
        public static extern int GetDesktopWindow();
        [DllImport("user32.dll")]
        public static extern int FindWindowEx(int hWnd1,int hWnd2,string lpsz1,string lpsz2);
        [DllImport("user32.dll")]
        public static extern int SendMessage(int hWnd,int wMsg,int wParam,uint lParam);
        [DllImport("user32.dll")]
        public static extern int InvalidateRect(int hwnd,ref Rectangle lpRect,bool bErase);
        //声明常量
        private const int wMsg1=0x1026;
        private const int wMsg2=0x1024;
        private const uint lParam1=0xffffffff;
        private const uint lParam2=0x00ffffff;
        Rectangle lpRect=new Rectangle(0,0,0,0);
        
       
		
		void Button1Click(object sender, EventArgs e)
		{
			int hwnd;
        	hwnd=GetDesktopWindow();
        	hwnd=FindWindowEx(hwnd ,0,"Progman",null);
        	hwnd=FindWindowEx(hwnd ,0,"SHELLDLL_DefView",null);
        	hwnd=FindWindowEx(hwnd ,0,"SysListView32",null);
        	SendMessage(hwnd,wMsg1,0,lParam1);
        	SendMessage(hwnd,wMsg2,0,lParam2);
        	InvalidateRect(hwnd ,ref lpRect,true);
        	MessageBox.Show("设置成功，","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}
	}
}
