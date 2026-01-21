namespace TaskManager.Models
{
    public class TaskItem
    {
        public string Title { get; set; }

        public TaskItem(string title)
        {
            Title = title;
        }
    }
}
