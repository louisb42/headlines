using AutoMapper;

using Headline.API.RequestModels;
using Headline.API.Services;

using Microsoft.AspNetCore.Mvc;

namespace Headline.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HeadlinesController : ControllerBase
    {
        private readonly IHeadlineService _headlineService;
        private readonly IMapper _mapper;

        public HeadlinesController(IHeadlineService headlineService, IMapper mapper)
        {
            _headlineService = headlineService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            List<Common.Models.HeadlineModel> headlines = await _headlineService.GetAllAsync();
            return Ok(headlines);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            Common.Models.HeadlineModel headline = await _headlineService.GetByIdAsync(id);
            return Ok(headline);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateHeadlineRequest model)
        {
            await _headlineService.CreateAsync(model);
            return Ok(new { message = "Headline created" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateHeadlineRequest model)
        {
            await _headlineService.UpdateAsync(id, model);
            return Ok(new { message = "Headline updated" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _headlineService.DeleteAsync(id);
            return Ok(new { message = "Headline deleted" });
        }
    }
}