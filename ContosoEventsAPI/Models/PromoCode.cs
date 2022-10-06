using System;
using System.Collections.Generic;

namespace ContosoEventsAPI.Models
{
    public partial class PromoCode
    {
        public PromoCode()
        {
            PaymentDetails = new HashSet<PaymentDetail>();
        }

        public int PromoId { get; set; }
        public string PromoName { get; set; } = null!;
        public int? PromoOffer { get; set; }

        public virtual ICollection<PaymentDetail> PaymentDetails { get; set; }
    }
}
