using MyTaskForSoftline.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTaskForSoftline.Services.IServices
{
    public interface ITaskService
    {
        ICollection<TaskModel> GetTasks();
        void EditTask(TaskModel taskModel);
        void CreatTask(string taskName, string description, string statusName);
        void DeleteTask(int taskId);
        TaskModel GetTaskById(int taskId);
    }
}
