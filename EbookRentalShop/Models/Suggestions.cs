using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EbookRentalShop.Models
{
    public class Suggestions
    {
        [Key]
        public int SuggestionID { get; set; }
        public string UserID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }
}