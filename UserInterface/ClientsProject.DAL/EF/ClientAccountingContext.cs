using ClientsProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClientsProject.DAL.EF;

public partial class ClientAccountingContext : DbContext
{
    public ClientAccountingContext()
    {
    }

    public ClientAccountingContext(DbContextOptions<ClientAccountingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Viewclient> Viewclients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ClientAccounting;Username=postgres;Password=123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("clients_pkey");

            entity.ToTable("clients");

            entity.HasIndex(e => e.Login, "clients_login_key").IsUnique();

            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.Contact)
                .HasMaxLength(13)
                .HasColumnName("contact");
            entity.Property(e => e.Email)
                .HasMaxLength(60)
                .HasColumnName("email");
            entity.Property(e => e.Lastvisit).HasColumnName("lastvisit");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(20)
                .HasColumnName("patronymic");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Registrationdate).HasColumnName("registrationdate");
            entity.Property(e => e.Surname)
                .HasMaxLength(30)
                .HasColumnName("surname");
            entity.Property(e => e.Type).HasDefaultValueSql("''::text");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Idorder).HasName("orders_pkey");

            entity.ToTable("orders");

            entity.HasIndex(e => e.IdClient, "IX_orders_id_client");

            entity.HasIndex(e => e.IdProduct, "IX_orders_id_product");

            entity.Property(e => e.Idorder).HasColumnName("idorder");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.Daterelease).HasColumnName("daterelease");
            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Purchaseprice).HasColumnName("purchaseprice");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_id_client_fkey");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_id_product_fkey");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("product_pkey");

            entity.ToTable("product");

            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.Branch).HasDefaultValueSql("''::text");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.Daterelease).HasColumnName("daterelease");
            entity.Property(e => e.Ispurchased).HasColumnName("ispurchased");
            entity.Property(e => e.Lastview).HasColumnName("lastview");
            entity.Property(e => e.Name)
                .HasMaxLength(40)
                .HasColumnName("name");
            entity.Property(e => e.Photo).HasColumnName("photo");
            entity.Property(e => e.Rating).HasColumnName("rating");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.IdReview).HasName("review_pkey");

            entity.ToTable("review");

            entity.HasIndex(e => e.IdClient, "IX_review_id_client");

            entity.HasIndex(e => e.IdProduct, "IX_review_id_product");

            entity.Property(e => e.IdReview).HasColumnName("id_review");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.Ishelpful).HasColumnName("ishelpful");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.Rating).HasColumnName("rating");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("review_id_client_fkey");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("review_id_product_fkey");
        });

        modelBuilder.Entity<Viewclient>(entity =>
        {
            entity.HasKey(e => e.IdView).HasName("viewclient_pkey");

            entity.ToTable("viewclient");

            entity.HasIndex(e => e.IdClient, "IX_viewclient_id_client");

            entity.HasIndex(e => e.IdProduct, "IX_viewclient_id_product");

            entity.Property(e => e.IdView).HasColumnName("id_view");
            entity.Property(e => e.Dateview).HasColumnName("dateview");
            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Viewclients)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("viewclient_id_client_fkey");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Viewclients)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("viewclient_id_product_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
