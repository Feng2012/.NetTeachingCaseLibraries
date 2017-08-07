using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManage.DDL;

namespace TestManage.BLL
{
    public class ClassBll
    {
        TestManageModel _testManageDB;
        public ClassBll(TestManageModel testManageDB)
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
