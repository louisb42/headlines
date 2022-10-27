using AutoMapper;

using Headline.API.Helpers;
using Headline.API.RequestModels;
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
            IConfigurationRoot configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
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

        [TestMethod()]
        public async Task CreateAsync_Test()
        {
            CreateHeadlineRequest model = new()
            {
                Banner = "This is a test."
            };
            var newId = await _headlineService.CreateAsync(model);
            HeadlineModel result = await _headlineService.GetByIdAsync(newId);
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public async Task UpdateAsync_Test()
        {
            HeadlineModel model = await _headlineService.GetByIdAsync(1);
            UpdateHeadlineRequest reqModel = new()
            {
                Active = model.Active,
                BackgroundColour = model.BackgroundColour,
                ForegroundColour = model.ForegroundColour,
                Banner = model.Banner,
                ImageUrl = model.ImageUrl
            };
            reqModel.Banner = "This is an update test.";
            await _headlineService.UpdateAsync(1, reqModel);
            HeadlineModel result = await _headlineService.GetByIdAsync(1);
            Assert.AreEqual("This is an update test.", result.Banner);
        }

        [TestMethod()]
        [ExpectedException(typeof(KeyNotFoundException))]
        public async Task DeleteAsync_Test()
        {
            await _headlineService.DeleteAsync(2);
            HeadlineModel result = await _headlineService.GetByIdAsync(2);
        }
    }
}