using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UTS_PLOO_151524032_YudisthiraPoyoh.Models
{
    public class Product
    {
        [Key]
        [Required]
        public string product_id { get; set; }
        [Required]
        public string product_name { get; set; }
        public int price { get; set; }
        public int minimum_stock { get; set; }

        public string supplier_id { get; set; }
        public string category_id { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Category Category { get; set; }
    }
}