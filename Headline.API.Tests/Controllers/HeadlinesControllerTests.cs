using AutoMapper;

using Headline.API.Controllers;

using Headline.API.Helpers;
using Headline.API.Services;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Headline.API.Tests.Controllers
{
    [TestClass()]
    public class HeadlinesControllerTests
    {
        protected readonly IConfiguration configuration;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IHeadlineService _headlineService;
        private readonly HeadlinesController _controller;

        public HeadlinesControllerTests()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var services = new ServiceCollection();
            _ = services.AddSingleton<IConfiguration>(configuration);
            _ = services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            _ = services.AddDbContext<DataContext>();
            _ = services.AddScoped<IHeadlineService, HeadlineService>();

            ServiceProvider serviceProvider = services.BuildServiceProvider();

            _context = serviceProvider.GetService<DataContext>();
            _headlineService = serviceProvider.GetService<IHeadlineService>();
            _mapper = serviceProvider.GetService<IMapper>();
            _ = _context.Database.EnsureCreated();

            _controller = new HeadlinesController(_headlineService, _mapper);
        }

        [TestMethod()]
        public async Task GetAllAsync_Test_OK()
        {
            Microsoft.AspNetCore.Mvc.IActionResult result = await _controller.GetAllAsync();
            Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.OkObjectResult));
        }

        [TestMethod()]
        public async Task GetByIdAsync_Test_OK()
        {
            Microsoft.AspNetCore.Mvc.IActionResult result = await _controller.GetByIdAsync(1);
            Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.OkObjectResult));
        }

        [TestMethod()]
        [ExpectedException(typeof(KeyNotFoundException))]
        public async Task GetByIdAsync_Test_404() => _ = await _controller.GetByIdAsync(0);
    }
}