namespace ModelEF.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QLVPHC : DbContext
    {
        public QLVPHC()
            : base("name=QLVPHC")
        {
        }

        public virtual DbSet<MucPhat> MucPhats { get; set; }
        public virtual DbSet<NguoiViPham> NguoiViPhams { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<ThongTinBienBan> ThongTinBienBans { get; set; }
        public virtual DbSet<ThongTinTangVatTamGiu> ThongTinTangVatTamGius { get; set; }
        public virtual DbSet<TTBienLai> TTBienLais { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MucPhat>()
                .Property(e => e.maLoi)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MucPhat>()
                .Property(e => e.soTienPhat)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MucPhat>()
                .HasMany(e => e.ThongTinBienBans)
                .WithOptional(e => e.MucPhat)
                .HasForeignKey(e => e.maLoiViPham);

            modelBuilder.Entity<NguoiViPham>()
                .Property(e => e.soCMND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NguoiViPham>()
                .Property(e => e.soDienThoai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.soCMND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.soDienThoai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.taiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.ThongTinBienBans)
                .WithOptional(e => e.NhanVien)
                .HasForeignKey(e => e.maThanhTra);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.tenTaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.matKhau)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.NhanViens)
                .WithRequired(e => e.TaiKhoan1)
                .HasForeignKey(e => e.taiKhoan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThongTinBienBan>()
                .Property(e => e.maBienBan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinBienBan>()
                .Property(e => e.soCMND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinBienBan>()
                .Property(e => e.bienSoXe)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinBienBan>()
                .Property(e => e.maLoiViPham)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinBienBan>()
                .HasOptional(e => e.ThongTinTangVatTamGiu)
                .WithRequired(e => e.ThongTinBienBan);

            modelBuilder.Entity<ThongTinTangVatTamGiu>()
                .Property(e => e.maBienBan)
                .IsFixedLength()
                .IsUnicode(false);

            //modelBuilder.Entity<TTBienLai>()
            //    .Property(e => e.maBienLai)
            //    .IsUnicode(false);

            modelBuilder.Entity<TTBienLai>()
                .Property(e => e.maBienBan)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
