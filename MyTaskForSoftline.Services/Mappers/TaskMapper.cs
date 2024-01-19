using MyTaskForSoftline.Repositories.Items;
using MyTaskForSoftline.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTaskForSoftline.Services.Mappers
{
    public class TaskMapper
    {
        public static TaskItem Map(TaskModel taskModel, StatusItem status)
        {

            return taskModel == null || status == null ? null : new TaskItem()
            {
                ID = taskModel.TaskId,
                Name = taskModel.Name,
                Description = taskModel.Description,
                Status_ID = status.Status_ID,
                Status = status
            };
        }
        public static TaskModel Map(TaskItem taskItem, string statusName)
        {
            return taskItem == null || statusName == null ? null : new TaskModel()
            {
                TaskId = taskItem.ID,
                Name = taskItem.Name,
                Description = taskItem.Description,
                StatusName = statusName
            };
        }
    }
}
