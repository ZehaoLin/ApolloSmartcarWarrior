using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserWinFroms
{
    public partial class frmImageAlgorithm : Form
    {
        private OpenFileDialog openFileDialog = new OpenFileDialog();
        public byte[,] Image { get; set; }

        public frmImageAlgorithm()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            //打开文本操作，这里仅限TXT文件~！！！
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                if (System.IO.File.Exists(fileName))// 确认文件是否存在
                {
                    //读取指定的文本文件,并支持中文编码字符 
                    StreamReader sr = new StreamReader(fileName, System.Text.Encoding.GetEncoding("gb2312"));
                    string str = sr.ReadToEnd();
                    sr.Close();//关闭文本文件
                    txbCode.Text = str;//将文本显示到TextBox中                  
                }
            }
            else
            {
                MessageBox.Show("Warning", "文件打开失败，请打开文本文件！");
            }
        }

        public void Run()
        {
            CSharpCodeProvider provider = new CSharpCodeProvider();
            ICodeCompiler compiler = provider.CreateCompiler();

            CompilerParameters parameter = new CompilerParameters();

            //添加需要引用的DLL
            parameter.ReferencedAssemblies.Add("System.dll");
            parameter.ReferencedAssemblies.Add("System.Windows.Forms.dll");

            //是否生成可执行文件
            parameter.GenerateExecutable = false;
            //是否生成在内存中
            parameter.GenerateInMemory = true;

            CompilerResults cr = compiler.CompileAssemblyFromSource(parameter, txbCode.Text);

            if (cr.Errors.HasErrors)
            {
                var msg = string.Join(Environment.NewLine, cr.Errors.Cast<CompilerError>().Select(err => err.ErrorText));
                MessageBox.Show(msg, "编译错误");
            }
            else
            {
                Assembly assembly = cr.CompiledAssembly;
                object obj = assembly.CreateInstance("CSharpCode");
                MethodInfo mi = obj.GetType().GetMethod("ImageProcess");
                mi.Invoke(obj, new object[] { Image });
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            Run();
        }
    }
}
