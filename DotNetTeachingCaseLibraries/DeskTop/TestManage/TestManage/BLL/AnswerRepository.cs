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
    /// 答案业务类
    /// </summary>
    public class AnswerRepository : IAnswerRepository
    {
        /// <summary>
        /// 数据操作对象
        /// </summary>
        IDBModel db;

        public AnswerRepository(IDBModel testManageDB)
        {
            db = testManageDB;
        }
        /// <summary>
        /// 添加答案
        /// </summary>
        /// <param name="answer">科目</param>
        /// <returns></returns>
        public bool AddAnswer(Answer answer)
        {
            db.Answers.Add(answer);
            var result = db.SaveChanges();
            return result > 0;
        }
        /// <summary>
        /// 按问题ID查询答案
        /// </summary>
        /// <returns></returns>
        public IList GetAnswers(int questionID)
        {
            return db.Answers.Where(w=>w.QuestionID==questionID).Select(s => new { 编号 = s.ID, 答案 = s.Answer1, 是否正确答案=s.IsAnswer }).ToList();
        }
        /// <summary>
        /// 修改答案
        /// </summary>
        /// <param name="answer">答案</param>
        /// <returns></returns>
        public bool ModifyAnswer(Answer answer)
        {
            var oldAnswer = db.Answers.Find(answer.ID);
            if (oldAnswer == null)
            {
                throw new Exception($"查询不到ID为{answer.ID}的科目");
            }
            else
            {
                oldAnswer.IsAnswer = answer.IsAnswer;
                oldAnswer.QuestionID = answer.QuestionID;
              
                var result = db.SaveChanges();
                return result > 0;
            }
        }
        /// <summary>
        /// 删除答案
        /// </summary>
        /// <param name="id">答案ID</param>
        /// <returns></returns>
        public bool RemoveAnswer(int id)
        {
            var oldAnswer = db.Answers.Find(id);
            if (oldAnswer == null)
            {
                throw new Exception($"查询不到ID为{id}的科目");
            }
            else
            {
                db.Answers.Remove(oldAnswer);
                var result = db.SaveChanges();
                return result > 0;
            }

        }

    }
}
