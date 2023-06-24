using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class FoodyContext : IdentityDbContext<AuthUser>
{
    public FoodyContext()
    {
    }

    public FoodyContext(DbContextOptions<FoodyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartMenuItem> CartMenuItems { get; set; }

    public virtual DbSet<Chef> Chefs { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<MenuItem> MenuItems { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Proposal> Proposals { get; set; }

    public virtual DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region Scaffolded Code

        modelBuilder.UseCollation("Latin1_General_CI_AS");

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.ToTable("Cart");

            entity.Property(e => e.Id)
            .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DeliveryDate)
                .HasColumnType("datetime")
                .HasColumnName("delivery_date");
            entity.Property(e => e.Location).HasColumnName("location");
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("order_date");
            entity.Property(e => e.TotalPrice).HasColumnName("total_price");
            entity.Property(e => e.UserMobile)
                .HasMaxLength(20)
                .HasColumnName("user_mobile");


            entity.HasOne(d => d.UserMobileNavigation).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UserMobile)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cart_User");

            entity.HasOne(c => c.Chef).WithMany(ch => ch.Carts)
            .HasForeignKey(c => c.ChefId).OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("FK_Cart_Chef"); 
        });

        modelBuilder.Entity<CartMenuItem>(entity =>
        {
            entity.HasKey(e => new { e.MenuItemId, e.CartId });

            entity.ToTable("Cart/MenuItems");

            entity.Property(e => e.MenuItemId).HasColumnName("Menu_item_id");
            entity.Property(e => e.CartId).HasColumnName("Cart_id");
            entity.Property(e => e.TotalItemPrice).HasColumnName("total_item_price");

            entity.HasOne(d => d.Cart).WithMany(p => p.CartMenuItems)
                .HasForeignKey(d => d.CartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cart/MenuItems_Cart");

            entity.HasOne(d => d.MenuItem).WithMany(p => p.CartMenuItems)
                .HasForeignKey(d => d.MenuItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cart/MenuItems_Menu_item");
        });

        modelBuilder.Entity<Chef>(entity =>
        {
            entity.ToTable("Chef");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Media)
                .HasColumnName("media");

            entity.Property(e => e.Rating).HasColumnName("rating");

        });

        modelBuilder.Entity<Chef>()
                  .Ignore(e => e.Rating)
                  .Property(e => e.Rating)
                  .HasColumnName("rating")
                  .HasComputedColumnSql("(dbo.GetAvgRatingValue(e.id)");

        modelBuilder.Entity<Feedback>(entity =>
        {
            
            entity.ToTable("feedback");

            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .HasColumnName("user_id");
            entity.Property(e => e.ChefId).HasColumnName("chef_id");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Review).HasColumnName("review");

            entity.HasOne(d => d.Chef).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.ChefId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_feedback_Chef");

            entity.HasOne(d => d.User).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_feedback_User");
        });

        modelBuilder.Entity<MenuItem>(entity =>
        {
            entity.ToTable("Menu_item");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Availability).HasColumnName("availability");
            entity.Property(e => e.ChefId).HasColumnName("chef_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Likes).HasColumnName("likes");
            entity.Property(e => e.Media)
                .HasColumnName("media");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.PrepTimeMin).HasColumnName("prep_time(min)");
            entity.Property(e => e.UnitPriceLE).HasColumnName("unit_price(L.E)");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.ToTable("Post");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Description)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.FromPrice).HasColumnName("from_price");
            //entity.Property(e => e.PrepTimeMin).HasColumnName("prep_time_min");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.QuantityUnit).HasColumnName("quantity_unit");
            entity.Property(e => e.ToPrice).HasColumnName("to_price");
            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Post_User");
        });

        modelBuilder.Entity<Proposal>(entity =>
        {
            entity.ToTable("Proposal");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ChefId).HasColumnName("chef_id");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.Chef).WithMany(p => p.Proposals)
                .HasForeignKey(d => d.ChefId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Proposal_Chef");

            entity.HasOne(d => d.Post).WithMany(p => p.Proposals)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Proposal_Post");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Gender).HasColumnName("gender");
        });

        OnModelCreatingPartial(modelBuilder);

        #endregion

        modelBuilder.Entity<AuthUser>()
            .UseTptMappingStrategy();
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
