﻿using AppraisalTracker.Data;
using AppraisalTracker.Exceptions;
using AppraisalTracker.Modules.Configurables.Models;
using Microsoft.EntityFrameworkCore;

namespace AppraisalTracker.Modules.Configurables.Services
{
    public interface IConfigMenuItemService
    {
        //General Configurable Items Methods
        Task<List<ConfigMenuItem>> FetchConfigMenuItems(Guid userId);
        Task<ConfigMenuItem> FetchASingleConfigMenuItem(Guid Id);
        Task<ConfigMenuItem> AddConfigMenuItem(ConfigMenuItem configMenuItem);
        public Task<ConfigMenuItem> DeleteConfigMenuItem(Guid id);

        //Measurable activity Methods
        Task<ConfigMenuItem> AddActivityItem(ConfigMenuItem addActivityItem);
        Task<List<ConfigMenuItem>> GetAllActivityItems(Guid userId);
        Task<ConfigMenuItem?> GetAnActivityItem(Guid id);
        Task<ConfigMenuItem?> UpdateAnActivityItem(Guid id, ConfigMenuItem activityItem);
        Task<ConfigMenuItem?> DeleteAnActivity(Guid id);

        //Period Methods
        Task<ConfigMenuItem> AddPeriodItem(ConfigMenuItem periodItem);
        Task<List<ConfigMenuItem>> GetPeriodItems();
        Task<ConfigMenuItem?> GetAPeriodItem(Guid id);
        Task<ConfigMenuItem?> UpdateAPeriodItem(Guid id, ConfigMenuItem periodItem);
        Task<ConfigMenuItem?> DeleteAPeriod(Guid id);

        //SSmartaObjectives Methods
        Task<ConfigMenuItem> AddObjectiveItem(ConfigMenuItem addObjectiveItem);
        Task<List<ConfigMenuItem>> GetAllObjectiveItems(Guid userId);
        Task<ConfigMenuItem?> GetAnObjectiveItem(Guid id);
        Task<ConfigMenuItem?> UpdateObjectiveItem(Guid id, ConfigMenuItem objectiveItem);
        Task<ConfigMenuItem?> DeleteAnObjective(Guid id);

        // Perspective-specific methods
        Task<List<ConfigMenuItem>> FetchPerspectives();
        Task<ConfigMenuItem> FetchPerspective(Guid id);
        Task<ConfigMenuItem> AddPerspective(ConfigMenuItem perspective);
        Task<ConfigMenuItem> UpdatePerspective(Guid id, ConfigMenuItem perspective);
        Task<ConfigMenuItem> DeletePerspective(Guid id);

        // Initiative-specific methods
        Task<List<ConfigMenuItem>> FetchInitiatives(Guid userId);
        Task<ConfigMenuItem> FetchInitiative(Guid id);
        Task<ConfigMenuItem> AddInitiative(ConfigMenuItem initiative);
        Task<ConfigMenuItem> UpdateInitiative(Guid id, ConfigMenuItem initiative);
        Task<ConfigMenuItem> DeleteInitiative(Guid id);
    }

    public class ConfigMenuItemService : IConfigMenuItemService
    {
        private readonly AppDbContext _context;

        public ConfigMenuItemService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ConfigMenuItem>> FetchConfigMenuItems(Guid userId)
        {
            try
            {
                return await _context.ConfigMenuItems.Where(user => user.UserId == userId && user.IsDeleted == false).ToListAsync();
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

        public async Task<List<ConfigMenuItem>> GetAllActivityItems(Guid userId)
        {
            try
            {
                return await _context.ConfigMenuItems
                                     .Where(item => item.FieldName == "Measurable Activity" && item.UserId == userId && item.IsDeleted == false)
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

                activityToUpdate.FieldName = "Measurable Activity";
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
            return await DeleteConfigMenuItem(id);
        }


        public async Task<ConfigMenuItem> AddPeriodItem(ConfigMenuItem periodItem)
        {
            try
            {
                if (_context.ConfigMenuItems.Any(e => e.ItemId == periodItem.ItemId))
                {
                    throw new ClientFriendlyException("Period already existing");
                }

                _context.ConfigMenuItems.Add(periodItem);
                await _context.SaveChangesAsync();

                return periodItem;
            }
            catch (Exception ex)
            {
                throw new ClientFriendlyException($"An error occurred while adding the activity item: {ex.Message}");
            }
        }

        public async Task<List<ConfigMenuItem>> GetPeriodItems()
        {
            try
            {
                return await _context.ConfigMenuItems
                                     .Where(item => item.FieldName == "Period" && item.IsDeleted == false)
                                     .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ClientFriendlyException($"An error occurred while fetching all period items: {ex.Message}");
            }
        }

        public async Task<ConfigMenuItem?> GetAPeriodItem(Guid id)
        {
            try
            {
                var periodItem = await _context.ConfigMenuItems.FindAsync(id);

                if (periodItem == null)
                {
                    throw new ClientFriendlyException($"Couldn't find activity item with id :'{id}'");
                }

                return periodItem;
            }
            catch (Exception ex)
            {
                throw new ClientFriendlyException($"An error occurred while fetching the activity item: {ex.Message}");
            }
        }

        public async Task<ConfigMenuItem?> UpdateAPeriodItem(Guid id, ConfigMenuItem periodItem)
        {
            try
            {
                var periodToUpdate = await _context.ConfigMenuItems.FirstOrDefaultAsync(item => item.ItemId == id);

                if (periodToUpdate == null)
                {
                    throw new ClientFriendlyException("Could not find record to update.");
                }

                periodToUpdate.FieldName = "Period";
                periodToUpdate.FieldDescription = periodItem.FieldDescription;

                _context.ConfigMenuItems.Update(periodToUpdate);
                await _context.SaveChangesAsync();

                return periodToUpdate;
            }
            catch (Exception ex)
            {
                throw new ClientFriendlyException($"An error occurred while updating the period item: {ex.Message}");
            }
        }

        public async Task<ConfigMenuItem?> DeleteAPeriod(Guid id)
        {
            return await DeleteConfigMenuItem(id);
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

        public async Task<List<ConfigMenuItem>> GetAllObjectiveItems(Guid userId)
        {
            try
            {
                return await _context.ConfigMenuItems
                                     .Where(item => item.FieldName == "Objective" && item.UserId == userId && item.IsDeleted == false)
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

        public async Task<ConfigMenuItem> DeleteConfigMenuItem(Guid id)
        {
            var configMenuItem = await _context.ConfigMenuItems.FindAsync(id);
            if (configMenuItem != null)
            {
                configMenuItem.IsDeleted = true;
                await _context.SaveChangesAsync();
                return configMenuItem;
            }

            throw new ClientFriendlyException($"Couldn't find objective item with id '{id}'");
        }

        // Perspective-specific methods

        public async Task<List<ConfigMenuItem>> FetchPerspectives()
        {
            return await _context.ConfigMenuItems.Where(e => e.FieldName == "Perspective").ToListAsync();
        }

        public async Task<ConfigMenuItem> FetchPerspective(Guid id)
        {
            var perspective = await _context.ConfigMenuItems.FirstOrDefaultAsync(e => e.ItemId == id && e.FieldName == "Perspective" && e.IsDeleted == false);

            if (perspective == null)
            {
                throw new KeyNotFoundException("Perspective not found.");
            }

            return perspective;
        }

        public async Task<ConfigMenuItem> AddPerspective(ConfigMenuItem perspective)
        {
            perspective.FieldName = "Perspective";
            return await AddConfigMenuItem(perspective);
        }

        public async Task<ConfigMenuItem> UpdatePerspective(Guid id, ConfigMenuItem perspective)
        {
            
            var existingItem = await FetchPerspective(id);
            existingItem.FieldDescription = perspective.FieldDescription;
            _context.ConfigMenuItems.Update(existingItem);
            await _context.SaveChangesAsync();
            return existingItem;
        }


        public async Task<ConfigMenuItem> DeletePerspective(Guid id)
        {
            return await DeleteConfigMenuItem(id);
        }


        // Initiative-specific methods

        public async Task<List<ConfigMenuItem>> FetchInitiatives(Guid userId)
        {
            return await _context.ConfigMenuItems.Where(e => e.FieldName == "Initiative" && e.UserId == userId && e.IsDeleted == false).ToListAsync();
        }

        public async Task<ConfigMenuItem> FetchInitiative(Guid id)
        {
            var initiative = await _context.ConfigMenuItems.FirstOrDefaultAsync(e => e.ItemId == id && e.FieldName == "Initiative");

            if (initiative == null)
            {
                throw new KeyNotFoundException("Initiative not found.");
            }

            return initiative;
        }

        public async Task<ConfigMenuItem> AddInitiative(ConfigMenuItem initiative)
        {
            initiative.FieldName = "Initiative";
            return await AddConfigMenuItem(initiative);
        }

        public async Task<ConfigMenuItem> UpdateInitiative(Guid id, ConfigMenuItem initiative)
        {

            var existingItem = await FetchInitiative(id);

            existingItem.FieldDescription = initiative.FieldDescription;
            _context.ConfigMenuItems.Update(existingItem);
            await _context.SaveChangesAsync();
            return existingItem;
        }


        public async Task<ConfigMenuItem> DeleteInitiative(Guid id)
        {
            return await DeleteConfigMenuItem(id);
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

                objectiveToUpdate.FieldName = "Objective";
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
            return await DeleteConfigMenuItem(id);
        }

        public async Task<ConfigMenuItem> FetchASingleConfigMenuItem(Guid Id)
        {
            var configItem = await _context.ConfigMenuItems.FindAsync(Id);
            if (configItem == null)
            {
                throw new ClientFriendlyException("Item not found.");

            }
            return configItem;
        }
    }



}

