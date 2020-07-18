using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlazorOrdering.Shared
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        [Required]
        public string ProductName { get; set; }

        [Required]
        public decimal Price { get; set; }

    }
}
