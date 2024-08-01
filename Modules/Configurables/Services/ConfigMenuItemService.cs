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
        public Task<bool> DeleteConfigMenuItem(Guid id);



        // Perspective-specific methods
        Task<List<ConfigMenuItem>> FetchPerspectives();
        Task<ConfigMenuItem> FetchPerspective(Guid id);
        Task<ConfigMenuItem> AddPerspective(ConfigMenuItem perspective);
        Task<ConfigMenuItem> UpdatePerspective(Guid id, ConfigMenuItem perspective);
        Task<bool> DeletePerspective(Guid id);

        // Initiative-specific methods
        Task<List<ConfigMenuItem>> FetchInitiatives();
        Task<ConfigMenuItem> FetchInitiative(Guid id);
        Task<ConfigMenuItem> AddInitiative(ConfigMenuItem initiative);
        Task<ConfigMenuItem> UpdateInitiative(Guid id, ConfigMenuItem initiative);
        Task<bool> DeleteInitiative(Guid id);

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
                throw new ClientFriendlyException("Implementation already exisiting");
            }

            _context.ConfigMenuItems.Add(configmenuitem);
            await _context.SaveChangesAsync();

            return configmenuitem;
        }

         public async Task<bool> DeleteConfigMenuItem(Guid id)
        {
            var configMenuItem = await _context.ConfigMenuItems.FindAsync(id);
            if (configMenuItem != null)
            {
                _context.ConfigMenuItems.Remove(configMenuItem);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        // Perspective-specific methods

        public async Task<List<ConfigMenuItem>> FetchPerspectives()
        {
            return await _context.ConfigMenuItems.Where(e => e.FieldDescription == "Perspective").ToListAsync();
        }

        public async Task<ConfigMenuItem> FetchPerspective(Guid id)
        {
            var perspective = await _context.ConfigMenuItems.FirstOrDefaultAsync(e => e.ItemId == id && e.FieldDescription == "Perspective");

            if (perspective == null)
            {
                throw new KeyNotFoundException("Perspective not found.");
            }

            return perspective;
        }

        public async Task<ConfigMenuItem> AddPerspective(ConfigMenuItem perspective)
        {
            perspective.FieldDescription = "Perspective";
            return await AddConfigMenuItem(perspective);
        }

        public async Task<ConfigMenuItem> UpdatePerspective(Guid id, ConfigMenuItem perspective)
        {
            if (id != perspective.ItemId)
            {
                throw new ClientFriendlyException("Id mismatch.");
            }
            var existingItem = await FetchPerspective(id);
            existingItem.FieldName = perspective.FieldName;
            _context.ConfigMenuItems.Update(existingItem);
            await _context.SaveChangesAsync();
            return existingItem;
        }


        public async Task<bool> DeletePerspective(Guid id)
        {
            return await DeleteConfigMenuItem(id);
        }


        // Initiative-specific methods

        public async Task<List<ConfigMenuItem>> FetchInitiatives()
        {
            return await _context.ConfigMenuItems.Where(e => e.FieldDescription == "Initiative").ToListAsync();
        }

        public async Task<ConfigMenuItem> FetchInitiative(Guid id)
        {
            var initiative = await _context.ConfigMenuItems.FirstOrDefaultAsync(e => e.ItemId == id && e.FieldDescription == "Initiative");

            if (initiative == null)
            {
                throw new KeyNotFoundException("Initiative not found.");
            }

            return initiative;
        }

        public async Task<ConfigMenuItem> AddInitiative(ConfigMenuItem initiative)
        {
            initiative.FieldDescription = "Initiative";
            return await AddConfigMenuItem(initiative);
        }

        public async Task<ConfigMenuItem> UpdateInitiative(Guid id, ConfigMenuItem initiative)
        {
            if (id != initiative.ItemId)
            {
                throw new ClientFriendlyException("Id mismatch.");
            }

            var existingItem = await FetchInitiative(id);

            existingItem.FieldName = initiative.FieldName;
            _context.ConfigMenuItems.Update(existingItem);
            await _context.SaveChangesAsync();
            return existingItem;
        }


        public async Task<bool> DeleteInitiative(Guid id)
        {
            return await DeleteConfigMenuItem(id);
        }





    }



}

