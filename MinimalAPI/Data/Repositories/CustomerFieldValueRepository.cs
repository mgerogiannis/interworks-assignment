using Microsoft.EntityFrameworkCore;
using MinimalAPI.Data.Context;
using MinimalAPI.Data.Entities;
using MinimalAPI.Interfaces;

namespace MinimalAPI.Data.Repositories
{
    public class CustomerFieldValueRepository : ICustomerFieldValueRepository, IDisposable
    {
        private readonly MinimalAPIContext _context;

        public CustomerFieldValueRepository(MinimalAPIContext context)
        {
            _context = context;
        }

        public void Create(CustomerFieldValue entry)
        {
            if (entry == null)
                throw new ArgumentNullException(nameof(entry));
            _context.customerFieldValue.Add(entry);
        }

        public void Update(int id, CustomerFieldValue entry)
        {
            if (entry == null)
                throw new ArgumentNullException(nameof(entry));

            var oldEntry = _context.customerFieldValue.FirstOrDefaultAsync(x => x.FieldId == id).Result;

            if (oldEntry == null)
                throw new ArgumentNullException(nameof(oldEntry));

            Delete(id);

            Create(entry);
        }

        public async Task<List<CustomerFieldValue>> GetAllPerCriteria(int customerId, int fieldId)
        {
            var result = await _context.customerFieldValue
                .Where(x => x.CustomerId == customerId && x.FieldId == fieldId)
                .AsNoTracking()
                .ToListAsync();
            return result;
        }

        public async Task<CustomerFieldValue> GetById(int id)
        {
            var result = await _context.customerFieldValue.AsNoTracking().FirstOrDefaultAsync(x => x.FieldId == id);
            return result!;
        }

        public void Delete(int id)
        {
            _context.customerFieldValue.Where(x => x.FieldId == id).ExecuteDelete();
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
