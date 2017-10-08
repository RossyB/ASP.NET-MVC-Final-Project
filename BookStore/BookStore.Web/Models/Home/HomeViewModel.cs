using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Web.Models.Home
{
    public class HomeViewModel
    {
        public ICollection<BookViewModel> Books { get; set; }
    }
}