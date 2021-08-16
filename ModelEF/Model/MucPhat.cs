namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MucPhat")]
    public partial class MucPhat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MucPhat()
        {
            ThongTinBienBans = new HashSet<ThongTinBienBan>();
        }

        [Key]
        [StringLength(5)]
        public string maLoi { get; set; }

        [StringLength(200)]
        public string tenLoi { get; set; }

        public decimal? soTienPhat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongTinBienBan> ThongTinBienBans { get; set; }
    }
}
