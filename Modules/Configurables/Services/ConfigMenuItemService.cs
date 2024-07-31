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

    }
}
