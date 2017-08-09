using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManage.DDL
{
    /// <summary>
    /// EF操作类接口
    /// </summary>
    public interface IDBModel
    {
        DbSet<Answer> Answers { get; set; }
        DbSet<Class> Classes { get; set; }
        DbSet<ClassTest> ClassTests { get; set; }
        DbSet<Question> Questions { get; set; }
        DbSet<Score> Scores { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<Subject> Subjects { get; set; }
        DbSet<Test> Tests { get; set; }
        DbSet<Teacher> Teachers { get; set; }
        int SaveChanges();
    }
}
