/*
 * 由SharpDevelop创建。
 * 用户： ki
 * 日期: 2016/4/19
 * 时间: 18:52
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace MusicPlayer
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.OnlineMusic = new System.Windows.Forms.Button();
			this.YourselfMusic = new System.Windows.Forms.Button();
			this.Search = new System.Windows.Forms.Button();
			this.SearchMusicName = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.Previous = new System.Windows.Forms.Button();
			this.PlayOrPause = new System.Windows.Forms.Button();
			this.Next = new System.Windows.Forms.Button();
			this.TimeBox = new System.Windows.Forms.GroupBox();
			this.TotalTime = new System.Windows.Forms.Label();
			this.NowTime = new System.Windows.Forms.Label();
			this.trackTime = new System.Windows.Forms.TrackBar();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.groupBox1.SuspendLayout();
			this.TimeBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackTime)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.OnlineMusic);
			this.groupBox1.Controls.Add(this.YourselfMusic);
			this.groupBox1.Controls.Add(this.Search);
			this.groupBox1.Controls.Add(this.SearchMusicName);
			this.groupBox1.Location = new System.Drawing.Point(13, 5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(160, 307);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(7, 36);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "我的音乐";
			// 
			// OnlineMusic
			// 
			this.OnlineMusic.Location = new System.Drawing.Point(6, 100);
			this.OnlineMusic.Name = "OnlineMusic";
			this.OnlineMusic.Size = new System.Drawing.Size(75, 23);
			this.OnlineMusic.TabIndex = 3;
			this.OnlineMusic.Text = "云音乐";
			this.OnlineMusic.UseVisualStyleBackColor = true;
			// 
			// YourselfMusic
			// 
			this.YourselfMusic.Location = new System.Drawing.Point(7, 62);
			this.YourselfMusic.Name = "YourselfMusic";
			this.YourselfMusic.Size = new System.Drawing.Size(75, 23);
			this.YourselfMusic.TabIndex = 2;
			this.YourselfMusic.Text = "本地音乐";
			this.YourselfMusic.UseVisualStyleBackColor = true;
			this.YourselfMusic.Click += new System.EventHandler(this.YourselfMusicClick);
			// 
			// Search
			// 
			this.Search.Location = new System.Drawing.Point(113, 8);
			this.Search.Name = "Search";
			this.Search.Size = new System.Drawing.Size(47, 23);
			this.Search.TabIndex = 1;
			this.Search.Text = "搜索";
			this.Search.UseVisualStyleBackColor = true;
			// 
			// SearchMusicName
			// 
			this.SearchMusicName.Location = new System.Drawing.Point(6, 8);
			this.SearchMusicName.Name = "SearchMusicName";
			this.SearchMusicName.Size = new System.Drawing.Size(100, 21);
			this.SearchMusicName.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.panel1.Location = new System.Drawing.Point(180, 13);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(327, 299);
			this.panel1.TabIndex = 1;
			// 
			// Previous
			// 
			this.Previous.Location = new System.Drawing.Point(13, 319);
			this.Previous.Name = "Previous";
			this.Previous.Size = new System.Drawing.Size(34, 23);
			this.Previous.TabIndex = 2;
			this.Previous.Text = "上";
			this.Previous.UseVisualStyleBackColor = true;
			this.Previous.Click += new System.EventHandler(this.PreviousClick);
			// 
			// PlayOrPause
			// 
			this.PlayOrPause.Location = new System.Drawing.Point(76, 319);
			this.PlayOrPause.Name = "PlayOrPause";
			this.PlayOrPause.Size = new System.Drawing.Size(31, 23);
			this.PlayOrPause.TabIndex = 3;
			this.PlayOrPause.Text = "<>";
			this.PlayOrPause.UseVisualStyleBackColor = true;
			this.PlayOrPause.Click += new System.EventHandler(this.PlayOrPauseClick);
			// 
			// Next
			// 
			this.Next.Location = new System.Drawing.Point(140, 319);
			this.Next.Name = "Next";
			this.Next.Size = new System.Drawing.Size(33, 23);
			this.Next.TabIndex = 4;
			this.Next.Text = "下";
			this.Next.UseVisualStyleBackColor = true;
			this.Next.Click += new System.EventHandler(this.NextClick);
			// 
			// TimeBox
			// 
			this.TimeBox.Controls.Add(this.TotalTime);
			this.TimeBox.Controls.Add(this.NowTime);
			this.TimeBox.Controls.Add(this.trackTime);
			this.TimeBox.Location = new System.Drawing.Point(180, 311);
			this.TimeBox.Name = "TimeBox";
			this.TimeBox.Size = new System.Drawing.Size(327, 31);
			this.TimeBox.TabIndex = 5;
			this.TimeBox.TabStop = false;
			// 
			// TotalTime
			// 
			this.TotalTime.Location = new System.Drawing.Point(248, 12);
			this.TotalTime.Name = "TotalTime";
			this.TotalTime.Size = new System.Drawing.Size(53, 23);
			this.TotalTime.TabIndex = 2;
			this.TotalTime.Text = "label2";
			// 
			// NowTime
			// 
			this.NowTime.Location = new System.Drawing.Point(7, 12);
			this.NowTime.Name = "NowTime";
			this.NowTime.Size = new System.Drawing.Size(35, 23);
			this.NowTime.TabIndex = 1;
			this.NowTime.Text = "label1";
			// 
			// trackTime
			// 
			this.trackTime.Location = new System.Drawing.Point(48, 8);
			this.trackTime.Name = "trackTime";
			this.trackTime.Size = new System.Drawing.Size(194, 45);
			this.trackTime.TabIndex = 0;
			this.trackTime.TickStyle = System.Windows.Forms.TickStyle.None;
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(519, 348);
			this.Controls.Add(this.TimeBox);
			this.Controls.Add(this.Next);
			this.Controls.Add(this.PlayOrPause);
			this.Controls.Add(this.Previous);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.groupBox1);
			this.Name = "MainForm";
			this.Text = "MusicPlayer";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.TimeBox.ResumeLayout(false);
			this.TimeBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackTime)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.TrackBar trackTime;
		private System.Windows.Forms.Label NowTime;
		private System.Windows.Forms.Label TotalTime;
		private System.Windows.Forms.GroupBox TimeBox;
		private System.Windows.Forms.Button Next;
		private System.Windows.Forms.Button PlayOrPause;
		private System.Windows.Forms.Button Previous;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox SearchMusicName;
		private System.Windows.Forms.Button Search;
		private System.Windows.Forms.Button YourselfMusic;
		private System.Windows.Forms.Button OnlineMusic;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
