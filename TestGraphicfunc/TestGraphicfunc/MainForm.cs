/*
 * 由SharpDevelop创建。
 * 用户： ki
 * 日期: 2016/4/23
 * 时间: 19:30
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TestGraphicfunc
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
			timer1.Tick+= Button1Click;
			timer1.Start();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			panel1.BackColor=Color.FromArgb(120,0,0,0);
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			Graphics g=panel1.CreateGraphics();
			g.DrawString("button", new Font(FontFamily.GenericMonospace, 12f), Brushes.Red, new PointF(0,0));
			panel1.Refresh();
		}

		
		
		
		
	}
	
	
}

