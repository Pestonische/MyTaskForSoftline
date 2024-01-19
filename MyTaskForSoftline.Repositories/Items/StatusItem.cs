using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyTaskForSoftline.Repositories.Items
{
    [Table("Statuses")]
    public class StatusItem
    {
        [Key]
        public int Status_ID { get; set; }
        [Required]
        public string Status_name { get; set; }
    }
}
