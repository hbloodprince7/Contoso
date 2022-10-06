using System;
using System.Collections.Generic;

namespace ContosoEventsAPI.Models
{
    public partial class PaymentDetail
    {
        public int PaymentId { get; set; }
        public int? PaymentUserId { get; set; }
        public int? PaymentEventId { get; set; }
        public int? PaymentPromoId { get; set; }
        public decimal PaymentAmount { get; set; }

        public virtual EventsDetail? PaymentEvent { get; set; }
        public virtual PromoCode? PaymentPromo { get; set; }
        public virtual UserDetail? PaymentUser { get; set; }
    }
}
