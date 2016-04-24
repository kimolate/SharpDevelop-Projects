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
		private DataProcess DataSong;
		private string path;
		private delegate void ShowLrcdelegate(string time);
		private ShowLrcdelegate myShowLrc;
		Dictionary<string ,string> lrcDic;
		private Image startPic;
		private string connectionString;
		
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
			path=Application.StartupPath+@"\Music";
			rm=new ResourceManager("MusicPlayer.Resource1",this.GetType().Assembly);
			startPic=(Image)(rm.GetObject("StartPicture"));
			if(startPic!=null)
			{
				panel1.BackgroundImage=startPic;
			}
			
		}
		
		
		
		
		void YourselfMusicClick(object sender, EventArgs e)
		{
			panel1.Hide();
			
			//songList.Items.Add("kimolate");
			ListView songList=ShowSongList();
			
			string originPath=Application.StartupPath+@"\Music";
			path=originPath;
			GetMusicList(songList);
			List<string> songs=new List<string>();
			if((Button)sender==OnlineMusic)
			{
				songList.Items.Clear();
				DataSong=new DataProcess();
				connectionString =string.Format("Data Source={0};Pooling=true;FailIfMissing=false",Application.StartupPath+"\\Song.db");
				songs=DataSong.ConnectSQLite(connectionString);
				foreach(string songPath in songs)
				{
					string song=songPath.Substring(songPath.LastIndexOf('\\')+1);
					songList.Items.Add(new ListViewItem(song));
				}
				path=songs[0].Substring(0,songs[0].LastIndexOf('\\'));
			}
			
			if((Button)sender==Search)
			{
				string searchSong=null;
				foreach(ListViewItem songLine in songList.Items)
				{
					if(songLine.SubItems[0].ToString().IndexOf(SearchMusicName.Text)!=-1)
					{
						searchSong=songLine.SubItems[0].Text;
						break;
					}
				}
				songList.Clear();
				songList=ShowSongList();
				if(searchSong!=null)
				{
				songList.Items.Add(new ListViewItem(searchSong));
				}
			}
			this.Controls.Add(songList);
			
		}
		public ListView ShowSongList()
		{
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
			return songList;
		}
		
		
		
		//获取音乐列表
		public void GetMusicList(ListView LV)
		{
			
			
		
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
			path=path+"\\"+LV.SelectedItems[0].Text;
			//pl.OpenMusic(path);
			pl.CloseMusic();//打开前，先关闭音乐
			pl.playMusic(path);
			timer1.Start();
			LV.Hide();
			panel1.Show();
			panel1.Refresh();
			//MessageBox.Show("hello");
		}
		//单击切换到下一首
		void NextClick(object sender, EventArgs e)
		{
			//Control ctr=this.Controls.Find("songList",true)[0];
			ListView LV=this.Controls.Find("songList",true)[0] as ListView;
			path=pl.Next(LV);
			timer1.Stop();
			pl.CloseMusic();
			pl.playMusic(path);
			timer1.Start();
			PlayOrPause.Text="<>";
			panel1.Refresh();
			
			
		}
		
		//单击上一首按钮，切换到上一首
		void PreviousClick(object sender, EventArgs e)
		{
			ListView LV=this.Controls.Find("songList",true)[0] as ListView;
			path=pl.Previous(LV);
			timer1.Stop();
			pl.CloseMusic();
			
			pl.playMusic(path);
			timer1.Start();
			PlayOrPause.Text="<>";
			panel1.Refresh();
			
			
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
			TotalTime.Text=pl.GetTotaTime();
			string lrcPath=path.Substring(0,path.Length-3)+"lrc";
			if(File.Exists(lrcPath))
			{
				lrcDic=lrc.ReadLrc(lrcPath);
				
				
				foreach(string time in lrcDic.Keys)
				{
					if(time.IndexOf(NowTime.Text)!=-1)
					{
						
						
						myShowLrc(time);
						
						break;
						
						
						
					}
				}
			}
			
			
			
		}
		
		
		
		void TrackTimeScroll(object sender, EventArgs e)
		{
			pl.SetSongTime(trackTime.Value*1000);
		}
		
		void ShowLrc(string time)
		{
			Bitmap bmap=new Bitmap(startPic,panel1.Width,panel1.Height);
			Graphics grap=Graphics.FromImage(bmap);
			grap.DrawString(string.Format("{0}",lrcDic[time]), new Font(FontFamily.GenericMonospace, 12f), Brushes.Red, new PointF(10,100));

			
			
			
			Graphics g=panel1.CreateGraphics();
			g.DrawImage(bmap,0,0);
			//panel1.Controls.Add(LrcPanel);
			//startPic.Dispose();
			
			grap.Dispose();
			bmap.Dispose();
			
			
			
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
