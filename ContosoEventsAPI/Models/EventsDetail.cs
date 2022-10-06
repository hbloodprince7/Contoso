using System;
using System.Collections.Generic;

namespace ContosoEventsAPI.Models
{
    public partial class EventsDetail
    {
        public EventsDetail()
        {
            BookingDetails = new HashSet<BookingDetail>();
            PaymentDetails = new HashSet<PaymentDetail>();
        }

        public int EventId { get; set; }
        public string EventName { get; set; } = null!;
        public string EventType { get; set; } = null!;
        public string? EventLocation { get; set; }
        public DateTime EventStartdate { get; set; }
        public DateTime EventEnddate { get; set; }
        public string? EventStatus { get; set; }
        public int? EventTicketCatageory { get; set; }

        public virtual TicketCategory? EventTicketCatageoryNavigation { get; set; }
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
        public virtual ICollection<PaymentDetail> PaymentDetails { get; set; }
    }
}
