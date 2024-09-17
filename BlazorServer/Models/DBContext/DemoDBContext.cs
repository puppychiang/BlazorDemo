using BlazorServer.Models.DBModel;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.Models.DBContext
{
    public class DemoDBContext : DbContext
    {
        public DemoDBContext(DbContextOptions<DemoDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<OrderInfo> OrderInfos { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_Taiwan_Stroke_CI_AS");

            modelBuilder.Entity<OrderInfo>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.ToTable("OrderInfo");

                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasComment("訂單流水號");

                entity.Property(e => e.CreateTime)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasComment("訂單成立時間");

                entity.Property(e => e.Price)
                    .HasDefaultValueSql("(0)")
                    .HasComment("訂單總金額");

                entity.Property(e => e.CustomerId)
                    .HasComment("客戶流水號");

                entity.Property(e => e.IsDeleted)
                    .HasDefaultValueSql("(0)")
                    .HasComment("是否刪除");
            });

            //OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    }
}
