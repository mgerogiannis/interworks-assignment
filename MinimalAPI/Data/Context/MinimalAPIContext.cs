using Microsoft.EntityFrameworkCore;
using MinimalAPI.Data.Entities;

namespace MinimalAPI.Data.Context
{
    public class MinimalAPIContext : DbContext
    {
        public MinimalAPIContext(DbContextOptions<MinimalAPIContext> options) : base(options) 
        {

        }

        public DbSet<CustomerField> customerField => Set<CustomerField>();
        public DbSet<CustomerFieldValue> customerFieldValue => Set<CustomerFieldValue>();
        public DbSet<CustomerFieldValueHistory> customerFieldValueHistory => Set<CustomerFieldValueHistory>();
    }
}
