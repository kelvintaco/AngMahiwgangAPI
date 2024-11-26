using Microsoft.EntityFrameworkCore;
using SystemMonitoringAPI.Context;
using SystemMonitoringAPI.Models;

namespace SystemMonitoringAPI.Repositories
{
    public class TransRepository : ITransrepository
    {
        private readonly DataContext _dataContext;

        public TransRepository(DataContext dataContext) 
        { 
            this._dataContext = dataContext;
        }

        public async Task<Transactions> CreateAsync(Transactions transactions)
        {
            await _dataContext.Transactions.AddAsync(transactions);
            await _dataContext.SaveChangesAsync();
            return transactions;
        }
        
        public async Task<List<Transactions>> GetAllAsync()
        {
            return await _dataContext.Transactions.Include(x => x.Items).Include(x => x.Borrowers).ToListAsync();
        }
    }
}
