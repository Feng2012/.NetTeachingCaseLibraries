﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManage.DDL;

namespace TestManage.BLL
{
    public interface IStudentRepository
    {
        /// <summary>
        /// 按学号查询学生
        /// </summary>
        /// <param name="sutNo">学号</param>
        /// <param name="cardID">身份证</param>
        /// <returns></returns>
        Student GetStudent(string sutNo, string cardID);


        /// <summary>
        /// 添加学生
        /// </summary>
        /// <param name="student">学生</param>
        /// <returns></returns>
        bool AddStudent(Student student);

        /// <summary>
        /// 查询全部学生
        /// </summary>
        /// <returns></returns>
        IList GetStudentsByClsID(int clsID);

        /// <summary>
        /// 修改学生
        /// </summary>
        /// <param name="student">学生</param>
        /// <returns></returns>
        bool ModifyStudent(Student student);

        /// <summary>
        /// 删除学生
        /// </summary>
        /// <param name="stuNo">学号</param>
        /// <returns></returns>
        bool RemoveClass(string stuNo);

    }
}
