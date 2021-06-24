using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EbookRentalShop.Models
{
    public class Borrows
    {
        [Key]
        public int BorrowID { get; set; }
        public string UserID { get; set; }
        public int EbookID { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }

        //public virtual EBooks Ebook { get; set; }
    }
}