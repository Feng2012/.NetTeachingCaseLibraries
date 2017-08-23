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
    /// 题目业务类
    /// </summary>
    public class QuestionRepository : IQuestionRepository
    {
        /// <summary>
        /// 数据操作对象
        /// </summary>
        IDBModel db;

        public QuestionRepository(IDBModel testManageDB)
        {
            db = testManageDB;
        }
        /// <summary>
        /// 添加题目
        /// </summary>
        /// <param name="question">题目</param>
        /// <returns></returns>
        public bool AddQuestion(Question question)
        {
            db.Questions.Add(question);
            var result = db.SaveChanges();
            return result > 0;
        }
        /// <summary>
        /// 按考试ID查询全部题目
        /// </summary>
        /// <returns></returns>
        public IList GetQuestionsByTestID(int testID)
        {
            return db.Questions.Where(w=>w.TestID==testID).Select(s => new {ID= s.ID, 题目名称 = s.Question1, 题目编号 = s.TestID,满分=s.FullScore,编号 = s.No }).ToList();
        }
        /// <summary>
        /// 修改题目
        /// </summary>
        /// <param name="Question">题目</param>
        /// <returns></returns>
        public bool ModifyQuestion(Question Question)
        {
            var oldQuestion = db.Questions.Find(Question.ID);
            if (oldQuestion == null)
            {
                throw new Exception($"查询不到ID为{Question.ID}的题目");
            }
            else
            {
                oldQuestion.No = Question.No;
                oldQuestion.FullScore = Question.FullScore;
                oldQuestion.Question1 = Question.Question1;
                oldQuestion.TestID = Question.TestID;             
                var result = db.SaveChanges();
                return result > 0;
            }
        }
        /// <summary>
        /// 删除题目
        /// </summary>
        /// <param name="id">题目ID</param>
        /// <returns></returns>
        public bool RemoveQuestion(int id)
        {
            var oldQuestion = db.Questions.Find(id);
            if (oldQuestion == null)
            {
                throw new Exception($"查询不到ID为{id}的题目");
            }
            else
            {
                db.Questions.Remove(oldQuestion);
                var result = db.SaveChanges();
                return result > 0;
            }

        }

    }
}
