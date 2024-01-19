using MyTaskForSoftline.DAL.Interfaces;
using MyTaskForSoftline.Repositories.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyTaskForSoftline.DAL.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private readonly DatabaseContext _context;

        public TasksRepository(DatabaseContext context)
        {
            _context = context;
        }
        public bool CreatTask(string taskName, string description, int statusId)
        {
            TaskItem task = new TaskItem
            {
                Name = taskName,
                Description = description,
                Status_ID = statusId,
                Status = _context.StatusItems.AsQueryable().Where(s => s.Status_ID == statusId).FirstOrDefault()
            };
            _context.Add(task);
            return Save();
        }

        public bool DeleteTask(int taskId)
        {
            TaskItem task = _context.TaskItems.AsQueryable().Where(t => t.ID == taskId).FirstOrDefault();
            _context.Remove(task);
            return Save();
        }
        public TaskItem GetTaskById(int taskId)
        {
            return _context.TaskItems.AsQueryable().Where(s => s.ID == taskId).FirstOrDefault();
        }
        public bool EditTask(int taskId, string taskName, string description, int statusId)
        {
            TaskItem taskItem = _context.TaskItems.AsQueryable().Where(t => t.ID == taskId).FirstOrDefault();
            taskItem.Name = taskName;
            taskItem.Description = description;
            taskItem.Status_ID = statusId;
            taskItem.Status = _context.StatusItems.AsQueryable().Where(s => s.Status_ID == statusId).FirstOrDefault();
            _context.Update(taskItem);
            return Save();
        }

        public ICollection<TaskItem> GetTasks()
        {
            ICollection<TaskItem> taskItems = _context.TaskItems.AsQueryable().OrderBy(p => p.ID).ToList();            
            return taskItems;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
