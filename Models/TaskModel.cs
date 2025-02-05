namespace SimpleListWinUI.Models
{
    public class TaskModel
    {
        public string TaskDescription { get; set; }
        public TaskModel (string description)
        {
            TaskDescription = description;
        }
    }
}