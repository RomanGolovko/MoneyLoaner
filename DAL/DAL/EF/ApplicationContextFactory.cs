using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DAL.EF
{
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var bulder = new DbContextOptionsBuilder<ApplicationContext>();
            bulder.UseSqlServer("Data Source=DP8450\\SQLEXPRESS;Initial Catalog=MoneyLoaner;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");

            return new ApplicationContext(bulder.Options);
        }
    }
}
