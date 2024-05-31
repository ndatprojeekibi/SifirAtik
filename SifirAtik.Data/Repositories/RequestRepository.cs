using Microsoft.EntityFrameworkCore;
using SifirAtik.Data.Contexts;
using SifirAtik.Data.Generics;
using SifirAtik.Domain.Entities;
using SifirAtik.Common.Enums;

namespace SifirAtik.Data.Repositories
{
    public class RequestRepository : GenericRepository<Request>
    {
        private readonly DataContext _context;
        public RequestRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IQueryable<Request>> GetAllDonationRequests()
        {
            return await Task.FromResult(
                _context.Requests
                .Where(request => request.RequestType == RequestType.Donation)
                .Include(request => request.Item));
        }

        public async Task<IQueryable<Request>> GetAllAdoptionRequests()
        {
            return await Task.FromResult(
                _context.Requests
                .Where(request => request.RequestType == RequestType.Adoption)
                .Include(request => request.Item));
        }

        public async Task<IQueryable<Request>> GetUserDonationRequestsByIdAsync(Guid guid)
        {
            return await Task.FromResult(
                _context.Requests
                .Where(request => request.CreatedById == guid && request.RequestType == RequestType.Donation)
                .Include(request => request.Item));
        }

        public async Task<IQueryable<Request>> GetUserAdoptionRequestsByIdAsync(Guid guid)
        {
            return await Task.FromResult(
                _context.Requests
                .Where(request => request.CreatedById == guid && request.RequestType == RequestType.Adoption)
                .Include(request => request.Item));
        }

        public async Task<Request> GetRequestByItemIdAsync(Guid guid)
        {
            return await _context.Requests.FirstOrDefaultAsync(request => request.ItemId == guid);
        }

        public async Task<Request> GetRequestByItemIdAndCreatedByIdAsync(Guid itemId, Guid createdById)
        {
            return await _context.Requests
                .FirstOrDefaultAsync(request => request.ItemId == itemId && request.CreatedById == createdById);
        }

        public async Task<int> GetUnapprovedRequestCountByUserIdAsync(Guid guid)
        {
            return await _context.Requests
                .Where(request => request.CreatedById == guid && request.IsApproved == ApproveType.NotChecked)
                .CountAsync();
        }
    }
}
