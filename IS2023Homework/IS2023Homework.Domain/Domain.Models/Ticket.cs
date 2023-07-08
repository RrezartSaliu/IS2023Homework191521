using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IS2023Homework.Domain.Domain.Models
{
    public class Ticket : BaseEntity
    {
        public enum Category
        {
            BIOGRAPHICAL,
            SCIENCE_FICTION,
            ACTION,
            COMEDY,
            DRAMA
        }
        public Category MovieCategory { get; set; }
        public string Title { get; set; }
        public string MovieImage { get; set; }
    
        public double Price { get; set; }
        public System.DateTime Time { get; set; }
        public ICollection<TicketsInShoppingCart> TicketsInShoppingCart { get; set; }
    }
}
