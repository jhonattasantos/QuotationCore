using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuotationCore.Domain;

namespace QuotationCore.Repository
{
    public class QuotationCoreRepository : IQuotationCoreRepository
    {
        private readonly QuotationCoreContext _context;
        public QuotationCoreRepository(QuotationCoreContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
             _context.Remove(entity);
        }

        public async Task<Quotation[]> GetAllQuotationsAsync()
        {
            IQueryable<Quotation> query = _context.Quotations
                .Include(c => c.Items)
                .Include(c => c.Validations)
                .OrderBy(c => c.Id);
            return await query.ToArrayAsync();
            
        }

        public async Task<Quotation> GetQuotationAsyncById(int id)
        {
            IQueryable<Quotation> query = _context.Quotations
                .Include(c => c.Items)
                .Include(c => c.Validations)
                .Where(c => c.Id == id)
                .OrderBy(c => c.Id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Quotation[]> GetQuotationAsyncByName(string name)
        {
            IQueryable<Quotation> query = _context.Quotations
                .Include(c => c.Items)
                .Include(c => c.Validations)
                .Where(c => c.Name.ToLower().Contains(name.ToLower()))
                .OrderBy(c => c.Name);
            return await query.ToArrayAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void Update<T>(T entity) where T : class
        {
             _context.Update(entity);
        }
    }
}