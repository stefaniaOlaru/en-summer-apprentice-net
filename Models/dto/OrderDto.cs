namespace TicketManagementSystem.Models.dto
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public string Event { get; set; }
        public int NumberOfTickets { get; set; }
        public string? TicketCategory { get; set; }
        public int TotalPrice { get; set; }

    }
}
