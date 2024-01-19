using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyTaskForSoftline.Services.Models
{
    public class TaskModel
    {
        public int TaskId { get; set; }
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Статус")]
        public string StatusName { get; set; }
    }
}
