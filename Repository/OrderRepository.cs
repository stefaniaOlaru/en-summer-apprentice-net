﻿using Microsoft.EntityFrameworkCore;
using TicketManagementSystem.Models;

namespace TicketManagementSystem.Repository
{
    public class OrderRepository : IOrderRepository
    {   
        private readonly TicketManagementSystemContext _dbContext;

        public OrderRepository()
        {
            _dbContext = new TicketManagementSystemContext();
        }
        public int Add(Order order)
        {
            throw new NotImplementedException();
        }

        public void Delete(Order @order)
        {
           _dbContext.Remove(@order);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Order> GetAll()
        {
           var orders = _dbContext.Orders;

            return orders;
        }

        public async Task<Order> GetById(int id)
        {
            var @order = await _dbContext.Orders.Where(o => o.OrderId == id).FirstOrDefaultAsync();

            return @order;
        }

        public void Update(Order @order)
        {
            _dbContext.Entry(@order).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
