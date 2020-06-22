using System.Threading.Tasks;
using QuotationCore.Domain;

namespace QuotationCore.Repository
{
    public interface IQuotationCoreRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();
        Task<Quotation[]> GetAllQuotationsAsync();
        Task<Quotation> GetQuotationAsyncById(int id);
        Task<Quotation[]> GetQuotationAsyncByName(string name);
    }
}