/*
 * 由SharpDevelop创建。
 * 用户： ki
 * 日期: 2016/4/19
 * 时间: 21:31
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Data;


namespace MusicPlayer.公共类
{
	/// <summary>
	/// Description of DataProcess.
	/// </summary>
	public class DataProcess
	{
		public DataProcess()
		{
		}
		
		
		#region 连接数据库
		
		public List<string> ConnectSQLite(string conString)
		{
			List<string> songList=new List<string>();
			SQLiteConnection sqliteCon=new SQLiteConnection(conString);
			sqliteCon.Open();
			SQLiteCommand cmd=new SQLiteCommand(sqliteCon);
			cmd.CommandText="select * from SongList";
			cmd.CommandType=CommandType.Text;
			using(SQLiteDataReader reader=cmd.ExecuteReader())
			{
				while(reader.Read())
				{
					songList.Add(reader[0].ToString());
				}
			}
			return songList;
			      
		}
		#endregion
		
		#region 读取歌曲目录
		#endregion
		
	}
}
