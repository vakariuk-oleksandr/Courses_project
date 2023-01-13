using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Models.Application;
using Models.domain;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Teachers.WepApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudyingformController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IDistributedCache _cache;

        public StudyingformController(IMediator mediator, IDistributedCache cache)
        {
            _mediator = mediator;
            _cache = cache;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSpec()
        {
            var cachedResponse = await _cache.GetStringAsync($"Studyingform");
            if (cachedResponse is not null)
            {
                return Ok(JsonSerializer.Deserialize<IEnumerable<Studyingform>>(cachedResponse));
            }

            var query = new GetAllFormsQuery();
            var form = await _mediator.Send(query);
            await _cache.SetStringAsync("Studyingform", JsonSerializer.Serialize(form),
                new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });

            return Ok(form);
        }

        [HttpPost]
        public async Task<IActionResult> Upsert([FromBody] UpdateForm command)
        {
            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteStudyingform command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}
