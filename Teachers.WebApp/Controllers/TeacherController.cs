using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System.Collections.Generic;
using System;
using Models.Application;

namespace Teachers.WepApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IDistributedCache _cache;

        public TeacherController(IMediator mediator, IDistributedCache cache)
        {
            _mediator = mediator;
            _cache = cache;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cachedResponse = await _cache.GetStringAsync($"Teacher");
            if (cachedResponse is not null)
            {
                return Ok(JsonSerializer.Deserialize<IEnumerable<Models.domain.Teachers>>(cachedResponse));
            }

            var query = new GetAllTeachersQuery();
            var teacher = await _mediator.Send(query);
            await _cache.SetStringAsync("Teacher", JsonSerializer.Serialize(teacher),
                new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });

            return Ok(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> Upsert([FromBody] UpdateTeacherCommand command)
        {
            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteTeacherCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}