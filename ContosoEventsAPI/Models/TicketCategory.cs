using System;
using System.Collections.Generic;

namespace ContosoEventsAPI.Models
{
    public partial class TicketCategory
    {
        public TicketCategory()
        {
            EventsDetails = new HashSet<EventsDetail>();
        }

        public int TicketCategoryId { get; set; }
        public string? TicketCategoryName { get; set; }
        public int? TicketCategoryTicketsAvailable { get; set; }

        public virtual ICollection<EventsDetail> EventsDetails { get; set; }
    }
}
