using System;
using System.ComponentModel.DataAnnotations;

namespace EventManagerWeb.Entity
{
    public class EnrolledEvent
    {
        [Key]
        public int Id { get; set; }
        public int EventId { get; set; }
        public Event Event  { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
