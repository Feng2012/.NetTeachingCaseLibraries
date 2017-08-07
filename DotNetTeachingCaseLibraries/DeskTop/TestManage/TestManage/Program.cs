using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestManage.BLL;
using TestManage.DDL;

namespace TestManage
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ////实例化登录窗体
            //var loginForm = new frmLogin();
            ////判断登录是否成功
            //if (loginForm.ShowDialog() == DialogResult.OK)
            //{
            //    Application.Run(new frmMain());
            //}
            LoadContioner();

            Application.Run(new frmMain());

        }

        public static IContainer container;
        static void LoadContioner()
        {
            var builder = new ContainerBuilder();
            //注入
            builder.RegisterType<TestManageModel>().As<IDBModel>();

            builder.RegisterType<ClassRepository>().As<IClassRepository>();

          

            container = builder.Build();
          
 
        }
    }


}
