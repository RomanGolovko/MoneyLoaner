using Microsoft.EntityFrameworkCore;
using Models.BusinessModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<CreditEntity> Credits { get; set; }
        public DbSet<BorrowerEntity> Borrowers { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // populate DB if it's empty
            modelBuilder.Entity<CreditEntity>().HasData(
                new CreditEntity[]
                {
                    new CreditEntity
                    {
                        Id = 1,
                        Amount = 100,
                        Currency = "USD",
                        Since = new DateTime(2018, 5, 23),
                        Till = new DateTime(2018, 10, 1),
                        Percentage = 0,
                        BorrowerId = 1
                    },
                    new CreditEntity
                    {
                        Id = 2,
                        Amount = 1000,
                        Currency = "UAH",
                        Since = new DateTime(2017, 8, 19),
                        Till = new DateTime(2018, 10, 17),
                        Percentage = 0,
                        BorrowerId = 2
                    }
                });

            modelBuilder.Entity<BorrowerEntity>().HasData(
                new BorrowerEntity[]
                {
                    new BorrowerEntity
                    {
                        Id = 1,
                        FirstName = "Vasya",
                        LastName = "Pupkin",
                        Age = 28,
                        PhoneNumber = "+380505896474",
                        AddressId = 1
                    },
                    new BorrowerEntity
                    {
                        Id = 2,
                        FirstName = "Ivan",
                        LastName = "Ivanov",
                        Age = 32,
                        PhoneNumber = "+380965896447",
                        AddressId = 2
                    }
                });

            modelBuilder.Entity<Address>().HasData(
                new Address[]
                {
                    new Address
                    {
                        Id = 1,
                        Country = "Ukraine",
                        City = "Kamenskoe",
                        ZipCode = "41900",
                        Street = "Mahnitogorskaya",
                        HouseNumber = "8",
                        Apartments = "84",
                    },
                    new Address
                    {
                        Id = 2,
                        Country = "Ukraine",
                        City = "Dnipro",
                        ZipCode = "41900",
                        Street = "Lenina",
                        HouseNumber = "18",
                        Apartments = "4",
                    }
                });
        }

        public override int SaveChanges()
        {
            AddAuditInfo();

            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            AddAuditInfo();

            return await base.SaveChangesAsync();
        }

        private void AddAuditInfo()
        {
            var entries = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                    ((BaseEntity)entry.Entity).Created = DateTime.UtcNow;

                ((BaseEntity)entry.Entity).Modified = DateTime.UtcNow;
            }
        }
    }
}
