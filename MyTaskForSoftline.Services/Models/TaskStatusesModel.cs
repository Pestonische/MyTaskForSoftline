using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyTaskForSoftline.Services.Models
{
    public class TaskStatusesModel
    {
        public int TaskId { get; set; }
        [Required(ErrorMessage = "Не может быть пустым")]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не может быть пустым")]
        [Display(Name = "Описание")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Display(Name = "Статус")]
        public SelectList StatusesNames { get; set; }
    }
}
