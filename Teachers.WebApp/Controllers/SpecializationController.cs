using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System.Collections.Generic;
using System;
using Models.domain;
using Models.Application;

namespace Teachers.WepApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IDistributedCache _cache;

        public SpecializationController(IMediator mediator, IDistributedCache cache)
        {
            _mediator = mediator;
            _cache = cache;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSpec()
        {
            var cachedResponse = await _cache.GetStringAsync($"Specialization");
            if (cachedResponse is not null)
            {
                return Ok(JsonSerializer.Deserialize<IEnumerable<Specialization>>(cachedResponse));
            }

            var query = new GetAllSpecializationQuery();
            var spec = await _mediator.Send(query);
            await _cache.SetStringAsync("Specialization", JsonSerializer.Serialize(spec),
                new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });

            return Ok(spec);
        }

        [HttpPost]
        public async Task<IActionResult> Upsert([FromBody] UpdateSpecialization command)
        {
            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteSpecialization command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}
