﻿// <auto-generated />
using System;
using BlazorServer.Models.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorServer.Migrations
{
    [DbContext(typeof(DemoDBContext))]
    partial class DemoDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("Chinese_Taiwan_Stroke_CI_AS")
                .HasAnnotation("ProductVersion", "6.0.30");

            modelBuilder.Entity("BlazorServer.Models.DBModel.OrderInfo", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER")
                        .HasComment("訂單流水號");

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())")
                        .HasComment("訂單成立時間");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER")
                        .HasComment("客戶流水號");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValueSql("(0)")
                        .HasComment("是否刪除");

                    b.Property<int>("Price")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValueSql("(0)")
                        .HasComment("訂單總金額");

                    b.HasKey("OrderId");

                    b.ToTable("OrderInfo", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
