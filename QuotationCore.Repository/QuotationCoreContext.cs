using Microsoft.EntityFrameworkCore;
using QuotationCore.Domain;

namespace QuotationCore.Repository
{
    public class QuotationCoreContext : DbContext
    {

        public QuotationCoreContext(DbContextOptions<QuotationCoreContext> options) : base (options){}
        
        public DbSet<Quotation> Quotations {get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Validation> Validations { get; set; }
    }
}