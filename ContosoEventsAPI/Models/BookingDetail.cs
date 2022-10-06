using System;
using System.Collections.Generic;

namespace ContosoEventsAPI.Models
{
    public partial class BookingDetail
    {
        public int BookingId { get; set; }
        public int? BookingEventId { get; set; }
        public decimal BookingAmount { get; set; }
        public int? BookingUserId { get; set; }
        public int BookingNumberofTickets { get; set; }
        public decimal? BookingSingleUnitPrice { get; set; }

        public virtual EventsDetail? BookingEvent { get; set; }
        public virtual UserDetail? BookingUser { get; set; }
    }
}
