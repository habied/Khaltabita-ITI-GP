﻿// <auto-generated />
using System;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Web_Api.Migrations
{
    [DbContext(typeof(FoodyContext))]
    partial class FoodyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("Latin1_General_CI_AS")
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DAL.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("datetime")
                        .HasColumnName("delivery_date");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("location");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime")
                        .HasColumnName("order_date");

                    b.Property<int?>("ProposalId")
                        .HasColumnType("int")
                        .HasColumnName("proposal_id");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int")
                        .HasColumnName("total_price");

                    b.Property<string>("UserMobile")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("user_mobile");

                    b.HasKey("Id");

                    b.HasIndex("ProposalId");

                    b.HasIndex("UserMobile");

                    b.ToTable("Cart", (string)null);
                });

            modelBuilder.Entity("DAL.Models.CartMenuItem", b =>
                {
                    b.Property<int>("MenuItemId")
                        .HasColumnType("int")
                        .HasColumnName("Menu_item_id");

                    b.Property<int>("CartId")
                        .HasColumnType("int")
                        .HasColumnName("Cart_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("TotalItemPrice")
                        .HasColumnType("int")
                        .HasColumnName("total_item_price");

                    b.HasKey("MenuItemId", "CartId");

                    b.HasIndex("CartId");

                    b.ToTable("Cart/MenuItems", (string)null);
                });

            modelBuilder.Entity("DAL.Models.Chef", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("address");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<string>("Media")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("media");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("mobile");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<double?>("Rating")
                        .HasColumnType("float")
                        .HasColumnName("rating");

                    b.HasKey("Id");

                    b.ToTable("Chef", (string)null);
                });

            modelBuilder.Entity("DAL.Models.Feedback", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("user_id");

                    b.Property<int>("ChefId")
                        .HasColumnType("int")
                        .HasColumnName("chef_id");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime")
                        .HasColumnName("date");

                    b.Property<int>("Rating")
                        .HasColumnType("int")
                        .HasColumnName("rating");

                    b.Property<string>("Review")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("review");

                    b.HasKey("UserId", "ChefId");

                    b.HasIndex("ChefId");

                    b.ToTable("feedback", (string)null);
                });

            modelBuilder.Entity("DAL.Models.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Availability")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("availability");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ChefId")
                        .HasColumnType("int")
                        .HasColumnName("chef_id");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<int>("Likes")
                        .HasColumnType("int")
                        .HasColumnName("likes");

                    b.Property<string>("Media")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("media");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<int?>("PrepTimeMin")
                        .HasColumnType("int")
                        .HasColumnName("prep_time(min)");

                    b.Property<int>("UnitPriceLE")
                        .HasColumnType("int")
                        .HasColumnName("unit_price(L.E)");

                    b.HasKey("Id");

                    b.ToTable("Menu_item", (string)null);
                });

            modelBuilder.Entity("DAL.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("date")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Description")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("description");

                    b.Property<int?>("FromPrice")
                        .HasColumnType("int")
                        .HasColumnName("from_price");

                    b.Property<byte[]>("Media")
                        .HasColumnType("image");

                    b.Property<string>("PostState")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PrepTimeMin")
                        .HasColumnType("int")
                        .HasColumnName("prep_time_min");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<string>("QuantityUnit")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("quantity_unit");

                    b.Property<int?>("ToPrice")
                        .HasColumnType("int")
                        .HasColumnName("to_price");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Post", (string)null);
                });

            modelBuilder.Entity("DAL.Models.Proposal", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("ChefId")
                        .HasColumnType("int")
                        .HasColumnName("chef_id");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("date")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Media")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("media");

                    b.Property<int>("PostId")
                        .HasColumnType("int")
                        .HasColumnName("post_id");

                    b.Property<int>("PrepTimeMin")
                        .HasColumnType("int")
                        .HasColumnName("prep_time_min");

                    b.Property<int>("Price")
                        .HasColumnType("int")
                        .HasColumnName("price");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex("ChefId");

                    b.HasIndex("PostId");

                    b.ToTable("Proposal", (string)null);
                });

            modelBuilder.Entity("DAL.Models.User", b =>
                {
                    b.Property<string>("Mobile")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("mobile");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("address");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("gender");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.HasKey("Mobile");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("DAL.Models.Cart", b =>
                {
                    b.HasOne("DAL.Models.Proposal", "Proposal")
                        .WithMany("Carts")
                        .HasForeignKey("ProposalId")
                        .HasConstraintName("FK_Cart_Proposal");

                    b.HasOne("DAL.Models.User", "UserMobileNavigation")
                        .WithMany("Carts")
                        .HasForeignKey("UserMobile")
                        .IsRequired()
                        .HasConstraintName("FK_Cart_User");

                    b.Navigation("Proposal");

                    b.Navigation("UserMobileNavigation");
                });

            modelBuilder.Entity("DAL.Models.CartMenuItem", b =>
                {
                    b.HasOne("DAL.Models.Cart", "Cart")
                        .WithMany("CartMenuItems")
                        .HasForeignKey("CartId")
                        .IsRequired()
                        .HasConstraintName("FK_Cart/MenuItems_Cart");

                    b.HasOne("DAL.Models.MenuItem", "MenuItem")
                        .WithMany("CartMenuItems")
                        .HasForeignKey("MenuItemId")
                        .IsRequired()
                        .HasConstraintName("FK_Cart/MenuItems_Menu_item");

                    b.Navigation("Cart");

                    b.Navigation("MenuItem");
                });

            modelBuilder.Entity("DAL.Models.Feedback", b =>
                {
                    b.HasOne("DAL.Models.Chef", "Chef")
                        .WithMany("Feedbacks")
                        .HasForeignKey("ChefId")
                        .IsRequired()
                        .HasConstraintName("FK_feedback_Chef");

                    b.HasOne("DAL.Models.User", "User")
                        .WithMany("Feedbacks")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_feedback_User");

                    b.Navigation("Chef");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Models.Post", b =>
                {
                    b.HasOne("DAL.Models.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Post_User");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Models.Proposal", b =>
                {
                    b.HasOne("DAL.Models.Chef", "Chef")
                        .WithMany("Proposals")
                        .HasForeignKey("ChefId")
                        .IsRequired()
                        .HasConstraintName("FK_Proposal_Chef");

                    b.HasOne("DAL.Models.Post", "Post")
                        .WithMany("Proposals")
                        .HasForeignKey("PostId")
                        .IsRequired()
                        .HasConstraintName("FK_Proposal_Post");

                    b.Navigation("Chef");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("DAL.Models.Cart", b =>
                {
                    b.Navigation("CartMenuItems");
                });

            modelBuilder.Entity("DAL.Models.Chef", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("Proposals");
                });

            modelBuilder.Entity("DAL.Models.MenuItem", b =>
                {
                    b.Navigation("CartMenuItems");
                });

            modelBuilder.Entity("DAL.Models.Post", b =>
                {
                    b.Navigation("Proposals");
                });

            modelBuilder.Entity("DAL.Models.Proposal", b =>
                {
                    b.Navigation("Carts");
                });

            modelBuilder.Entity("DAL.Models.User", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("Feedbacks");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
