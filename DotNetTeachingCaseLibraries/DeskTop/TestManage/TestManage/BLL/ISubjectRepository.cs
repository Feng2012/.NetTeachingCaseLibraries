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
    /// 课目业务类
    /// </summary>
    public interface ISubjectRepository
    {

        /// <summary>
        /// 添加科目
        /// </summary>
        /// <param name="subject">科目</param>
        /// <returns></returns>
        bool AddSubject(Subject subject);

        /// <summary>
        /// 查询全部科目
        /// </summary>
        /// <returns></returns>
        IList GetSubjects();

        /// <summary>
        /// 修改科目
        /// </summary>
        /// <param name="subject">科目</param>
        /// <returns></returns>
         bool ModifySubject(Subject subject);

        /// <summary>
        /// 删除科目
        /// </summary>
        /// <param name="id">科目ID</param>
        /// <returns></returns>
         bool RemoveSubject(int id);      

    }
}
