using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataModel
{
    public partial class QLD_THDContext : DbContext
    {
        public QLD_THDContext()
        {
        }

        public QLD_THDContext(DbContextOptions<QLD_THDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Ctdiem> Ctdiems { get; set; }
        public virtual DbSet<Diem> Diems { get; set; }
        public virtual DbSet<GiaoVien> GiaoViens { get; set; }
        public virtual DbSet<HocSinh> HocSinhs { get; set; }
        public virtual DbSet<Khoi> Khois { get; set; }
        public virtual DbSet<LoaiDiem> LoaiDiems { get; set; }
        public virtual DbSet<Lop> Lops { get; set; }
        public virtual DbSet<MonHoc> MonHocs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=NAM\\SQLEXPRESS;Initial Catalog=QLD_THD;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.AccountId).ValueGeneratedNever();

                entity.Property(e => e.AccountName).HasMaxLength(50);

                entity.Property(e => e.LoaiQuyen).HasMaxLength(50);

                entity.Property(e => e.MatKhau).HasMaxLength(50);

                entity.Property(e => e.TrangThai).HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Account_User");
            });

            modelBuilder.Entity<Ctdiem>(entity =>
            {
                entity.HasKey(e => e.MaCtdiem);

                entity.ToTable("CTDiem");

                entity.Property(e => e.MaCtdiem)
                    .HasMaxLength(50)
                    .HasColumnName("MaCTDiem");

                entity.Property(e => e.DiemTbmon).HasColumnName("DiemTBMon");

                entity.Property(e => e.MaBangDiem)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MaGvcn)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("MaGVCN");

                entity.Property(e => e.MaHocSinh)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MaLoaiDiem)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MaMonHoc)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.MaBangDiemNavigation)
                    .WithMany(p => p.Ctdiems)
                    .HasForeignKey(d => d.MaBangDiem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CTDiem_Diem");

                entity.HasOne(d => d.MaLoaiDiemNavigation)
                    .WithMany(p => p.Ctdiems)
                    .HasForeignKey(d => d.MaLoaiDiem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CTDiem_LoaiDiem");

                entity.HasOne(d => d.MaMonHocNavigation)
                    .WithMany(p => p.Ctdiems)
                    .HasForeignKey(d => d.MaMonHoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CTDiem_MonHoc");
            });

            modelBuilder.Entity<Diem>(entity =>
            {
                entity.HasKey(e => e.MaBangDiem);

                entity.ToTable("Diem");

                entity.Property(e => e.MaBangDiem).HasMaxLength(50);

                entity.Property(e => e.DanhHieu)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DiemTb).HasColumnName("DiemTB");

                entity.Property(e => e.HanhKiem)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HocLuc)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MaGvcn)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("MaGVCN");

                entity.Property(e => e.MaHocSinh)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MaLop)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NamHoc)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.HasOne(d => d.MaGvcnNavigation)
                    .WithMany(p => p.Diems)
                    .HasForeignKey(d => d.MaGvcn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Diem_GiaoVien");

                entity.HasOne(d => d.MaHocSinhNavigation)
                    .WithMany(p => p.Diems)
                    .HasForeignKey(d => d.MaHocSinh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Diem_HocSinh");

                entity.HasOne(d => d.MaLopNavigation)
                    .WithMany(p => p.Diems)
                    .HasForeignKey(d => d.MaLop)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Diem_Lop");
            });

            modelBuilder.Entity<GiaoVien>(entity =>
            {
                entity.HasKey(e => e.MaGiaoVien);

                entity.ToTable("GiaoVien");

                entity.Property(e => e.MaGiaoVien).HasMaxLength(50);

                entity.Property(e => e.HoTen)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.QueQuan)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SoCmnd)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("SoCMND");

                entity.Property(e => e.SoDienThoai)
                    .IsRequired()
                    .HasMaxLength(11);
            });

            modelBuilder.Entity<HocSinh>(entity =>
            {
                entity.HasKey(e => e.MaHocSinh);

                entity.ToTable("HocSinh");

                entity.Property(e => e.MaHocSinh).HasMaxLength(50);

                entity.Property(e => e.HoTen)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MaLop)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.QueQuan)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SoCmnd)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("SoCMND");

                entity.Property(e => e.SoDienThoai)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.HasOne(d => d.MaLopNavigation)
                    .WithMany(p => p.HocSinhs)
                    .HasForeignKey(d => d.MaLop)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HocSinh_Lop");
            });

            modelBuilder.Entity<Khoi>(entity =>
            {
                entity.HasKey(e => e.MaKhoi);

                entity.ToTable("Khoi");

                entity.Property(e => e.MaKhoi).HasMaxLength(50);

                entity.Property(e => e.TenKhoi).HasMaxLength(50);
            });

            modelBuilder.Entity<LoaiDiem>(entity =>
            {
                entity.HasKey(e => e.MaLoaiDiem);

                entity.ToTable("LoaiDiem");

                entity.Property(e => e.MaLoaiDiem).HasMaxLength(50);

                entity.Property(e => e.TenLoaiDiem)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Lop>(entity =>
            {
                entity.HasKey(e => e.MaLop);

                entity.ToTable("Lop");

                entity.Property(e => e.MaLop).HasMaxLength(50);

                entity.Property(e => e.MaGvcn)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("MaGVCN");

                entity.Property(e => e.MaKhoi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TenLop)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.MaGvcnNavigation)
                    .WithMany(p => p.Lops)
                    .HasForeignKey(d => d.MaGvcn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lop_GiaoVien");

                entity.HasOne(d => d.MaKhoiNavigation)
                    .WithMany(p => p.Lops)
                    .HasForeignKey(d => d.MaKhoi)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lop_Khoi");
            });

            modelBuilder.Entity<MonHoc>(entity =>
            {
                entity.HasKey(e => e.MaMonHoc);

                entity.ToTable("MonHoc");

                entity.Property(e => e.MaMonHoc).HasMaxLength(50);

                entity.Property(e => e.TenMonHoc)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.AnhDaiDien).HasMaxLength(200);

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.GioiTinh).HasMaxLength(50);

                entity.Property(e => e.Ngaysinh).HasColumnType("datetime");

                entity.Property(e => e.Sdt).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
