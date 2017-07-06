namespace TestManage.DDL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            Scores = new HashSet<Score>();
        }

        [Key]
        [StringLength(50)]
        public string StuNo { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(18)]
        public string CardID { get; set; }

        [StringLength(4)]
        public string Sex { get; set; }

        public DateTime? Birthday { get; set; }

        public int? ClassID { get; set; }

        public virtual Class Class { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Score> Scores { get; set; }
    }
}
