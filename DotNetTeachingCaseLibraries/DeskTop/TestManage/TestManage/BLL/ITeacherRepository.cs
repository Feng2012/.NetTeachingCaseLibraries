using Autofac;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManage.DDL;

namespace TestManage.BLL
{
    /// <summary>
    /// 班级业务类
    /// </summary>
    public interface ITeacherRepository 
    {

        /// <summary>
        /// 添加教师
        /// </summary>
        /// <param name="teacher">教师</param>
        /// <returns></returns>
        bool AddTeacher(Teacher teacher);

        /// <summary>
        /// 查询全部教师
        /// </summary>
        /// <returns></returns>
        IList GetTeachers();

        /// <summary>
        /// 修改教师
        /// </summary>
        /// <param name="teacher">教师</param>
        /// <returns></returns>
         bool ModifyTeacher(Teacher teacher);

        /// <summary>
        /// 删除教师
        /// </summary>
        /// <param name="id">教师ID</param>
        /// <returns></returns>
        bool RemoveTeacher(int id);

    }
}
