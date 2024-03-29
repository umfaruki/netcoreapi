﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApi_Umer.Models;
using CoreApi_Umer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApi_Umer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        // GET: api/Booking
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(BookingService.GetBookings());
            // return Ok(new BookingModel().DefaultBookings());
        }

        // GET: api/Booking/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(Guid id)
        {
            return Ok(new ActionResult<BookingModel>(new BookingModel { }));
        }
    
        // POST: api/Booking
        /// <summary>
        /// Post bookings.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post /Post
        ///     {
        ///        "BookingId": 1,
        ///        "Description": "test booking",
        ///        "BookDate": date
        ///     }
        ///
        /// </remarks>
        /// <param name="item"></param>
        /// <returns>A newly created BookingItem</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>        
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]       
        public IActionResult Post(BookingModel bookingModel)
        {
            if (string.IsNullOrEmpty(bookingModel.Name))
            {
                return BadRequest("you must enter the description");
            }
            return Ok(BookingService.SaveBooking(bookingModel));
        }

        // PUT: api/Booking/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
