using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketManagementSystem.Models;
using TicketManagementSystem.Models.dto;
using TicketManagementSystem.Repository;

namespace TicketManagementSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController: ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ITicketCategoryRepository _ticketCategoryRepository;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepository, ITicketCategoryRepository ticketCategory,  IMapper mapper)
        {
            _orderRepository = orderRepository;
            _ticketCategoryRepository = ticketCategory;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<OrderDto>> GetAll()
        {
            var orders = _orderRepository.GetAll();

            var orderDto = orders.Select(o => new OrderDto()
            {
                OrderId = o.OrderId,
                NumberOfTickets = o.NumberOfTickets ?? 0,
                TicketCategory = o.TicketCategory?.Description ?? string.Empty,
                TotalPrice=o.TotalPrice ?? 0,
            });
            return Ok(orderDto);
        }

        [HttpGet]
        public async Task<ActionResult<OrderDto>> GetById(int id)
        {
            var @order =await _orderRepository.GetById(id);

            var orderDto = _mapper.Map<OrderDto>(@order);

            return Ok(orderDto);
        }

        [HttpPatch]
        public async Task<ActionResult<OrderPatchDto>> Patch(OrderPatchDto orderPatch)
        {
            var orderEntity = await _orderRepository.GetById(orderPatch.OrderId);
            int numberOfTickets = (int)orderEntity.NumberOfTickets;
            int totalPrice = (int)orderEntity.TotalPrice;
            var ticketCategory = await _ticketCategoryRepository.GetById((int)orderEntity.TicketCategoryId);

            if (orderEntity == null)
            {
                return NotFound();
            }

             _mapper.Map(orderPatch, orderEntity);
            _orderRepository.Update(orderEntity);

            if (numberOfTickets < orderPatch.NumberOfTickets) {
                orderEntity.TotalPrice = orderEntity.NumberOfTickets * ticketCategory.Price;
            }
            else
            {
                orderEntity.TotalPrice = totalPrice - (numberOfTickets - orderPatch.NumberOfTickets) * ticketCategory.Price;
            }

            _orderRepository.Update(orderEntity);

            return Ok(orderEntity);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var orderEntity = await _orderRepository.GetById(id);

            if (orderEntity == null)
            {
                return NotFound();
            }

            _orderRepository.Delete(orderEntity);
            return NoContent();
        }

    }
}
