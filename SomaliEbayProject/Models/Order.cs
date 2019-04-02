using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SomaliEbayProject.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Qty { get; set; }
        [Required]
        public decimal TotalCost { get; set; }
        [Required]
        public decimal TotalPaid { get; set; }
        public bool IsPaid { get; set; } = false;
        public decimal? Discount { get; set; }

        public int? ProductId { get; set;}
        public Product Product { get; set; }
    }
}
