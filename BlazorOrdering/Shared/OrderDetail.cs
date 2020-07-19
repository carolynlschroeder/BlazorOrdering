using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Text;

namespace BlazorOrdering.Shared
{
    public class OrderDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }

        [ForeignKey("Order")]
        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [ForeignKey("Product")]
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Product is Required")]
        public string ProductIdString { get; set; }

        public void CopyFrom(OrderDetail other)
        {
            OrderId = other.OrderId;
            ProductId = other.ProductId;
            Quantity = other.Quantity;
            ProductIdString = other.ProductIdString;
        }
    }
}
