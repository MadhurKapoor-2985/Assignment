using Assignment.Business;
using Assignment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RectangleController : ControllerBase
    {
        
        private readonly ILogic _logic;

        public RectangleController(ILogic logic)
        {
               _logic = logic;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Sort")] // Sort?sortBy=asc
        public IActionResult Sort([FromBody]List<Rectangle> rectangles, [FromQuery]string sortBy="asc")
        {
            try
            {
                if (!ModelState.IsValid || (sortBy != "asc" && sortBy != "desc"))
                {
                    return BadRequest();
                }

                var sortedList = _logic.SortRectangle(rectangles, sortBy);
                return Ok(sortedList);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
