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
using System.Text;
using System.Threading;

namespace MusicPlayer.公共类
{
	/// <summary>
	/// Description of Player.
	/// </summary>
	public class Player
	{
		
		#region 调用系统API
		[DllImport("winmm.dll",CharSet=CharSet.Unicode)]
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
			mciSendString(string.Format("open \"{0}\" type mpegvideo alias song",path ),null,0,IntPtr.Zero);
			
		}
		#endregion
		
		#region 获取歌曲状态
		public string GetSongStatus()
		{
			string _temp="".PadLeft(128,' ');
			mciSendString("status song mode",_temp,128,IntPtr.Zero);
			_temp=_temp.Trim();
			return _temp;
		}
		#endregion
		#region 获取歌曲原始时间
		public int[] GetOriginTime()
		{
			string _temp="".PadLeft(128,' ');
			mciSendString("status song position",_temp,128,IntPtr.Zero);
			int[] originTime=new int[2];
			originTime[0]=int.Parse(_temp.Trim())/1000;
			_temp="".PadLeft(128,' ');
			mciSendString("status song length",_temp,128,IntPtr.Zero);
			originTime[1]=int.Parse(_temp.Trim())/1000;
			return originTime;
		}
		#endregion
		
		
		#region 获取歌曲播放长度
		
		public string GetTotaTime()
		{
			string _temp="".PadLeft(128,' ');
			mciSendString("status song length",_temp,128,IntPtr.Zero);
			_temp=FormatTime(_temp);
			//_temp=int.Parse(_temp)/1000;
			return _temp;
			
		}
		#endregion
		
		
		#region  获取歌曲播放时间
		public string GetSongTime()
		{
			string _temp="".PadLeft(128,' ');
			
			                          mciSendString("status song position",_temp,128,IntPtr.Zero);
			                                 _temp=FormatTime(_temp);
			                                             	
			                                             	
			                                     
		
			return _temp;
		}
		#endregion
		#region 播放方法
		public void playMusic(string path)
		{
			//CloseMusic();
			OpenMusic(path);
			mciSendString("play song",null,0,IntPtr.Zero);
			string[] time=new string[2];
			 
			
		}
		
		
		#endregion
		
		
		#region 暂停或开始音乐
		
		public string  PlayOrPause(string status)
		{
			
			//string _Temp = "".PadLeft(128, ' ');
			
			//mciSendString("status song mode ",_Temp,_Temp.Length,IntPtr.Zero);
			
			//return _Temp.Trim();
			if(status=="<>")
			{
				mciSendString("pause song",null,0,IntPtr.Zero);
				return "==";
			}
			else
			{
				mciSendString("resume song",null,0,IntPtr.Zero);
				return "<>";
			}
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
		
		#region 格式化时间
		
		public string FormatTime(string time)
		{
			time=time.Trim();
			int unFormatTime=int.Parse(time);
			string min=(unFormatTime/1000/60).ToString();
			string second=(unFormatTime/1000%60).ToString();
			return min+":"+second;
		}
		#endregion
		
		
	}
}
