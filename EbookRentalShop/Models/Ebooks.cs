using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EbookRentalShop.Models
{
    public class Ebooks
    {
        [Key]
        public int EbookID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorID { get; set; }
        public int CategoryID { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int PublisherID { get; set; }

        //public virtual ICollection<Borrows> Borrows { get; set; }
        //public virtual Authors Author { get; set; }
        //public virtual Categories Category { get; set; }
        //public virtual Publishers Publisher { get; set; }

    }
}