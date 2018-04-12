using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UTS_PLOO_151524032_YudisthiraPoyoh.Models
{
    public class Supplier
    {
        [Key]
        [Required]
        public string supplier_id { get; set; }
        [Required]
        public string supplier_name { get; set; }
        [Required]
        public string address { get; set; }
        public string phone { get; set; }
        public string description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}