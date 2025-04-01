using Microsoft.OpenApi.Models;
using System.ComponentModel.DataAnnotations;

namespace TicketHub.Api.Models
{
    public class PurchaseRequest
    {
        public int ConcertId { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, Phone]
        public string Phone { get; set; }

        [Range(1, 10)]
        public int Quantity { get; set; }

        [Required, CreditCard]
        public string CreditCard { get; set; }

        [Required]
        public string Expiration { get; set; }

        [Required]
        public string SecurityCode { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Province { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string Country { get; set; }
    }
}
