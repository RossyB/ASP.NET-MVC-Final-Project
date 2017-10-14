using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Data.Model.Abstracts;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Data.Model
{
    public class Book : DataModel
    {
        private ICollection<Comment> comments;

        public Book()
        {
            this.comments = new HashSet<Comment>();
        }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(50)]
        public string Author { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public Decimal Price { get; set; }

        public string BookImageUrl { get; set; }

        public int Rathing { get; set; }

        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string OwnerId { get; set; }

        public virtual User Owner { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
