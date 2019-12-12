using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS.Models.Models
{
    public class SalesDetails
    {
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        public int SalesId { get; set; }
        public Sales Sales { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
