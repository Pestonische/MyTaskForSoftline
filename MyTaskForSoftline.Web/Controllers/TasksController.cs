using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyTaskForSoftline.DAL.Interfaces;
using MyTaskForSoftline.Repositories.Items;
using MyTaskForSoftline.Services.IServices;

using MyTaskForSoftline.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyTaskForSoftline.Web.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly IStatusesRepository _statusesRepository;
        private static int ID { get; set; } = 0;
        private static bool IsSelected { get; set; } = false;

        public TasksController(ITaskService taskService, IStatusesRepository statusesRepository)
        {
            _taskService = taskService;
            _statusesRepository = statusesRepository;
        }

        public IActionResult Tasks()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetTasks()
        {
            return Json(new { data = _taskService.GetTasks() });
        }

        #region--Добавление--
        [HttpGet]
        public IActionResult Create()
        {
            TaskStatusesModel taskStatusesModel = new TaskStatusesModel();
            
            List<StatusItem> statuses = _statusesRepository.GetStatuses().ToList();
            List<string> statusesNames = new List<string>();
            foreach (var status in statuses)
            {
                statusesNames.Add(status.Status_name);
            }
            taskStatusesModel.StatusesNames = new SelectList(statusesNames);
                
            return View(taskStatusesModel);               
        }

        [HttpPost]
        public IActionResult Create(TaskModel taskModel)
        {
            _taskService.CreatTask(taskModel.Name, taskModel.Description,
                taskModel.StatusName);

            return Json(new { success = true });
        }
        #endregion

        #region--Редактирование--
        [HttpGet]
        public IActionResult Edit()
        {
            TaskStatusesModel taskStatusesModel = new TaskStatusesModel();
            try
            {
                if (IsSelected)
                {
                    TaskModel taskModel = _taskService.GetTaskById(ID);
                    taskStatusesModel.TaskId = ID;
                    taskStatusesModel.Name = taskModel.Name;
                    taskStatusesModel.Description = taskModel.Description;

                    List<StatusItem> statuses = _statusesRepository.GetStatuses() as List<StatusItem>;
                    List<string> statusesNames = new List<string>();
                    foreach (var status in statuses)
                    {
                        if(status.Status_name == taskModel.StatusName)
                        {
                            statusesNames.Insert(0, status.Status_name);
                        }
                        else
                        {
                            statusesNames.Add(status.Status_name);
                        }
                    }
                    taskStatusesModel.StatusesNames = new SelectList(statusesNames);  
                }
                else
                {
                    throw new Exception();
                }
            }
            catch(Exception e)
            {
                return Ok(null);
            }
            return View(taskStatusesModel);
        }
        
        [HttpPost]
        public IActionResult Edit(TaskModel taskModel)
        {
            _taskService.EditTask(taskModel);
            IsSelected = false;
            ID = 0;
            return Json(new { success = true });
        }
        #endregion


        
        [HttpPost]
        public IActionResult Selected(int id)
        {
            if (ID == id)
            {
                ID = 0;
                IsSelected = false;
            }
            else
            {
                ID = id;
                IsSelected = true;
            }
            return Json(new { success = true, message = "" });
        }
       
        
        [HttpPost]
        public IActionResult Delete()
        {
            try
            {
                if (IsSelected)
                {
                    _taskService.DeleteTask(ID);
                }
                else
                {
                    throw new Exception("Ничего не выбрано!");
                }
                IsSelected = false;
            }
            catch(Exception e)
            {
                return Json(new { success = false, message = e.Message });
            }
            return Json(new { success = true, message = "" });
        }
    }
}
