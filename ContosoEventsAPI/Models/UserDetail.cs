using System;
using System.Collections.Generic;

namespace ContosoEventsAPI.Models
{
    public partial class UserDetail
    {
        public UserDetail()
        {
            BookingDetails = new HashSet<BookingDetail>();
            PaymentDetails = new HashSet<PaymentDetail>();
        }

        public int UserId { get; set; }
        public string UserUserName { get; set; } = null!;
        public string? UserFirstName { get; set; }
        public string? UserLastName { get; set; }
        public string UserEmail { get; set; } = null!;
        public long UserContact { get; set; }
        public string? UserPassword { get; set; }
        public string? UserGender { get; set; }
        public string? UserCountry { get; set; }
        public string? UserAddress { get; set; }

        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
        public virtual ICollection<PaymentDetail> PaymentDetails { get; set; }
    }
}
