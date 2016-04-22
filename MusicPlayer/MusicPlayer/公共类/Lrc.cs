/*
 * 由SharpDevelop创建。
 * 用户： ki
 * 日期: 2016/4/22
 * 时间: 20:00
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace MusicPlayer.公共类
{
	/// <summary>
	/// Description of Lrc.
	/// </summary>
	public class Lrc
	{
		public Lrc()
		{
		}
		
		
		#region 打开歌词文件
		
		
		public Dictionary<string,string> ReadLrc(string lrc)
		{
			StreamReader Sreader=new StreamReader(lrc);
			Dictionary<string,string> lrcDic=new Dictionary<string, string>();
			List<string> timeAndLrc=new List<string>();
			string lrcLine;
			while((lrcLine=Sreader.ReadLine())!=null)
			{
				timeAndLrc=FormatLrcLine(lrcLine);
				for(int i=0;i<timeAndLrc.Count-1;i++)
				{
					lrcDic.Add(timeAndLrc[i],timeAndLrc[timeAndLrc.Count-1]);
				}
				
			}
			return lrcDic;
		}
		#endregion
		
		#region 格式化歌词行
		public List<string> FormatLrcLine(string lrcLine)
		{
			string timePattern=@"(?<=\[).*?(?=\])";
			string lrcPattern=@"(?<=\])(?!\[).*";
			MatchCollection Timemc=Regex.Matches(lrcLine,timePattern);
			MatchCollection Lrcmc=Regex.Matches(lrcLine,lrcPattern);
			List<string> timeAndLrc=new List<string>();
			foreach(var time in Timemc)
			{
				timeAndLrc.Add(time.ToString());
			}
			foreach(var lrc in Lrcmc)
			{
				timeAndLrc.Add(lrc.ToString());
			}
			return timeAndLrc;
		}
		
		
		#endregion
	}
}
