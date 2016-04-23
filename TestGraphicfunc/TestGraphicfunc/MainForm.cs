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
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			Panel p = new Panel();
			p.Location = new Point(10, 10);
			p.Size = new Size(200, 200);
			p.Paint+=new PaintEventHandler(p_Paint);
			p.Click+=new EventHandler(p_Click);
			this.Controls.Add(p);
		}
		
		void p_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			g.DrawRectangle(Pens.Blue,new Rectangle(0,0,((Control)sender).Width-2,((Control)sender).Height-2));
			
			g.DrawString("button", new Font(FontFamily.GenericMonospace, 12f), Brushes.Red, new PointF(10, 20));
		}
		void p_Click(object sender, EventArgs e)
		{
			MessageBox.Show("这是panel的点击事件");
		}
	}
}
