using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlazorOrdering.Shared
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }

        [StringLength(25)]
        [Required]
        public string CustomerCode { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        [Required]
        public string CustomerName{ get; set; }
    }
}
