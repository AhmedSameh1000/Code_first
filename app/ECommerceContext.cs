using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;



public partial class ECommerceContext : DbContext
{
   
    public  DbSet<Brand> Brands { get; set; }

    public  DbSet<CardVisa> CardVisas { get; set; }

    public  DbSet<Category> Categories { get; set; }

    public  DbSet<CompanyInfo> CompanyInfos { get; set; }

    public  DbSet<Customer> Customers { get; set; }

    public  DbSet<Gender> Genders { get; set; }

    public  DbSet<Governorate> Governorates { get; set; }

    public  DbSet<ImgAdvertising> ImgAdvertisings { get; set; }

    public  DbSet<MasterCard> MasterCards { get; set; }

    public  DbSet<Order> Orders { get; set; }

    public  DbSet<OrdersDetail> OrdersDetails { get; set; }

    public  DbSet<PaymentMethod> PaymentMethods { get; set; }

    public  DbSet<Product> Products { get; set; }

    public  DbSet<RecomendedForYou> RecomendedForYous { get; set; }

    public  DbSet<Review> Reviews { get; set; }

    public  DbSet<Role> Roles { get; set; }

    public  DbSet<ShowRecommendedItem> ShowRecommendedItems { get; set; }

    public  DbSet<User> Users { get; set; }

    public  DbSet<ViewList> ViewLists { get; set; }
    public  DbSet<Wishlist> Wishlists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=A_A_Commerce;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.ToTable("Brand");

            entity.Property(e => e.BrandId).HasColumnName("BrandID");
            entity.Property(e => e.BrandName).HasMaxLength(50);
        });

        modelBuilder.Entity<CardVisa>(entity =>
        {
            entity.HasKey(e => e.CardNumber);

            entity.ToTable("Card_Visa");

            entity.Property(e => e.CardNumber)
                .HasMaxLength(20)
                .HasColumnName("Card_Number");
            entity.Property(e => e.CardType).HasColumnName("Card_Type");
            entity.Property(e => e.MasterBalance).HasColumnName("Master_Balance");
            entity.Property(e => e.Month)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.NameInCard)
                .HasMaxLength(50)
                .HasColumnName("Name_In_Card");
            entity.Property(e => e.UserName).HasMaxLength(50);
            entity.Property(e => e.Year)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.CardTypeNavigation).WithMany(p => p.CardVisas)
                .HasForeignKey(d => d.CardType)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Card_Visa_PaymentMethod");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CatId);

            entity.Property(e => e.CatId).HasColumnName("CatID");
            entity.Property(e => e.CatName).HasMaxLength(50);
            entity.Property(e => e.CatPicture)
                .HasMaxLength(50)
                .HasDefaultValueSql("(N'~/images/no.png')");
        });

        modelBuilder.Entity<CompanyInfo>(entity =>
        {
            entity.ToTable("CompanyInfo");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Phone1).HasMaxLength(50);
            entity.Property(e => e.Phone2).HasMaxLength(50);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustId);

            entity.HasIndex(e => e.CustMail, "IX_Customers").IsUnique();

            entity.HasIndex(e => e.CustUserName, "IX_Customers_1").IsUnique();

            entity.Property(e => e.CustId).HasColumnName("CustID");
            entity.Property(e => e.CustCity).HasMaxLength(50);
            entity.Property(e => e.CustFullAddress).HasMaxLength(50);
            entity.Property(e => e.CustGenderId).HasColumnName("CustGenderID");
            entity.Property(e => e.CustGovId).HasColumnName("CustGovID");
            entity.Property(e => e.CustIsBlocked)
                .HasMaxLength(50)
                .HasDefaultValueSql("(N'OPEN')");
            entity.Property(e => e.CustMail).HasMaxLength(50);
            entity.Property(e => e.CustMasterCardId)
                .HasMaxLength(14)
                .IsFixedLength()
                .HasColumnName("CustMasterCardID");
            entity.Property(e => e.CustName).HasMaxLength(50);
            entity.Property(e => e.CustPassword).HasMaxLength(50);
            entity.Property(e => e.CustRegDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CustTel1)
                .HasMaxLength(11)
                .IsFixedLength();
            entity.Property(e => e.CustTel2)
                .HasMaxLength(11)
                .IsFixedLength();
            entity.Property(e => e.CustUserName).HasMaxLength(50);

            entity.HasOne(d => d.CustGender).WithMany(p => p.Customers)
                .HasForeignKey(d => d.CustGenderId)
                .HasConstraintName("FK_Customers_Gender");

            entity.HasOne(d => d.CustGov).WithMany(p => p.Customers)
                .HasForeignKey(d => d.CustGovId)
                .HasConstraintName("FK_Customers_Governorates");

            entity.HasOne(d => d.CustMasterCard).WithMany(p => p.Customers)
                .HasForeignKey(d => d.CustMasterCardId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Customers_MasterCards");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.ToTable("Gender");

            entity.Property(e => e.GenderId)
                .ValueGeneratedNever()
                .HasColumnName("GenderID");
            entity.Property(e => e.GenderName).HasMaxLength(6);
        });

        modelBuilder.Entity<Governorate>(entity =>
        {
            entity.HasKey(e => e.GovId);

            entity.Property(e => e.GovId)
                .ValueGeneratedNever()
                .HasColumnName("GovID");
            entity.Property(e => e.GovName).HasMaxLength(50);
        });

        modelBuilder.Entity<ImgAdvertising>(entity =>
        {
            entity.HasKey(e => e.ImgId);

            entity.ToTable("ImgAdvertising");

            entity.Property(e => e.ImgId).HasColumnName("ImgID");
            entity.Property(e => e.AdId).HasColumnName("AdID");
            entity.Property(e => e.ImgPath).HasColumnType("image");

          
        });

        modelBuilder.Entity<MasterCard>(entity =>
        {
            entity.Property(e => e.MasterCardId)
                .HasMaxLength(14)
                .IsFixedLength()
                .HasColumnName("MasterCardID");
            entity.Property(e => e.MasterExpDate).HasColumnType("date");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderNo);

            entity.Property(e => e.OrderNo).HasColumnName("Order_No");
            entity.Property(e => e.MemberName)
                .HasMaxLength(50)
                .HasColumnName("Member_Name");
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("Order_Date");
            entity.Property(e => e.ShipAddress)
                .HasMaxLength(50)
                .HasColumnName("Ship_Address");
            entity.Property(e => e.ShipArea)
                .HasMaxLength(50)
                .HasColumnName("Ship_Area");
            entity.Property(e => e.ShipCity)
                .HasMaxLength(50)
                .HasColumnName("Ship_City");
            entity.Property(e => e.ShipName)
                .HasMaxLength(50)
                .HasColumnName("Ship_Name");
        });

        modelBuilder.Entity<OrdersDetail>(entity =>
        {
            entity.ToTable("Orders_Details");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CategoryNumber).HasColumnName("Category_Number");
            entity.Property(e => e.OrderNo).HasColumnName("Order_No");
            entity.Property(e => e.ProductId).HasColumnName("Product_ID");
            entity.Property(e => e.SalePrice).HasColumnName("Sale_Price");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasKey(e => e.MethodId);

            entity.ToTable("PaymentMethod");

            entity.Property(e => e.MethodId)
                .ValueGeneratedNever()
                .HasColumnName("MethodID");
            entity.Property(e => e.MethodName).HasMaxLength(50);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProId);

            entity.HasIndex(e => e.ProName, "IX_Products").IsUnique();

            entity.Property(e => e.ProId)
                .ValueGeneratedNever()
                .HasColumnName("ProID");
            entity.Property(e => e.BrandId).HasColumnName("BrandID");
            entity.Property(e => e.ProCatId).HasColumnName("ProCatID");
            entity.Property(e => e.ProDiscountPercent).HasDefaultValueSql("((0))");
            entity.Property(e => e.ProInsertingDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ProIsFeatured).HasDefaultValueSql("((0))");
            entity.Property(e => e.ProIsValid).HasDefaultValueSql("((1))");
            entity.Property(e => e.ProName).HasMaxLength(50);
            entity.Property(e => e.ProPicture).HasDefaultValueSql("(N'~/images/no.png')");
            entity.Property(e => e.ProQuantityPerUnit).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.ProCat).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProCatId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Products_Categories");
        });

        modelBuilder.Entity<RecomendedForYou>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Recomended_For_You");

            entity.Property(e => e.CatId).HasColumnName("CatID");
            entity.Property(e => e.CatName).HasMaxLength(50);
            entity.Property(e => e.CatPicture).HasMaxLength(50);
            entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");
            entity.Property(e => e.ProCount).HasColumnName("Pro_Count");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("RoleID");
            entity.Property(e => e.RoleDescription).HasMaxLength(200);
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<ShowRecommendedItem>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Show_Recommended_Item");

            entity.Property(e => e.CatId).HasColumnName("CatID");
            entity.Property(e => e.CatName).HasMaxLength(50);
            entity.Property(e => e.CatPicture).HasMaxLength(50);
            entity.Property(e => e.ProId).HasColumnName("ProID");
            entity.Property(e => e.ProName).HasMaxLength(50);
        });

      

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserFullName).HasMaxLength(50);
            entity.Property(e => e.UserMail).HasMaxLength(50);
            entity.Property(e => e.UserPassword).HasMaxLength(50);
            entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");
            entity.Property(e => e.UserUserName).HasMaxLength(50);

            entity.HasOne(d => d.UserRole).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserRoleId)
                .HasConstraintName("FK_Users_Roles");
        });

        modelBuilder.Entity<ViewList>(entity =>
        {
            entity.HasKey(e => e.ViewlistId).HasName("PK__VIEW_Lis__1D0505BFAD8DDD97");

            entity.ToTable("VIEW_List");

            entity.Property(e => e.ViewlistId).HasColumnName("Viewlist_ID");
            entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");
            entity.Property(e => e.DateTime)
                .HasColumnType("datetime")
                .HasColumnName("Date_Time");
            entity.Property(e => e.ProductId).HasColumnName("Product_ID");
            entity.Property(e => e.TypeOfAction).HasColumnName("Type_Of_Action");
        });

       
      

        modelBuilder.Entity<Wishlist>(entity =>
        {
            entity.ToTable("Wishlist");

            entity.Property(e => e.WishlistId).HasColumnName("Wishlist_ID");
            entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");
            entity.Property(e => e.ProductId).HasColumnName("Product_ID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Wishlists)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Wishlist_Customers");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
