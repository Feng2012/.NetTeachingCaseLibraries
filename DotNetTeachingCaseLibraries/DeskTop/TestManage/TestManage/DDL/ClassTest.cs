namespace TestManage.DDL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ClassTest
    {
        public int ID { get; set; }

        public int? ClassID { get; set; }

        public int? TestID { get; set; }

        public bool? IsValidate { get; set; }

        public virtual Class Class { get; set; }

        public virtual Test Test { get; set; }
    }
}
