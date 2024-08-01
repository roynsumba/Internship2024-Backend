using AppraisalTracker.Data;
using AppraisalTracker.Exceptions;
using AppraisalTracker.Modules.AppraisalActivity.Models;
using Microsoft.EntityFrameworkCore;

namespace AppraisalTracker.Modules.AppraisalActivity.Services
{
    public interface IConfigMenuItemService
    {
        public Task<List<ConfigMenuItem>> FetchConfigMenuItems();
        public Task<ConfigMenuItem> AddConfigMenuItem(ConfigMenuItem configmenuitem);
        Task<ConfigMenuItem> AddActivityItem(ConfigMenuItem addActivityItem);
        Task<List<ConfigMenuItem>> GetAllActivityItems();
        Task<ConfigMenuItem?> GetAnActivityItem(Guid id);
        Task<ConfigMenuItem?> UpdateAnActivityItem(Guid id, ConfigMenuItem activityItem);
        Task<ConfigMenuItem?> DeleteAnActivity(Guid id);
    }
    public class ConfigMenuItemService(AppDbContext context) : IConfigMenuItemService
    {

        public readonly AppDbContext _context = context;

        public async Task<List<ConfigMenuItem>> FetchConfigMenuItems()
        {
            return await _context.ConfigMenuItems.ToListAsync();
        }

        public async Task<ConfigMenuItem> AddConfigMenuItem(ConfigMenuItem configmenuitem)
        {
            if (_context.ConfigMenuItems.Any(e => e.ItemId == configmenuitem.ItemId))
            {
                throw new ClientFriendlyException("Implementation already exisitng");
            }

            _context.ConfigMenuItems.Add(configmenuitem);
            await _context.SaveChangesAsync();

            return configmenuitem;
        }
        public async Task<ConfigMenuItem> AddActivityItem(ConfigMenuItem addActivityItem)
        {
            _context.ConfigMenuItems.Add(addActivityItem);
            await _context.SaveChangesAsync();
            return addActivityItem;
        }

        public async Task<List<ConfigMenuItem>> GetAllActivityItems()
        {
            return await _context.ConfigMenuItems
                                 .Where(item => item.FieldDescription == "Measurable Activity")
                                 .ToListAsync();
        }

        public async Task<ConfigMenuItem?> GetAnActivityItem(Guid id)
        {
            return await _context.ConfigMenuItems.FindAsync(id);
        }

        public async Task<ConfigMenuItem?> UpdateAnActivityItem(Guid id, ConfigMenuItem activityItem)
        {
            var activityToUpdate = await _context.ConfigMenuItems.FirstOrDefaultAsync(item => item.ItemId == id);

            if (activityToUpdate == null)
            {
                throw new KeyNotFoundException("Activity record for update not found.");
            }

            activityToUpdate.FieldName = activityItem.FieldName;
            activityToUpdate.FieldDescription = activityItem.FieldDescription;

            _context.ConfigMenuItems.Update(activityToUpdate);
            await _context.SaveChangesAsync();

            return activityToUpdate;
        }

        public async Task<ConfigMenuItem?> DeleteAnActivity(Guid id)
        {
            var activityToDelete = await _context.ConfigMenuItems.FindAsync(id);
            if (activityToDelete == null)
            {
                throw new KeyNotFoundException("Activity record for deletion not found.");
            }
            _context.ConfigMenuItems.Remove(activityToDelete);
            await _context.SaveChangesAsync();

            return activityToDelete;

        }
    }
}
