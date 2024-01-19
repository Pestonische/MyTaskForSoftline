using MyTaskForSoftline.Repositories.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTaskForSoftline.DAL.Interfaces
{
    public interface IStatusesRepository
    {
        ICollection<StatusItem> GetStatuses();
        StatusItem GetStatusById(int? statusId);
        StatusItem GetStatusByName(string statusName);
    }
}
