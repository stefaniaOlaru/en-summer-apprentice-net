using TicketManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using TicketManagementSystem.Repository;

namespace TicketManagementSystem.Repository
{
    public class TicketCategoryRepository : ITicketCategoryRepository
    {
        private readonly TicketManagementSystemContext _dbContext;

        public TicketCategoryRepository()
        {
            _dbContext = new TicketManagementSystemContext();
        }

        public async Task<TicketCategory> GetById(int id)
        {
            var ticketCategory = await _dbContext.TicketCategories.Where(e => e.TicketCategoryId == id).FirstOrDefaultAsync();

            return ticketCategory;
        }
    }
}
