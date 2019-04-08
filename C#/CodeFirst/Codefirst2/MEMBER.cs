namespace Test1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MEMBER")]
    public partial class MEMBER
    {
        [StringLength(50)]
        public string ID { get; set; }

        [Required]
        [StringLength(200)]
        public string PASSWORD { get; set; }

        [Required]
        [StringLength(100)]
        public string NAME { get; set; }

        public int AGE { get; set; }

        [StringLength(200)]
        public string ADDRESS { get; set; }

        [StringLength(200)]
        public string COMMENT { get; set; }
    }
}
