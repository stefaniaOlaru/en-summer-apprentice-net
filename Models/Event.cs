﻿using System;
using System.Collections.Generic;

namespace TicketManagementSystem.Models;

public partial class Event
{
    public int EventId { get; set; }

    public int? VenueId { get; set; }

    public int? EventTypeId { get; set; }

    public string? EventDescription { get; set; }

    public string? EventName { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual EventType? EventType { get; set; }

    public virtual ICollection<TicketCategory> TicketCategories { get; set; } = new List<TicketCategory>();

    public virtual Venue? Venue { get; set; }
}
