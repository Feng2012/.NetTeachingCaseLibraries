namespace TestManage.DDL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Score
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string StudentNo { get; set; }

        public int? AnswerID { get; set; }

        [Column("Score")]
        public double? Score1 { get; set; }

        public virtual Answer Answer { get; set; }

        public virtual Student Student { get; set; }
    }
}
