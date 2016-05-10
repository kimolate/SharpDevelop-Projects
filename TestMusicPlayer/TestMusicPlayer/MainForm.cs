/*
 * 由SharpDevelop创建。
 * 用户： ki
 * 日期: 2016/5/8
 * 时间: 21:42
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TestMusicPlayer
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		
		#region 调用系统API
        [DllImport("winmm.dll", CharSet = CharSet.Unicode)]
        private static extern long mciSendString(
            string command,
            string returnString,
            int returnSize,
            IntPtr hwndCallback
        );
        #endregion
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
			string songPath =@"C:\Users\ki\Documents\SharpDevelop Projects\TestMusicPlayer\TestMusicPlayer\bin\Debug\BEYOND.mp3";
            playMusic(songPath);
		}
		public void OpenMusic(string path)
        {
            mciSendString(string.Format("open \"{0}\"  alias song", path), null, 0, IntPtr.Zero);

        }
       

        #region 播放音乐
        public void playMusic(string path)
        {
            //CloseMusic();
            OpenMusic(path);
            mciSendString("play song", null, 0, IntPtr.Zero);



        }
        #endregion
	}
}
