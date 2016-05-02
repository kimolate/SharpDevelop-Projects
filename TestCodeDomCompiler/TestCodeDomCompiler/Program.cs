/*
 * 由SharpDevelop创建。
 * 用户： ki
 * 日期: 2016/4/24
 * 时间: 21:50
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Reflection;
using Microsoft.CSharp;
using System.CodeDom.Compiler;

namespace CodeDom
{
    class Program
    {
        static void Main(string[] args)
        {
            //需要编译的字符串
            string MyCodeString = @"
                using System;
                using System.Collections;
                using System.Xml;
                using System.IO;
                using System.Windows.Forms;

                namespace CSharpScripter
                {
                    public class MyTest
                    {
                        public static string GetTestString(string param)
                        {
                            string MyStr = ""This is a Dynamic Compiler Demo!"" + param + DateTime.Now;
                            MessageBox.Show(MyStr);
                            return MyStr;
                        }
                    }
                }";

            CompilerParameters compilerParams = new CompilerParameters();
            //编译器选项设置
            compilerParams.CompilerOptions = "/target:library /optimize";
            //编译时在内存输出
            compilerParams.GenerateInMemory = true;
            //生成调试信息
            compilerParams.IncludeDebugInformation = false;
            //添加相关的引用
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add("System.Data.dll");
            compilerParams.ReferencedAssemblies.Add("System.Xml.dll");
            compilerParams.ReferencedAssemblies.Add("mscorlib.dll");
            compilerParams.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            ICodeCompiler compiler = new CSharpCodeProvider().CreateCompiler();
            //编译
            CompilerResults results = compiler.CompileAssemblyFromSource(compilerParams, MyCodeString);
            //创建程序集
            Assembly asm = results.CompiledAssembly;
            //获取编译后的类型
            object objMyTestClass = asm.CreateInstance("CSharpScripter.MyTest");
            Type MyTestClassType = objMyTestClass.GetType();
            //输出结果
            Console.WriteLine(MyTestClassType.GetMethod("GetTestString").Invoke(objMyTestClass, new object[] { "测试" }));
            Console.ReadLine();
        }
    }
}