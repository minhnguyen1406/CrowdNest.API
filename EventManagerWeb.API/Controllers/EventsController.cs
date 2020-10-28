using EventManagerWeb.Contracts;
using EventManagerWeb.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace EventManagerWeb.API.Controllers
{
    [Route("api/EventManagerWeb")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventBusiness eventBusiness;

        public EventController(IEventBusiness eventBusiness)
        {
            this.eventBusiness = eventBusiness;
        }

        /// <summary>
        /// Retrieve all available events
        /// </summary>
        /// <returns>Return all events</returns>
        [HttpGet]
        [Route("events")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<Event>>> GetEvents()
        {
            var events = await this.eventBusiness.GetAllEvents();
            return Ok(events);
        }

        /// <summary>
        /// Filter events
        /// </summary>
        /// <returns>Return filtered events</returns>
        [HttpGet]
        [Route("events/filter")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<Event>>> FilterEvents([FromQuery] bool? isActive, [FromQuery] bool? isPublished)
        {
            var events = await this.eventBusiness.FilterEvents(isActive, isPublished);
            return Ok(events);
        }


        /// <summary>       
        /// Retrive a event based on id
        /// </summary>
        /// <returns>Return the event</returns>
        [HttpGet]
        [Route("events/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<Event>>> GetEventById(int id)
        {
            var eventModel = await this.eventBusiness.GetEventById(id);
            if (eventModel == null)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

            return Ok(eventModel);
        }

        /// <summary>
        /// Save a new event
        /// </summary>
        /// <param name="event">Given a event</param>
        /// <returns>Returns status of event created</returns>
        [HttpPost]
        [Route("events")]
        public async Task<ActionResult<List<Event>>> SaveNewEvent(Event eventModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input");
            }
            var response = await this.eventBusiness.AddEvent(eventModel);

            return Ok(response);
        }

        /// <summary>
        /// Update an existing event
        /// </summary>
        /// <param name="event">Given event information to update</param>
        /// <returns>Returns status of event updated</returns>
        [HttpPut]
        [Route("events")]
        public async Task<ActionResult<int>> SaveUpdatedEvent(Event eventModel)
        {
            if (this.eventBusiness.GetEventById(eventModel.Id) == null)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input");
            }
            var response = await this.eventBusiness.UpdateEvent(eventModel);

            return Ok(response);
        }

        /// <summary>
        /// Delete an existing event
        /// </summary>
        /// <param name="id">Given event id</param>
        /// <returns>Returns status of event removed</returns>
        [HttpDelete]
        [Route("events")]
        public async Task<ActionResult<int>> RemoveEvent(int id)
        {
            var eventModel = await this.eventBusiness.GetEventById(id);
            if (eventModel == null)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
            var response = await this.eventBusiness.RemoveEvent(eventModel);

            return Ok(response);
        }
    }
}
