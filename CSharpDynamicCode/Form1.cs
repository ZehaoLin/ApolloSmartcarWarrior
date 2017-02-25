using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpDynamicCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            Run();
        }

        private void Run()
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
                object obj = assembly.CreateInstance("Test");
                MethodInfo mi = obj.GetType().GetMethod("Hello");
                mi.Invoke(obj, null);
            }
        }
    }
}
