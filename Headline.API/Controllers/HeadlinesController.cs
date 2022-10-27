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
        public IActionResult GetAll()
        {
            List<Common.Models.HeadlineModel> headlines = _headlineService.GetAll();
            return Ok(headlines);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Common.Models.HeadlineModel headline = _headlineService.GetById(id);
            return Ok(headline);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateHeadlineRequest model)
        {
            _headlineService.Create(model);
            return Ok(new { message = "Headline created" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateHeadlineRequest model)
        {
            _headlineService.Update(id, model);
            return Ok(new { message = "Headline updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _headlineService.Delete(id);
            return Ok(new { message = "Headline deleted" });
        }
    }
}