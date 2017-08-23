﻿using Autofac;
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
    /// 题目业务类
    /// </summary>
    public interface IQuestionRepository
    {

        /// <summary>
        /// 添加题目
        /// </summary>
        /// <param name="question">题目</param>
        /// <returns></returns>
        bool AddQuestion(Question question);
        /// <summary>
        /// 按考试ID查询全部题目
        /// </summary>
        /// <returns></returns>
        IList GetQuestions(int testID);
        /// <summary>
        /// 修改题目
        /// </summary>
        /// <param name="Question">题目</param>
        /// <returns></returns>
        bool ModifyQuestion(Question Question);
        /// <summary>
        /// 删除题目
        /// </summary>
        /// <param name="id">题目ID</param>
        /// <returns></returns>
        bool RemoveQuestion(int id);
    }
}
