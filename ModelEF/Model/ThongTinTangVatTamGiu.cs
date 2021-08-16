namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongTinTangVatTamGiu")]
    public partial class ThongTinTangVatTamGiu
    {
        [Key]
        [StringLength(5)]
        public string maBienBan { get; set; }

        public int? soBienLai { get; set; }

        public bool? tinhTrangHoanTra { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngayHoanTra { get; set; }

        public virtual ThongTinBienBan ThongTinBienBan { get; set; }
    }
}
