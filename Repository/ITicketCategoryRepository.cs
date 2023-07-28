using TicketManagementSystem.Models;

namespace TicketManagementSystem.Repository
{
    public interface ITicketCategoryRepository
    {
        Task<TicketCategory> GetById(int id);
    }
}
