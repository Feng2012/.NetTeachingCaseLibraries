using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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


            var container = CreateContioner();
            using (var scope = container.BeginLifetimeScope())
            {


                //实例化登录窗体
                var frmLogin = scope.Resolve<frmLogin>();
                //判断登录是否成功
                if (frmLogin.ShowDialog() == DialogResult.OK)
                {
                    if (frmLogin.Teacher != null)
                    {
                        var frmMain = scope.Resolve<frmMain>();
                        Application.Run(frmMain);
                    }
                    else
                    {
                        var frmTest = scope.Resolve<frmTest>();
                        frmTest.TestStudent = frmLogin.Student;
                        Application.Run(frmTest);
                    }
                }
            }
        }
        static IContainer CreateContioner()
        {
            var builder = new ContainerBuilder();
            //注入数据操作
            builder.RegisterType<TestManageModel>().As<IDBModel>();
            //注入业务仓储
            //builder.RegisterType<ClassRepository>().As<IClassRepository>();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
      .Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces();
            //注入窗体
            // builder.RegisterType<frmClassSetting>().As<frmClassSetting>();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
       .Where(t => t.Name.StartsWith("frm")).AsSelf();

            return builder.Build();


        }
    }



}
