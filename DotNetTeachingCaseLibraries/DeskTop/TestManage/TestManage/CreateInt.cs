using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManage
{
    public class CreateInt
    {
        public static T Create<T>(T obj) where T:class
        {
            var scope = Program.container.BeginLifetimeScope();
            return scope.Resolve<T>();
        }
    }
}
