using AppraisalTracker.Data;
using AppraisalTracker.Exceptions;
using AppraisalTracker.Modules.AppraisalActivity.Models;
using Microsoft.EntityFrameworkCore;

namespace AppraisalTracker.Modules.AppraisalActivity.Services
{
    public interface IConfigMenuItemService
    {
        Task<List<ConfigMenuItem>> FetchConfigMenuItems();
        Task<ConfigMenuItem> AddConfigMenuItem(ConfigMenuItem configMenuItem);
        Task<ConfigMenuItem> AddActivityItem(ConfigMenuItem addActivityItem);
        Task<List<ConfigMenuItem>> GetAllActivityItems();
        Task<ConfigMenuItem?> GetAnActivityItem(Guid id);
        Task<ConfigMenuItem?> UpdateAnActivityItem(Guid id, ConfigMenuItem activityItem);
        Task<ConfigMenuItem?> DeleteAnActivity(Guid id);
        Task<ConfigMenuItem> AddObjectiveItem(ConfigMenuItem addObjectiveItem);
        Task<List<ConfigMenuItem>> GetAllObjectiveItems();
        Task<ConfigMenuItem?> GetAnObjectiveItem(Guid id);
        Task<ConfigMenuItem?> UpdateObjectiveItem(Guid id, ConfigMenuItem objectiveItem);
        Task<ConfigMenuItem?> DeleteAnObjective(Guid id);
    }

    public class ConfigMenuItemService : IConfigMenuItemService
    {
        private readonly AppDbContext _context;

        public ConfigMenuItemService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ConfigMenuItem>> FetchConfigMenuItems()
        {
            try
            {
                return await _context.ConfigMenuItems.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ClientFriendlyException($"An error occurred while fetching config menu items: {ex.Message}");
            }
        }

        public async Task<ConfigMenuItem> AddConfigMenuItem(ConfigMenuItem configMenuItem)
        {
            try
            {
                if (_context.ConfigMenuItems.Any(e => e.ItemId == configMenuItem.ItemId))
                {
                    throw new ClientFriendlyException("Implementation already existing");
                }

                _context.ConfigMenuItems.Add(configMenuItem);
                await _context.SaveChangesAsync();

                return configMenuItem;
            }
            catch (Exception ex)
            {
                throw new ClientFriendlyException($"An error occurred while adding the config menu item: {ex.Message}");
            }
        }

        public async Task<ConfigMenuItem> AddActivityItem(ConfigMenuItem addActivityItem)
        {
            try
            {
                if (_context.ConfigMenuItems.Any(e => e.ItemId == addActivityItem.ItemId))
                {
                    throw new ClientFriendlyException("Implementation already existing");
                }

                _context.ConfigMenuItems.Add(addActivityItem);
                await _context.SaveChangesAsync();

                return addActivityItem;
            }
            catch (Exception ex)
            {
                throw new ClientFriendlyException($"An error occurred while adding the activity item: {ex.Message}");
            }
        }

        public async Task<List<ConfigMenuItem>> GetAllActivityItems()
        {
            try
            {
                return await _context.ConfigMenuItems
                                     .Where(item => item.FieldDescription == "Measurable Activity")
                                     .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ClientFriendlyException($"An error occurred while fetching all activity items: {ex.Message}");
            }
        }

        public async Task<ConfigMenuItem?> GetAnActivityItem(Guid id)
        {
            try
            {
                var activityItem = await _context.ConfigMenuItems.FindAsync(id);

                if (activityItem == null)
                {
                    throw new ClientFriendlyException($"Couldn't find activity item with id :'{id}'");
                }

                return activityItem;
            }
            catch (Exception ex)
            {
                throw new ClientFriendlyException($"An error occurred while fetching the activity item: {ex.Message}");
            }
        }

        public async Task<ConfigMenuItem?> UpdateAnActivityItem(Guid id, ConfigMenuItem activityItem)
        {
            try
            {
                var activityToUpdate = await _context.ConfigMenuItems.FirstOrDefaultAsync(item => item.ItemId == id);

                if (activityToUpdate == null)
                {
                    throw new ClientFriendlyException("Could not find record to update.");
                }

                activityToUpdate.FieldName = activityItem.FieldName;
                activityToUpdate.FieldDescription = activityItem.FieldDescription;

                _context.ConfigMenuItems.Update(activityToUpdate);
                await _context.SaveChangesAsync();

                return activityToUpdate;
            }
            catch (Exception ex)
            {
                throw new ClientFriendlyException($"An error occurred while updating the activity item: {ex.Message}");
            }
        }

        public async Task<ConfigMenuItem?> DeleteAnActivity(Guid id)
        {
            try
            {
                var activityToDelete = await _context.ConfigMenuItems.FindAsync(id);

                if (activityToDelete == null)
                {
                    throw new ClientFriendlyException("Activity record for deletion not found.");
                }

                _context.ConfigMenuItems.Remove(activityToDelete);
                await _context.SaveChangesAsync();

                return activityToDelete;
            }
            catch (Exception ex)
            {
                throw new ClientFriendlyException($"An error occurred while deleting the activity item: {ex.Message}");
            }
        }

        public async Task<ConfigMenuItem> AddObjectiveItem(ConfigMenuItem addObjectiveItem)
        {
            try
            {
                if (_context.ConfigMenuItems.Any(e => e.ItemId == addObjectiveItem.ItemId))
                {
                    throw new ClientFriendlyException("Implementation already existing");
                }

                _context.ConfigMenuItems.Add(addObjectiveItem);
                await _context.SaveChangesAsync();

                return addObjectiveItem;
            }
            catch (Exception ex)
            {
                throw new ClientFriendlyException($"An error occurred while adding the objective item: {ex.Message}");
            }
        }

        public async Task<List<ConfigMenuItem>> GetAllObjectiveItems()
        {
            try
            {
                return await _context.ConfigMenuItems
                                     .Where(item => item.FieldDescription == "Objective")
                                     .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ClientFriendlyException($"An error occurred while fetching all objective items: {ex.Message}");
            }
        }

        public async Task<ConfigMenuItem?> GetAnObjectiveItem(Guid id)
        {
            try
            {
                var objectiveItem = await _context.ConfigMenuItems.FindAsync(id);

                if (objectiveItem == null)
                {
                    throw new ClientFriendlyException($"Couldn't find objective item with id '{id}'");
                }

                return objectiveItem;
            }
            catch (Exception ex)
            {
                throw new ClientFriendlyException($"An error occurred while fetching the objective item: {ex.Message}");
            }
        }

        public async Task<ConfigMenuItem?> UpdateObjectiveItem(Guid id, ConfigMenuItem objectiveItem)
        {
            try
            {
                var objectiveToUpdate = await _context.ConfigMenuItems.FirstOrDefaultAsync(item => item.ItemId == id);

                if (objectiveToUpdate == null)
                {
                    throw new ClientFriendlyException("Objective for update not found.");
                }

                objectiveToUpdate.FieldName = objectiveItem.FieldName;
                objectiveToUpdate.FieldDescription = objectiveItem.FieldDescription;

                _context.ConfigMenuItems.Update(objectiveToUpdate);
                await _context.SaveChangesAsync();

                return objectiveToUpdate;
            }
            catch (Exception ex)
            {
                throw new ClientFriendlyException($"An error occurred while updating the objective item: {ex.Message}");
            }
        }

        public async Task<ConfigMenuItem?> DeleteAnObjective(Guid id)
        {
            try
            {
                var objectiveToDelete = await _context.ConfigMenuItems.FindAsync(id);

                if (objectiveToDelete == null)
                {
                    throw new ClientFriendlyException("Objective for deletion not found.");
                }

                _context.ConfigMenuItems.Remove(objectiveToDelete);
                await _context.SaveChangesAsync();

                return objectiveToDelete;
            }
            catch (Exception ex)
            {
                throw new ClientFriendlyException($"An error occurred while deleting the objective item: {ex.Message}");
            }
        }
    }
}
