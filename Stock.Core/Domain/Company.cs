using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stock.Core.Domain
{
    public class Company
    {
        public Guid Id { get; set; }

        [MaxLength(128), Column(TypeName = "varchar")]
        [Required]
        public string Name { get; set; }

        [MaxLength(32), Column(TypeName = "varchar")]
        [Required]
        public string StockCode { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
