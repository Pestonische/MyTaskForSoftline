using MyTaskForSoftline.DAL.Interfaces;
using MyTaskForSoftline.Repositories.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyTaskForSoftline.DAL.Repositories
{
    public class StatusesRepository : IStatusesRepository
    {
        private readonly DatabaseContext _context;

        public StatusesRepository(DatabaseContext context)
        {
            _context = context;
        }

        public StatusItem GetStatusById(int? statusId)
        {
            return _context.StatusItems.AsQueryable().Where(s => s.Status_ID == statusId).FirstOrDefault();
        }

        public StatusItem GetStatusByName(string statusName)
        {
            return _context.StatusItems.AsQueryable().Where(s => s.Status_name == statusName).FirstOrDefault();
        }

        public ICollection<StatusItem> GetStatuses()
        {
            ICollection<StatusItem> statusItem = _context.StatusItems.AsQueryable().OrderBy(p => p.Status_ID).ToList();
            return statusItem;
        }
    }
}
