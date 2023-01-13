using AutoMapper;
using Courses.BL;
using Courses_project.EventAutoBus;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private ICoursesServices coursesServices;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMapper _mapper;
        public CoursesController(ICoursesServices courses, IPublishEndpoint publishEndpoint, IMapper mapper)
        {
            _publishEndpoint = publishEndpoint;
            coursesServices = courses;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PostCoursesDTO>> GetC()
        {
            return await coursesServices.GetAllC(); // Ok - status 200 (We have some data)
        }
        /*
        [HttpGet("GetByUser/{userId}")]
        public async Task<IEnumerable<CoursesInUserDTO>> GetByUserId(string userId)
        {
            await coursesServices.GetCoursesById(userId);
        }
        */
        [HttpPost]
        public async Task<ActionResult> InsertAsync([FromBody] PostCoursesDTO request)
        {
            try
            {
                await coursesServices.InsertAsync(request);
                return Ok();
            }
            catch (DbUpdateException)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new { Message = "Courses from you to this user already exists." });
            }
        }
        [HttpPost("GetConsumerCours")]
        public async Task<ActionResult> CreateCourseForUser([FromBody] PostCoursesDTO request)
        {
            var eventMessage = _mapper.Map<CoursesCreatedEvent>(request);
            await _publishEndpoint.Publish(eventMessage);
            await coursesServices.InsertAsync(request);
            return NoContent(); //NoContent - status 204 (We havn't any data)
        }

        [HttpGet("GetById/{CoursesID}")]
        public async Task<ActionResult<PostCoursesDTO>> GetC(string CoursesID)
        {
            return Ok(await coursesServices.GetCoursesById(CoursesID));
        }

        [HttpDelete("{CoursesID}")]
        public async Task<ActionResult> DelC(string CoursesID)
        {
            await coursesServices.DeleteAsync(CoursesID);
            return NoContent();
        }
        /*
        [HttpPost("AddCourseToUser")]
        public async Task AddCourseToUser(CoursesInUserDTO coursesInUserDTO)
        {
            await coursesServices.AddCourseToUser(coursesInUserDTO);
        }*/


    }
}
