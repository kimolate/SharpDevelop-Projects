using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
 
namespace TestHttpDownload
{
    public class DownLoadFile
    {
        ///
        /// 下载文件方法
        ///
        /// 文件保存路径
        /// 返回下载成功否？
        ///
        public bool DeownloadFile(string strFileName)
        {
        	WebRequest request=WebRequest.Create("http://111.23.10.19/cache/dl.2345.com/haozip/haozip_v5.8.exe?ich_args=38455d2b495458ea72a812945548839a_5400_0_0_9_e93f520b0704dddd2eaea1bd866fe84887ea2c9f5d2c96347ce800798330194f_de3d215f60d25a86f104f66858a6a922_1_0&ich_ip=10-202");
        	request.Credentials=CredentialCache.DefaultCredentials;
        	HttpWebResponse response=(HttpWebResponse)request.GetResponse();
        	Stream data=response.GetResponseStream();
        	FileStream Fstream=new FileStream(strFileName,FileMode.Create);
        	byte[] btContent=new byte[512];
        	int size=data.Read(btContent,0,512);
        	while(size>0)
        	{
        		Fstream.Write(btContent, 0, size);
                    size = data.Read(btContent, 0, 512);

        	}
        	data.Close();
        	Fstream.Close();
        	return true ;
        	
        }
    }
}