using MyTaskForSoftline.DAL.Interfaces;
using MyTaskForSoftline.DAL.Repositories;
using MyTaskForSoftline.Repositories.Items;
using MyTaskForSoftline.Services.IServices;
using MyTaskForSoftline.Services.Mappers;
using MyTaskForSoftline.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTaskForSoftline.Services.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITasksRepository _tasksRepository;
        private readonly IStatusesRepository _statusesRepository;
        public TaskService(ITasksRepository tasksRepository, IStatusesRepository statusesRepository)
        {
            _tasksRepository = tasksRepository;
            _statusesRepository = statusesRepository;
        }

        public ICollection<TaskModel> GetTasks()
        {
            List<TaskModel> taskModels = new List<TaskModel>();
            List<TaskItem> taskItems = _tasksRepository.GetTasks() as List<TaskItem>;
            foreach (var taskItem in taskItems)
            {
                string statusName = _statusesRepository.GetStatusById(taskItem.Status_ID).Status_name;
                taskModels.Add(TaskMapper.Map(taskItem, statusName));                
            }
            return taskModels;
        }

        public void EditTask(TaskModel taskModel)
        {
            int statusId = _statusesRepository.GetStatusByName(taskModel.StatusName).Status_ID;
            _tasksRepository.EditTask(taskModel.TaskId, taskModel.Name, taskModel.Description, statusId);
        }

        public void CreatTask(string taskName, string description, string statusName)
        {
            int statusId = _statusesRepository.GetStatusByName(statusName).Status_ID;
            _tasksRepository.CreatTask(taskName, description, statusId);
        }
        public TaskModel GetTaskById(int taskId)
        {
            TaskItem taskItem = _tasksRepository.GetTaskById(taskId);
            string statusName = _statusesRepository.GetStatusById(taskItem.Status_ID).Status_name;
            return TaskMapper.Map(taskItem, statusName);
        }
        public void DeleteTask(int taskId)
        {
            _tasksRepository.DeleteTask(taskId);
        }        
    }
}
