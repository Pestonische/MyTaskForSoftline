using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyTaskForSoftline.Repositories.Items
{
    [Table("Tasks")]
    public class TaskItem
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [ScaffoldColumn(false)]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [ScaffoldColumn(false)]
        public string Description { get; set; }

        [ScaffoldColumn(false)]
        public int? Status_ID { get; set; }
        [ForeignKey("Status_ID")]
        public StatusItem Status { get; set; }
    }
}
