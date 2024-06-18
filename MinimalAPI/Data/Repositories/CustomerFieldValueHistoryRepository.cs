using Microsoft.EntityFrameworkCore;
using MinimalAPI.Data.Context;
using MinimalAPI.Data.Entities;
using MinimalAPI.Interfaces;

namespace MinimalAPI.Data.Repositories
{
    public class CustomerFieldValueHistoryRepository : ICustomerFieldValueHistoryRepository, IDisposable
    {
        private readonly MinimalAPIContext _context;

        public CustomerFieldValueHistoryRepository(MinimalAPIContext context)
        {
            _context = context;
        }

        public void Create(CustomerFieldValueHistory entry)
        {
            if (entry == null)
                throw new ArgumentNullException(nameof(entry));
            _context.customerFieldValueHistory.Add(entry);
        }

        public async Task<List<CustomerFieldValueHistory>> GetById(int fieldValueId)
        {
            var result = await _context.customerFieldValueHistory.Where(x => x.FieldValueId == fieldValueId).ToListAsync();
            return result;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
