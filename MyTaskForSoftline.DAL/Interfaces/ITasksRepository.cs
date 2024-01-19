using System;
using System.Collections.Generic;
using MyTaskForSoftline.Repositories.Items;
using System.Text;

namespace MyTaskForSoftline.DAL.Interfaces
{
    public interface ITasksRepository
    {
        ICollection<TaskItem> GetTasks();
        bool EditTask(int taskId, string taskName, string description, int statusId);
        bool CreatTask(string taskName, string description, int statusId);
        bool DeleteTask(int taskId);
        TaskItem GetTaskById(int taskId);
        bool Save();
        
    }
}
