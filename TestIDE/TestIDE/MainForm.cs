/*
 * 由SharpDevelop创建。
 * 用户： ki
 * 日期: 2016/4/11
 * 时间: 12:52
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CSharpCompliler;

namespace TestIDE
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
		
		
		void MainFormLoad(object sender, EventArgs e)
		{
			

			
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			CSharpCompiler compiler = new CSharpCompiler ();
			compiler.SourceCode = richTextBox1.Text;
			compiler.Output = CSharpCompiler.OutputType.EXE;
			compiler.Path = "C:\\Users\\ki\\Desktop";
			compiler.NameOfAssembly = "Hello World!";
			compiler.CompileCode();
			if (compiler.SuccessfullCompilation == false )
			{
				
				if (compiler.CompilerErrors != null )
					listBox1.Items.AddRange(compiler.CompilerErrors);
				
				if (compiler.CompilerWarnings != null )
					listBox1.Items.AddRange(compiler.CompilerWarnings);
			}
		}
	}
}
