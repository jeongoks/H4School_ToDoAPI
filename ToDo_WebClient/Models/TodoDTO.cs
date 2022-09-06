using System.ComponentModel.DataAnnotations;

namespace ToDo_WebClient.Models
{
    public class TodoDTO
    {
        public int ID { get; set; }
        [Required]
        public string? Name { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        [Required]
        public string? Description { get; set; }
        public bool Completed { get; set; }
        [Required]
        public Priority Priority { get; set; }
    }

    public enum Priority
    {
        Low,
        Normal,
        High
    }
}
