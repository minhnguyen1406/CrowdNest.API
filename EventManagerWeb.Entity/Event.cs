using System;
using System.ComponentModel.DataAnnotations;


namespace EventManagerWeb.Entity
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }

        public DateTime? PublishedDate { get; set; }
        public bool? IsPublished { get; set; }
        public bool? IsActive { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
