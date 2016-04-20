/*
 * 由SharpDevelop创建。
 * 用户： ki
 * 日期: 2016/4/16
 * 时间: 19:55
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace BubleSort
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			DateTime beforDT = System.DateTime.Now;
			string tempStr="6 97 31 21 55 14 95 30 47 41 73 15 79 98 16 56 12 33 3 20 52 48 68 81 43 89 96 83 5 86 35 84 46 76 10 27 61 44 87 32 22 85 80 39 50 23 29 38 45 9 65 28 72 60 82 49 91 66 67 64 94 51 75 100 92 63 88 2 77 11 57 4 36 17 13 18 74 78 53 19 93 40 99 42 8 25 1 62 26 7 90 71 59 24 70 34 54 0 37 58";
			
			string[] Numstr=tempStr.Split(' ');
			int[] list=Array.ConvertAll<string, int>(Numstr, s => int.Parse(s));
			int[] listTemp=new int[list.Length];
			//MergeSort(list,0,list.Length-1,listTemp);
			QuickSort(list,0,list.Length-1);
			foreach(int i in list)
			{
				System.Console.WriteLine(i);
			}
			DateTime afterDT = System.DateTime.Now;
			TimeSpan ts = afterDT.Subtract(beforDT);
			Console.WriteLine("DateTime总共花费{0}ms.", ts.TotalMilliseconds);
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
		
		
		
		
		public static void QuickSort(int[] unsorted,int L,int R)
		{
			if(L<R)
			{
			int i=L,j=R;
			int x=unsorted[L];
			while(i<j)
			{
			while(i<j&&unsorted[j]>x)
				--j;
			if(i<j)
			{
				unsorted[i]=unsorted[j];
				i++;
			}
			while(i<j&&unsorted[i]<x)
				++i;
			if(i<j)
			{
				unsorted[j]=unsorted[i];
				--j;
			}
			}
			unsorted[i]=x;
			
		
				QuickSort(unsorted,L,i-1);
				QuickSort(unsorted,i+1,R);
			}
			
		}
		public static void MergeSort(int[] unsorted,int first,int last,int[] sorted)
		{
			if(first<last)
			{
				int mid=(first+last)/2;
				MergeSort(unsorted,first,mid,sorted);//左边序列
				MergeSort(unsorted,mid+1,last,sorted);//右边序列
				GuiBingSort(unsorted,first,mid,last,sorted);
				
			}
		}
		public static void GuiBingSort(int[] unsorted,int first,int mid,int last,int[] sorted)
		{
			
			int i=first;
			int j=mid+1;
			
			
			int k=0;
			while(i<=mid&&j<=last)
			{
				if(unsorted[i]>unsorted[j])
			{
				sorted[k++]=unsorted[j++];
			}
			else 
			{
				sorted[k++]=unsorted[i++];
			}
			}
			while(i<=mid)
			{
				sorted[k++]=unsorted[i++];
			}
			while(j<=last)
			{
				sorted[k++]=unsorted[j++];
			}
			for(i=0;i<k;i++)
			{
				unsorted[first+i]=sorted[i];
			}
		
		}
		
		
		
		
		
		
		public static void hellSort()
		{
			string tempStr="6 97 31 21 55 14 95 30 47 41 73 15 79 98 16 56 12 33 3 20 52 48 68 81 43 89 96 83 5 86 35 84 46 76 10 27 61 44 87 32 22 85 80 39 50 23 29 38 45 9 65 28 72 60 82 49 91 66 67 64 94 51 75 100 92 63 88 2 77 11 57 4 36 17 13 18 74 78 53 19 93 40 99 42 8 25 1 62 26 7 90 71 59 24 70 34 54 0 37 58";
			
			string[] Numstr=tempStr.Split(' ');
			int[] list=Array.ConvertAll<string, int>(Numstr, s => int.Parse(s));
			
			// TODO: Implement Functionality Here
			//int[] array=new int[]{1,2,5,6,3,4,9,7,8};
			for(int inc=list.Length/9;inc>1;inc/=2)
			{
				for(int ii=0;ii<inc;ii++)
				{
				for(int i=ii+inc;i<list.Length ;i+=inc)
				{
					int insertNum=list[i];
					int j=i-inc;
					while((j>=0)&&(list[j]>insertNum))
					{
						int temp=list[j];
						list[j]=insertNum;
						list[j+inc]=temp;
						j-=inc;
						
					}
				}
				}
			}
			
			foreach(int i in list)
			{
				System.Console.WriteLine(i);
			}
		}
		
	}
}