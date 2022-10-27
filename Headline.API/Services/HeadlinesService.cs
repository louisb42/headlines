using AutoMapper;

using Headline.API.Helpers;
using Headline.API.RequestModels;
using Headline.Common.Models;

namespace Headline.API.Services
{
    public interface IHeadlineService
    {
        List<HeadlineModel> GetAll();
        HeadlineModel GetById(int id);
        void Create(CreateHeadlineRequest model);
        void Update(int id, UpdateHeadlineRequest model);
        void Delete(int id);
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

        public List<HeadlineModel> GetAll()
            => _context.Headlines.ToList();

        public HeadlineModel GetById(int id)
            => GetHeadline(id);


        public void Create(CreateHeadlineRequest model)
        {
            HeadlineModel headline = _mapper.Map<HeadlineModel>(model);
            var lastId = _context.Headlines.OrderBy(x => x.Id).Last().Id;
            headline.Id = lastId + 1;
            _context.Headlines.Add(headline);
            _context.SaveChanges();
        }

        public void Update(int id, UpdateHeadlineRequest model)
        {
            HeadlineModel headline = GetHeadline(id);
            _mapper.Map(model, headline);
            _context.Headlines.Update(headline);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            HeadlineModel headline = GetHeadline(id);
            _context.Headlines.Remove(headline);
            _context.SaveChanges();
        }

        // helper methods
        private HeadlineModel GetHeadline(int id)
        {
            HeadlineModel? user = _context.Headlines.Find(id);
            if (user == null)
                throw new KeyNotFoundException("Headline not found");
            return user;
        }
    }
}
