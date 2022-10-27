using AutoMapper;

using Headline.API.Helpers;
using Headline.API.RequestModels;
using Headline.Common.Models;

using Microsoft.EntityFrameworkCore;

namespace Headline.API.Services
{
    public interface IHeadlineService
    {
        Task<List<HeadlineModel>> GetAllAsync();
        Task<HeadlineModel> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateHeadlineRequest model);
        Task UpdateAsync(int id, UpdateHeadlineRequest model);
        Task DeleteAsync(int id);
    }

    public class HeadlineService : IHeadlineService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public HeadlineService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            context.Database.EnsureCreated();

        }

        public async Task<List<HeadlineModel>> GetAllAsync()
            => await _context.Headlines.ToListAsync();

        public async Task<HeadlineModel> GetByIdAsync(int id)
            => await GetHeadlineAsync(id);


        public async Task<int> CreateAsync(CreateHeadlineRequest model)
        {
            HeadlineModel headline = _mapper.Map<HeadlineModel>(model);
            var lastId = _context.Headlines.OrderBy(x => x.Id).Last().Id;
            headline.Id = lastId + 1;
            await _context.Headlines.AddAsync(headline);
            await _context.SaveChangesAsync();
            return lastId + 1;
        }

        public async Task UpdateAsync(int id, UpdateHeadlineRequest model)
        {
            HeadlineModel headline = await GetHeadlineAsync(id);
            _mapper.Map(model, headline);
            _context.Headlines.Update(headline);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            HeadlineModel headline = await GetHeadlineAsync(id);
            _context.Headlines.Remove(headline);
            await _context.SaveChangesAsync();
        }

        // helper methods
        private async Task<HeadlineModel> GetHeadlineAsync(int id)
        {
            HeadlineModel? user = await _context.Headlines.FindAsync(id);
            return user ?? throw new KeyNotFoundException("Headline not found");
        }
    }
}
