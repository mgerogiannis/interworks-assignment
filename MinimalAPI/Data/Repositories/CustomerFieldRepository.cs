using Microsoft.EntityFrameworkCore;
using MinimalAPI.Data.Context;
using MinimalAPI.Data.Entities;
using MinimalAPI.Interfaces;

namespace MinimalAPI.Data.Repositories
{
    public class CustomerFieldRepository : ICustomerFieldRepository, IDisposable
    {
        private readonly MinimalAPIContext _context;

        public CustomerFieldRepository(MinimalAPIContext context)
        {
            _context = context;
        }

        public void Create(CustomerField entry)
        {
            if (entry == null)
                throw new ArgumentNullException(nameof(entry));
            _context.customerField.Add(entry);
        }

        public void Update(int id, CustomerField entry)
        {
            if (entry == null)
                throw new ArgumentNullException(nameof(entry));

            var oldEntry = _context.customerField.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id).Result;

            if (oldEntry == null)
                throw new ArgumentNullException(nameof(oldEntry));

            oldEntry.Name = entry.Name;
            oldEntry.FieldType = entry.FieldType;
        }

        public async Task<List<CustomerField>> GetAll()
        {
            var result = await _context.customerField.AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<CustomerField> GetById(int id)
        {
            var result = await _context.customerField.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return result!;
        }

        public void Delete(int id)
        {
            _context.customerField.Where(x => x.Id == id).ExecuteDelete();        
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
