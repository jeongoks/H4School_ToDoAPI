namespace ToDo_WebClient
{
    public class Todo
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public string? Description { get; set; }
        public bool Completed { get; set; }
        public Priority Priority { get; set; }
    }

    public enum Priority
    {
        Low,
        Normal,
        High
    }
}
