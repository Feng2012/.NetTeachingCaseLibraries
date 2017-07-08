using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManage.DDL;

namespace TestManage.BLL
{
    public interface IClassRepository
    {
         bool AddClass(Class cls);

        bool RemoveClass(int id);

        bool ModifyClass(Class cls);

        List<Class> GetClasses();

    }
}
