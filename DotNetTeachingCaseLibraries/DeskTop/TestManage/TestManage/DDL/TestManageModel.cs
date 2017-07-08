namespace TestManage.DDL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TestManageModel : DbContext,IDBModel
    {
        public TestManageModel()
            : base("name=TestManageModel")
        { 
        }

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<ClassTest> ClassTests { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Score> Scores { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Test> Tests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>()
                .Property(e => e.Answer1)
                .IsUnicode(false);

            modelBuilder.Entity<Class>()
                .Property(e => e.ClassName)
                .IsUnicode(false);

            modelBuilder.Entity<Class>()
                .Property(e => e.Memo)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.No)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.Question1)
                .IsUnicode(false);

            modelBuilder.Entity<Score>()
                .Property(e => e.StudentNo)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.StuNo)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.CardID)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Sex)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Scores)
                .WithOptional(e => e.Student)
                .HasForeignKey(e => e.StudentNo);

            modelBuilder.Entity<Subject>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Test>()
                .Property(e => e.TestName)
                .IsUnicode(false);
        }
     
    }
}
