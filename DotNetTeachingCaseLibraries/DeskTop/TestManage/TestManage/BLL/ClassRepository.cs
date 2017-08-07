using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManage.DDL;

namespace TestManage.BLL
{
    public class ClassRepository : IClassRepository
    {
        public IDBModel _testManageDB;
    
        public ClassRepository(IDBModel testManageDB)
        {
            _testManageDB = testManageDB;
        }

        public bool AddClass(Class cls)
        {
            _testManageDB.Classes.Add(cls);
            var result = _testManageDB.SaveChanges();
            return result > 0;
        }

    }
}
