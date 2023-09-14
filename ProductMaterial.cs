namespace PriatnijShelest
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductMaterial")]
    public partial class ProductMaterial
    {
        public int ProductID { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaterialID { get; set; }

        public double? Count { get; set; }

        public virtual Material Material { get; set; }

        public virtual Product Product { get; set; }
    }
}
