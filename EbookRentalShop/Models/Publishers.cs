using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EbookRentalShop.Models
{
    public class Publishers
    {
        [Key]
        public int PublisherID { get; set; }
        public string Name { get; set; }

        //public virtual ICollection<EBooks> Ebooks { get; set; }
    }
}