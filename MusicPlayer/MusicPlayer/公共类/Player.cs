/*
 * 由SharpDevelop创建。
 * 用户： ki
 * 日期: 2016/4/19
 * 时间: 21:30
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MusicPlayer;

namespace MusicPlayer.公共类
{
	/// <summary>
	/// Description of Player.
	/// </summary>
	public class Player
	{
		
		#region 调用系统API
		[DllImport("winmm.dll")]
		private static extern long mciSendString(
			string command,
			string returnString,
			int returnSize,
			IntPtr hwndCallback
		);
		#endregion
		
		public Player()
		{
		}
		
		
		#region 打开音乐
		
		public void OpenMusic(string path)
		{
			mciSendString(string.Format("open \"{0}\" alias song",path ),null,0,IntPtr.Zero);
			
		}
		#endregion
		#region 播放方法
		public void playMusic(string path)
		{
			//CloseMusic();
			OpenMusic(path);
			mciSendString("play song",null,0,IntPtr.Zero);
		}
		
		
		#endregion
		#region 关闭音乐
		public void CloseMusic()
		{
			mciSendString("close song",null,0,IntPtr.Zero);
		}
		#endregion
		
		#region 上一首
		
		public string Previous(ListView LV)
		{
			int index=LV.SelectedItems[0].Index;
			
			string path=Application.StartupPath+@"\Music\"+LV.Items[index].Text;

			if(index!=0)
			{
				LV.Items[index].Selected=false;//取消选中上一首歌
				index--;
				path=Application.StartupPath+@"\Music\"+LV.Items[index].Text;
				LV.Items[index].Selected=true;//选中下一首歌
				//pl.OpenMusic(path);
				//pl.playMusic(path);
			}
			return path;
		}
		#endregion
		
		
		#region 下一首
		public string Next(ListView LV)
		{
			int index=LV.SelectedItems[0].Index;
			
			

			string path=Application.StartupPath+@"\Music\"+LV.Items[index].Text;
			if(index!=LV.Items.Count-1)
			{
				
				LV.Items[index].Selected=false;
				index++;
				path=Application.StartupPath+@"\Music\"+LV.Items[index].Text;
				LV.Items[index].Selected=true;
				//pl.OpenMusic(path);
				//pl.playMusic(path);
			}
			return path;
		}
		#endregion
		
		
	}
}
