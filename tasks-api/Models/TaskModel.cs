using tasks_api.Enums;

namespace tasks_api.Models
{
    public class TaskModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public TaskEnumStatus Status { get; set; }
    }
}
