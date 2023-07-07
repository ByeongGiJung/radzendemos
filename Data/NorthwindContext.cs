using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace RadzenDemos.Data
{
    public partial class NorthwindContext : Microsoft.EntityFrameworkCore.DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("Northwind");
            }
        }

        partial void OnModelBuilding(ModelBuilder builder);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<RadzenDemos.Models.Northwind.CustomerCustomerDemo>().HasKey(table => new
            {
                table.CustomerID,
                table.CustomerTypeID
            });

            builder.Entity<RadzenDemos.Models.Northwind.EmployeeTerritory>().HasKey(table => new
            {
                table.EmployeeID,
                table.TerritoryID
            });

            builder.Entity<RadzenDemos.Models.Northwind.OrderDetail>().HasKey(table => new
            {
                table.OrderID,
                table.ProductID
            });

            builder.Entity<RadzenDemos.Models.Northwind.Employee>()
                   .HasOne(i => i.Employee1)
                   .WithMany(i => i.Employees1)
                   .HasForeignKey(i => i.ReportsTo)
                   .HasPrincipalKey(i => i.EmployeeID);

            builder.Entity<RadzenDemos.Models.Northwind.CustomerCustomerDemo>()
                  .HasOne(i => i.Customer)
                  .WithMany(i => i.CustomerCustomerDemos)
                  .HasForeignKey(i => i.CustomerID)
                  .HasPrincipalKey(i => i.CustomerID);

            builder.Entity<RadzenDemos.Models.Northwind.CustomerCustomerDemo>()
                  .HasOne(i => i.CustomerDemographic)
                  .WithMany(i => i.CustomerCustomerDemos)
                  .HasForeignKey(i => i.CustomerTypeID)
                  .HasPrincipalKey(i => i.CustomerTypeID);

            builder.Entity<RadzenDemos.Models.Northwind.EmployeeTerritory>()
                  .HasOne(i => i.Employee)
                  .WithMany(i => i.EmployeeTerritories)
                  .HasForeignKey(i => i.EmployeeID)
                  .HasPrincipalKey(i => i.EmployeeID);

            builder.Entity<RadzenDemos.Models.Northwind.EmployeeTerritory>()
                  .HasOne(i => i.Territory)
                  .WithMany(i => i.EmployeeTerritories)
                  .HasForeignKey(i => i.TerritoryID)
                  .HasPrincipalKey(i => i.TerritoryID);

            builder.Entity<RadzenDemos.Models.Northwind.Order>()
                  .HasOne(i => i.Customer)
                  .WithMany(i => i.Orders)
                  .HasForeignKey(i => i.CustomerID)
                  .HasPrincipalKey(i => i.CustomerID);

            builder.Entity<RadzenDemos.Models.Northwind.Order>()
                  .HasOne(i => i.Employee)
                  .WithMany(i => i.Orders)
                  .HasForeignKey(i => i.EmployeeID)
                  .HasPrincipalKey(i => i.EmployeeID);

            builder.Entity<RadzenDemos.Models.Northwind.OrderDetail>()
                  .HasOne(i => i.Order)
                  .WithMany(i => i.OrderDetails)
                  .HasForeignKey(i => i.OrderID)
                  .HasPrincipalKey(i => i.OrderID);

            builder.Entity<RadzenDemos.Models.Northwind.OrderDetail>()
                  .HasOne(i => i.Product)
                  .WithMany(i => i.OrderDetails)
                  .HasForeignKey(i => i.ProductID)
                  .HasPrincipalKey(i => i.ProductID);

            builder.Entity<RadzenDemos.Models.Northwind.Product>()
                  .HasOne(i => i.Supplier)
                  .WithMany(i => i.Products)
                  .HasForeignKey(i => i.SupplierID)
                  .HasPrincipalKey(i => i.SupplierID);

            builder.Entity<RadzenDemos.Models.Northwind.Product>()
                  .HasOne(i => i.Category)
                  .WithMany(i => i.Products)
                  .HasForeignKey(i => i.CategoryID)
                  .HasPrincipalKey(i => i.CategoryID);

            builder.Entity<RadzenDemos.Models.Northwind.Territory>()
                  .HasOne(i => i.Region)
                  .WithMany(i => i.Territories)
                  .HasForeignKey(i => i.RegionID)
                  .HasPrincipalKey(i => i.RegionID);

            builder.Entity<RadzenDemos.Models.Northwind.Order>()
                  .Property(p => p.Freight);

            builder.Entity<RadzenDemos.Models.Northwind.OrderDetail>()
                  .Property(p => p.UnitPrice);

            builder.Entity<RadzenDemos.Models.Northwind.OrderDetail>()
                  .Property(p => p.Quantity);

            builder.Entity<RadzenDemos.Models.Northwind.OrderDetail>()
                  .Property(p => p.Discount);

            builder.Entity<RadzenDemos.Models.Northwind.Product>()
                  .Property(p => p.UnitPrice);

            builder.Entity<RadzenDemos.Models.Northwind.Product>()
                  .Property(p => p.UnitsInStock);

            builder.Entity<RadzenDemos.Models.Northwind.Product>()
                  .Property(p => p.UnitsOnOrder);

            builder.Entity<RadzenDemos.Models.Northwind.Product>()
                  .Property(p => p.ReorderLevel);

            builder.Entity<RadzenDemos.Models.Northwind.Product>()
                  .Property(p => p.Discontinued);

            this.OnModelBuilding(builder);
        }


        public DbSet<RadzenDemos.Models.Northwind.Category>? Categories
        {
            get;
            set;
        }

        public DbSet<RadzenDemos.Models.Northwind.Customer>? Customers
        {
            get;
            set;
        }

        public DbSet<RadzenDemos.Models.Northwind.CustomerCustomerDemo>? CustomerCustomerDemos
        {
            get;
            set;
        }

        public DbSet<RadzenDemos.Models.Northwind.CustomerDemographic>? CustomerDemographics
        {
            get;
            set;
        }

        public DbSet<RadzenDemos.Models.Northwind.Employee>? Employees
        {
            get;
            set;
        }

        public DbSet<RadzenDemos.Models.Northwind.EmployeeTerritory>? EmployeeTerritories
        {
            get;
            set;
        }

        public DbSet<RadzenDemos.Models.Northwind.Order>? Orders
        {
            get;
            set;
        }

        public DbSet<RadzenDemos.Models.Northwind.OrderDetail>? OrderDetails
        {
            get;
            set;
        }

        public DbSet<RadzenDemos.Models.Northwind.Product>? Products
        {
            get;
            set;
        }

        public DbSet<RadzenDemos.Models.Northwind.Region>? Regions
        {
            get;
            set;
        }

        public DbSet<RadzenDemos.Models.Northwind.Supplier>? Suppliers
        {
            get;
            set;
        }

        public DbSet<RadzenDemos.Models.Northwind.Territory>? Territories
        {
            get;
            set;
        }

        public async Task SeedAsync()
        {
            try
            {
                AddData();

                if (ChangeTracker.HasChanges())
                {
                    await SaveChangesAsync();
                }
            }
            catch
            {
                //
            }
        }

        public void Seed()
        {
            try
            {
                AddData();

                if (ChangeTracker.HasChanges())
                {
                    SaveChanges();
                }
            }
            catch
            {
                //
            }
        }

        public void AddData()
        {
            if (!Customers.Any())
            {
                Customers.AddRange(CustomersData.Data);
            }

            if (!Categories.Any())
            {
                Categories.AddRange(CategoriesData.Data);
            }

            if (!Employees.Any())
            {
                Employees.AddRange(EmployeesData.Data);
            }

            if (!Orders.Any())
            {
                Orders.AddRange(OrdersData.Data);
            }

            if (!OrderDetails.Any())
            {
                OrderDetails.AddRange(OrderDetailsData.Data);
            }

            if (!Products.Any())
            {
                Products.AddRange(ProductsData.Data);
            }

            if (!Regions.Any())
            {
                Regions.AddRange(RegionsData.Data);
            }

            if (!Territories.Any())
            {
                Territories.AddRange(TerritoriesData.Data);
            }

            if (!Suppliers.Any())
            {
                Suppliers.AddRange(SuppliersData.Data);
            }
        }
    }
}
