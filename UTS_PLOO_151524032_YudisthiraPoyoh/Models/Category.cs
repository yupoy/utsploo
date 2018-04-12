using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UTS_PLOO_151524032_YudisthiraPoyoh.Models
{
    public class Category
    {
        [Key]
        [Required]
        public string category_id { get; set; }
        [Required]
        public string category_name { get; set; }
        public string description { get; set; }
        
        public virtual ICollection<Product> Products { get; set; }
    }
}