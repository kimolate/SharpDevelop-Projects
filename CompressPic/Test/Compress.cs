/*
 * 由SharpDevelop创建。
 * 用户： ki
 * 日期: 2016/5/9
 * 时间: 23:12
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading;
namespace CompressPic

{
    /// <summary>
    /// Description of MyClass.
    /// </summary>
    public class Compress
    {
    	#region 压缩路径，保存路径，分组路径，序号等属性
         string CompressPath;
         public string _CompressPath
         {
         	get{return CompressPath;}
         	set{CompressPath=value;}
         }
        string savepath;
        public string _savepath
        {
        	get{return savepath;}
        	set{savepath=value;}
        }
         string path;
         public string _path
         {
         	get{return path;}
         	set{path=value;}
         }
         int tag;
         public int _tag
         {
         	get{return tag;}
         	set{tag=value;}
         }
         #endregion
        //static ManualResetEvent _mre = new ManualResetEvent(false);
        //public Compress(string path,int tag)
        //{
        //	this.path=path;
        //	this.tag=tag;
        //}
        //public Compress(string CPath, string saPath)
        //{
        //    CompressPath = CPath;
        //  savepath = saPath;
       // }

        public void compress()
        {

            if (_path != "")
            {
                
            	Process exep= new Process();
            	exep.StartInfo.FileName="C:\\Program Files\\2345Soft\\HaoZip\\HaoZipC.exe";
            	exep.StartInfo.Arguments=string.Format("a -tzip  {0}Pic{1}.zip -psecret {2}", _savepath + "\\", _tag, _path);
                exep.StartInfo.UseShellExecute = false;
                exep.StartInfo.CreateNoWindow = true;
               	exep.Start();
                //_mre.WaitOne();
             
                Thread th = Thread.CurrentThread;
                while (!exep.HasExited)
                {
                   
                }
                
                //exep.WaitForExit();//阻塞线程，直至上一个外部程序线程退出
                //Thread.Sleep(10000);
            }
            //return true;

        }


        /// <summary>
        /// 获取指定目录中的所有图片路径，以100个一组添加入list
        /// </summary>
        /// <returns>字符串列表数组</returns>
        public  List<string> GetFileName()
        {
            
                var files = Directory.GetFiles(_CompressPath, "*.*", SearchOption.TopDirectoryOnly)//读取所有文件
                    .Where(s => s.EndsWith(".png") || s.EndsWith(".jpg") || s.EndsWith(".jpeg") || s.EndsWith(".bmp") || s.EndsWith(".gif"));//过滤图片文件
                string fileCollection = "";
                List<string> fileUnit = new List<string>();
                int count = 0;//记录文件数
                foreach (string file in files)
                {
                    _CompressPath = file.ToString();


                    fileCollection += " " + file.ToString();
                    count++;

                    if ((count != 0) && (count % 10 == 0))//以100个一组
                    {
                        fileUnit.Add(fileCollection);
                        fileCollection = "";
                        //fileCollection.Clear();
                    }


                }
                fileUnit.Add(fileCollection);//将剩余的图片路径添加进去
            
           
            return fileUnit;
        }
        //生成包含所有文件名的字符串参数
        public  List<string> CreateFileParam()
        {
            return GetFileName();
        }
      



    }
}