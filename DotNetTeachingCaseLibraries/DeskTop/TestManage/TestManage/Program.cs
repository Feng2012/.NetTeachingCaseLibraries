using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            using (var scope = container.BeginLifetimeScope())
            {
                var sometype = scope.Resolve<IService>();

                Application.Run(new frmMain(sometype));
            }
        }

        public static IContainer container;
        static void LoadContioner()
        {
            var builder = new ContainerBuilder();

            // Register individual components
            builder.RegisterType<SomeType>().As<IService>();

            container = builder.Build();
        }
    }

    public interface IService
    {
        void F();
    }
    public class SomeType : IService
    {
        public void F()
        {
            MessageBox.Show("F");
        }
    }
}
