/*
 * 由SharpDevelop创建。
 * 用户： ki
 * 日期: 2016/4/19
 * 时间: 18:52
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Resources;
using System.IO;
using MusicPlayer.公共类;

namespace MusicPlayer
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		
		
		
		
		
		
		private ResourceManager rm;
		private Player pl;
		private Lrc lrc;
		private string path;
		private delegate void ShowLrcdelegate(string time);
		private ShowLrcdelegate myShowLrc;
		Dictionary<string ,string> lrcDic;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			Previous.Enabled=false;
			PlayOrPause.Enabled=false;
			Next.Enabled=false;
			trackTime.Enabled=false;
			NowTime.Text="";
			TotalTime.Text="";
			rm=new ResourceManager("MusicPlayer.Resource1",this.GetType().Assembly);
			Image startPic=(Image)(rm.GetObject("StartPicture"));
			if(startPic!=null)
			{
				panel1.BackgroundImage=startPic;
			}
			
		}
		
		
		
		
		void YourselfMusicClick(object sender, EventArgs e)
		{
			panel1.Hide();
			ListView songList=new ListView();
			songList.Name="songList";
			songList.View=View.Details;
			songList.Location=new Point(180,13);
			songList.Size=new Size(330,300);
			songList.FullRowSelect=true;
			songList.DoubleClick+=new EventHandler (this.songList_DoubleClick);
			ColumnHeader ch=new ColumnHeader();
			ch.Text="歌曲名字";
			ch.Width=80;
			ch.TextAlign=HorizontalAlignment.Left;
			songList.Columns.Add(ch);
			songList.Columns.Add("歌手",80,HorizontalAlignment.Left);
			songList.Columns.Add("时长",80,HorizontalAlignment.Left);
			//songList.Items.Add("kimolate");
			GetMusicList(songList);
			this.Controls.Add(songList);
		}
		//获取音乐列表
		public void GetMusicList(ListView LV)
		{
			
			
			string path=Application.StartupPath+@"\Music";
			var songs=Directory.GetFiles(path,"*.mp3");
			foreach(var song in songs)
			{
				ListViewItem lvi=new ListViewItem();
				string SongPath=song.ToString();
				lvi.Text=Path.GetFileName(SongPath);
				LV.Items.Add(lvi);
			}
		}
		
		
		//双击歌曲开始播放
		public void songList_DoubleClick(object sender,EventArgs e)
		{
			Previous.Enabled=true;
			Next.Enabled=true;
			PlayOrPause.Enabled=true;
			trackTime.Enabled=true;
			pl=new Player();
			ListView LV=(ListView)sender;
			path=Application.StartupPath+@"\Music\"+LV.SelectedItems[0].Text;
			//pl.OpenMusic(path);
			pl.CloseMusic();//打开前，先关闭音乐
			pl.playMusic(path);
			timer1.Start();
			LV.Hide();
			panel1.Show();
			//MessageBox.Show("hello");
		}
		//单击切换到下一首
		void NextClick(object sender, EventArgs e)
		{
			//Control ctr=this.Controls.Find("songList",true)[0];
			ListView LV=this.Controls.Find("songList",true)[0] as ListView;
			string path=pl.Next(LV);
			timer1.Stop();
			pl.CloseMusic();
			pl.playMusic(path);
			timer1.Start();
			PlayOrPause.Text="<>";
			
			
		}
		
		//单击上一首按钮，切换到上一首
		void PreviousClick(object sender, EventArgs e)
		{
			ListView LV=this.Controls.Find("songList",true)[0] as ListView;
			string path=pl.Previous(LV);
			timer1.Stop();
			pl.CloseMusic();
			
			pl.playMusic(path);
			timer1.Start();
			PlayOrPause.Text="<>";
			
			
		}
		
		void PlayOrPauseClick(object sender, EventArgs e)
		{
			Button playButt=(Button)sender;
			string status=playButt.Text;
			playButt.Text=pl.PlayOrPause(status);
			
		}
		
		void Timer1Tick(object sender, EventArgs e)
		{
			string songStatus=pl.GetSongStatus ();
			if(songStatus.IndexOf("playing")!=-1)
			{
				NowTime.Text=pl.GetSongTime();
				trackTime.Value=pl.GetOriginTime()[0];
				trackTime.Maximum=pl.GetOriginTime()[1];
			}
			string lrcPath=path.Substring(0,path.Length-3)+"lrc";
			//if(File.Exists(lrcPath))
			//{
				lrcDic=lrc.ReadLrc(lrcPath);
			//}
			TotalTime.Text=pl.GetTotaTime();
			foreach(string time in lrcDic.Keys)
			{
				if(time.IndexOf(NowTime.Text)!=-1)
				{
					
					
					myShowLrc(time);
					
					
					
				}
			}
			
			
			
		}
		
		
		
		void TrackTimeScroll(object sender, EventArgs e)
		{
			pl.SetSongTime(trackTime.Value*1000);
		}
		
		void ShowLrc(string time)
		{
			
			TextBox txtBox=(TextBox)panel1.Controls.Find("lrcTxtBox",true)[0];
			txtBox.Show();
			txtBox.Text=lrcDic[time];
			
			
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			myShowLrc=ShowLrc;
			lrc=new Lrc();
			
			lrcDic=new Dictionary<string, string>();
			
			TextBox txtBox=new TextBox();
			txtBox.Name="lrcTxtBox";
			txtBox.Width=200;
			txtBox.Location=new Point(20,100);
			txtBox.BorderStyle=BorderStyle.None;
			panel1.Controls.Add(txtBox);
			txtBox.Hide();
			
			
			
			
			
			
			
			
		}
	}
}
