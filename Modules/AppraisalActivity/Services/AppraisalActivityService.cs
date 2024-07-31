using AppraisalTracker.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppraisalTracker.Data;
using AppraisalTracker.Modules.AppraisalActivity.Models;

namespace AppraisalTracker.Modules.AppraisalActivity.Services
{
    public interface IAppraisalActivityService
    {
        public Task<List<MeasurableActivity>> FetchMeasurableActivities();
        public Task<List<Implementation>> FetchImplementations();
        public Task<MeasurableActivity> FetchMeasurableActivity(int id);
        public Task<Implementation> FetchImplementation(int id);

        public Task<MeasurableActivity> UpdateMeasurableActivity(int id, MeasurableActivity measurableActivity);
        public Task<bool> DeleteMeasurableActivity(int id);

        public Task<Implementation> UpdateImplementation(Implementation implementation);

        public Task<MeasurableActivity> PostMeasurableActivity(MeasurableActivity measurableActivity);
        public Task<Implementation> PostImplementation(Implementation implementation);

        public Task<bool> DeleteImplementation(int id);



    }
    public class AppraisalActivityService : IAppraisalActivityService
    {

        public readonly AppDbContext _context;
        public AppraisalActivityService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<MeasurableActivity>> FetchMeasurableActivities()
        {
            return await _context.MeasurableActivities.Include(x => x.Implementation).ToListAsync();
        }

        public async Task<List<Implementation>> FetchImplementations()
        {
            return await _context.Implementations.ToListAsync();
        }

        public async Task<MeasurableActivity> FetchMeasurableActivity(int id)
        {

            var measurableActivity = await _context.MeasurableActivities.FindAsync(id);

            return measurableActivity ?? throw new KeyNotFoundException("Measurable activity not found.");
        }

        public async Task<Implementation> FetchImplementation(int id)
        {
            var implementation = await _context.Implementations.FindAsync(id);

            return implementation ?? throw new KeyNotFoundException("Measurable activity not found.");
        }

        public async Task<MeasurableActivity> UpdateMeasurableActivity(int id, MeasurableActivity measurableActivity)
        {

            if (_context.MeasurableActivities.Any(e => e.MeasurableActivityId == measurableActivity.MeasurableActivityId))
            {

                _context.Update(measurableActivity);

                await _context.SaveChangesAsync();
                return measurableActivity;

            }
            throw new ClientFriendlyException("no measurable activity found");


        }

        public async Task<Implementation> UpdateImplementation(Implementation implementation)
        {

            if (_context.Implementations.Any(e => e.ImplementationId == implementation.ImplementationId))
            {
                _context.Update(implementation);

                await _context.SaveChangesAsync();
                return implementation;

            }
            throw new ClientFriendlyException("no implementation found");


        }

        public async Task<bool> DeleteMeasurableActivity(int id)
        {
            var measurableActivity = await _context.MeasurableActivities.FindAsync(id);
            if (measurableActivity == null)
            {
                return false;
            }

            _context.MeasurableActivities.Remove(measurableActivity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<MeasurableActivity> PostMeasurableActivity(MeasurableActivity measurableActivity)
        {
            if (_context.MeasurableActivities.Any(e => e.MeasurableActivityId == measurableActivity.MeasurableActivityId))
            {
                throw new ClientFriendlyException("Measurable activity already exisitng");
            }
            _context.MeasurableActivities.Add(measurableActivity);
            await _context.SaveChangesAsync();
            return measurableActivity;
        }

        public async Task<Implementation> PostImplementation(Implementation implementation)
        {

            if (_context.Implementations.Any(e => e.ImplementationId == implementation.ImplementationId))
            {
                throw new ClientFriendlyException("Implementation already exisitng");
            }

            _context.Implementations.Add(implementation);
            await _context.SaveChangesAsync();

            return implementation;
        }

        public async Task<bool> DeleteImplementation(int id)
        {
            var implementation = await _context.Implementations.FindAsync(id);
            if (implementation != null)
            {
                _context.Implementations.Remove(implementation);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }



        }

    }
}

