using AppraisalTracker.Exceptions;
using Microsoft.EntityFrameworkCore;
using AppraisalTracker.Data;
using AppraisalTracker.Modules.AppraisalActivity.Models;
using AutoMapper;

namespace AppraisalTracker.Modules.AppraisalActivity.Services
{
    public interface IAppraisalActivityService
    {
        public Task<List<MeasurableActivityViewModel>> FetchMeasurableActivities();
        public Task<List<Implementation>> FetchImplementations();
        public Task<MeasurableActivity> FetchMeasurableActivity(Guid Id);
        public Task<Implementation> FetchImplementation(Guid Id);

        public Task<MeasurableActivity> UpdateMeasurableActivity(Guid Id, MeasurableActivity measurableActivity);
        public Task<bool> DeleteMeasurableActivity(Guid Id);

        public Task<Implementation> UpdateImplementation(Implementation implementation);

        public Task<MeasurableActivityViewModel> AddMeasurableActivity(MeasurableActivityCreateModel measurableActivity);
        public Task<ImplementationViewModel> AddImplementation(ImplementationCreateModel implementation);

        public Task<bool> DeleteImplementation(Guid Id);
        public Task<ImplementationViewModel> FetchEvidence(Guid id);



    }
    public class AppraisalActivityService(AppDbContext context, IMapper mapper) : IAppraisalActivityService
    {

        public readonly AppDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<List<MeasurableActivityViewModel>> FetchMeasurableActivities()
        {
            var measurableActivities = await _context.MeasurableActivities.Include(x => x.Implementation).ToListAsync();
            return _mapper.Map<List<MeasurableActivityViewModel>>(measurableActivities);
        }

        public async Task<List<Implementation>> FetchImplementations()
        {
            return await _context.Implementations.ToListAsync();
        }

        public async Task<MeasurableActivity> FetchMeasurableActivity(Guid Id)
        {

            var measurableActivity = await _context.MeasurableActivities.FindAsync(Id);

            return measurableActivity ?? throw new ClientFriendlyException("Measurable activity not found.");
        }

        public async Task<Implementation> FetchImplementation(Guid Id)
        {
            var implementation = await _context.Implementations.FindAsync(Id);

            return implementation ?? throw new ClientFriendlyException("Implementation not found.");
        }

        public async Task<MeasurableActivity> UpdateMeasurableActivity(Guid Id, MeasurableActivity measurableActivity)
        {

            if (_context.MeasurableActivities.Any(e => e.MeasurableActivityId == measurableActivity.MeasurableActivityId))
            {

                _context.Update(measurableActivity);

                await _context.SaveChangesAsync();
                return measurableActivity;

            }
            throw new ClientFriendlyException("No measurable activity found");


        }

        public async Task<Implementation> UpdateImplementation(Implementation implementation)
        {

            if (_context.Implementations.Any(e => e.ImplementationId == implementation.ImplementationId))
            {
                _context.Update(implementation);

                await _context.SaveChangesAsync();
                return implementation;

            }
            throw new ClientFriendlyException("No implementation found");


        }

        public async Task<bool> DeleteMeasurableActivity(Guid Id)
        {
            var measurableActivity = await _context.MeasurableActivities.FindAsync(Id);
            if (measurableActivity == null)
            {
                return false;
            }

            _context.MeasurableActivities.Remove(measurableActivity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<MeasurableActivityViewModel> AddMeasurableActivity(MeasurableActivityCreateModel measurableActivity)
        {
            var newMeasurableActivity = new MeasurableActivity
            {
                ActivityId = measurableActivity.ActivityId,
                InitiativeId = measurableActivity.InitiativeId,
                PeriodId = measurableActivity.PeriodId,
                PerspectiveId = measurableActivity.PerspectiveId,
                SsMartaObjectivesId = measurableActivity.SsMartaObjectivesId
            };

            await _context.MeasurableActivities.AddAsync(newMeasurableActivity);
            await _context.SaveChangesAsync();
            var addedActivity = _mapper.Map<MeasurableActivity, MeasurableActivityViewModel>(newMeasurableActivity);
            return addedActivity;
        }

        public async Task<ImplementationViewModel> AddImplementation(ImplementationCreateModel implementation)
        {

            if (implementation.Evidence == null || implementation.Evidence.Length == 0)
            {
                throw new ClientFriendlyException("Evidence file is required.");
            }

            using var memoryStream = new MemoryStream();
            await implementation.Evidence.CopyToAsync(memoryStream);

            // Check if the file size is within the 2 MB limit (2099990 bytes)

            if (memoryStream.Length < 2099990)
            {

                byte[] filevar = memoryStream.ToArray();


                var newImplementation = new Implementation
                {
                    Description = implementation.Description,
                    Comment = implementation.Comment,
                    Stakeholder = implementation.Stakeholder,
                    Evidence = filevar,
                    EvidenceContentType = implementation.Evidence.ContentType,
                    EvidenceFileName = implementation.Evidence.FileName,
                    Date = implementation.Date,
                    MeasurableActivityId = implementation.MeasurableActivityId
                };


                await _context.Implementations.AddAsync(newImplementation);
                await _context.SaveChangesAsync();


                var addedImplementation = _mapper.Map<Implementation, ImplementationViewModel>(newImplementation);
                return addedImplementation;
            }
            else
            {

                throw new ClientFriendlyException("File size exceeds the 2 MB limit.");
            }
        }

        public async Task<ImplementationViewModel> FetchEvidence(Guid id)
        {
            var uploadedFile = await _context.Implementations.FindAsync(id) ?? throw new ClientFriendlyException("No implementation found");
            var uploadedFileView = _mapper.Map<Implementation, ImplementationViewModel>(uploadedFile);

            return uploadedFileView;
        }

        public async Task<bool> DeleteImplementation(Guid Id)
        {
            var implementation = await _context.Implementations.FindAsync(Id);
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

