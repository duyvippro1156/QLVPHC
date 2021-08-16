namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TTBienLai")]
    public partial class TTBienLai
    {
        [Key]        
        public int maBienLai { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngayXuat { get; set; }

        [StringLength(5)]
        public string maBienBan { get; set; }

        [StringLength(10)]
        public string tinhTrangNopPhat { get; set; }

        public virtual ThongTinBienBan ThongTinBienBan { get; set; }
    }
}
