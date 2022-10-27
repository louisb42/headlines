using AutoMapper;

using Headline.API.Helpers;
using Headline.Common.Models;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Headline.API.Services.Tests
{
    [TestClass()]
    public class HeadlineServiceTests
    {
        protected readonly IConfiguration configuration;
        private DataContext _context;
        private readonly IMapper _mapper;
        private readonly IHeadlineService _headlineService;

        public HeadlineServiceTests()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(configuration);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddDbContext<DataContext>();
            services.AddScoped<IHeadlineService, HeadlineService>();

            ServiceProvider serviceProvider = services.BuildServiceProvider();

            _context = serviceProvider.GetService<DataContext>();
            _context.Database.EnsureCreated();

            _headlineService = serviceProvider.GetService<IHeadlineService>();
        }

        [TestMethod()]
        public async Task GetAllAsync_Test()
        {
            List<HeadlineModel> result = await _headlineService.GetAllAsync();
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public async Task GetByIdAsync_Test()
        {
            HeadlineModel result = await _headlineService.GetByIdAsync(1);
            Assert.IsNotNull(result);
        }
    }
}